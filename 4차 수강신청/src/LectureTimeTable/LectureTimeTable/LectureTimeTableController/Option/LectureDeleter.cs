using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.Option
{
    public class LectureDeleter
    {
        LectureDisplay lectureDisplay;
        TotalStorage totalStorage;
        ExceptionHandler exceptionHandler;
        GuidancePhrase guidancePhrase;
        public LectureDeleter(LectureDisplay lectureDisplay, TotalStorage totalStorage, ExceptionHandler exceptionHandler, GuidancePhrase guidancePhrase)
        {
            this.lectureDisplay = lectureDisplay;
            this.totalStorage = totalStorage;
            this.exceptionHandler = exceptionHandler;
            this.guidancePhrase = guidancePhrase;
        }

        public void DelectLectureList(bool isEnrolled)
        {
            bool isESC = false;

            string lectureNumber;
            int numberNo;

            while (!isESC)
            {
                lectureDisplay.PrintSearchLectureUI();

                if (!isEnrolled)
                {   // 관심과목 메뉴에서 진입했다면
                    isESC = DeleteInterestedLecture();
                }
                else
                {   // 수강신청 메뉴에서 진입했다면
                    //isESC = DeleteEnrolledLecture();
                }
            }
        }

        private bool FindDeleteLectureIndex(int number)
        {
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {   // 찾고자 하는 강의의 NO와 일치하는 강의의 인덱스 존재 유무 찾기
                if (totalStorage.interestedLectures[i].Id == number)
                    return true;
            }
            return false;
        }

        private bool DeleteInterestedLecture()
        {   // 관심과목 강의 삭제
            string lectureNumber;
            int numberNo;
            bool isEnd = false;

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            lectureDisplay.PrintDelectInterestedCredit(totalStorage.user);

            if (totalStorage.interestedLectures.Count == 0)
            {   // 관심 과목에 담긴 강의가 없다면
                isEnd = true;
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, 0, Console.CursorTop + 1);
            }
            else
            {
                lectureNumber = exceptionHandler.IsValid(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if (lectureNumber == ConstantNumber.ESC)
                {   // 중간에 ESC를 눌렀다면
                    isEnd = true;
                }
                else
                {
                    numberNo = int.Parse(lectureNumber);
                    if (!FindDeleteLectureIndex(numberNo))
                    {   // 존재하지 않는 강의라면
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, Console.CursorLeft, Console.CursorTop);
                        isEnd = false;
                    }
                    else
                    {   // 강의 삭제
                        totalStorage.interestedLectures.RemoveAt(numberNo - 1);
                        guidancePhrase.PrintException((int)EXCEPTION.SUCCESS_DELETE, Console.CursorLeft, Console.CursorTop);
                    }
                }
            }
            return isEnd;
        }

        private bool DeleteEnrolledLecture()
        {   // 수강신청 강의 삭제
            string lectureNumber;
            int numberNo;
            bool isEnd = false;

            Console.SetCursorPosition(0, Console.CursorTop + 1);
            lectureDisplay.PrintDelectInterestedCredit(totalStorage.user);

            if (totalStorage.enrolledLectures.Count == 0)
            {   // 수강 신청 중인 강의가 없다면
                isEnd = true;
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, 0, Console.CursorTop + 1);
            }
            else
            {
                lectureNumber = exceptionHandler.IsValid(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if (lectureNumber == ConstantNumber.ESC)
                {   // 중간에 ESC를 눌렀다면
                    isEnd = true;
                }
                else
                {
                    numberNo = int.Parse(lectureNumber);
                    if (!FindDeleteLectureIndex(numberNo))
                    {   // 존재하지 않는 강의라면
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, Console.CursorLeft, Console.CursorTop);
                        isEnd = false;
                    }
                    else
                    {
                        totalStorage.enrolledLectures.RemoveAt(numberNo - 1);
                        guidancePhrase.PrintException((int)EXCEPTION.SUCCESS_DELETE, Console.CursorLeft, Console.CursorTop);
                    }
                }
            }
            return isEnd;
        }
    }
}
