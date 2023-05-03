﻿using Library.Utility;
using Library.View;
using Org.BouncyCastle.Bcpg;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMode
{
    public class UserMode
    {
        MainView MainView;
        MenuIndexSelector menuIndexSelector;

        public UserMode()
        {
            MainView = MainView.SetMainView();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
        }

        public void SelectMenu(string userId)
        {
            int column = 30;
            int row = 10;

            int selectedMenu = 0;
            int checkingBreak = -1;

            bool isNotESC = true;

            string[] menu = { "도서 찾기", "도서 대여", "도서 대여 확인", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제" };

            while (isNotESC)
            {
                Console.SetWindowSize(76, 20);
                checkingBreak = -1;
                Console.Clear();
                MainView.PrintMain();
                MainView.PrintBox(9);

                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if(selectedMenu == Constant.EXIT_INT)
                {
                    isNotESC = false;
                    continue;
                }

                checkingBreak = EnterSelectedMenu(selectedMenu);

                if(checkingBreak == Constant.DELETE_ACCOUNT)
                {
                    isNotESC = false;
                }
            }
        }

        private int EnterSelectedMenu(int selectedMenu)
        {
            int breakPoint = -1;

            switch(selectedMenu)
            {
                case (int)USERMENU.FIND:

                    break;
                case (int)USERMENU.RENT:

                    break;
                case (int)USERMENU.RENT_LIST:

                    break;
                case (int)USERMENU.RETURN:

                    break;
                case (int)USERMENU.RETURN_LIST:

                    break;
                case (int)USERMENU.MODIFY_MY_INFORMATION:

                    break;
                case (int)USERMENU.DELETE_ACCOUNT:
                    //breakPoint = 
                    break;
            }
            return breakPoint;
        }
    }
}
