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
    public class LectureLookUp
    {
        GuidancePhrase guidancePhrase;
        SelecterMenu selecterMenu;
        SearchResults searchResults;
        ExceptionHandler exceptionHandler;
        public LectureLookUp(GuidancePhrase guidancePhrase, SelecterMenu selecterMenu, ExceptionHandler exceptionHandler) 
        {
            this.guidancePhrase = guidancePhrase;
            this.selecterMenu = selecterMenu;
            this.exceptionHandler = exceptionHandler;
            searchResults = new SearchResults();
        }

        int consoleColumn;
        int consoleRow;

        bool isESC;
        bool isEnter;

        int choosedIndex;

        public void LookUpLecture()
        {
            Console.SetWindowSize(150, 40);
            Console.Clear();

            int choosedMenu = 0;
            isESC = false;

            guidancePhrase.PrintAnounce();

            string[] lectureSearchMenu = { "개설 학과 전공 :  ", "이수 구분       : ", "교과목명        : ", "교수명          : ", "학년            : ", "학수번호        : ", "< 검색하기 > " };

            while (!isESC)
            {
                consoleColumn = 10;
                consoleRow = 10;

                choosedMenu = selecterMenu.SelectMenu(lectureSearchMenu, choosedMenu, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);

                if(choosedMenu == ConstantNumber.EXIT)
                {
                    isESC = true;
                }

                switch(choosedMenu)
                {
                    case (int)INQUIRY.MAJOR:
                        SelectLectureMajor();
                        break;
                    case (int)INQUIRY.COMPLETE_TYPE:
                        SelectCompleteType();
                        break;
                    case (int)INQUIRY.LECTURE_TITLE:
                        searchResults.LectureTitle = SearchKeyword(1, ConstantNumber.KOREAN);
                        break;
                    case (int)INQUIRY.PROFESSOR:
                        searchResults.Professor = SearchKeyword(2, ConstantNumber.KOREAN);
                        break;
                    case (int)INQUIRY.GRADE:
                        searchResults.Grade = SearchKeyword(3, ConstantNumber.GRADE);
                        break;
                    case (int)INQUIRY.COURSE_NUMBER:
                        searchResults.CourseNumber = SearchKeyword(4, ConstantNumber.COURSER_NUMBER);
                        break;
                    case (int)INQUIRY.SEARCH:

                        break;
                }
            }
        }
        private void SelectLectureMajor()
        {
            choosedIndex = 0;
            isEnter = false;
            isESC = false;

            string[] major = { "전체", "컴퓨터공학과", "소프트웨어공학과", "지능기전공학부", "기계항공우주공학부" };

            while (!isESC && !isEnter)
            {
                consoleColumn = 28;
                consoleRow = 10;

                choosedIndex = selecterMenu.SelectMenu(major, choosedIndex, consoleColumn, consoleRow, ConstantNumber.IS_OPTION, 9);

                if (choosedIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }
                else
                {
                    searchResults.Major = major[choosedIndex];
                    isEnter = true;
                }
            }
        }

        private void SelectCompleteType()
        {
            string[] completeType = { "전체", "교양필수  ", "전공필수    ", "전공선택   " };

            isESC = false;
            isEnter = false;

            while (!isESC && !isEnter)
            {
                consoleColumn = 28;
                consoleRow = 11;

                choosedIndex = selecterMenu.SelectMenu(completeType, choosedIndex, consoleColumn, consoleRow, ConstantNumber.IS_OPTION, 9);

                if(choosedIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                }
                else
                {
                    searchResults.CompleteType = completeType[choosedIndex];
                    isEnter = true;
                }
            }
        }

        private string SearchKeyword(int row, string regex)
        {
            consoleColumn = 15;
            consoleRow = 11 + row;

            string input = "";

            input = exceptionHandler.IsValid(regex, consoleColumn, consoleRow, 36, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

            return input;
        }
    }
}
