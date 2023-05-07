using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InputFromUser
    {

        static ConsoleKeyInfo keyInfo;
        private static InputFromUser inputFromUser;

        private InputFromUser() { }

        public static InputFromUser GetInputFromUser()
        {
            if(inputFromUser == null)
            {
                inputFromUser = new InputFromUser();
            }
            return inputFromUser;
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }

        private bool IsCharacterOrNumber(char input)        // 문자에 해당하는 값이 입력되었다면
        {
            if ((input >= 'A' && input <= 'Z') || (input >= 'a' && input <= 'z') || (input >= '0' || input <= '9'))
                return true;
            return false;
        }

        public bool EnteredESC()     // ESC 입력
        {
            bool isESC = false;

            while (!isESC)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isESC = true;
                }
            }
            return isESC;
        }

        public string InputEnterESC()        // ESC나 ENTER 입력
        {
            keyInfo = Console.ReadKey(true);

            string returnValue = "";
            bool isBreak = false;

            while (!isBreak)
            {
                switch (keyInfo.Key)
                {   
                    case ConsoleKey.Enter:
                        isBreak = true;
                        returnValue = Constant.ENTER_STRING;
                        break;
                    case ConsoleKey.Escape:
                        isBreak = true;
                        returnValue = Constant.ESC_STRING;
                        break;
                }
            }
            return returnValue;
        }

        public int SelectMenuIndex(int endMenuIndex, int selectedMenu)
        {   // 메뉴는 위아래로 움직임            

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenuIndex;
                }
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenu++;
                if (selectedMenu > endMenuIndex)
                {
                    selectedMenu = 0;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                selectedMenu = Constant.ENTER_INT;
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                selectedMenu = Constant.EXIT_INT;
            }
            else
            {
                selectedMenu = Constant.FAIL_INT;
            }
            return selectedMenu;
        }

        public string InputStringFromUser(int maxLength, bool isPassword, int consoleColumn, int consoleRow)
        {
            Console.CursorVisible = true;
            bool isEnter = true;
            string input = "";

            int originColumn = Console.CursorLeft + 13;
            int originRow = Console.CursorTop;
            Console.SetCursorPosition(consoleColumn, consoleRow);
            Console.Write("                ");
            // 이미 출력되어 있던 문자열이 있을 경우를 대비해 입력할 위치를 지워 줌
            Console.SetCursorPosition(consoleColumn, consoleRow);

            while (isEnter)
            {
                keyInfo = Console.ReadKey(true);

               switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Console.CursorVisible = false;
                        return Constant.ESC_STRING;
                    case ConsoleKey.Enter:
                        isEnter = false;
                        break;
                    case ConsoleKey.Backspace:
                        input = InputBackspace(input, consoleColumn, consoleRow, isPassword);
                        break;
                    default:
                        input = inputKeyChar(input, maxLength, consoleColumn, consoleRow, isPassword);
                        break;
                }

            }
            Console.CursorVisible = false;
            return input;
        }

        private string InputBackspace(string input, int column, int row, bool isPassword)
        {       // 백스페이스를 입력받았을 경우
            if(input.Length == 0)
            {
                return "";
            }

            input = input.Substring(0, input.Length - 1);
            Console.SetCursorPosition(column, row);
            Console.Write("                       ");
            Console.SetCursorPosition(column, row);
            if (isPassword)
            {
                for(int i = 0; i < input.Length; i++)
                {
                    Console.Write("*");
                }
            }
            else
            {
                Console.Write(input);
            }

            return input;
        }

        private string inputKeyChar(string input, int maxLength, int column, int row, bool isPassword)
        {       // 유효한 값이 입력되었을 경우
            if(input.Length < maxLength && 
                IsCharacterOrNumber(keyInfo.KeyChar) &&
                keyInfo.KeyChar != '\0')
            {
                input += keyInfo.KeyChar;
                Console.SetCursorPosition(column, row);
                Console.Write("                       ");
                Console.SetCursorPosition(column, row);
                if (isPassword)
                {
                    for(int i=0;i<input.Length;i++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write(input);
                }
            }
            return input;
        }
    }
}
