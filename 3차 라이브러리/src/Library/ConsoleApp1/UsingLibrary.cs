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
        UserMenu userMenu = new UserMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        private void UseLibrary()
        {
            int selectedMenu;

            selectedMenu = ui.PrintMain();
            
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
