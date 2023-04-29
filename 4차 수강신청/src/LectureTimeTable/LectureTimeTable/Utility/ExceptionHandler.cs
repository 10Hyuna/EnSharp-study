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

        public int CalculateRadRightSize(string message, int count)
        {   // 문자가 한글에 해당하는지 확인하고, 한글이 몇 개 나오는지 확인 후, 맞추려는 PadRight 개수 빼기 한글의 개수만큼 공백으로 채우는 계산
            int koreanCount = 0;
            string korean;

            Regex regex = new Regex(ConstantNumber.KOREAN);

            for (int i = 0; i < message.Length; i++)
            {
                korean = Convert.ToString(message[i]);
                if(IsCheckException(korean, regex))
                {
                    koreanCount++;
                }
            }

            return (count - koreanCount);
        }

        public bool IsCheckException(string message, Regex regex)     // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
        {
            if (regex.IsMatch(message))
            {
                return true;
            }
            return false;
        }

        public string IsValidInput(string regex, int consoleColumn, int consoleRow, int maxLength, bool isPassword, bool isId)
        {   // 의미 있게 표현
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
                else if (IsCheckException(message, regexForm) == true
                    || message == "")
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, consoleColumn, consoleRow);
                    continue;
                }
            }
            return message;
        }

        public string CheckNull(object message)
        {
            if(message == null)
            {
                message = "";
            }

            return message.ToString();
        }

        public bool IsStringAllNumber(string input)
        {
            bool isNumber = true;
            Regex regex = new Regex(ConstantNumber.NUMBER);
            char splitString;
            for(int i = 0; i < input.Length; i++)
            {
                splitString = input[i];
                isNumber = IsCheckException(splitString.ToString(), regex);
                if(isNumber == false)
                {
                    break;
                }
            }
            return isNumber;
        }
    }
}
