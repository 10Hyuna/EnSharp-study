using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class UserMenu
    {
        Member memberFunction = new Member();
        public void UsingUserMenu(UI ui, CurserController curser, DataController dataController, Member memberFunction, BookFunction bookFunction)
        {       // 유저 모드에 진입했을 경우
            int selectedMenu = 0;

            bool isEnterCheck = false;
            bool isExitCheck = false;

            ConsoleKeyInfo keyInfo;

            const int signIn = 0;
            const int signUp = 1;
            const int exit = -1;
            const int enter = 10;

            string[] menu = { "로그인", "회원가입" };

            do
            {

                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);        // 키보드를 통한 진입과 선택으로 최종 엔터키를 입력한 뒤
                                                                                                // 선택된 인덱스가 무엇인지 출력

                if (selectedMenu == signUp)             // 회원가입을 선택했을 경우
                {
                    Console.Clear();
                    ui.PrintSignUpUI();
                    memberFunction.SignUpMember(dataController, ui);        // 회원가입 함수로 진입
                    while (!isEnterCheck)       // 엔터키를 입력하지 않는 동안 무한반복
                    {
                        Console.Clear();
                        ui.PrintMain();
                        ui.PrintSuccessSignup();
                 
                        keyInfo = Console.ReadKey();

                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            isEnterCheck = true;
                        }
                    }
                }
                else if (selectedMenu == signIn)        // 로그인을 선택했을 경우
                {
                    Console.Clear();
                    ui.PrintLogin();
                    while(!isExitCheck)
                    {
                        memberFunction.SignInMember(dataController, ui, curser, bookFunction);      // 로그인 함수로 진입

                        keyInfo = Console.ReadKey();

                        if(keyInfo.Key == ConsoleKey.Escape)
                        {
                            isExitCheck = true;
                        }
                    }
                }
            } while (selectedMenu != exit);         // ESC를 누르지 않는 한 계속 반복
        }
    }
}
