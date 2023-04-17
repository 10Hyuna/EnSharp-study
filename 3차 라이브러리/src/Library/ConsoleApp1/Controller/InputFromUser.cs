using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;
using Library.View;

namespace Library.Controller
{
    class InputFromUser
    {
        RegexStorage regex;
        HandlingException handlingException;

        public InputFromUser() { }
        public InputFromUser(RegexStorage regex, HandlingException handlingException) 
        {
            this.regex = regex;
            this.handlingException = handlingException;
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }
        public int EnterEsc(string input)
        {
            if (input == null)
            {
                return ConstantNumber.EXIT;
            }
            return ConstantNumber.SUCCESS;
        }

        private bool isCharacterOrNumber(char input)
        {
            if (input >= 'A' && input <= 'Z' || input >= 'a' && input <= 'z' || input >= '0' || input <= '9')
                return true;
            return false;
        }

        public int SelectKey(int endMenu, int selectedMenu)
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

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
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            bool isEnter = false;
            string input = "";
            int i = 0;

            ConsoleKeyInfo keyInfo;

            while (!isEnter)
            {
                Console.SetCursorPosition(consoleInputRow + i, consoleInputColumn);
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return null;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnter = true;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.SetCursorPosition(consoleInputRow + i - 1, consoleInputColumn);
                    Console.Write(" ");
                    i--;
                }
                else if(keyInfo.Key == ConsoleKey.Backspace && input.Length == 0)
                {
                    continue;
                }
                else if (input.Length <= maxLength && isCharacterOrNumber(keyInfo.KeyChar) && keyInfo.KeyChar != '\0')
                {
                    input += keyInfo.KeyChar;
                    i++;
                    if(ispassword)
                    {
                        Console.WriteLine("*");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                        Console.Write(input);
                    }
                }
            }
            return input;
        }
    }
}
