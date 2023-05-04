using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.TotalAccess
{
    public class DeleterInformation
    {

        private ExceptionHandler exceptionHandler;
        private AccessorData accessorData;
        private PrintUserInformation printUserInformation;
        private InputFromUser inputFromUser;

        public DeleterInformation()
        {
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            accessorData = AccessorData.GetAccessorData();
            printUserInformation = PrintUserInformation.GetPrintUserInformation();
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

                id = SearchId();
                if (id == Constant.ESC_STRING)
                {
                    return;
                }

                isSucessDelete = IsAbleDelete(id);
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

                isSuccessDelete = IsAbleDelete(id);
                if(!isSuccessDelete)
                {
                    Console.Clear();
                    PrintUserInformation.PrintNotWorkedDeleteAccout();
                    continue;
                }

                AccessorData.DeleteUserData(id);
                Console.Clear();
                PrintUserInformation.PrintSuccessDeleteUser();
            }
            return Constant.DELETE_ACCOUNT;
        }

        private bool IsAbleDelete(string id)
        {
            List<UsersBookDTO> rentBook = AccessorData.SelectAllRentBookList(id);

            if (rentBook.Count == 0)
            {
                return true;
            }
            return false;
        }

        private string SearchId()
        {
            int column = 40;
            int row = 3;
            string id = ExceptionHandler.IsValidInput(Constant.ID, column, row, 15, Constant.IS_NOT_PASSWORD);

            return id;
        }
    }
}
