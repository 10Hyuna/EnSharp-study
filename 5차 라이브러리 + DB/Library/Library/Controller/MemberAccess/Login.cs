using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.MemberAccess
{
    public class Login
    {
        MainView mainView;
        ExceptionHandler exceptionHandler;

        public Login()
        {
            mainView = MainView.SetMainView();
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
        }

        public bool EntryUserLogin()
        {
            List<string> account;
            bool isNotValidAccount = false;

            while (isNotValidAccount)
            {
                Console.Clear();
                MainView.PrintLoginUI("USER");

                account = ReturnInformation();

                if (account[0] == Constant.ESC_STRING)
                {
                    return false;
                }

                isNotValidAccount = IsCheckValidAccount();

                if(!isNotValidAccount)
            }
            return true;
        }

        public void EntryManagerLogin()
        {

        }

        private List<string> ReturnInformation()
        {
            List<string> account = new List<string>();

            int column = 25;
            int row = 10;
            string id;
            string password;

            id = ExceptionHandler.IsValidInput(Constant.IDCHECK, column, row, 15, Constant.IS_NOT_PASSWORD);
            if(id== Constant.ESC_STRING)
            {
                account.Add(Constant.ESC_STRING);
                return account;
            }

            password = ExceptionHandler.IsValidInput(Constant.PASSWORDCHECK, column, row + 1, 15, Constant.IS_PASSWORD);
            if (password == Constant.ESC_STRING)
            {
                account.Add(Constant.ESC_STRING);
                return account;
            }
            account.Add(id);
            account.Add(password);

            return account;
        }

        private bool IsCheckValidAccount()
        {
            return true;
        }
    }
}
