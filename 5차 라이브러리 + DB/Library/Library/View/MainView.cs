using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class MainView
    {
        private static MainView mainView = null;

        private MainView() { }

        public static MainView SetMainView()
        {
            if(mainView == null)
            {
                mainView = new MainView();
            }
            return mainView;
        }

        public static void PrintMain()
        {
            Console.WriteLine("\n\t     ##     #####   ######    #####    ######   #####   ##   ##");
            Console.WriteLine("\t    ##       ##    ###  ##   ##  ##  ###  ##   ##  ##   ## ##");
            Console.WriteLine("\t   ##       ##    ######    ##  ###  ##  ##   ##  ###    ###");
            Console.WriteLine("\t  ##       ##    ###  ##   ######  #######   ######     ##");
            Console.WriteLine("\t ##       ##    ##   ##  ##  ##   ##  ##   ##  ##     ##");
            Console.WriteLine("\t#####  #####   ######   ##   ### ##  ##   ##   ###   ##\n");
        }

        public static void PrintBox(int line)
        {
            Console.WriteLine("\t\t┌─────────────────────────────────────┐");
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("\t\t│                                     │");
            }
            Console.WriteLine("\t\t└─────────────────────────────────────┘");
        }

        public static void PrintLoginUI(string objectName)
        {
            PrintMain();
            PrintBox(4);

            int column = 32;
            int row = 10;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("로 그 인");
            Console.SetCursorPosition(column - 12, row + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 뒤로 가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ENTER : 입력하기\n\n");
            Console.ResetColor();
            Console.WriteLine("\t    {0} ID   :", objectName);
            Console.WriteLine("\t{0} PASSWORD :", objectName);
        }
    }
}
