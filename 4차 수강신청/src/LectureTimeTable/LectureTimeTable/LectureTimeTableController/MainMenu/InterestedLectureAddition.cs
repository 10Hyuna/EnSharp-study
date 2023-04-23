using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
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
        LectureLookUp lectureLookUp;

        public InterestedLectureAddition(MenuAndOption menuAndOption, ExceptionHandler exceptionHandler, Design design,
            MenuSelecter menuSelecter, GuidancePhrase guidancePhrase, TotalStorage totalStorage, LectureLookUp lectureLookUp)
        {
            this.menuAndOption = menuAndOption;
            this.exceptionHandler = exceptionHandler;
            this.design = design;
            this.menuSelecter = menuSelecter;
            this.guidancePhrase = guidancePhrase;
            this.totalStorage = totalStorage;
            this.lectureLookUp = lectureLookUp;
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

            string SearchLectureId;
            int lectureId;
            int lectureIndex;

            while(!isESC)
            {
                SearchInterestedLecture = exceptionHandler.IsValid(ConstantNumber.NUMBER, Console.CurserLeft, Console.CursorTop, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if(SearchInterestedLecture == ConstantNumber.EXIT)
                {
                    isESC = true;
                }
                lectureId = SearchInterestedLecture.ToString();

                lectureIndex = FindLectureIndex(lectureId);

                if (CheckNullLecture(lectureIndex))
                {

                    continue;
                }
                if (CheckOverlapLecture(lectureId))
                {

                    continue;
                }
                if (CheckOverlapTime(lectureIndex))
                {

                    continue;
                }
            }
        }

        private int FindLectureIndex(int lectureId)
        {
            int lectureIndex;

            for(int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if(lectureId == totalStorage.lecture[i].id)
                {
                    lectureIndex = i;
                    break;
                }
            }
            return lectureIndex;
        }
        private bool CheckNullLecture(int lectureIndex)
        {
            string major;
            string completeType;
            string lectureTitle;
            string professor;
            string grade;
            string courseNumber;

            Lecture findLecture = totalStorage.lecture[lectureIndex];
            SearchResults searchLecture = totalStorage.searchResult[0];

            major = findLecture.Major;
            completeType = findLecture.CompleteType;
            lectureTitle = findLecture.lectureTitle;
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
                return true;
            }
            return false;
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

        } 
    }
}
