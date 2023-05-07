using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class ExceptionHandler
    {
        private static ExceptionHandler exceptionHandler;
        private InputFromUser inputFromUser;
        private GuidancePhrase guidancePhrase;

        private ExceptionHandler() 
        {
            inputFromUser = InputFromUser.GetInputFromUser();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
        }

        public static ExceptionHandler GetExceptionHandler()
        {
            if(exceptionHandler == null)
            {
                exceptionHandler = new ExceptionHandler();
            }
            return exceptionHandler;
        }

        public bool IsStringAllNumber(string input)      // 입력받은 모든 값이 다 숫자라면
        {
            bool isNumber = true;
            Regex regex = new Regex(Constant.NUMBER);
            char splitString;
            for (int i = 0; i < input.Length; i++)
            {
                splitString = input[i];
                isNumber = IsCheckException(splitString.ToString(), regex);
                if (isNumber == false)
                {
                    break;
                }
            }
            return isNumber;
        }

        private bool IsCheckException(string message, Regex regex)     // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
        {
            if (regex.IsMatch(message))
            {
                return true;
            }
            return false;
        }

        public string IsValidInput(string regex, int consoleColumn, int consoleRow, int maxLength, bool isPassword)
        {
            string message = "";
            Regex regexForm = new Regex(regex);
            bool isValidInput = false;

            while (!isValidInput)
            {
                message = InputFromUser.GetInputFromUser().InputStringFromUser(maxLength, isPassword, consoleColumn, consoleRow);
                if (message == Constant.ESC_STRING)
                {
                    isValidInput = true;
                }
                else if (IsCheckException(message, regexForm) == true
                    || message == "")
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, consoleColumn, consoleRow);
                    continue;
                }
            }
            return message;
        }

        public string BlockEmptyString(string regex, int consoleColumn, int consoleRow, int maxLength, bool isPassword)
        {
            bool isValidInput = true;
            string inputMessage = "";

            while(isValidInput)
            {
                isValidInput = false;
                inputMessage = IsValidInput(regex, consoleColumn, consoleRow, maxLength, isPassword);
                if (inputMessage == "")
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, consoleColumn, consoleRow);
                    isValidInput = true;
                    continue;
                }
            }
            return inputMessage;
        }
    }
}
