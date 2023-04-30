using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Library.Model;
using Library.View;
using System.Runtime.CompilerServices;

namespace Library.Utility
{
    class HandlingException
    {
        InputFromUser inputFromUser;
        ConstantNumber constantNumber;
        UI ui;

        public HandlingException(UI ui, InputFromUser inputFromUser)
        {
            this.ui = ui;
            this.inputFromUser = inputFromUser;
        }
        public bool CheckException(string message, Regex regex)     // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
        {

            if (regex.IsMatch(message))
            {
                return true;
            }

            return false;
        }

        public string IsValid(string regex, int ConsoleInputRow, int ConsoleInputColumn, int maxLength, bool isPassword)     // 문자열이 주어진 조건에 해당하는 값이 아닐 때 계속 입력하도록 하는 함수
        {
            Regex regexForm = new Regex(regex);
            bool isValidInput = false;
            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            string message = "";
            while (!isValidInput)
            {
                message = inputFromUser.InputStringFromUser(maxLength, isPassword, ConsoleInputRow, ConsoleInputColumn);
                if(message == null)
                {
                    isValidInput = true;
                }
                else if (CheckException(message, regexForm) == true || message == "")
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, ConsoleInputRow, ConsoleInputColumn);
                    continue;
                }
            }
            return message;     // 반복문에서 나왔을 때, 정규식에 해당하는 값이라는 의미이므로 문자열 반환
        }
    }
}
