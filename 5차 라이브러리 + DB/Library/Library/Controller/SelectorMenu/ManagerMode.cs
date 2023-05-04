using Library.Controller.BookAccess;
using Library.Controller.MemberAccess;
using Library.Controller.SelectorMenu;
using Library.Controller.TotalAccess;
using Library.Utility;
using Library.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMode
{
    public class ManagerMode
    {
        Searcher searcher;
        SortList sortList;
        DeleterInformation deleterInformation;
        ModificationInformation modificationInformation;
        MainView mainView;
        MenuIndexSelector menuIndexSelector;
        Addition addition;
        UserManagement userManagement;

        public ManagerMode(Searcher searcher, SortList sortList, DeleterInformation deleterInformation, ModificationInformation modificationInformation)
        {
            this.searcher = searcher;
            this.sortList = sortList;
            this.deleterInformation = deleterInformation;
            this.modificationInformation = modificationInformation;
            mainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            addition = new Addition();
            userManagement = new UserManagement();
        }

        public void EnterMenu()
        {
            int column = 30;
            int row = 10;

            int selectedMenu = 0;

            bool isNotESC = true;

            string[] menu = { "도서 찾기", "도서 추가", "도서 삭제", "도서 수정", "회원 관리", "대여 내역" };

            while (isNotESC)
            {
                Console.SetWindowSize(76, 20);
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(8);

                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if (selectedMenu == Constant.EXIT_INT)
                {
                    isNotESC = false;
                    continue;
                }

                EnterSelectedMenu(selectedMenu);
            }
        }

        private void EnterSelectedMenu(int selectedMenu)
        {
            switch(selectedMenu)
            {
                case (int)MANAGERMODE.FIND:
                    searcher.SearchBook((int)MANAGERMODE.FIND);
                    break;
                case (int)MANAGERMODE.ADD:
                    addition.AddBook();
                    break;
                case (int)MANAGERMODE.DELETE:
                    deleterInformation.DeleteBookInformation();
                    break;
                case (int)MANAGERMODE.MODIFY:
                    modificationInformation.ModifyBookInformation();
                    break;
                case (int)MANAGERMODE.MANAGEMENT:

                    break;
                case (int)MANAGERMODE.LIST:

                    break;

            }
        }
    }
}
