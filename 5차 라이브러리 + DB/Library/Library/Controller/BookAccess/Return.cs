using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.BookAccess
{
    public class Return
    {
        PrintBookInformation printBookInformation;
        ExceptionHandler exceptionHandler;
        AccessorData accessorData;
        GuidancePhrase guidancePhrase;
        public Return()
        {
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            accessorData = AccessorData.GetAccessorData();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
        }

        public void ReturnBook(string userId)
        {
            bool isNotESC = true;
            bool isAbleReturn;

            string returnId = "";
            int returnIdNumber = 0;

            int column = 9;
            int row = 2;

            List<UsersBookDTO> returnBookList = new List<UsersBookDTO>();

            while(isNotESC)
            {
                Console.SetWindowSize(76, 40);

                Console.Clear();
                PrintBookInformation.PrintReturnTheBookUI();

                returnBookList = AccessorData.SelectAllRentBookList(userId);
                Console.SetCursorPosition(0, 9);

                PrintBookInformation.PrintUserBookListUI(returnBookList);
                
                returnId = ExceptionHandler.IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);
                if(returnId == Constant.ESC_STRING)
                {
                    return;
                }

                else if (!ExceptionHandler.IsStringAllNumber(returnId))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                returnIdNumber = int.Parse(returnId);

                UsersBookDTO returnBook = AccessorData.SelectRentBook(userId, returnIdNumber);

                if (returnBook.Id == 0)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_RENT, column, row);
                    continue;
                }

                returnBook.Amount++;
                AccessorData.InsertReturnBookData(returnBook);
                AccessorData.DeleteRentBookData(userId, returnIdNumber);

                UpdateBook(returnBook);
                isNotESC = false;
            }
        }
        private void UpdateBook(UsersBookDTO returnbook)
        {
            List<BookDTO> books = AccessorData.SelectBookData(returnbook.Title, returnbook.Author, returnbook.Publisher);
            books[0].Amount++;

            AccessorData.UpdateBookIntData(books[0].Id, "amount", books[0].Amount);
        }
    }
}
