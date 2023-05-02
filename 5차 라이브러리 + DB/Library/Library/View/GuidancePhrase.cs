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
    }
}
