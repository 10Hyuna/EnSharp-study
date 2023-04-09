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

            const int userMenuEnter = 0;
            const int managerMenuEnter = 1;
            const int exit = -1;

            string[] menu = { "유저 모드", "매니저 모드" };
            do
            {
                Console.Clear();
                ui.PrintMain();
                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);

                if (selectedMenu == userMenuEnter)
                {
                    Console.Clear();
                    userMenu.UsingUserMenu(ui, curser);
                }

                else if (selectedMenu == managerMenuEnter)
                {
                    Console.Clear();
                    managerMenu.UsingManagerMenu(ui, curser);
                }
                else if (selectedMenu == exit)
                {
                    Console.Clear();
                }
            } while (selectedMenu != -1);
        }
    }
}
