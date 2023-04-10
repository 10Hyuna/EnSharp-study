using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LibraryStart
    {
        public static int WindowRow = 120;
        public static int WindowColumn = 80;
        static void Main(string[] args)
        { 
            UsingLibrary library = new UsingLibrary();
            DataController dataController = new DataController();
            SavedInformation saved = new SavedInformation(dataController);
            Console.SetWindowSize(WindowRow, WindowColumn);
            library.MainLibrary(dataController);
        }
    }
}
