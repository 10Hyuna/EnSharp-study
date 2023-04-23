using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableController;
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableUtility;

namespace LectureTimeTable.LectureTimeTableController
{
    public class ExcelLoader
    {
        TotalStorage totalStorage;
        ExceptionHandler exceptionHandler;

        public ExcelLoader(ExceptionHandler exceptionHandler, TotalStorage totalStorage)
        {
            this.exceptionHandler = exceptionHandler;
            this.totalStorage = totalStorage;
        }

        public void LoadExcelFile()
        {
            int id;
            string major;
            string courseNumber;
            string lectureTitle;
            string classNumber;
            string completeType;
            string grade;
            string credit;
            string dateAndTime;
            string lectureRoom;
            string professor;
            string language;

            try
            {
                // Excel Application 객체 생성
                Excel.Application application = new Excel.Application();

                // Workbook 객체 생성 및 파일 오픈 (바탕화면에 있는 excelStudy.xlsx 가져옴)
                Excel.Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표.xlsx");

                // sheets에 읽어온 엑셀값을 넣기 (한 workbook 내의 모든 sheet 가져옴)
                Excel.Sheets sheets = workbook.Sheets;

                // 특정 sheet의 값 가져오기
                Excel.Worksheet worksheet = sheets["Sheet1"] as Excel.Worksheet;

                // 범위 설정 (좌측 상단, 우측 하단)
                Excel.Range cellRange = worksheet.get_Range("A2", "L185") as Excel.Range;

                // 설정한 범위만큼 데이터 담기 (Value2 -셀의 기본 값 제공)
                Array data = (Array)cellRange.Cells.Value2;

                for (int i = 1; i < 185; i++)
                {
                    id = int.Parse(exceptionHandler.CheckNull(data.GetValue(i, 1)));
                    major = exceptionHandler.CheckNull(data.GetValue(i, 2));
                    courseNumber = exceptionHandler.CheckNull(data.GetValue(i, 3));
                    classNumber = exceptionHandler.CheckNull(data.GetValue(i, 4));
                    lectureTitle = exceptionHandler.CheckNull(data.GetValue(i, 5));
                    completeType = exceptionHandler.CheckNull(data.GetValue(i, 6));
                    grade = exceptionHandler.CheckNull(data.GetValue(i, 7));
                    credit = exceptionHandler.CheckNull(data.GetValue(i, 8));
                    dateAndTime = exceptionHandler.CheckNull(data.GetValue(i, 9));
                    lectureRoom = exceptionHandler.CheckNull(data.GetValue(i, 10));
                    professor = exceptionHandler.CheckNull(data.GetValue(i, 11));
                    language = exceptionHandler.CheckNull(data.GetValue(i, 12));

                    totalStorage.lecture.Add(new Lecture(id, major, courseNumber, classNumber, lectureTitle, completeType, grade, credit, dateAndTime, lectureRoom, professor, language));
                }

                // 모든 워크북 닫기
                application.Workbooks.Close();

                // application 종료
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
