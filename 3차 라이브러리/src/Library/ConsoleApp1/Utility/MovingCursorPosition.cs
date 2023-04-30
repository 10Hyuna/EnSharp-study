using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.View;

namespace Library.Utility
{
    class MovingCursorPosition      // 커서를 이용해 입력을 받을 때나 사용자의 커서가 위치해 있는 메뉴를 표기하기 위해 커서의 위치를 컨트롤할 때 사용하는 클래스
    {
        UI ui;
        InputFromUser inputFromUser;

        public MovingCursorPosition(UI ui, InputFromUser inputFromUser)
        {
            this.ui = ui;
            this.inputFromUser = inputFromUser;
        }

        const int WindowAnnouce = 25;

        const int errorKey = -1;
        const int enterKey = 10;
        const int exitKey = 11;
        public int SelectCurser(string[] menu, int endMenu, int index, int WindowCenterWidth, int WindowCenterHeight)       // 메뉴를 전달받아 사용
        {
            int selectedMenu = 0;
            bool isSelectedEnter = false;
            while (!isSelectedEnter)
            {
                for (int i = 0; i < endMenu; i++)
                {
                    Console.SetCursorPosition(WindowCenterWidth, i + WindowCenterHeight);

                    if (i == index)     // 사용자의 커서가 위치해 있는 곳일 때
                    {
                        Console.ForegroundColor = ConsoleColor.Green;   // 초록색으로 색 변경
                    }

                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }

                selectedMenu = inputFromUser.SelectKey(endMenu - 1, index);

                if (selectedMenu == errorKey)            // 사용자가 사용할 수 있는 키를 제외한 키를 눌렀을 때
                {
                    Console.SetCursorPosition(WindowCenterWidth, WindowAnnouce);
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, 40, 24);
                    selectedMenu = index;
                }
                else if (selectedMenu == enterKey)       // 엔터키를 입력할 경우 메뉴에 진입하기 위해 반복문에서 탈출
                {
                    isSelectedEnter = true;
                    selectedMenu = index;
                }
                else if (selectedMenu == exitKey)        // ESC 키 입력
                {
                    return -1;
                }
                index = selectedMenu;

            }     // 엔터키를 통해 메뉴에 진입하고자 할 때 반복문에서 탈출

            return index;
        }
    }
}
