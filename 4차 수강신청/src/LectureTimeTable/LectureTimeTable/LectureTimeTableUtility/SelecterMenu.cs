using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableView;

namespace LectureTimeTable.LectureTimeTableUtility
{
    public class SelecterMenu
    {
        MenuAndOption menuAndOption;
        InputFromUser inputFromUser;
        public SelecterMenu(MenuAndOption menuAndOption, InputFromUser inputFromUser)
        {
            this.menuAndOption = menuAndOption;
            this.inputFromUser = inputFromUser;
        }

        public void SetColorMenu(string[] menu, int menuIndex, int consoleColumn, int consoleRow)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(consoleColumn, consoleRow + i);
                if (i == menuIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    menuAndOption.PrintMenu(menu[i]);
                    Console.ResetColor();
                }
                else
                {
                    menuAndOption.PrintMenu(menu[i]);
                }
            }
        }
        public int SelectMenu(string[] menu, int menuIndex, int consoleColumn, int consoleRow)
        {
            int selectedIndex;
            bool isEnter = false;
            while(!isEnter)
            {
                for(int i = 0; i < menu.Length; i++)
                {
                    Console.SetCursorPosition(consoleColumn, consoleRow + i);
                    if(i == menuIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        menuAndOption.PrintMenu(menu[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        menuAndOption.PrintMenu(menu[i]);
                    }
                }
                selectedIndex = inputFromUser.SelectIndexKey(menu.Length - 1, menuIndex);

                switch (selectedIndex)
                {
                    case (int)ConstantNumber.FAILE:
                        // 잘못된 입력
                        selectedIndex = menuIndex;
                        break;
                    case (int)ConstantNumber.ENTER:
                        isEnter = true;
                        selectedIndex = menuIndex;
                        break;
                    case (int)ConstantNumber.EXIT:
                        isEnter = true;
                        selectedIndex = (int)ConstantNumber.EXIT;
                        break;
                }
                menuIndex = selectedIndex;
            }
            return menuIndex;
        }
    }
}
