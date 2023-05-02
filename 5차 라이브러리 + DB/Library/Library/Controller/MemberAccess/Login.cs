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
            bool isValidAccount = true;

            while (isValidAccount)
            {
                Console.Clear();
                MainView.PrintLoginUI("USER");

                account = ReturnInformation();

                if (account[0] == Constant.ESC_STRING)
                {
                    return false;
                }

                isValidAccount = IsCheckValidAccount();
            }
            return true;
        }

        public void EntryManagerLogin()
        {

        }

        private List<string> ReturnInformation()
        {
            return null;
        }

        private bool IsCheckValidAccount()
        {
            return true;
        }
    }
}
