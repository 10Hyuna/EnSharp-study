using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.View;

namespace Library.Utility
{
    class InputFromUser
    {
        HandlingException handlingException;
        public InputFromUser() { }
        public InputFromUser(HandlingException handlingException)
        {
            this.handlingException = handlingException;
        }
        static void ConsoleCancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }
        public int EnterEsc(string input)
        {
            if (input == null)      // esc가 입력되었다면
            {
                return ConstantNumber.EXIT;     // esc 입력을 표시하는 값 반환
            }
            return ConstantNumber.SUCCESS;
        }

        private bool isCharacterOrNumber(char input)        // 문자에 해당하는 값이 입력되었다면
        {
            if (input >= 'A' && input <= 'Z' || input >= 'a' && input <= 'z' || input >= '0' || input <= '9')
                return true;
            return false;
        }

        public int SelectKey(int endMenu, int selectedMenu)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancelKeyPress);

            ConsoleKeyInfo keyInfo;

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenu;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenu++;
                if (selectedMenu > endMenu)
                {
                    selectedMenu = 0;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                return 10;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return 11;
            }
            else
            {
                return -1;
            }
        }

        public string InputStringFromUser(int maxLength, bool ispassword, int consoleInputRow, int consoleInputColumn)
        {
            Console.CursorVisible = true;       // 커서 보이게 
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleCancelKeyPress);

            bool isEnter = false;
            string input = "";

            int originColumn = Console.CursorLeft;
            int originRow = Console.CursorTop;

            ConsoleKeyInfo keyInfo;

            while (!isEnter)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = false;
                    return "ESC";
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {   // 백스페이스를 눌렀을 경우
                    input = input.Substring(0, input.Length - 1);
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                         ");
                    Console.SetCursorPosition(originColumn, originRow);
                    if (ispassword)
                    {
                        for (int i = 0; i < input.Length; i++)
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
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length == 0)
                {
                    continue;
                }
                else if (input.Length < maxLength &&
                    isCharacterOrNumber(keyInfo.KeyChar) &&
                    keyInfo.KeyChar != '\0')
                {
                    input += keyInfo.KeyChar;
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("                         ");
                    Console.SetCursorPosition(originColumn, originRow);
                    if (ispassword)
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
            Console.CursorVisible = false;      // 다시 커서 안 보이게
            return input;
        }
    }
}
