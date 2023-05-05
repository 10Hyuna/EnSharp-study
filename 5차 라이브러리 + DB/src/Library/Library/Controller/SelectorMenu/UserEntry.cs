using Library.Controller.BookAccess;
using Library.Controller.MemberAccess;
using Library.Controller.TotalAccess;
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
        ManagerMode managerMode;
        Searcher searcher;
        SortList sortList;
        DeleterInformation deleterInformation;
        ModificationInformation modificationInformation;

        public UserEntry(Login login, Searcher searcher, SortList sortList, DeleterInformation deleterInformation, ModificationInformation modificationInformation)
        {
            this.searcher = searcher;
            this.sortList = sortList;
            this.deleterInformation = deleterInformation;
            this.modificationInformation = modificationInformation;
            mainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            this.login = login;
            signUp = new SignUp();
            userMode = new UserMode(searcher, sortList, deleterInformation, modificationInformation);
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
                        loginResult = login.EntryLogin(Constant.USERENTRY);
                        EnterUserMode(loginResult);
                        break;
                    case (int)USERENTRY.SIGNUP:
                        signUp.EntrySignUp();
                        break;
                }
            }
        }

        private void EnterUserMode(string loginResult)
        {
            if (loginResult != Constant.ID_FAIL
                && loginResult != Constant.PW_FAIL
                && loginResult != Constant.ESC_STRING)
            {
                userMode.SelectMenu(loginResult);
            }
        }
    }
}
