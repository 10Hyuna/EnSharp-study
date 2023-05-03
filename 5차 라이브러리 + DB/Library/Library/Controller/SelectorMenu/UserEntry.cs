using Library.Controller.MemberAccess;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMode
{
    public class UserEntry
    {
        MainView mainView;
        MenuIndexSelector menuIndexSelector;
        Login login;
        SignUp signUp;
        UserMode userMode;

        public UserEntry(Login login)
        {
            mainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            this.login = login;
            signUp = new SignUp();
            userMode = new UserMode();
        }

        public void SelectEntryType()
        {
            int column = 32;
            int row = 10;

            int selectedMenu = 0;
            int modeIndex = 0;

            string loginResult = "";
            bool isNotESC = true;
            string[] menu = { "로그인", "회원가입" };

            while (isNotESC)
            {
                Console.SetWindowSize(76, 16);
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(4);

                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if(selectedMenu == Constant.EXIT_INT)
                {
                    isNotESC = false;
                    continue;
                }

                switch (selectedMenu)
                {
                    case (int)USERENTRY.SIGNIN:
                        loginResult = login.EntryUserLogin(Constant.USERENTRY);
                        EnterUserMode(loginResult);
                        break;
                    case (int)USERENTRY.SIGNUP:
                        signUp.EntrySignUp();
                        break;
                }

                if(loginResult == Constant.ESC_STRING)
                {
                    isNotESC = false;
                }
            }
        }

        private void EnterUserMode(string loginResult)
        {
            if (loginResult != Constant.ID_FAIL
                && loginResult != Constant.PW_FAIL
                && loginResult != Constant.ESC_STRING)
            {
                userMode.SelectMenu();
            }
        }
    }
}
