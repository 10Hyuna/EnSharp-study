using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class HandingException
    {
        public bool DealWithException(string input)     // 예외 처리 함수
        {
            if (int.TryParse(input, out int result) == false)       // 입력 값이 숫자로 변환되지 않을 때
            {
                return false;
            }

            else        // 숫자로 변환 가능
            {
                return true;
            }
        }
    }
}
