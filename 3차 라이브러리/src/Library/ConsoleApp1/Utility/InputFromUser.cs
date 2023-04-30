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
            int i = 0;

            int originColumn = Console.CursorLeft;
            int originRow = Console.CursorTop;

            ConsoleKeyInfo keyInfo;

            while (!isEnter)
            {
                keyInfo = Console.ReadKey(true);

                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                if (keyInfo.Key == ConsoleKey.Escape)       // esc가 입력되었다면
                {
                    return null;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)       // enter가 입력되었다면
                {
                    isEnter = true;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)       // backspace를 입력했고 문자열의 길이가 0이 아니라면
                {
                    input = input.Substring(0, input.Length - 1);       // 문자열의 가장 마지막 부분 삭제
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write("            ");      // 출력되어 있던 정보 삭제
                    Console.SetCursorPosition(originColumn, originRow);
                    Console.Write(input);       // 삭제된 정보를 다시 출력
                    i--;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length == 0)       // 문자열의 길이가 0이라면 backspace 값을 뱉어냄
                {
                    continue;
                }
                else if (input.Length <= maxLength && isCharacterOrNumber(keyInfo.KeyChar) && keyInfo.KeyChar != '\0')      // 입력 값이 maxLenght 이하이고 문자열이고 유효한 키를 입력했다면
                {
                    input += keyInfo.KeyChar;       // 문자열에 값 추가
                    i++;
                    if (ispassword)      // 비밀번호라면
                    {
                        Console.Write("*");         // 마스킹 처리
                    }
                    else
                    {
                        Console.Write(keyInfo.KeyChar);
                    }
                }
            }
            Console.CursorVisible = false;      // 다시 커서 안 보이게
            return input;
        }
    }
}
