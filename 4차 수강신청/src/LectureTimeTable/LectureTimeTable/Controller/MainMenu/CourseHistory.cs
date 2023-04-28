using LectureTimeTable.LectureTimeTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.MainMenu
{
    public class CourseHistory
    {
        TotalStorage totalStorage;
        SaverExcelFile saverExcelFile;

        public CourseHistory(TotalStorage totalStorage) 
        {
            this.totalStorage = totalStorage;
            saverExcelFile = new SaverExcelFile(totalStorage);
        }

        public void InquireCourseHistory()
        {
            saverExcelFile.SaveTimeTableFile();
        }
    }
}
