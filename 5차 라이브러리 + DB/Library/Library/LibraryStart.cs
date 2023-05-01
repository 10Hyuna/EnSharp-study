using Library.Controller;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryStart
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ModeSelector modeSelector = new ModeSelector();
            modeSelector.SelectMode();
        }
    }
}
