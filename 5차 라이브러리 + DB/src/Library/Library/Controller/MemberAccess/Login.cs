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

        public string EntryLogin(string entryType)      // 로그인하는 메소드
        {
            List<string> account = null;
            bool isValidAccount = true;
            string loginResult = "";

            int column = 10;
            int row = 12;

            while (isValidAccount)
            {
                isValidAccount = false;
                Console.SetWindowSize(76, 20);
                Console.Clear();
                MainView.SetMainView().PrintLoginUI(entryType);

                account = ReturnInformation();      // 아이디와 비밀번호 값을 입력받는 메소드 호출

                if (account[0] == Constant.ESC_STRING)
                {       // 중간에 ESC가 입력되었다면
                    return Constant.ESC_STRING;
                }

                if(entryType == Constant.USERENTRY)
                {       // 유저 모드에서 로그인하는 중이라면
                    loginResult = IsCheckUserAccount(account);
                }
                else
                {       // 매니저 모드에서 로그인하는 중이라면
                    loginResult = IsCheckManagerAccount(account);
                }

                if (loginResult == Constant.ID_FAIL)
                {       // 일치하는 아이디 값이 없다면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.ID_FAIL, column, row);
                }
                else if (loginResult == Constant.PW_FAIL)
                {       // 일치하는 아이디 값의 비밀번호와 입력된 비밀번호의 값이 다르다면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.PW_FAIL, column, row);
                }
            }
            if(entryType == Constant.USERENTRY)
            {
                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.LOGIN, account[(int)ACCOUNT.ID]);
            }
            else
            {
                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOGIN, account[(int)ACCOUNT.ID]);
            }
            return loginResult;
        }

        private List<string> ReturnInformation()
        {
            List<string> account = new List<string>();

            bool isValidInput = true;
            int column = 30;
            int row = 15;
            string id = "";
            string password = "";

            while (isValidInput)
            {
                isValidInput = false;
                id = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.ID, column, row, 15, Constant.IS_NOT_PASSWORD);
                if (id == "")
                {   // 아무 값도 입력하지 않았다면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 18, row + 2);
                    isValidInput = true;
                    continue;
                }
                if (id == Constant.ESC_STRING)
                {
                    account.Add(Constant.ESC_STRING);
                    return account;
                }

                password = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.PASSWORD, column, row + 1, 15, Constant.IS_PASSWORD);
                if (password == "")
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 18, row + 2);
                    isValidInput = true;
                    continue;
                }
                if (password == Constant.ESC_STRING)
                {
                    account.Add(Constant.ESC_STRING);
                    return account;
                }
            }
            account.Add(id);
            account.Add(password);

            return account;
        }

        private string IsCheckUserAccount(List<string> account)
        {
            UserDTO user = null;
            user = AccessorData.SelectUserData(account[(int)ACCOUNT.ID]);
                
            if(user.Id == null)
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
