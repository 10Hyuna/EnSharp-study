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
        QurserController qurser = new QurserController();
        UserMenu userMenu = new UserMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        private void UseLibrary()
        {
            int selectedMenu;

            string[] menu = { "유저 모드", "매니저 모드" };

            ui.PrintMain();
            selectedMenu = qurser.QurserSelect(menu, 2);
            
            if(selectedMenu == 1)
            {
                userMenu.UsingUserMenu(ui);
            }
            
            else if(selectedMenu == 2)
            {
                managerMenu.UsingManagerMenu(ui);
            }
        }
    }
}
