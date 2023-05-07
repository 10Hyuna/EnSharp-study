using Library.Controller.LogAccess;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMenu
{
    public class Log
    {
        private ManagementLog managementLog;
        public Log()
        {
            managementLog = new ManagementLog();
        }
        public void SelectMenu()
        {
            string[] menu = { "로그 수정", "로그 저장", "로그 삭제", "로그 리셋" };
            int selectedMenu = 0;

            int column = 32;
            int row = 10;

            bool isESC = true;

            while (isESC)
            {
                isESC = false;
                Console.SetWindowSize(76, 18);
                Console.Clear();
                MainView.SetMainView().PrintMain();
                MainView.SetMainView().PrintBox(6);

                selectedMenu = MenuIndexSelector.GetMenuIndexSelector().SelectMenuIndex(menu, selectedMenu, column, row);

                if(selectedMenu == Constant.EXIT_INT)
                {
                    continue;
                }

                EnterMenu(selectedMenu);
                isESC = true;
            }
        }

        private void EnterMenu(int selectedMenu)
        {
            switch(selectedMenu)
            {
                case (int)LOG.MODIFY:
                    managementLog.ModifyLog();
                    break;
                case (int)LOG.SAVE:
                    managementLog.AskSaveLog();
                    break;
                case (int)LOG.DELETE:
                    managementLog.AskDeleteLog();
                    break;
                case (int)LOG.RESET:
                    managementLog.CheckResetLog();
                    break;
            }
        }
    }
}
