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

        public void RentBook(string userId)     // 책 대여하는 메소드
        {
            bool isESC = true;
            bool isLeakAmount = true;
            bool isAlreadyRent = false;

            int column = 9;
            int row = 2;

            string rentBookId;
            int rentBookIdNumber = 0;
            int bookIndex = -1;

            List<BookDTO> searchedBook = new List<BookDTO>();

            searchedBook = searcher.SearchBook((int)USERMENU.RENT);     // 검색 결과를 바탕으로 책을 빌려야 하기 때문에 우선 책 검색 

            while (isESC)
            {
                isESC = false;
                if (searchedBook[0].Title == Constant.ESC_STRING
                    || searchedBook[0].Author == Constant.ESC_STRING
                    || searchedBook[0].Publisher == Constant.ESC_STRING)
                {       // 책 검색 도중 ESC를 눌렀을 경우
                    continue;
                }
                rentBookId = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);   
                // 빌리려는 책의 아이디 입력

                if(rentBookId == Constant.ESC_STRING)
                {
                    continue;
                }

                if ((!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(rentBookId)) || rentBookId == "")
                {   // 책의 아이디가 숫자가 아닐 경우
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                rentBookIdNumber = int.Parse(rentBookId);

                for (int i = 0; i < searchedBook.Count; i++)
                {
                    if (searchedBook[i].Id == rentBookIdNumber)
                    {   // 검색 결과와 빌리려는 책의 아이디가 일치할 때
                        bookIndex = i;
                        break;
                    }
                }

                if(bookIndex == -1)
                {   // 검색 결과와 빌리려는 책의 아이디가 일치하지 않을 때
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row);
                    isESC = true;
                    continue;
                }
                isLeakAmount = IsAffluentBook(searchedBook[bookIndex]); 
                // 빌리려는 책의 수량이 넉넉한지 확인
                if (!isLeakAmount)
                {   // 책의 수량이 0 이하라면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.LEAK_AMOUNT, column, row);
                    isESC = true;
                    continue;
                }

                isAlreadyRent = IsAlreadyRentBook(searchedBook[bookIndex], userId, rentBookIdNumber);
                // 이미 빌린 책인지 확인
                if (isAlreadyRent)
                {   // 이미 빌린 책이라면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.ALREADY_RENT, column, row);
                    isESC = true;
                    continue;
                }

                searchedBook[bookIndex].Amount--;
                // 책을 빌리고 나서 수량 감소

                AccessorData.InsertRentBookData(userId, searchedBook[bookIndex]);
                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.SUCCESS_RENT, searchedBook[bookIndex].Title);
                AccessorData.UpdateBookIntData(searchedBook[bookIndex].Id, "amount", searchedBook[bookIndex].Amount);
                PrintBookInformation.GetPrintBookInformation().PrintSuccessRent();
                isESC = InputFromUser.GetInputFromUser().EnteredESC();
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

        private bool IsAlreadyRentBook(BookDTO book, string userId, int bookId)
        {
            List<UsersBookDTO> rentedBook = new List<UsersBookDTO>();

            rentedBook = AccessorData.SelectAllRentBookList(userId);

            for(int i = 0; i < rentedBook.Count; i++)
            {
                if (rentedBook[i].Id == bookId) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
