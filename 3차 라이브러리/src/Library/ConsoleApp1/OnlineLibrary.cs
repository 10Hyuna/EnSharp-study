using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class OnlineLibrary
    {
        public static int WindowRow = 120;
        public static int WindowColumn = 40;
        static void Main(string[] args)
        {
            Console.SetWindowSize(WindowRow, WindowColumn);
        }
    }
}
