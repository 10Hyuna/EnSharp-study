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
                    DeleteUserManagerMode(id);
                    break;
                case (int)MODE.USER:
                    returnValue = DeleteMyAccount(id);
                    break;
            }
            return returnValue;
        }

        public void DeleteBookInformation()
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
                PrintBookInformation.PrintDeleteTheBookUI();

                List<BookDTO> books = new List<BookDTO>();
                books = AccessorData.AllBookData();

                for (int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.PrintBookList(books[i]);
                }

                Console.SetCursorPosition(0, 0);
                bookId = SearchId((int)MODE.MANAGER);
                if (bookId == Constant.ESC_STRING)
                {
                    return;
                }
                else if (!ExceptionHandler.IsStringAllNumber(bookId))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                bookNumber = int.Parse(bookId);

                isSuccessDelete = IsAbleDelete(bookId, (int)MODE.MANAGER);
                if (!isSuccessDelete)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_KEYWORD, column, row);
                    continue;
                }
                AccessorData.DeleteBookData(bookNumber);
                PrintBookInformation.PrintSuccessDeleteBook();
            }
        }

        private void DeleteUserManagerMode(string id)
        {
            List<UserDTO> users = new List<UserDTO>();
            users = AccessorData.SelectAllUserData();

            bool isSucessDelete = false;
            
            while (!isSucessDelete)
            {
                Console.Clear();
                PrintUserInformation.PrintManageUser();

                PrintUserInformation.PrintUserList(users);

                id = SearchId((int)MODE.USER);
                if (id == Constant.ESC_STRING)
                {
                    return;
                }

                isSucessDelete = IsAbleDelete(id, (int)MODE.USER);
                if (!isSucessDelete)
                {
                    Console.Clear();
                    PrintUserInformation.PrintNotWorkedDeleteAccout();
                    continue;
                }

                AccessorData.DeleteUserData(id);
                Console.Clear();
                PrintUserInformation.PrintSuccessDeleteUser();
            }
        }

        private int DeleteMyAccount(string id)
        {
            bool isSuccessDelete = false; ;

            string inputValue;
            while (!isSuccessDelete)
            {
                Console.Clear();
                PrintUserInformation.PrintDeleteAccountUI();

                inputValue = InputFromUser.InputEnterESC();
                if(inputValue == Constant.ESC_STRING)
                {
                    return Constant.FAIL_INT;
                }

                isSuccessDelete = IsAbleDelete(id, (int)MODE.USER);
                if(!isSuccessDelete)
                {
                    Console.Clear();
                    PrintUserInformation.PrintNotWorkedDeleteAccout();
                    continue;
                }

                AccessorData.DeleteUserData(id);
                Console.Clear();
                PrintUserInformation.PrintSuccessDeleteAccount();
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
            string id = ExceptionHandler.IsValidInput(regexForm, column, row, 15, Constant.IS_NOT_PASSWORD);

            return id;
        }
    }
}
