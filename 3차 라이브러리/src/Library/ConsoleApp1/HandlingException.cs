using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library
{
    class HandlingException
    {
        public bool CheckException(string message, Regex regex)
        {

            if (regex.IsMatch(message))
            {
                return true;
            }

            return false;
        }

        public string IsValid(Regex regex, int ConsoleInputRow, int ConsoleInputColumn) 
        {

            bool isValidInput = false;
            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            string message = Console.ReadLine();
            while (!isValidInput)
            {
                if (CheckException(message, regex) == true)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                    Console.Write("주어진 조건에 맞는 값을 입력해 주세요.");
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                    message = Console.ReadLine();
                }
            }
            return message;
        }
    }
}
