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
            UsingLibrary library = new UsingLibrary();
            Console.SetWindowSize(WindowRow, WindowColumn);
            library.MainLibrary();
            Console.Write(" 프로그램을 종료합니다 . . .");
        }
    }
}
