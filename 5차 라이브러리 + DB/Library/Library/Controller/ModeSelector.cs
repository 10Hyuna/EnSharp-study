using Library.Controller.MemberAccess;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ModeSelector
    {
        MainView mainView;
        MenuIndexSelector menuIndexSelector;
        Login login;

        public ModeSelector()
        {
            MainView mainView = MainView.SetMainView();
            MenuIndexSelector menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
        }

        public void SelectMode()
        {
            string[] modeMenu = { "유저 모드", "매니저 모드" };
            int menuIndex = 0;

            int consoleColumn = 50;
            int consoleRow = 30;

            Console.Clear();
            mainView.PrintMain();
            mainView.PrintBox(4);

            bool isEnterESC = true;

            while(isEnterESC)
            {
                menuIndex = menuIndexSelector.SelectMenuIndex(modeMenu, menuIndex, consoleColumn, consoleRow);

                switch (menuIndex)
                {
                    case (int)MODE.USER:

                        break;
                    case (int)MODE.MANAGER:

                        break;
                }
            }
        }
    }
}
