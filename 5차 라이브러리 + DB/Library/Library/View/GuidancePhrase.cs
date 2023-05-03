using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class GuidancePhrase
    {
        private static GuidancePhrase guidancePhrase;

        private GuidancePhrase() { }

        public static GuidancePhrase SetGuidancePhrase()
        {
            if(guidancePhrase == null)
            {
                guidancePhrase = new GuidancePhrase();
            }
            return guidancePhrase;
        }

        public static void PrintMenu(string menu)
        {
            Console.Write(menu);
        }

        public static void PrintException(int condition, int column, int row)
        {

        }

        public static void PrintEsc()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ResetColor();
        }

        public static void PrintEnter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기 / 다시 선택");
            Console.ResetColor();
        }
    }
}
