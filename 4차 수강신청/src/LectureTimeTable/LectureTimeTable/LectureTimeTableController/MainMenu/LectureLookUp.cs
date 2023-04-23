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
        MenuSelecter selecterMenu;
        SearchResults searchResults;
        ExceptionHandler exceptionHandler;
        LectureDisplay lectureDisplay;
        TotalStorage totalStorage;
        public LectureLookUp(GuidancePhrase guidancePhrase, MenuSelecter selecterMenu, ExceptionHandler exceptionHandler,
            LectureDisplay lectureDisplay, SearchResults searchResults, TotalStorage totalStorage) 
        {
            this.guidancePhrase = guidancePhrase;
            this.selecterMenu = selecterMenu;
            this.exceptionHandler = exceptionHandler;
            this.lectureDisplay = lectureDisplay;
            this.searchResults = searchResults;
            this.totalStorage = totalStorage;
        }

        int consoleColumn;
        int consoleRow;

        bool isESC;
        bool isEnter;

        int choosedIndex;
        int choosedMenu;

        public void LookUpLecture(bool isLookUp)
        {
            Console.SetWindowSize(120, 40);

            choosedMenu = 0;
            isESC = false;

            Console.Clear();
            guidancePhrase.PrintAnounce();

            string[] lectureSearchMenu = { "개설 학과 전공  :", "이수 구분       :", "교과목명        :", "교수명          :", "학년            :", "학수번호        :", "< 검색하기 > " };

            while (!isESC)
            {
                Console.SetWindowSize(120, 35);

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
                        SelectSearch(isLookUp);
                        break;
                }
                choosedIndex = 0;
            }
        }

        private void SelectSearch(bool isLookUp)
        {
            ConsoleKeyInfo keyInfo;

            if (isLookUp)
            {
                FindSearchResult();

                guidancePhrase.PrintESC();

                while (!isESC)
                {
                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isESC = true;
                    }
                }
                Console.Clear();
                guidancePhrase.PrintAnounce();
                isESC = false;
                choosedMenu = 0;
            }
            else
            {
                FindSearchResult();
                lectureDisplay.PrintInterestedCredit(totalStorage.user);
                isESC = true;
            }
        }

        private void SelectLectureMajor()
        {
            choosedIndex = 0;
            isEnter = false;
            isESC = false;

            string[] major = { "전체", "컴퓨터공학과", "소프트웨어학과", "지능기전공학부", "기계항공우주공학부" };

            while (!isESC && !isEnter)
            {
                consoleColumn = 28;
                consoleRow = 10;

                choosedIndex = selecterMenu.SelectMenu(major, choosedIndex, consoleColumn, consoleRow, ConstantNumber.IS_OPTION, 9);

                if (choosedIndex == ConstantNumber.EXIT)
                {
                    isESC = true;
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.ErasePrint();
                    guidancePhrase.ErasePrint();
                }
                else
                {
                    if(choosedIndex == 0)
                    {
                        searchResults.Major = "";
                        isEnter = true;
                    }
                    else
                    {
                        searchResults.Major = major[choosedIndex];
                        isEnter = true;
                    }
                }
            }
            isESC = false;
        }

        private void SelectCompleteType()
        {
            string[] completeType = { "전체", "교양필수", "전공필수", "전공선택" };

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
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.ErasePrint();
                    guidancePhrase.ErasePrint();
                }
                else
                {
                    if(choosedIndex == 0)
                    {
                        searchResults.CompleteType = "";
                        isEnter = true;
                    }
                    else
                    {
                        searchResults.CompleteType = completeType[choosedIndex];
                        isEnter = true;
                    }
                }
            }
            isESC = false;
        }

        private string SearchKeyword(int row, string regex)
        {
            consoleColumn = 15;
            consoleRow = 11 + row;

            string input = "";

            input = exceptionHandler.IsValid(regex, consoleColumn, consoleRow, 36, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

            if(input == ConstantNumber.ESC)
            {
                isESC = true;
                Console.SetCursorPosition(consoleColumn, consoleRow);
                guidancePhrase.ErasePrint();
                guidancePhrase.ErasePrint();
            }
            isESC = false;
            return input;
        }

        private void FindSearchResult()
        {
            ConsoleKeyInfo keyInfo;

            bool isESC = false;

            lectureDisplay.PrintSearchLectureUI(totalStorage.lecture, searchResults);

            for (int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if (totalStorage.lecture[i].Major.Contains(searchResults.Major)
                && totalStorage.lecture[i].CourseNumber.Contains(searchResults.CourseNumber)
                && totalStorage.lecture[i].LectureTitle.Contains(searchResults.LectureTitle)
                && totalStorage.lecture[i].Professor.Contains(searchResults.Professor)
                && totalStorage.lecture[i].Grade.Contains(searchResults.Grade)
                && totalStorage.lecture[i].CompleteType.Contains(searchResults.CompleteType))
                {
                    lectureDisplay.PrintSearchLecture(totalStorage.lecture[i]);
                }
            }
            lectureDisplay.PrintLine();
        }
    }
}
