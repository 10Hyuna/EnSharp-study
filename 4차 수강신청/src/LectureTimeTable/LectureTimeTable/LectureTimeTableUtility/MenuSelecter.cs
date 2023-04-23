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

        int selectedIndex;
        bool isEnter = false;

        int consoleInputColumn;

        public void SetColorMenu(string[] menu, int menuIndex, int consoleColumn, int consoleRow, int length)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(consoleColumn, consoleRow + i);
                if (i == menuIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    menuAndOption.PrintMenu(menu[i], length);
                    Console.ResetColor();
                }
                else
                {
                    menuAndOption.PrintMenu(menu[i], length);
                }
            }
        }
        public int SelectMenu(string[] menu, int menuIndex, int consoleColumn, int consoleRow, bool isOption, int length)
        {
            isEnter = false;

            int originColumn = consoleColumn;
            int originRow = consoleRow;

            while (!isEnter)
            { 
                consoleColumn = originColumn;
                consoleRow = originRow;
                Console.SetCursorPosition(consoleColumn, consoleRow);

                for (int i = 0; i < menu.Length; i++)
                {
                    if(i == menuIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        menuAndOption.PrintMenu(menu[i], length);
                        consoleInputColumn = Console.CursorLeft;
                        Console.ResetColor();
                    }
                    else
                    {
                        menuAndOption.PrintMenu(menu[i], length);
                        consoleInputColumn = Console.CursorLeft;
                    }
                    if (isOption)
                    {
                        consoleColumn += menu[i].Length + 10;
                        Console.SetCursorPosition(consoleColumn, consoleRow);
                    }
                    else
                    {
                        Console.SetCursorPosition(consoleColumn, consoleRow + i + 1);
                    }
                }
                if (isOption)
                {
                    selectedIndex = inputFromUser.SelectOptionIndex(menu.Length - 1, menuIndex);
                }
                else
                {
                    selectedIndex = inputFromUser.SelectMenuIndex(menu.Length - 1, menuIndex);
                }

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
