using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Controller.BookAccess
{
    public  class Rental
    {
        private Searcher searcher;
        private ExceptionHandler exceptionHandler;
        private GuidancePhrase guidancePhrase;
        private PrintBookInformation printBookInformation;
        private InputFromUser inputFromUser;
        private AccessorData accessorData;

        public Rental(Searcher searcher)
        {
            this.searcher = searcher;
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            inputFromUser = InputFromUser.GetInputFromUser();
            accessorData = AccessorData.GetAccessorData();
        }

        public void RentBook(string userId)
        {
            bool isNotESC = true;
            bool isLeakAmount = true;
            bool isAlreadyRent = false;

            int column = 9;
            int row = 2;

            string returnBookId;
            int returnBookIdNumber = 0;
            int bookIndex = -1;

            List<BookDTO> searchedBook = new List<BookDTO>();

            while(isNotESC)
            {
                searchedBook = searcher.SearchBook((int)USERMENU.RENT);
                if (searchedBook[0].Title == Constant.ESC_STRING
                    || searchedBook[0].Author == Constant.ESC_STRING
                    || searchedBook[0].Publisher == Constant.ESC_STRING)
                {
                    isNotESC = false;
                    continue;
                }
                returnBookId = ExceptionHandler.IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);
                if(returnBookId == Constant.ESC_STRING)
                {
                    isNotESC = false;
                    continue;
                }

                if (!ExceptionHandler.IsStringAllNumber(returnBookId))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                returnBookIdNumber = int.Parse(returnBookId);

                for (int i = 0; i < searchedBook.Count; i++)
                {
                    if (searchedBook[i].Id == returnBookIdNumber)
                    {
                        bookIndex = i;
                        break;
                    }
                }

                if(bookIndex == -1)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row);
                    continue;
                }
                isLeakAmount = IsAffluentBook(searchedBook[bookIndex]);
                if (!isLeakAmount)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.LEAK_AMOUNT, column, row);
                    continue;
                }

                isAlreadyRent = IsAlreadyRentBook(searchedBook[bookIndex], userId);
                if (isAlreadyRent)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.ALREADY_RENT, column, row);
                    continue;
                }

                searchedBook[bookIndex].Amount--;

                AccessorData.InsertRentBookData(userId, searchedBook[bookIndex]);
                AccessorData.UpdateBookIntData(searchedBook[bookIndex].Id, "amount", searchedBook[bookIndex].Amount);
                PrintBookInformation.PrintSuccessRent();
                isNotESC = InputFromUser.EnteredESC();
            }
        }
        
        private bool IsAffluentBook(BookDTO book)
        {
            if(book.Amount > 0)
            {
                return true;
            }
            return false;
        }

        private bool IsAlreadyRentBook(BookDTO book, string userId)
        {
            List<UsersBookDTO> rentedBook = new List<UsersBookDTO>();

            rentedBook = AccessorData.SelectAllRentBookList(userId);

            for(int i = 0; i < rentedBook.Count; i++)
            {
                if (rentedBook[i].UserId == userId) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
