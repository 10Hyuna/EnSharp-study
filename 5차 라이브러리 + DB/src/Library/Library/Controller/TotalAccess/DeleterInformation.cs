using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Controller.TotalAccess
{
    public class DeleterInformation
    {

        private ExceptionHandler exceptionHandler;
        private AccessorData accessorData;
        private PrintUserInformation printUserInformation;
        private PrintBookInformation printBookInformation;
        private InputFromUser inputFromUser;

        public DeleterInformation()
        {
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            accessorData = AccessorData.GetAccessorData();
            printUserInformation = PrintUserInformation.GetPrintUserInformation();
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            inputFromUser = InputFromUser.GetInputFromUser();
        }
        public int DeleteUserInformation(int entryType, string id)
        {
            int returnValue = Constant.FAIL_INT;
            switch (entryType)
            {
                case (int)MODE.MANAGER:
                    DeleteUserManagerMode(id);      // 매니저 모드에서 유저 정보를 삭제하는 거라면
                    break;
                case (int)MODE.USER:
                    returnValue = DeleteMyAccount(id);      // 유저 모드에서 탈퇴하는 거라면
                    break;
            }
            return returnValue;
        }

        public void DeleteBookInformation()     // 책의 정보 삭제
        {
            string bookId;
            int bookNumber;
            bool isSuccessDelete = true;

            int column = 30;
            int row = 10;

            while (isSuccessDelete)
            {
                Console.Clear();
                Console.SetWindowSize(76, 30);
                PrintBookInformation.GetPrintBookInformation().PrintDeleteTheBookUI();

                List<BookDTO> books = new List<BookDTO>();
                books = AccessorData.AllBookData();

                for (int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.GetPrintBookInformation().PrintBookList(books[i]);
                }

                Console.SetCursorPosition(0, 0);
                bookId = SearchId((int)MODE.MANAGER);       // 삭제하려는 책의 아이디 입력

                if (bookId == Constant.ESC_STRING)
                {
                    return;
                }
                else if ((!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(bookId)) || bookId == "")       // 책의 아이디가 모두 숫자인지 확인
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                bookNumber = int.Parse(bookId);

                isSuccessDelete = IsAbleDelete(bookId, (int)MODE.MANAGER);  // 삭제할 수 있는 책인지 확인

                if (!isSuccessDelete)
                {
                    isSuccessDelete = true;
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row - 3);
                    continue;
                }

                AccessorData.DeleteBookData(bookNumber);
                AccessorData.DeleteRentBookData(bookNumber);
                AccessorData.DeleteReturnBookData(bookNumber);
                PrintBookInformation.GetPrintBookInformation().PrintSuccessDeleteBook();
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private void DeleteUserManagerMode(string id)       // 유저 정보 삭제
        {
            List<UserDTO> users = new List<UserDTO>();
            users = AccessorData.SelectAllUserData();

            bool isSucessDelete = true;
            
            while (isSucessDelete)
            {
                isSucessDelete = false;
                Console.SetWindowSize(76, 40);
                Console.Clear();
                PrintUserInformation.GetPrintUserInformation().PrintManageUser();

                PrintUserInformation.GetPrintUserInformation().PrintUserList(users);

                id = SearchId((int)MODE.USER);      // 삭제하려는 유저의 아이디 입력
                if (id == Constant.ESC_STRING)
                {
                    return;
                }

                isSucessDelete = IsAbleDelete(id, (int)MODE.USER);      // 삭제할 수 있는지 확인
                if (!isSucessDelete)
                {
                    isSucessDelete = true;
                    Console.Clear();
                    PrintUserInformation.GetPrintUserInformation().PrintNotWorkedDeleteAccout();
                    InputFromUser.GetInputFromUser().EnteredESC();
                    continue;
                }

                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.DELETE_USER_ACCOUNT, id);
                AccessorData.DeleteUserData(id);
                Console.Clear();
                PrintUserInformation.GetPrintUserInformation().PrintSuccessDeleteUser();
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private int DeleteMyAccount(string id)      // 회원 탈퇴 메소드
        {
            bool isSuccessDelete = true;

            string inputValue;
            while (isSuccessDelete)
            {
                isSuccessDelete = false;

                Console.Clear();
                PrintUserInformation.GetPrintUserInformation().PrintDeleteAccountUI();

                inputValue = InputFromUser.GetInputFromUser().InputEnterESC();     // 엔터를 입력하면 회원탈퇴
                if(inputValue == Constant.ESC_STRING)
                {
                    return Constant.FAIL_INT;
                }

                isSuccessDelete = IsAbleDelete(id, (int)MODE.USER);     // 대여 중인 책이 있는지 확인
                if(!isSuccessDelete)
                {
                    Console.Clear();
                    PrintUserInformation.GetPrintUserInformation().PrintNotWorkedDeleteAccout();
                    InputFromUser.GetInputFromUser().EnteredESC();
                    isSuccessDelete = true;
                    continue;
                }

                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.DELETE_USER_ACCOUNT, id);
                AccessorData.DeleteUserData(id);
                Console.Clear();
                PrintUserInformation.GetPrintUserInformation().PrintSuccessDeleteAccount();
                InputFromUser.GetInputFromUser().EnteredESC();
            }
            return Constant.DELETE_ACCOUNT;
        }

        private bool IsAbleDelete(string id, int entryType)
        {
            if(entryType == (int)MODE.USER)
            {
                List<UsersBookDTO> rentBook = new List<UsersBookDTO>();
                rentBook = AccessorData.SelectAllRentBookList(id);

                if (rentBook.Count == 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                BookDTO book = new BookDTO();
                book = AccessorData.SelectPartlyBook(int.Parse(id));

                if (book.Title == null)
                {
                    return false;
                }
                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.DELETE_BOOK_INFROMATION, book.Title);
                return true;
            }
        }

        private string SearchId(int entryType)
        {
            int column = 45;
            int row = 3;
            string regexForm;

            if(entryType == (int)MODE.USER)
            {
                regexForm = Constant.ID;
            }
            else
            {
                regexForm = Constant.NUMBER;
            }
            string id = ExceptionHandler.GetExceptionHandler().IsValidInput(regexForm, column, row, 15, Constant.IS_NOT_PASSWORD);

            return id;
        }
    }
}
