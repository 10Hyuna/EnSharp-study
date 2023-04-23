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
        
        public void PrintSearchLectureUI(List<Lecture> lectureList, SearchResults searchResults)
        {
            string[] lectureInformation = new string[] { "NO", "개설학과전공", "학수번호", "분반", "교과목명", "이수구분", "학년", "학점", "요일 및 강의시간", "강의실", "메인교수명", "강의언어" };
            Console.SetWindowSize(194, 40);
            Console.Clear();
            Console.WriteLine("===============================================================================================================================================================================================");
            Console.Write(lectureInformation[0].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[0], 4)));
            Console.Write(lectureInformation[1].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[1], 24)));
            Console.Write(lectureInformation[2].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[2], 10)));
            Console.Write(lectureInformation[3].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[3], 6)));
            Console.Write(lectureInformation[4].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[4], 36)));
            Console.Write(lectureInformation[5].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[5], 14)));
            Console.Write(lectureInformation[6].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[6], 6)));
            Console.Write(lectureInformation[7].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[7], 6)));
            Console.Write(lectureInformation[8].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[8], 35)));
            Console.Write(lectureInformation[9].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[9], 14)));
            Console.Write(lectureInformation[10].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[10], 28)));
            Console.Write(lectureInformation[11].PadRight(exceptionHandler.calculateRadRightSize(lectureInformation[11], 14)));
            Console.Write("\n===============================================================================================================================================================================================");
        }

        public void PrintSearchLecture(Lecture lectureList)
        {
            Console.Write(lectureList.Id.ToString().PadRight(exceptionHandler.calculateRadRightSize(lectureList.Id.ToString(), 4)));
            Console.Write(lectureList.Major.PadRight(exceptionHandler.calculateRadRightSize(lectureList.Major, 24)));
            Console.Write(lectureList.CourseNumber.PadRight(exceptionHandler.calculateRadRightSize(lectureList.CourseNumber, 10)));
            Console.Write(lectureList.ClassNumber.PadRight(exceptionHandler.calculateRadRightSize(lectureList.ClassNumber, 6)));
            Console.Write(lectureList.LectureTitle.PadRight(exceptionHandler.calculateRadRightSize(lectureList.LectureTitle, 36)));
            Console.Write(lectureList.CompleteType.PadRight(exceptionHandler.calculateRadRightSize(lectureList.CompleteType, 14)));
            Console.Write(lectureList.Grade.PadRight(exceptionHandler.calculateRadRightSize(lectureList.Grade, 6)));
            Console.Write(lectureList.Credit.PadRight(exceptionHandler.calculateRadRightSize(lectureList.Credit, 6)));
            Console.Write(lectureList.DateAndTime.PadRight(exceptionHandler.calculateRadRightSize(lectureList.DateAndTime, 35)));
            Console.Write(lectureList.LectureRoom.PadRight(exceptionHandler.calculateRadRightSize(lectureList.LectureRoom, 14)));
            Console.Write(lectureList.Professor.PadRight(exceptionHandler.calculateRadRightSize(lectureList.Professor, 28)));
            Console.Write(lectureList.Language.PadRight(exceptionHandler.calculateRadRightSize(lectureList.Language, 14)));
            Console.WriteLine();
        }

        public void PrintLine()
        {
            Console.Write("\n===============================================================================================================================================================================================\n");
        }

        public void PrintInterestedCredit(List<USER> user)
        {
            Console.Write(" 등록 가능 학점 :  {0}      담은 학점 : {1}      담을 과목 NO : ", user[0].AbleInterestedCredit, user[0].EnrolledInterestedCredit);
        }

        public void PrintEnrolledCredit(List<USER> user)
        {
            Console.Write(" 등록 가능 학점 : {0}      담은 학점 : {1}      담을 과목 NO : ", user[0].AbleEnrolledCredit, user[0].EnrolledCredit)
;        }
    }
}
