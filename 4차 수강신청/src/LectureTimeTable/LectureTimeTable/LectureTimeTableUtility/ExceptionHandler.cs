using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableView;

namespace LectureTimeTable.LectureTimeTableUtility
{
    public class ExceptionHandler
    {
        InputFromUser inputFromUser;
        GuidancePhrase guidancePhrase;

        public ExceptionHandler(InputFromUser inputFromUser, GuidancePhrase guidancePhrase)
        {
            this.inputFromUser = inputFromUser;
            this.guidancePhrase = guidancePhrase;
        }

        public bool CheckException(string message, Regex regex)     // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
        {

            if (regex.IsMatch(message))
            {
                return true;
            }

            return false;
        }

        public string IsValid(string regex, int consoleColumn, int consoleRow, int maxLength, bool isPassword, bool isId)
        {
            string message = "";
            Regex regexForm = new Regex(regex);
            bool isValidInput = false;
            Console.SetCursorPosition(consoleColumn, consoleRow);

            while (!isValidInput)
            {
                message = inputFromUser.InputStringFromUser(maxLength, isPassword, isId, consoleColumn, consoleRow);
                if (message == ConstantNumber.ESC 
                    || message == ConstantNumber.UP
                    || message == ConstantNumber.DOWN)
                {
                    isValidInput = true;
                }
                else if (CheckException(message, regexForm) == true
                    || message == "")
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.PrintException(ConstantNumber.NOT_MATCH_CONDITION, consoleColumn, consoleRow);
                    continue;
                }
            }
            return message;
        }
    }
}
