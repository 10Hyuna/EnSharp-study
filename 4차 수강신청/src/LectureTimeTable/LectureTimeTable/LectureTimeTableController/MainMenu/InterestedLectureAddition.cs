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
    public class InterestedLectureAddition
    {
        Design design;
        MenuAndOption menuAndOption;
        ExceptionHandler exceptionHandler;
        MenuSelecter menuSelecter;
        GuidancePhrase guidancePhrase;
        TotalStorage totalStorage;
        LectureDisplay lectureDisplay;
        LectureLookUp lectureLookUp;
        LectureList lectureList;
        TimeTable timeTable;
        LectureDelecter lectureDelecter;

        public InterestedLectureAddition(MenuAndOption menuAndOption, ExceptionHandler exceptionHandler, Design design,
            MenuSelecter menuSelecter, GuidancePhrase guidancePhrase, TotalStorage totalStorage, LectureLookUp lectureLookUp,
            LectureList lectureList, TimeTable timeTable, LectureDelecter lectureDelecter, LectureDisplay lectureDisplay)
        {
            this.menuAndOption = menuAndOption;
            this.exceptionHandler = exceptionHandler;
            this.design = design;
            this.menuSelecter = menuSelecter;
            this.guidancePhrase = guidancePhrase;
            this.totalStorage = totalStorage;
            this.lectureLookUp = lectureLookUp;
            this.lectureList = lectureList;
            this.timeTable = timeTable;
            this.lectureDelecter = lectureDelecter;
            this.lectureDisplay = lectureDisplay;
        }

        public void AddInterestedLecture()
        {
            ConsoleKeyInfo keyInfo;

            bool isESC = false;

            int menuIndex = 0;

            int consoleColumn;
            int consoleRow;
            
            string[] interestedMenu = { "관심과목 검색", "관심과목 내역", "관심과목 시간표", "관심과목 삭제" };

            Console.SetWindowSize(120, 40);

            while (!isESC)
            {
                Console.Clear();
                design.PrintMain();
                design.PrintBox(6);

                consoleColumn = 50;
                consoleRow = 28;

                menuIndex = menuSelecter.SelectMenu(interestedMenu, menuIndex, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);
                
                if(menuIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)INTERESTED.SEARCH:
                        lectureLookUp.LookUpLecture(ConstantNumber.IS_INTERESTED);
                        SearchInterestedLecture();
                        break;
                    case (int)INTERESTED.LIST:
                        lectureList.InformLectureList(ConstantNumber.IS_INTERESTED);
                        break;
                    case (int)INTERESTED.TIMETABLE:

                        break;
                    case (int)INTERESTED.DELECT:

                        break;
                }
            }
        }

        private void SearchInterestedLecture()
        {
            bool isESC = false;

            string searchId;
            int SearchLectureId = 0;
            int lectureIndex = 0;

            int originColumn = Console.CursorLeft;

            while (!isESC)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                lectureDisplay.PrintInterestedCredit(totalStorage.user);

                searchId = exceptionHandler.IsValid(ConstantNumber.NUMBER, Console.CursorLeft - 13, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);
                
                if (searchId == ConstantNumber.ESC)
                {
                    isESC = true;
                }
                else
                {
                    SearchLectureId = int.Parse(searchId);
                    lectureIndex = FindLectureIndex(SearchLectureId);
                }
                if (!LeftFreeCredit(lectureIndex))
                {
                    continue;
                }
                if (!CheckNullLecture(lectureIndex))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.NULL_LECTURE, 0, Console.CursorTop + 1);
                    continue;
                }
                if (!CheckOverlapLecture(SearchLectureId))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.OVERLAP_LECTURE, 0, Console.CursorTop + 1);
                    continue;
                }
                if (!CheckOverlapTime(lectureIndex))
                {
                    guidancePhrase.PrintException((int)EXCEPTION.OVERLAP_TIME, 0, Console.CursorTop + 1);
                    continue;
                }
                totalStorage.interestedLectures.Add(totalStorage.lecture[lectureIndex]);
                originColumn = Console.CursorLeft - searchId.Length;
                Console.SetCursorPosition(originColumn, Console.CursorTop);
                originColumn -= 13;
                guidancePhrase.ErasePrint();

                totalStorage.user.AbleInterestedCredit = int.Parse(totalStorage.lecture[lectureIndex].Credit);
                totalStorage.user.EnrolledInterestedCredit = int.Parse(totalStorage.lecture[lectureIndex].Credit);
            }
        }

        private int FindLectureIndex(int lectureId)
        {
            int lectureIndex = 0;

            for(int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if(lectureId == totalStorage.lecture[i].Id)
                {
                    lectureIndex = i;
                    break;
                }
            }
            return lectureIndex;
        }
        private bool LeftFreeCredit(int lectureIndex)
        {
            if (totalStorage.user.AbleInterestedCredit - int.Parse(totalStorage.lecture[lectureIndex].Credit) >= 0)
                return true;
            return false;
        }
        private bool CheckNullLecture(int lectureIndex)
        {
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
            {
                isTrue = true;
            }
            if (lectureIndex < 0 || lectureIndex > 186)
            {
                isTrue = true;
            }
            return isTrue;
        }

        private bool CheckOverlapLecture(int lectureId)
        {
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if (totalStorage.interestedLectures[i].Id == lectureId)
                {
                    return false;
                }
            }
            return true;

        }

        private bool CheckOverlapTime(int lectureIndex)
        {
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if (totalStorage.interestedLectures[i].DateAndTime == totalStorage.lecture[lectureIndex].DateAndTime)
                {
                    return false;
                }
            }
            return true;
        } 
    }
}
