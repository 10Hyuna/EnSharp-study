using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class UserMenu
    {
        MemberData member = new MemberData();
        public void UsingUserMenu(UI ui, CurserController curser)
        {
            int selectedMenu = 0;

            const int signIn = 0;
            const int signup = 1;

            Console.Clear();
            ui.PrintMain();

            string[] menu = { "로그인", "회원가입" };

            do
            {
                Console.Clear();
                ui.PrintMain();
                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);

            } while (selectedMenu != -1);

            if(selectedMenu == signIn)
            {
                ui.PrintLogin();
                curser.SelectCurser(menu, menu.Length, selectedMenu, ui);
            }
            else if(selectedMenu == signup)
            {
                ui.PrintSignUpUI();
                curser.SelectCurser(menu, menu.Length, selectedMenu, ui);
            }
        }
    }
}
