using Library.Controller.APIAccess;
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
    public class Mode
    {
        MainView mainView;
        MenuIndexSelector menuIndexSelector;
        Login login;
        ManagerMode managerMode;
        UserEntry userEntry;
        Searcher searcher;
        SortList sortList;
        DeleterInformation deleterInformation;
        ModificationInformation modificationInformation;
        NaverBookSearch naverBookSearch;

        public Mode()
        {
            searcher = new Searcher();
            sortList = new SortList();
            deleterInformation = new DeleterInformation();
            modificationInformation = new ModificationInformation();
            naverBookSearch = new NaverBookSearch();
            MainView mainView = MainView.SetMainView();
            MenuIndexSelector menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            login = new Login();
            userEntry = new UserEntry(login, searcher, sortList, deleterInformation, modificationInformation, naverBookSearch);
            managerMode = new ManagerMode(searcher, sortList, deleterInformation, modificationInformation, naverBookSearch);
        }

        public void SelectMode()
        {
            string[] modeMenu = { "유저 모드", "매니저 모드" };
            int menuIndex = 0;
            string loginResult;

            int consoleColumn = 32;
            int consoleRow = 10;

            bool isNotEnterESC = true;

            while (isNotEnterESC)
            {
                Console.SetWindowSize(76, 16);
                Console.Clear();
                MainView.SetMainView().PrintMain();
                MainView.SetMainView().PrintBox(4);
                menuIndex = MenuIndexSelector.GetMenuIndexSelector().SelectMenuIndex(modeMenu, menuIndex, consoleColumn, consoleRow);

                if(menuIndex == Constant.EXIT_INT)
                {
                    isNotEnterESC = false;
                    continue;
                }

                switch (menuIndex)
                {
                    case (int)MODE.USER:
                        userEntry.SelectEntryType();
                        break;
                    case (int)MODE.MANAGER:
                        loginResult = login.EntryLogin(Constant.MANAGERENTRY);
                        EnterManagerMenu(loginResult);
                        break;
                }
            }
        }

        private void EnterManagerMenu(string loginResult)
        {
            if(loginResult!=Constant.ID_FAIL 
                && loginResult != Constant.PW_FAIL
                && loginResult != Constant.ESC_STRING)
            {
                managerMode.EnterMenu();
            }
        }
    }
}
