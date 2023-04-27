using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableUtility
{
    public class InputFromUser
    {
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }
        ConsoleKeyInfo keyInfo;
        private bool isCharacterOrNumber(char input)        // 문자에 해당하는 값이 입력되었다면
        {
            if (input >= 'A' && input <= 'Z' || input >= 'a' && input <= 'z' || input >= '0' || input <= '9')
                return true;
            return false;
        }

        public int SelectMenuIndex(int endMenuIndex, int selectedMenu)
        {   // 메뉴는 위아래로 움직임            

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

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
                selectedMenu = ConstantNumber.FAIL;
            }
            return selectedMenu;
        }
        
        public int SelectOptionIndex(int endMenuIndex, int selectedMenu)
        {   // 옵션은 위아래로 움직임

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenuIndex;
                }
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                selectedMenu++;
                if (selectedMenu > endMenuIndex)
                {
                    selectedMenu = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                selectedMenu = ConstantNumber.ENTER;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                selectedMenu = ConstantNumber.EXIT;
            }
            else
            {
                selectedMenu = ConstantNumber.FAIL;
            }
            return selectedMenu;
        }

        public string InputStringFromUser(int maxLength, bool isPassword, bool isId, int consoleColumn, int consoleRow)
        {

            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            Console.CursorVisible = true;
            bool isEnter = false;
            string input = "";

            int originColumn = Console.CursorLeft + 13;
            int originRow = Console.CursorTop;
            Console.SetCursorPosition(originColumn, originRow);
            Console.Write("                ");
            // 이미 출력되어 있던 문자열이 있을 경우를 대비해 입력할 위치를 지워 줌
            Console.SetCursorPosition(originColumn + input.Length, originRow);

            while (!isEnter)
            {
                keyInfo = Console.ReadKey(true);

                if(keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return ConstantNumber.ESC;
                }
                else if(keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.UpArrow && (isPassword || isId))
                {
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                ");
                    // 입력하던 것을 지우고 탈출
                    input = ConstantNumber.UP;
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.DownArrow && (isId || isPassword))
                {
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                ");
                    // 위아래를 눌렀을 경우 입력하던 것을 지우고 탈출
                    input = ConstantNumber.DOWN;
                    isEnter = true;
                }
                else if(keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {   // 백스페이스를 눌렀을 경우
                    input = input.Substring(0, input.Length - 1);
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                         ");
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
                        // 한글을 입력했을 경우, 바이트 크기 차이 탓에 글씨가 잘리는 것을
                        // 방지하기 위하여 문자열 전체를 출력
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
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                         ");
                    Console.SetCursorPosition(originColumn, originRow);
                    if (isPassword)
                    {
                        for (int i = 0; i < input.Length; i++)
                        {
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        Console.Write(input);
                    }
                }
            }
            Console.CursorVisible = false;
            return input;
        }
    }
}