using LectureTimeTable.LectureTimeTableController.MainMenu;
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
    public class SelecterEnrolledWay
    {
        LectureLookUp lectureLookUp;
        MainView design;
        MenuIndexSelecter menuIndexSelecter;
        LectureDisplay lectureDisplay;
        TotalStorage totalStorage;
        ExceptionHandler exceptionHandler;
        GuidancePhrase guidancePhrase;
        DuplicationLectureTime duplicationLectureTime;

        public SelecterEnrolledWay(LectureLookUp lectureLookUp, MainView design, MenuIndexSelecter menuIndexSelecter,
            LectureDisplay lectureDisplay, TotalStorage totalStorage, ExceptionHandler exceptionHandler, 
            GuidancePhrase guidancePhrase)
        {
            this.lectureLookUp = lectureLookUp;
            this.design = design;
            this.menuIndexSelecter = menuIndexSelecter;
            this.lectureDisplay = lectureDisplay;
            this.totalStorage = totalStorage;
            this.exceptionHandler = exceptionHandler;
            this.guidancePhrase = guidancePhrase;
            duplicationLectureTime = new DuplicationLectureTime(totalStorage);
        }

        public void SelectEnrolledWay()
        {
            bool isESC = false;
            bool isEnrollESC = false;

            int menuIndex = 0;

            int consoleColumn;
            int consoleRow;

            string[] enrolledWayMenu = { "검색으로 추가", "관심 과목으로 추가" };

            Console.SetWindowSize(120, 40);

            while (!isESC)
            {
                Console.Clear();
                design.PrintMain();
                design.PrintBox(4);

                consoleColumn = 50;
                consoleRow = 28;

                menuIndex = menuIndexSelecter.SelectMenu(enrolledWayMenu, menuIndex, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);

                if(menuIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)ENROLLWAY.SEARCH:
                        isEnrollESC = lectureLookUp.LookUpLecture(ConstantNumber.IS_INTERESTED);
                        enrollLecture(isEnrollESC, (int)ENROLLWAY.SEARCH);
                        break;
                    case (int)ENROLLWAY.INTERESTED:
                        enrolledInterestedLecture();
                        enrollLecture(false, (int)ENROLLWAY.INTERESTED);
                        break;
                }
            }
        }

        private void enrolledInterestedLecture()
        {
            Console.Clear();
            lectureDisplay.PrintSearchLectureUI();

            for (int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.interestedLectures[i]);
            }

            lectureDisplay.PrintCredit(totalStorage.user);
            lectureDisplay.PrintLectureNo();
        }
        private void enrollLecture(bool isESC, int search)
        {
            string lectureNO;
            int lectureId;
            int lectureIndex;

            int consoleColumn;
            int consoleRow;

            int originColumn = Console.CursorLeft;
            int originRow;

            while (!isESC)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                lectureDisplay.PrintCredit(totalStorage.user);
                lectureDisplay.PrintLectureNo();

                lectureNO = exceptionHandler.IsValidInput(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if (lectureNO == ConstantNumber.ESC)
                {
                    isESC = true;
                }
                if (exceptionHandler.IsStringAllNumber(lectureNO))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                    continue;
                }
                else
                {
                    lectureId = int.Parse(lectureNO);
                    lectureIndex = FindLectureIndex(lectureId);
                    if((search == (int)ENROLLWAY.SEARCH && lectureIndex == ConstantNumber.FAIL))
                    {
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (search == (int)ENROLLWAY.INTERESTED && !IsCheckInterestedLecture(lectureId))
                    {
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (!IsLeftFreeCredit(lectureIndex))
                    {   // 담고자 하는 강의의 학점이 담을 수 있는 최대 학점보다 크다면
                        guidancePhrase.PrintException((int)EXCEPTION.MAX_CREDIT, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (!IsCheckNullLecture(lectureIndex))
                    {   // 검색 결과에 없거나 주어진 강의에 해당하지 않는 경우
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (!IsCheckOverlapLecture(lectureIndex))
                    {   // 이미 담은 과목이라면
                        guidancePhrase.PrintException((int)EXCEPTION.OVERLAP_LECTURE, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (IsCheckOverlapTime(lectureIndex))
                    {   // 겹치는 시간대가 존재한다면
                        guidancePhrase.PrintException((int)EXCEPTION.OVERLAP_TIME, 0, Console.CursorTop + 1);
                        continue;
                    }

                    totalStorage.enrolledLectures.Add(totalStorage.lecture[lectureIndex]);
                    // 예외에 모두 해당하지 않는다면 저장
                    originColumn = Console.CursorLeft - lectureNO.Length;
                    Console.SetCursorPosition(originColumn, Console.CursorTop);
                    originColumn -= 13;
                    guidancePhrase.ErasePrint();

                    guidancePhrase.PrintException((int)EXCEPTION.FREE_CREDIT, 0, Console.CursorTop + 1);

                    totalStorage.user.AbleEnrolledCredit -= int.Parse(totalStorage.lecture[lectureIndex].Credit);
                    // 담을 수 있는 학점 갱신
                    totalStorage.user.EnrolledCredit += int.Parse(totalStorage.lecture[lectureIndex].Credit);
                    // 담아져 있는 학점 갱신
                }
            }
        }

        private bool IsCheckInterestedLecture(int lectureId)
        {
            bool isInterestedLecture = false;
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if(lectureId == totalStorage.interestedLectures[i].Id)
                {
                    isInterestedLecture = true;
                    break;
                }
            }
            return isInterestedLecture;
        }

        private int FindLectureIndex(int lectureId)
        {
            int count = 0;
            int lectureIndex = 0;

            for (int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if (lectureId == totalStorage.lecture[i].Id)
                {
                    lectureIndex = i;
                    count++;
                    break;
                }
            }
            if(count == 0)
            {
                return ConstantNumber.FAIL;
            }
            return lectureIndex;
        }

        private bool IsLeftFreeCredit(int lectureIndex)
        {
            if (totalStorage.user.AbleEnrolledCredit - int.Parse(totalStorage.lecture[lectureIndex].Credit) >= 0)
                return true;
            return false;
        }

        private bool IsCheckNullLecture(int lectureIndex)
        {
            bool isTrue = false;

            string major;
            string completeType;
            string lectureTitle;
            string professor;
            string grade;
            string courseNumber;

            LectureVO findLecture = totalStorage.lecture[lectureIndex];
            SearchResultsDTO searchLecture = totalStorage.searchResult;

            major = findLecture.Major;
            completeType = findLecture.CompleteType;
            lectureTitle = findLecture.LectureTitle;
            professor = findLecture.Professor;
            grade = findLecture.Grade;
            courseNumber = findLecture.CourseNumber;

            if (major.Contains(searchLecture.Major)
                && completeType.Contains(searchLecture.CompleteType)
                && lectureTitle.Contains(searchLecture.LectureTitle)
                && professor.Contains(searchLecture.Professor)
                && grade.Contains(searchLecture.Grade)
                && courseNumber.Contains(searchLecture.CourseNumber))
            {   // 검색 결과와 일치하는 값이라면
                isTrue = true;
            }
            if (lectureIndex < 0 || lectureIndex > 186)
            {   // 강의가 1부터 185 사이에 있지 않다면
                isTrue = false;
            }
            return isTrue;
        }

        private bool IsCheckOverlapLecture(int lectureIndex)
        {
            for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
            {
                if (totalStorage.enrolledLectures[i].CourseNumber == totalStorage.lecture[lectureIndex].CourseNumber)
                {   // 이미 저장 중인 강의와 동일한 학수번호라면
                    return false;
                }
            }
            return true;

        }

        private bool IsCheckOverlapTime(int lectureIndex)
        {
            bool isOverlapTime = false;

            for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
            {
                if (totalStorage.enrolledLectures[i].FirstDay == totalStorage.lecture[lectureIndex].FirstDay
                    || totalStorage.enrolledLectures[i].FirstDay == totalStorage.lecture[lectureIndex].LastDay
                    || totalStorage.enrolledLectures[i].LastDay == totalStorage.lecture[lectureIndex].FirstDay
                    || totalStorage.enrolledLectures[i].LastDay == totalStorage.lecture[lectureIndex].LastDay)
                {
                    isOverlapTime = duplicationLectureTime.IsCheckDuplicateTime(lectureIndex, ConstantNumber.IS_ENROLLED);
                }
            }
            return isOverlapTime;
        }
    }
}
