using LectureTimeTable.LectureTimeTableController.Option;
using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableModel.VO;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.MainMenu
{
    public class InterestedLectureAddition  // 관심강의를 담는 역할을 하는 클래스
    {
        private Design design;
        private MenuAndOption menuAndOption;
        private ExceptionHandler exceptionHandler;
        private MenuIndexSelecter menuIndexSelecter;
        private GuidancePhrase guidancePhrase;
        private TotalStorage totalStorage;
        private LectureDisplay lectureDisplay;
        private LectureLookUp lectureLookUp;
        private LectureList lectureList;
        private TimeTable timeTable;
        private LectureDeleter lectureDelecter;
        private DuplicationLectureTime duplicationLectureTime;

        public InterestedLectureAddition(MenuAndOption menuAndOption, ExceptionHandler exceptionHandler, Design design,
            LectureTimeTableUtility.MenuIndexSelecter menuIndexSelecter, GuidancePhrase guidancePhrase, TotalStorage totalStorage, LectureLookUp lectureLookUp,
            LectureList lectureList, TimeTable timeTable, LectureDeleter lectureDelecter, LectureDisplay lectureDisplay)
        {
            this.menuAndOption = menuAndOption;
            this.exceptionHandler = exceptionHandler;
            this.design = design;
            this.menuIndexSelecter = menuIndexSelecter;
            this.guidancePhrase = guidancePhrase;
            this.totalStorage = totalStorage;
            this.lectureLookUp = lectureLookUp;
            this.lectureList = lectureList;
            this.timeTable = timeTable;
            this.lectureDelecter = lectureDelecter;
            this.lectureDisplay = lectureDisplay;
            duplicationLectureTime = new DuplicationLectureTime(totalStorage);
        }

        public void AddInterestedLecture()
        {
            bool isESC = false;
            bool isLookupESC;

            int menuIndex = 0;

            int consoleColumn;
            int consoleRow;
            
            string[] interestedMenu = { "관심과목 담기", "관심과목 내역", "관심과목 시간표", "관심과목 삭제" };

            Console.SetWindowSize(120, 40);

            while (!isESC)
            {
                Console.Clear();
                design.PrintMain();
                design.PrintBox(6);

                consoleColumn = 50;
                consoleRow = 28;

                menuIndex = menuIndexSelecter.SelectMenu(interestedMenu, menuIndex, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);
                // 관심 과목에 대한 메뉴 네 가지 중 택 1

                if(menuIndex == ConstantNumber.EXIT)    // ESC를 눌렀다면
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)INTERESTED.SEARCH:    // 관심과목 검색
                        isLookupESC = lectureLookUp.LookUpLecture(ConstantNumber.IS_INTERESTED);  // 강의 검색을 도맡는 함수 호출
                        SearchInterestedLecture(ConstantNumber.IS_INTERESTED, isLookupESC);
                        break;
                    case (int)INTERESTED.LIST:      // 관심과목 내역
                        lectureList.InformLectureList(ConstantNumber.IS_INTERESTED);
                        break;
                    case (int)INTERESTED.TIMETABLE: // 관심과목 시간표

                        break;
                    case (int)INTERESTED.DELETE:    // 관심과목 삭제
                        lectureDelecter.DelectLectureList(ConstantNumber.IS_INTERESTED);
                        break;
                }
            }
        }

        private void SearchInterestedLecture(bool isEnroll, bool isESC)  // 관심 과목 검색
        {
            string searchId;
            int SearchLectureId = 0;
            int lectureIndex = 0;

            int originColumn = Console.CursorLeft;

            while (!isESC)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                lectureDisplay.PrintInterestedCredit(totalStorage.user);
                // 현재 로그인되어 있는 유저의 남아 있는 학점에 대한 출력

                searchId = exceptionHandler.IsValidInput(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);
                // 담고자 하는 강의 아이디 검색

                if (searchId == ConstantNumber.ESC)
                {   // ESC를 눌렀다면
                    isESC = true;
                }
                else
                {
                    SearchLectureId = int.Parse(searchId);
                    lectureIndex = FindLectureIndex(SearchLectureId);

                    if (lectureIndex == ConstantNumber.FAIL || !IsCheckNullLecture(lectureIndex))
                    {   // 검색 결과에 없거나 주어진 강의에 해당하지 않는 경우
                        guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                        continue;
                    }
                    if (!IsLeftFreeCredit(lectureIndex))
                    {   // 담고자 하는 강의의 학점이 담을 수 있는 최대 학점보다 크다면
                        guidancePhrase.PrintException((int)EXCEPTION.MAX_CREDIT, 0, Console.CursorTop + 1);
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

                    totalStorage.interestedLectures.Add(totalStorage.lecture[lectureIndex]);
                    // 예외에 모두 해당하지 않는다면 저장
                    originColumn = Console.CursorLeft - searchId.Length;
                    Console.SetCursorPosition(originColumn, Console.CursorTop);
                    originColumn -= 13;
                    guidancePhrase.ErasePrint();

                    guidancePhrase.PrintException((int)EXCEPTION.FREE_CREDIT, 0, Console.CursorTop + 1);

                    totalStorage.user.AbleInterestedCredit -= int.Parse(totalStorage.lecture[lectureIndex].Credit);
                    // 담을 수 있는 학점 갱신
                    totalStorage.user.EnrolledInterestedCredit += int.Parse(totalStorage.lecture[lectureIndex].Credit);
                    // 담아져 있는 학점 갱신
                }
            }
        }

        private int FindLectureIndex(int lectureId)
        {
            int lectureIndex = 0;
            int count = 0;

            for(int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if(lectureId == totalStorage.lecture[i].Id)
                {
                    lectureIndex = i;
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                return ConstantNumber.FAIL;
            }
            return lectureIndex;
        }
        private bool IsLeftFreeCredit(int lectureIndex)
        { // 담을 수 있는 학점의 공간이 존재하는지 확인하는 함수
            if (totalStorage.user.AbleInterestedCredit - int.Parse(totalStorage.lecture[lectureIndex].Credit) >= 0)
                return true;
            return false;
        }
        private bool IsCheckNullLecture(int lectureIndex)
        {   // 담고자 하는 강의가 실존하는 강의인지 확인하는 함수
            bool isTrue = false;

            string major;
            string completeType;
            string lectureTitle;
            string professor;
            string grade;
            string courseNumber;

            Lecture findLecture = totalStorage.lecture[lectureIndex];
            SearchResults searchLecture = totalStorage.searchResult;

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
        {   // 이미 담은 강의와 중복된다면
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if (totalStorage.interestedLectures[i].CourseNumber == totalStorage.lecture[lectureIndex].CourseNumber)
                {   // 이미 저장 중인 강의와 동일한 학수번호라면
                    return false;
                }
            }
            return true;

        }

        private bool IsCheckOverlapTime(int lectureIndex)
        {   // 이미 담겨 있는 강의와 시간대가 겹치는지 확인하는 함수
            bool isOverlapTime = false;

            for (int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if (totalStorage.interestedLectures[i].FirstDay == totalStorage.lecture[lectureIndex].FirstDay
                    || totalStorage.interestedLectures[i].FirstDay == totalStorage.lecture[lectureIndex].LastDay
                    || totalStorage.interestedLectures[i].LastDay == totalStorage.lecture[lectureIndex].FirstDay
                    || totalStorage.interestedLectures[i].LastDay == totalStorage.lecture[lectureIndex].LastDay)
                {   // 강의 요일이 겹친다면
                    isOverlapTime = duplicationLectureTime.IsCheckDuplicateTime(lectureIndex, ConstantNumber.IS_INTERESTED);
                }
            }
            return isOverlapTime;
        }
    }
}
