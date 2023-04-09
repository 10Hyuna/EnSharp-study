using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class CurserController
    {
        const int WindowCenterWidth = 53;
        const int WindowCenterHeight = 18;
        const int WindowAnnouce = 25;

        const int errorKey = -1;
        const int enterKey = 10;
        const int exitKey = 11;
        public int SelectCurser(string[] menu, int endMenu, int index, UI ui)
        {
            int selectedMenu = 0;
            bool isSelectedEnter = false;
            do
            {
                for (int i = 0; i < endMenu; i++)
                {
                    Console.SetCursorPosition(WindowCenterWidth, i + WindowCenterHeight);

                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
                selectedMenu = ui.SelectKey(endMenu - 1, index);
                if(selectedMenu == errorKey)
                {
                    Console.SetCursorPosition(WindowCenterWidth, WindowAnnouce);
                    Console.WriteLine("잘못된 입력입니다");
                    selectedMenu = index;
                }
                else if(selectedMenu == enterKey)
                {
                    isSelectedEnter = true;
                    selectedMenu = index;
                }
                else if(selectedMenu == exitKey)
                {
                    return -1;
                }
                index = selectedMenu;
            } while (!isSelectedEnter);

            return index;
        }
    }
}
