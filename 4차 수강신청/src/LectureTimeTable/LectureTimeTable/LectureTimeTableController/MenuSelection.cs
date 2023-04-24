using LectureTimeTable.LectureTimeTableController.MainMenu;
using LectureTimeTable.LectureTimeTableController.Option;
using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController
{
    public class MenuSelection
    {
        MenuAndOption menuAndOption;
        ExceptionHandler exceptionHandler;
        Design design;
        MenuSelecter menuSelecter;
        LectureLookUp lectureLookUp;
        EnrollmentLecture enrolmentLecture;
        InterestedLectureAddition additionInterestedLecture;
        CourseHistory courseHistory;
        GuidancePhrase guidancePhrase;
        LectureDisplay lectureDisplay;
        SearchResults searchResults;
        TotalStorage totalStorage;
        LectureDelecter lectureDelecter;
        LectureList lectureList;
        TimeTable timeTable;

        public MenuSelection(MenuAndOption menuAndOption, ExceptionHandler exceptionHandler, 
            Design design, MenuSelecter menuSelecter, GuidancePhrase guidancePhrase, TotalStorage totalStorage)
        {
            this.menuAndOption = menuAndOption;
            this.exceptionHandler = exceptionHandler;
            this.design = design;
            this.menuSelecter = menuSelecter;
            this.guidancePhrase = guidancePhrase;
            this.totalStorage = totalStorage;
            searchResults = new SearchResults();
            lectureDisplay = new LectureDisplay(exceptionHandler);
            courseHistory = new CourseHistory();
            lectureLookUp = new LectureLookUp(guidancePhrase, menuSelecter, exceptionHandler, lectureDisplay, searchResults, totalStorage);
            lectureList = new LectureList(totalStorage, lectureDisplay, guidancePhrase);
            enrolmentLecture = new EnrollmentLecture();
            additionInterestedLecture = new InterestedLectureAddition(menuAndOption, exceptionHandler, design, menuSelecter,
                guidancePhrase, totalStorage, lectureLookUp, lectureList, timeTable, lectureDelecter, lectureDisplay);
        }

        public void SelectMenu()
        {
            ConsoleKeyInfo keyInfo;

            bool isESC = false;

            int menuIndex = 0;

            int consoleColumn;
            int consoleRow;

            string[] enrolmentMenu = { "강의 시간표 조회", "관심과목 담기", "수강신청", "수강내역 조회" };

            Console.SetWindowSize(120, 40);
            
            while(!isESC)
            {
                Console.Clear();
                design.PrintMain();
                design.PrintBox(6);

                consoleColumn = 50;
                consoleRow = 28;

                menuIndex = menuSelecter.SelectMenu(enrolmentMenu, menuIndex, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);

                if(menuIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)ENROLMENTLECTURE.INQUIRY:
                        lectureLookUp.LookUpLecture(ConstantNumber.IS_LOOKUP);
                        break;
                    case (int)ENROLMENTLECTURE.INTERESTEDLECTURE:
                        additionInterestedLecture.AddInterestedLecture();
                        break;
                    case (int)ENROLMENTLECTURE.ENROLMENT:
                        enrolmentLecture.EnrolLecture();
                        break;
                    case (int)ENROLMENTLECTURE.SEARCHLIST:
                        courseHistory.InquireCourseHistory();
                        break;
                }
            }
        }
    }
}
