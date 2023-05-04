using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMenu
{
    public class UserManagement
    {
        MainView mainView;
        MenuIndexSelector menuIndexSelector;

        public UserManagement()
        {
            mainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
        }

        public void SelectManagement()
        {
            int column;
            int row;

            int selectedMenu = 0;
            bool isEnterESC = false;

            string[] menu = { "유저 정보 수정", "유저 삭제" };

            while (!isEnterESC)
            {
                column = 50;
                row = 17;

                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(6);

                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if (selectedMenu == Constant.EXIT_INT)     // 중간에 esc를 눌렀다면
                {
                    return;
                }

                switch (selectedMenu)
                {
                    case (int)MODIFICATION.INFORMATION:

                        break;
                    case (int)MODIFICATION.ACCOUNT:

                        break;
                }
            }
        }
    }
}
