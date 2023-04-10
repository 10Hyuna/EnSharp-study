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
        public bool CheckException(string message, Regex regex)     // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
        {

            if (regex.IsMatch(message))
            {
                return true;
            }

            return false;
        }

        public string IsValid(Regex regex, int ConsoleInputRow, int ConsoleInputColumn)     // 문자열이 주어진 조건에 해당하는 값이 아닐 때 계속 입력하도록 하는 함수
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
            return message;     // 반복문에서 나왔을 때, 정규식에 해당하는 값이라는 의미이므로 문자열 반환
        }
    }
}
