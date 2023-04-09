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
    }
}
