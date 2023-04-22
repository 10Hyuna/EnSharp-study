using LectureTimeTable.LectureTimeTableController.MainMenu;
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
        SelecterMenu selecterMenu;
        LectureLookUp lectureLookUp;
        EnrolmentLecture enrolmentLecture;
        AdditionInterestedLecture additionInterestedLecture;
        CourseHistory courseHistory;

        public MenuSelection(MenuAndOption menuAndOption, ExceptionHandler exceptionHandler, 
            Design design, SelecterMenu selecterMenu)
        {
            this.menuAndOption = menuAndOption;
            this.exceptionHandler = exceptionHandler;
            this.design = design;
            this.selecterMenu = selecterMenu;
            courseHistory = new CourseHistory();
            lectureLookUp = new LectureLookUp();
            enrolmentLecture = new EnrolmentLecture();
            additionInterestedLecture = new AdditionInterestedLecture();
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

                menuIndex = selecterMenu.SelectMenu(enrolmentMenu, menuIndex, consoleColumn, consoleRow);

                if(menuIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)ENROLMENTLECTURE.INQUIRY:
                        lectureLookUp.LookUpLecture();
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
