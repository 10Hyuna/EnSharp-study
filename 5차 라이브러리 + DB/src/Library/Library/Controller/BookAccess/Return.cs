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

        public void ReturnBook(string userId)       // 책 반납 메소드
        {
            bool isESC = true;
            bool isAbleReturn;

            string returnId = "";
            int returnIdNumber = 0;

            int column = 9;
            int row = 2;

            List<UsersBookDTO> returnBookList = new List<UsersBookDTO>();

            while(isESC)
            {
                isESC = false;
                Console.SetWindowSize(76, 40);

                Console.Clear();
                PrintBookInformation.GetPrintBookInformation().PrintRentReturnUI(Constant.RETURN);

                returnBookList = AccessorData.SelectAllRentBookList(userId);
                Console.SetCursorPosition(0, 9);

                PrintBookInformation.GetPrintBookInformation().PrintUserBookListUI(returnBookList);
                
                returnId = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);
                // 반납하려는 책의 아이디 입력

                if(returnId == Constant.ESC_STRING)     // 중간에 ESC 입력했을 경우
                {
                    return;
                }

                else if ((!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(returnId)) || returnId == "")     // 책의 아이디가 숫자로 구성돼 있지 않을 경우
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                returnIdNumber = int.Parse(returnId);

                UsersBookDTO returnBook = AccessorData.SelectRentBook(userId, returnIdNumber);

                if (returnBook.Id == 0)
                {   
                    // 반납하려는 책의 아이디와 빌린 책의 아이디가 일치하지 않을 경우
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NULL_RENT, column, row);
                    isESC = true;
                    continue;
                }

                returnBook.Amount++;
                // 반납하고 나서 책의 수량 증가

                CheckValidReturn(returnBook, userId);
                // 이미 반납한 책이라면 그 데이터를 추가하지 않도록
                AccessorData.DeleteRentBookData(userId, returnIdNumber);

                UpdateBook(returnBook); // 수량 증가
            }
        }
        private void UpdateBook(UsersBookDTO returnBook)
        {
            List<BookDTO> books = AccessorData.SelectBookData(returnBook.Title, returnBook.Author, returnBook.Publisher);
            books[0].Amount++;

            AccessorData.UpdateBookIntData(books[0].Id, "amount", books[0].Amount);
        }

        private void CheckValidReturn(UsersBookDTO returnBook, string userId)
        {
            UsersBookDTO returnedBook = new UsersBookDTO();
            returnedBook = AccessorData.SelectReturnedBook(userId, returnBook.Id);

            if (returnedBook.Id == null)
            {
                AccessorData.DeleteReturnBookData(returnBook.Id);
            }
            AccessorData.InsertReturnBookData(returnedBook);
            LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.SUCCESS_RETURN, returnedBook.Title);
        }
    }
}
