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
    public class Mode
    {
        MainView mainView;
        MenuIndexSelector menuIndexSelector;
        Login login;
        UserEntry userEntry;

        public Mode()
        {
            MainView mainView = MainView.SetMainView();
            MenuIndexSelector menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            login = new Login();
            userEntry = new UserEntry(login);
        }

        public void SelectMode()
        {
            string[] modeMenu = { "유저 모드", "매니저 모드" };
            int menuIndex = 0;

            int consoleColumn = 32;
            int consoleRow = 9;

            Console.Clear();
            MainView.PrintMain();
            MainView.PrintBox(4);

            bool isEnterESC = true;

            while (isEnterESC)
            {
                Console.SetWindowSize(76, 15);
                menuIndex = MenuIndexSelector.SelectMenuIndex(modeMenu, menuIndex, consoleColumn, consoleRow);

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
