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
        BookFunction bookFunction = new BookFunction();
        Member memberFunction = new Member();
        public void MainLibrary(DataController dataController)      // 메인 콘솔창
        {
            int selectedMenu = 0;

            bool isEnterESC = false;

            const int userMenuEnter = 0;
            const int managerMenuEnter = 1;
            const int exit = -1;

            string[] menu = { "유저 모드", "매니저 모드" };
            do
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);        // 키보드를 통해 선택한 메뉴의 값이 무엇인지 보고 

                if (selectedMenu == userMenuEnter)      // 유저 모드를 선택했다면
                {
                    userMenu.UsingUserMenu(ui, curser, dataController, memberFunction, bookFunction);       // 유저 모드로 진입
                }

                else if (selectedMenu == managerMenuEnter)      // 매니저 모드를 선택했다면
                {
                    managerMenu.UsingManagerMenu(ui, curser, dataController, memberFunction, bookFunction); // 매니저 모드로 진입
                }
                else if (selectedMenu == exit)      // ESC를 눌렀다면
                {
                    Console.Clear();
                    isEnterESC = true;
                }
            } while (!isEnterESC);
        }
    }
}
