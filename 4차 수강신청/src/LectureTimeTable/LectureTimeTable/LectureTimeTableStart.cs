using LectureTimeTable.LectureTimeTableController;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableModel;

namespace LectureTimeTable.LectureTimeTable
{
    class LectureTimeTableStart
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            LectureTimeTablePrestart lectureTimeTablePrestart = new LectureTimeTablePrestart();
            lectureTimeTablePrestart.Start();
        }
    }
}
