using Library.Model.DAO;
using Library.Model.DTO;
using Library.Model.VO;
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
        GuidancePhrase guidancePhrase;
        AccessorData accessorData;

        public Login()
        {
            mainView = MainView.SetMainView();
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            accessorData = AccessorData.GetAccessorData();
        }

        public string EntryUserLogin(string entryType)
        {
            List<string> account;
            bool isNotValidAccount = true;
            string loginResult = "";

            int column = 10;
            int row = 12;

            while (isNotValidAccount)
            {
                Console.SetWindowSize(76, 20);
                Console.Clear();
                MainView.PrintLoginUI(entryType);

                account = ReturnInformation();

                if (account[0] == Constant.ESC_STRING)
                {
                    return Constant.ESC_STRING;
                }

                if(entryType == Constant.USERENTRY)
                {
                    loginResult = IsCheckUserAccount(account);

                }
                else
                {
                    loginResult = IsCheckManagerAccount(account);
                }

                if (loginResult == Constant.ID_FAIL)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.ID_FAIL, column, row);
                }
                else if (loginResult == Constant.PW_FAIL)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.PW_FAIL, column, row);
                }
                else
                {
                    isNotValidAccount = false;
                }
            }
            return loginResult;
        }

        public void EntryManagerLogin()
        {

        }

        private List<string> ReturnInformation()
        {
            List<string> account = new List<string>();

            bool isValidInput = true;
            int column = 24;
            int row = 15;
            string id = "";
            string password = "";

            while (isValidInput)
            {
                id = ExceptionHandler.IsValidInput(Constant.ID, column, row, 15, Constant.IS_NOT_PASSWORD);
                if (id == "")
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 18, row + 2);
                    continue;
                }
                if (id == Constant.ESC_STRING)
                {
                    account.Add(Constant.ESC_STRING);
                    return account;
                }

                password = ExceptionHandler.IsValidInput(Constant.PASSWORD, column, row + 1, 15, Constant.IS_PASSWORD);
                if (password == "")
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 18, row + 2);
                    continue;
                }
                if (password == Constant.ESC_STRING)
                {
                    account.Add(Constant.ESC_STRING);
                    return account;
                }
                isValidInput = false;
            }
            account.Add(id);
            account.Add(password);

            return account;
        }

        private string IsCheckUserAccount(List<string> account)
        {
            UserDTO user = null;
            user = AccessorData.SelectUserData(account[(int)ACCOUNT.ID]);
           
            if(user == null)
            {
                return Constant.ID_FAIL;
            }
            else if (user.Password != account[(int)ACCOUNT.PASSWORD])
            {
                return Constant.PW_FAIL;
            }
            return user.Id;
        }

        private string IsCheckManagerAccount(List<string> account)
        {
            ManagerVO manager;

            manager = AccessorData.SelectManagerData(account[(int)ACCOUNT.ID]);

            if(manager == null)
            {
                return Constant.ID_FAIL;
            }
            else if(manager.Password != account[(int)ACCOUNT.PASSWORD])
            {
                return Constant.PW_FAIL;
            }
            return manager.Id;
        }
    }
}
