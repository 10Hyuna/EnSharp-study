using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class UsingLibrary
    {
        UI ui = new UI();
        CurserController curser = new CurserController();
        UserMenu userMenu = new UserMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public void MainLibrary()
        {
            int selectedMenu = 0;

            string[] menu = { "유저 모드", "매니저 모드" };
            do
            {
                Console.Clear();
                ui.PrintMain();
                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);

                if (selectedMenu == 1)
                {
                    Console.Clear();
                    userMenu.UsingUserMenu(ui);
                }

                else if (selectedMenu == 2)
                {
                    Console.Clear();
                    managerMenu.UsingManagerMenu(ui);
                }
                else if (selectedMenu == -1)
                {
                    Console.Clear();
                }
            } while (selectedMenu != -1);
        }
    }
}
