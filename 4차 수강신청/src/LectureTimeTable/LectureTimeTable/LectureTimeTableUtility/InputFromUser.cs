using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableUtility
{
    public class InputFromUser
    {
        ConsoleKeyInfo keyInfo;
        private bool isCharacterOrNumber(char input)        // 문자에 해당하는 값이 입력되었다면
        {
            if (input >= 'A' && input <= 'Z' || input >= 'a' && input <= 'z' || input >= '0' || input <= '9')
                return true;
            return false;
        }

        public int SelectIndexKey(int endMenuIndex, int selectedMenu)
        {
            keyInfo = Console.ReadKey(true);

            if(keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenu--;
                if(selectedMenu < 0)
                {
                    selectedMenu = endMenuIndex;
                }
            }
            else if(keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenu++;
                if(selectedMenu > endMenuIndex)
                {
                    selectedMenu = 0;
                }
            }
            else if(keyInfo.Key == ConsoleKey.Enter)
            {
                selectedMenu = ConstantNumber.ENTER;
            }
            else if(keyInfo.Key == ConsoleKey.Escape)
            {
                selectedMenu = ConstantNumber.EXIT;
            }
            else
            {
                selectedMenu = ConstantNumber.FAILE;
            }
            return selectedMenu;
        }

        public string InputStringFromUser(int maxLength, bool isPassword, bool isId, int consoleColumn, int consoleRow)
        {
            Console.CursorVisible = true;
            bool isEnter = false;
            string input = "";

            int originColumn = Console.CursorLeft + 13;
            int originRow = Console.CursorTop;
            Console.SetCursorPosition(originColumn, originRow);
            Console.Write("                ");

            while (!isEnter)
            {
                Console.SetCursorPosition(originColumn + input.Length, originRow);

                
                keyInfo = Console.ReadKey(true);

                if(keyInfo.Key == ConsoleKey.Escape)
                {
                    return ConstantNumber.ESC;
                }
                else if(keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                ");

                    input = ConstantNumber.UP;
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                ");

                    input = ConstantNumber.DOWN;
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("               ");
                    Console.SetCursorPosition(originColumn, originRow);
                    if (isPassword)
                    {
                        for(int i = 0;i<input.Length;i++)
                        {
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        Console.Write(input);
                    }
                }
                else if(keyInfo.Key == ConsoleKey.Backspace && input.Length == 0)
                {
                    continue;
                }
                else if(input.Length < maxLength && 
                    isCharacterOrNumber(keyInfo.KeyChar) &&
                    keyInfo.KeyChar != '\0')
                {
                    input += keyInfo.KeyChar;
                    if(isPassword)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                }
            }
            Console.CursorVisible = false;
            return input;
        }
    }
}