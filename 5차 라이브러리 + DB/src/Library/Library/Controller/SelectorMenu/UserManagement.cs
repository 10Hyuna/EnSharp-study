using Library.Utility;
using Library.Controller.TotalAccess;
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
        ModificationInformation modificationInformation;
        DeleterInformation deleterInformation;

        public UserManagement(ModificationInformation modificationInformation, DeleterInformation deleterInformation)
        {
            mainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            this.modificationInformation = modificationInformation;
            this.deleterInformation = deleterInformation;
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
                column = 30;
                row = 10;

                Console.SetWindowSize(76, 15);

                Console.Clear();
                MainView.SetMainView().PrintMain();
                MainView.SetMainView().PrintBox(4);

                selectedMenu = MenuIndexSelector.GetMenuIndexSelector().SelectMenuIndex(menu, selectedMenu, column, row);

                if (selectedMenu == Constant.EXIT_INT)     // 중간에 esc를 눌렀다면
                {
                    return;
                }

                switch (selectedMenu)
                {
                    case (int)MODIFICATION.INFORMATION:
                        modificationInformation.ModifyInformation((int)MODE.MANAGER, "");
                        break;
                    case (int)MODIFICATION.ACCOUNT:
                        deleterInformation.DeleteUserInformation((int)MODE.MANAGER, "");
                        break;
                }
            }
        }
    }
}
