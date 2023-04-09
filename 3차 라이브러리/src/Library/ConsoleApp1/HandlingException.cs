using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class HandlingException
    {
        private bool IsNumber(string message)
        {
            foreach(char c in message)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public bool IsLong(string message)
        {
            long number = 0;
            bool isSuccess;
            foreach(char c in message)
            {
                long forCheckSuccess = c - '0';
                if (number > (long.MaxValue - forCheckSuccess) / 10)
                    return false;
            }
            return true;
        }
    }
}
