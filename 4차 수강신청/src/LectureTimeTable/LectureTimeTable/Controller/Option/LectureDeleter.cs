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
                    isESC = DeleteInterestedLecture(isEnrolled);
                }
                else
                {   // 수강신청 메뉴에서 진입했다면
                    isESC = DeleteEnrolledLecture(isEnrolled);
                }
            }
        }

        private bool FindDeleteLectureIndex(int number, bool isEnrolled)
        {
            if (isEnrolled)
            {
                for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
                {   // 찾고자 하는 강의의 NO와 일치하는 강의의 인덱스 존재 유무 찾기
                    if (totalStorage.enrolledLectures[i].Id == number)
                        return true;
                }
                return false;
            }
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {   // 찾고자 하는 강의의 NO와 일치하는 강의의 인덱스 존재 유무 찾기
                if (totalStorage.interestedLectures[i].Id == number)
                    return true;
            }
            return false;
        }

        private bool DeleteInterestedLecture(bool isEnrolled)
        {   // 관심과목 강의 삭제
            string lectureNumber;
            int numberNo;
            int deleteIndex = 0;

            bool isEnd = false;

            Console.SetCursorPosition(0, Console.CursorTop + 1);

            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.interestedLectures[i]);
            }
            lectureDisplay.PrintCredit(totalStorage.user);
            lectureDisplay.PrintDeleteNo();
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            guidancePhrase.PrintESC();

            if (totalStorage.interestedLectures.Count == 0)
            {   // 관심 과목에 담긴 강의가 없다면
                isEnd = true;
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, 0, Console.CursorTop + 1);
            }
            else
            {
                lectureNumber = exceptionHandler.IsValidInput(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if (lectureNumber == ConstantNumber.ESC)
                {   // 중간에 ESC를 눌렀다면
                    isEnd = true;
                }
                else if(lectureNumber == "")
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 0, Console.CursorTop + 1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    return isEnd;
                }
                else if (!exceptionHandler.IsStringAllNumber(lectureNumber))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                    return isEnd;
                }
                else
                {
                    numberNo = int.Parse(lectureNumber);

                    for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
                    {
                        if (totalStorage.interestedLectures[i].Id == numberNo)
                        {
                            deleteIndex = i;
                        }
                    }
                    if (!FindDeleteLectureIndex(numberNo, isEnrolled))
                    {   // 존재하지 않는 강의라면
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        isEnd = false;
                    }
                    else
                    {   // 강의 삭제
                        totalStorage.user.EnrolledInterestedCredit -= int.Parse(totalStorage.interestedLectures[deleteIndex].Credit.ToString());
                        totalStorage.user.AbleInterestedCredit += int.Parse(totalStorage.interestedLectures[deleteIndex].Credit.ToString());

                        totalStorage.interestedLectures.RemoveAt(deleteIndex);
                        guidancePhrase.PrintException((int)EXCEPTION.SUCCESS_DELETE, 0, Console.CursorTop + 1);
                    }
                }
            }
            return isEnd;
        }

        private bool DeleteEnrolledLecture(bool isEnrolled)
        {   // 수강신청 강의 삭제
            string lectureNumber;
            int numberNo;
            bool isEnd = false;

            int deleteIndex = 0;


            Console.SetCursorPosition(0, Console.CursorTop + 1);

            for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.enrolledLectures[i]);
            }
            lectureDisplay.PrintEnrollCredit(totalStorage.user);
            lectureDisplay.PrintDeleteNo();

            if (totalStorage.enrolledLectures.Count == 0)
            {   // 수강 신청 중인 강의가 없다면
                isEnd = true;
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, 0, Console.CursorTop + 1);
            }
            else
            {
                lectureNumber = exceptionHandler.IsValidInput(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if (lectureNumber == ConstantNumber.ESC)
                {   // 중간에 ESC를 눌렀다면
                    isEnd = true;
                }
                else if (lectureNumber == "")
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, 0, Console.CursorTop + 1);
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    return isEnd;
                }
                else if (!exceptionHandler.IsStringAllNumber(lectureNumber))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                    return isEnd;
                }
                else
                {
                    numberNo = int.Parse(lectureNumber);
                    //책 출력
                    for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
                    {
                        if (totalStorage.enrolledLectures[i].Id == numberNo)
                        {
                            deleteIndex = i;
                        }
                    }
                    if (!FindDeleteLectureIndex(numberNo, isEnrolled))
                    {   // 존재하지 않는 강의라면
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        isEnd = false;
                    }
                    else
                    {
                        totalStorage.user.EnrolledCredit -= int.Parse(totalStorage.enrolledLectures[deleteIndex].Credit.ToString());
                        totalStorage.user.AbleEnrolledCredit += int.Parse(totalStorage.enrolledLectures[deleteIndex].Credit.ToString());

                        totalStorage.enrolledLectures.RemoveAt(deleteIndex);
                        guidancePhrase.PrintException((int)EXCEPTION.SUCCESS_DELETE, 0, Console.CursorTop + 1);
                    }
                }
            }
            return isEnd;
        }
    }
}
