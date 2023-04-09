using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class UserMenu
    {
        MemberFunction memberFunction = new MemberFunction();
        public void UsingUserMenu(UI ui, CurserController curser)
        {
            int selectedMenu = 0;

            bool isEnterCheck = false;

            const int signIn = 0;
            const int signUp = 1;
            const int exit = -1;
            const int enter = 10;

            string[] menu = { "로그인", "회원가입" };

            do
            {

                Console.Clear();
                ui.PrintMain();
                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);
                if (selectedMenu == signUp)
                {
                    Console.Clear();
                    ui.PrintSignUpUI();
                    memberFunction.SignUpMember();
                    while (!isEnterCheck)
                    {
                        Console.Clear();
                        ui.PrintMain();
                        ui.PrintSuccessSignup();

                        ConsoleKeyInfo keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            isEnterCheck = true;
                        }
                    }
                }
                else if (selectedMenu == signIn)
                {
                    Console.Clear();
                    ui.PrintLogin();
                    curser.SelectCurser(menu, menu.Length, selectedMenu, ui);
                }
            } while (selectedMenu != exit);
        }
    }
}
