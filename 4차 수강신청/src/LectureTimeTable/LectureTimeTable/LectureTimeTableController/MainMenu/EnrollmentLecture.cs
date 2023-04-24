using LectureTimeTable.LectureTimeTableController.Option;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.MainMenu
{
    public class EnrollmentLecture
    {
        Design design;
        LectureLookUp lectureLookUp;
        MenuIndexSelecter menuIndexSelecter;
        LectureList lectureList;
        LectureDeleter lectureDeleter;
        public EnrollmentLecture(Design design,  LectureLookUp lectureLookUp, MenuIndexSelecter menuIndexSelecter,
            LectureList lectureList, LectureDeleter lectureDeleter)
        {
            this.design = design;
            this.lectureLookUp = lectureLookUp;
            this.menuIndexSelecter = menuIndexSelecter;
            this.lectureList = lectureList;
            this.lectureDeleter = lectureDeleter;
        }

        public void EnrolLecture()
        {
            ConsoleKeyInfo keyInfo;

            bool isESC = false;

            int menuIndex = 0;

            int consoleColumn;
            int consoleRow;

            string[] enrolledMenu = { "수강 신청", "수강 신청 내역", "수강 신청 시간표", "수강 내역 삭제" };

            Console.SetWindowSize(120, 40);

            while (!isESC)
            {
                Console.Clear();
                design.PrintMain();
                design.PrintBox(6);

                consoleColumn = 50;
                consoleRow = 28;

                menuIndex = menuIndexSelecter.SelectMenu(enrolledMenu, menuIndex, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);

                if(menuIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch (menuIndex)
                {
                    case (int)ENROLL.SEARCH:
                        lectureLookUp.LookUpLecture(ConstantNumber.IS_INTERESTED);
                        SearchEnrolledLecture();
                        break;
                    case (int)ENROLL.LIST:
                        lectureList.InformLectureList(ConstantNumber.IS_ENROLLED);
                        break;
                    case (int)ENROLL.TIMETABLE:

                        break;
                    case (int)ENROLL.DELETE:
                        lectureDeleter.DelectLectureList(ConstantNumber.IS_ENROLLED);
                        break;
                }
            }
        }

        private void SearchEnrolledLecture()
        {

        }
    }
}
