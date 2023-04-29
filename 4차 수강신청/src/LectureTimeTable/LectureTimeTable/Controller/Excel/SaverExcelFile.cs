using LectureTimeTable.LectureTimeTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using LectureTimeTable.LectureTimeTableView;
using System.Data.Common;
using LectureTimeTable.LectureTimeTableUtility;

namespace LectureTimeTable.LectureTimeTableController
{
    public class SaverExcelFile
    {
        TotalStorage totalStorage;
        public SaverExcelFile(TotalStorage totalStorage) 
        {
            this.totalStorage = totalStorage;
        }

        private int FindColumn(int lectureIndex, bool isFirst)
        {
            int column = 0;
            if (isFirst)
            {
                switch (totalStorage.enrolledLectures[lectureIndex].FirstDay)
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
            }
            else
            {
                switch (totalStorage.enrolledLectures[lectureIndex].LastDay)
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
            }
            return column;
        }

        private void SaveValueCell(int lectureIndex, int dayIndex, bool isFirst,  Excel.Worksheet worksheet)
        {
            int column = 0;
            int row = 0;

            column = FindColumn(lectureIndex, isFirst);

            for (int i = totalStorage.enrolledLectures[lectureIndex].LectureTimeAndDates[dayIndex].StartTime;
                i < totalStorage.enrolledLectures[lectureIndex].LectureTimeAndDates[dayIndex].EndTime; i += 30)
            {
                if (totalStorage.enrolledLectures[lectureIndex].LectureTimeAndDates[dayIndex].StartTime == i)
                {
                    row = 2 + ((i / 60) - 8) * 4;
                    if (i % 60 == 30) {
                        row += 2;
                    }
                    worksheet.Cells[row, column] = totalStorage.enrolledLectures[lectureIndex].LectureTitle;
                    worksheet.Cells[++row, column] = totalStorage.enrolledLectures[lectureIndex].LectureRoom;
                }
                else if (totalStorage.enrolledLectures[lectureIndex].LectureTimeAndDates[dayIndex].EndTime == i)
                {
                    row = 2 + ((i / 60) - 8) * 4;
                    if (i % 60 == 30)
                    {
                        row += 2;
                    }
                    worksheet.Cells[row, column] = totalStorage.enrolledLectures[lectureIndex].LectureTitle;
                    worksheet.Cells[++row, column] = totalStorage.enrolledLectures[lectureIndex].LectureRoom;
                }
                else
                {
                    row++;
                    worksheet.Cells[row, column] = totalStorage.enrolledLectures[lectureIndex].LectureTitle;
                    worksheet.Cells[++row, column] = totalStorage.enrolledLectures[lectureIndex].LectureRoom;
                }
            }
        }

        public void SaveTimeTableFile()
        {
            try
            {
                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = Path.Combine(desktopPath, "강의 시간표.xlsx");

                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = workbook.Worksheets.get_Item(1) as Excel.Worksheet;

                string[] time = {"08:00~08:30","08:30~09:00","09:00~09:30","09:30~10:00","10:00~10:30","10:30~11:00",
                "11:00~11:30","11:30~12:00","12:00~12:30","12:30~13:00","13:00~13:30","13:30~14:00","14:00~14:30",
                "14:30~15:00","15:00~15:30","15:30~16:00","16:00~16:30","16:30~17:00","17:00~17:30","17:30~18:00",
                "18:00~18:30","18:30~19:00","19:00~19:30","19:30~20:00","20:00~20:30"};
                for (int i = 0; i < time.Length; i++)
                {
                    worksheet.Cells[(i + 1) * 2, 1] = time[i];
                }

                for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
                {
                    int column = 0;
                    int row = 0;

                    if (totalStorage.enrolledLectures[i].DateAndTime == "")
                    {
                        worksheet.Cells[52, 2] = totalStorage.enrolledLectures[i].LectureTitle;
                        continue;
                    }
                    SaveValueCell(i, 0, ConstantNumber.IS_FIRST, worksheet);
                    if (totalStorage.enrolledLectures[i].LastDay != "" 
                    && totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 1)
                    {
                        SaveValueCell(i, 0, ConstantNumber.IS_LAST, worksheet);
                    }
                    else if(totalStorage.enrolledLectures[i].LastDay != ""
                    && totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 2)
                    {
                        SaveValueCell(i, 1, ConstantNumber.IS_LAST, worksheet);
                    }
                }
                worksheet.Columns.AutoFit();
                workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookDefault);
                workbook.Close(true);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}
