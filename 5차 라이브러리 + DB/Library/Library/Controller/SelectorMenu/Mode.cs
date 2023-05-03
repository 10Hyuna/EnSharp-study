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

        public Mode()
        {
            searcher = new Searcher();
            sortList = new SortList();
            deleterInformation = new DeleterInformation();
            MainView mainView = MainView.SetMainView();
            MenuIndexSelector menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            login = new Login();
            userEntry = new UserEntry(login, searcher, sortList, deleterInformation);
            managerMode = new ManagerMode(login, searcher, sortList, deleterInformation);
        }

        public void SelectMode()
        {
            string[] modeMenu = { "유저 모드", "매니저 모드" };
            int menuIndex = 0;

            int consoleColumn = 32;
            int consoleRow = 10;

            bool isNotEnterESC = true;

            while (isNotEnterESC)
            {
                Console.SetWindowSize(76, 16);
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(4);
                menuIndex = MenuIndexSelector.SelectMenuIndex(modeMenu, menuIndex, consoleColumn, consoleRow);

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

                        break;
                }
            }
        }
    }
}
