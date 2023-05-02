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
            int column = 100;
            int row = 17;

            int selectedMenu = 0;
            int modeIndex = 0;

            bool isSuccessLogin = false;
            bool isNotESC = true;
            string[] menu = { "로그인", "회원가입" };

            while (isNotESC)
            {
                Console.SetWindowSize(50, 30);
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(6);

                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if(selectedMenu == Constant.EXIT_INT)
                {
                    isNotESC = false;
                    continue;
                }

                switch (selectedMenu)
                {
                    case (int)USERENTRY.SIGNIN:
                        isSuccessLogin = login.EntryUserLogin();
                        EnterUserMode(isSuccessLogin);
                        break;
                    case (int)USERENTRY.SIGNUP:
                        signUp.EntrySignUp();
                        break;
                }
            }
        }

        private void EnterUserMode(bool isSuccessLogin)
        {
            if (isSuccessLogin)
            {
                userMode.SelectMenu();
            }
        }
    }
}
