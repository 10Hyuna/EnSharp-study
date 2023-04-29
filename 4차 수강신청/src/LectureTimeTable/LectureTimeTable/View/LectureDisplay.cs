using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableController.Option;
using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableModel.VO;
using LectureTimeTable.LectureTimeTableUtility;

namespace LectureTimeTable.LectureTimeTableView
{
    public class LectureDisplay
    {
        private ExceptionHandler exceptionHandler;

        public LectureDisplay(ExceptionHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }
        
        public void PrintSearchLectureUI()
        {
            string[] lectureInformation = new string[] { "NO", "개설학과전공", "학수번호", "분반", "교과목명", "이수구분", "학년", "학점", "요일 및 강의시간", "강의실", "메인교수명", "강의언어" };
            Console.SetWindowSize(194, 40);
            Console.Clear();
            Console.WriteLine("===============================================================================================================================================================================================");
            Console.Write(lectureInformation[0].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[0], 4)));
            Console.Write(lectureInformation[1].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[1], 24)));
            Console.Write(lectureInformation[2].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[2], 10)));
            Console.Write(lectureInformation[3].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[3], 6)));
            Console.Write(lectureInformation[4].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[4], 36)));
            Console.Write(lectureInformation[5].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[5], 14)));
            Console.Write(lectureInformation[6].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[6], 6)));
            Console.Write(lectureInformation[7].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[7], 6)));
            Console.Write(lectureInformation[8].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[8], 35)));
            Console.Write(lectureInformation[9].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[9], 14)));
            Console.Write(lectureInformation[10].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[10], 28)));
            Console.Write(lectureInformation[11].PadRight(exceptionHandler.CalculateRadRightSize(lectureInformation[11], 14)));
            Console.Write("\n===============================================================================================================================================================================================\n");
        }

        public void PrintSearchLecture(LectureVO lectureList)
        {
            Console.Write(lectureList.Id.ToString().PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Id.ToString(), 4)));
            Console.Write(lectureList.Major.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Major, 24)));
            Console.Write(lectureList.CourseNumber.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.CourseNumber, 10)));
            Console.Write(lectureList.ClassNumber.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.ClassNumber, 6)));
            Console.Write(lectureList.LectureTitle.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.LectureTitle, 36)));
            Console.Write(lectureList.CompleteType.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.CompleteType, 14)));
            Console.Write(lectureList.Grade.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Grade, 6)));
            Console.Write(lectureList.Credit.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Credit, 6)));
            Console.Write(lectureList.DateAndTime.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.DateAndTime, 35)));
            Console.Write(lectureList.LectureRoom.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.LectureRoom, 14)));
            Console.Write(lectureList.Professor.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Professor, 28)));
            Console.Write(lectureList.Language.PadRight(exceptionHandler.CalculateRadRightSize(lectureList.Language, 14)));
            Console.WriteLine();
        }

        public void PrintLine()
        {
            Console.Write("\n===============================================================================================================================================================================================\n");
        }

        public void PrintCredit(USER user)
        {
            Console.Write(" 등록 가능 학점 :  {0}      담은 학점 : {1}      ", user.AbleInterestedCredit, user.EnrolledInterestedCredit);
        }

        public void PrintEnrollCredit(USER user)
        {
            Console.Write(" 등록 가능 학점 :  {0}      담은 학점 : {1}      ", user.AbleEnrolledCredit, user.EnrolledCredit);
        }

        public void PrintLectureNo()
        {
            Console.Write("담을 과목 NO : ");
        }
        public void PrintDeleteNo()
        {
            Console.Write("삭제할 과목 NO : ");
        }

        public void PrintTimeTable()
        {
            Console.SetWindowSize(200, 55);
            Console.Write("=================================================================================================시간표========================================================================================\n");
            Console.Write("뒤로가기 : ESC=================================================================================================================================================================================\n");
            string[] dayOfWeek = { " ", "월", "화", "수", "목", "금" };
            int column = Console.CursorLeft;
            int row = Console.CursorTop + 2;
            for(int i = 0; i < dayOfWeek.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write(dayOfWeek[i].PadRight(exceptionHandler.CalculateRadRightSize(dayOfWeek[i], 20)));
                }
                else
                {
                    Console.Write(dayOfWeek[i].PadRight(exceptionHandler.CalculateRadRightSize(dayOfWeek[i], 36)));
                }
            }

            for (int i = 510; i < 1230; i += 30)
            {
                Console.SetCursorPosition(column, row);
                Console.Write(String.Format("{0:00}", (i / 60)));
                Console.Write(":");
                Console.Write(String.Format("{0:00}", (i % 60)));
                Console.Write("-");
                Console.Write(String.Format("{0:00}", ((i + 30) / 60)));
                Console.Write(":");
                Console.Write(String.Format("{0:00}", ((i + 30) % 60)));
                row += 2;
            }
        }
        public void PrintLecture(string lecture, string lectureRoom)
        {
            int column = Console.CursorLeft;
            Console.Write(lecture.PadRight(exceptionHandler.CalculateRadRightSize(lecture, 36)));
            Console.SetCursorPosition(column, Console.CursorTop + 1);
            Console.Write(lectureRoom.PadRight(exceptionHandler.CalculateRadRightSize(lectureRoom, 36)));
        }
    }
}
