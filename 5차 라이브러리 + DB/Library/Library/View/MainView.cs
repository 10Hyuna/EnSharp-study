using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class MainView
    {
        private static MainView mainView;

        private MainView() { }

        public static MainView SetMainView()
        {
            if (mainView == null)
            {
                mainView = new MainView();
            }
            return mainView;
        }

        public void PrintMain()
        {
            Console.WriteLine("\t     ##     #####   ######    #####    ######   #####   ##   ##");
            Console.WriteLine("\t    ##       ##    ###  ##   ##  ##  ###  ##   ##  ##   ## ##");
            Console.WriteLine("\t   ##       ##    ######    ##  ###  ##  ##   ##  ###    ###");
            Console.WriteLine("\t  ##       ##    ###  ##   ######  #######   ######     ##");
            Console.WriteLine("\t ##       ##    ##   ##  ##  ##   ##  ##   ##  ##     ##");
            Console.WriteLine("\t#####  #####   ######   ##   ### ##  ##   ##   ###   ##");
        }

        public void PrintBox(int line)
        {
            Console.WriteLine("\t┌─────────────────────────────────────┐");
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("\t│                                        │");
            }
            Console.WriteLine("\t└─────────────────────────────────────┘");
        }
    }
}
