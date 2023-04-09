using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    class MemberFunction
    {
        HandlingException handlingException = new HandlingException();
        public void SignUpMember(MemberData memberData)
        {
            const int ConsoleInputRow = 71;
            const int ConsoleInputColumn = 22;

            bool isValidInput = false;

            Regex IDCheck = new Regex(@"^[0-9a-zA-Z]{8,20}");
            string ID;
            while (!isValidInput)
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                ID = Console.ReadLine();
                if(handlingException.CheckException(ID, IDCheck)==true)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                    Console.Write("주어진 조건에 맞는 값을 입력해 주세요.");
                }
            }
        }
    }
}
