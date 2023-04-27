using LectureTimeTable.LectureTimeTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable.LectureTimeTableController
{
    public class SaverExcelFile
    {
        TotalStorage totalStorage;
        public SaverExcelFile(TotalStorage totalStorage) 
        {
            this.totalStorage = totalStorage;
        }

        static Excel.Application excelApp = null;
        static Excel.Workbook workbook = null;
        static Excel.Worksheet worksheet = null;

        public void SaveTimeTableFile()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = Path.Combine(desktopPath, "Excel.xlsx");

                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet= workbook.Worksheets.get_Item(1) as Excel.Worksheet;

                worksheet.Cells[1, 2] = "09:00~09:30";
                worksheet.Cells[1, 4] = "09:30~10:00";
                worksheet.Cells[1, 6] = "10:00~10:30";
                worksheet.Cells[1, 8] = "10:30~11:00";
                worksheet.Cells[1, 10] = "11:00~11:30";
                worksheet.Cells[1, 12] = "11:30~12:00";
                worksheet.Cells[1, 14] = "12:00~12:30";
                worksheet.Cells[1, 16] = "12:30~13:00";
                worksheet.Cells[1, 18] = "13:00~13:30";
                worksheet.Cells[1, 20] = "13:30~14:00";
                worksheet.Cells[1, 22] = "14:00~14:30";
                worksheet.Cells[1, 24] = "14:30~15:00";
                worksheet.Cells[1, 26] = "15:00~15:30";
                worksheet.Cells[1, 28] = "15:30~16:00";
                worksheet.Cells[1, 30] = "16:00~16:30";
                worksheet.Cells[1, 32] = "16:30~17:00";
                worksheet.Cells[1, 34] = "17:00~17:30";
                worksheet.Cells[1, 36] = "17:30~18:00";
                worksheet.Cells[1, 38] = "18:00~18:30";
                worksheet.Cells[1, 40] = "18:30~19:00";
                worksheet.Cells[1, 42] = "19;00~19:30";
                worksheet.Cells[1, 44] = "19:30~20:00";
                worksheet.Cells[1, 46] = "20;00~20:30";
                worksheet.Cells[1, 48] = "20:30~21:00";

                for(int i = 0; i < totalStorage.enrolledLectures.Count; i++)
                {
                    int column;
                    int row;
                    int initiativeHour;
                    int initiativeMinute;

                    switch (totalStorage.enrolledLectures[i].FirstDay)
                    {
                        case "월":
                            column = 2; break;
                        case "화":
                            column = 3; break;
                        case "수":
                            column = 4; break;
                        case "목":
                            column = 5; break;
                        case "금":
                            column = 6; break;
                    }
                    initiativeHour = totalStorage.enrolledLectures[i].LectureTimeAndDates[0].StartTime / 60;
                    initiativeMinute = totalStorage.enrolledLectures[i].LectureTimeAndDates[0].StartTime % 60;
                }
                workbook.SaveAs(Filename: @"c:\강의 시간표.xlsx");

            }
        }
    }
}
