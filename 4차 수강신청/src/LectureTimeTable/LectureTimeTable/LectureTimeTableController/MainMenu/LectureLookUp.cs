using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.MainMenu
{
    public class LectureLookUp
    {
        GuidancePhrase guidancePhrase;
        SelecterMenu selecterMenu;
        public LectureLookUp(GuidancePhrase guidancePhrase, SelecterMenu selecterMenu) 
        {
            this.guidancePhrase = guidancePhrase;
            this.selecterMenu = selecterMenu;
        }

        int consoleColumn;
        int consoleRow;

        public void LookUpLecture()
        {
            int choosedMenu = 0;
            bool isESC = false;

            guidancePhrase.PrintAnounce();

            string[] lectureSearchMenu = { "개설 학과 전공  : ", " 이수 구분       : ", "교과목명       : ", "교수명         : ", "학년           : ", "학수번호       : ", "< 검색하기 > " };

            while (!isESC)
            {
                consoleColumn = 50;
                consoleRow = 20;

                choosedMenu = selecterMenu.SelectMenu(lectureSearchMenu, choosedMenu, consoleColumn, consoleRow);

                if(choosedMenu == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch(choosedMenu)
                {
                    case (int)INQUIRY.MAJOR:

                        break;
                    case (int)INQUIRY.COMPLETE_TYPE:

                        break;
                    case (int)INQUIRY.LECTURE_TITLE:

                        break;

                    case (int)INQUIRY.PROFESSOR:

                        break;
                    case (int)INQUIRY.CLASS:

                        break;
                    case (int)INQUIRY.COURSE_NUMBER:

                        break;
                    case (int)INQUIRY.SEARCH:

                        break;
                }
            }
        }
    }
}
