using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class HandingException
    {
        public bool DealWithException(string input)
        {
            if (int.TryParse(input, out int result) == false)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
