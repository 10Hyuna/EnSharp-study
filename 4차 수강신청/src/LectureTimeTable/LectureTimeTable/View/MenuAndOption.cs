using LectureTimeTable.LectureTimeTableUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableView
{
    public class MenuAndOption
    {
        public void PrintMenu(string menu, int length)
        {
            Console.WriteLine(menu.PadRight(length));
        }
    }
}
