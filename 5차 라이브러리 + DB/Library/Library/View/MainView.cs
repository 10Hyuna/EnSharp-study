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
            Console.WriteLine("\t#####  #####   ######   ##   ### ##  ##   ##   ###   ##");
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
            PrintBox(6);

            int column = 45;
            int row = 20;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("로 그 인");
            Console.SetCursorPosition(column - 8, row + 2);
            Console.WriteLine("ESC : 뒤로 가기  ENTER : 입력하기\n\n");
            Console.WriteLine("\t    {0} ID   :", objectName);
            Console.WriteLine("\t{0} PASSWORD :", objectName);
        }
    }
}
