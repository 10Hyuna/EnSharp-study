using Library.Controller.SelectorMode;
using Library.Model.DAO;
using Library.Utility;
using Library.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.DTO;

namespace Library
{
    public class LibraryStart
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Mode modeSelector = new Mode();
            modeSelector.SelectMode();
        }
    }
}
