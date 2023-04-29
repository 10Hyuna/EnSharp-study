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
        private GuidancePhrase guidancePhrase;
        private MenuIndexSelecter selecterMenu;
        private ExceptionHandler exceptionHandler;
        private LectureDisplay lectureDisplay;
        private TotalStorage totalStorage;
        private int consoleColumn;
        private int consoleRow;
        private bool isESC;
        private bool isEnter;
        private int choosedIndex;
        private int choosedMenu;

        public LectureLookUp(GuidancePhrase guidancePhrase, MenuIndexSelecter selecterMenu, ExceptionHandler exceptionHandler,
            LectureDisplay lectureDisplay, SearchResultsDTO searchResults, TotalStorage totalStorage) 
        {
            this.guidancePhrase = guidancePhrase;
            this.selecterMenu = selecterMenu;
            this.exceptionHandler = exceptionHandler;
            this.lectureDisplay = lectureDisplay;
            this.totalStorage = totalStorage;
        }


        public bool LookUpLecture(bool isLookUp)
        {
            Console.SetWindowSize(120, 40);

            choosedMenu = 0;
            isESC = false;

            Console.Clear();
            guidancePhrase.PrintAnounce();
            ResetSearchData();

            string[] lectureSearchMenu = { "개설 학과 전공  :", "이수 구분       :", "교과목명        :", "교수명          :", "학년            :", "학수번호        :", "< 검색하기 > " };

            while (!isESC)
            {
                Console.SetWindowSize(120, 35);

                consoleColumn = 10;
                consoleRow = 10;

                choosedMenu = selecterMenu.SelectMenu(lectureSearchMenu, choosedMenu, consoleColumn, consoleRow, ConstantNumber.IS_MENU, 9);
                // 어느 메뉴에 대한 검색을 할 건지 고르기

                if(choosedMenu == ConstantNumber.EXIT)
                {   // ESC를 눌렀다면
                    isESC = true;
                    Console.Clear();
                    return isESC;
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
                        totalStorage.searchResult.LectureTitle = SearchKeyword(1, ConstantNumber.CHARACTER);
                        break;
                    case (int)INQUIRY.PROFESSOR:
                        totalStorage.searchResult.Professor = SearchKeyword(2, ConstantNumber.CHARACTER);
                        break;
                    case (int)INQUIRY.GRADE:
                        SelectLectureGrade();
                        break;
                    case (int)INQUIRY.COURSE_NUMBER:
                        totalStorage.searchResult.CourseNumber = SearchKeyword(4, ConstantNumber.COURSER_NUMBER);
                        break;
                    case (int)INQUIRY.SEARCH:
                        SelectSearch(isLookUp);
                        break;
                }
                if (choosedMenu == (int)INQUIRY.SEARCH)
                    break;
                choosedIndex = 0;
                isESC = false;
            }
            return false;
        }

        private void ResetSearchData()
        {
            totalStorage.searchResult.Major = "";
            totalStorage.searchResult.Professor = "";
            totalStorage.searchResult.LectureTitle = "";
            totalStorage.searchResult.CourseNumber = "";
            totalStorage.searchResult.CompleteType = "";
            totalStorage.searchResult.Grade = "";
        }

        private void SelectSearch(bool isLookUp)
        {
            ConsoleKeyInfo keyInfo;

            if (isLookUp)
            {   // 강의 검색 메뉴에서 진입했을 경우
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
            {   // 관심과목 담기, 수강신청 메뉴에서 진입했을 경우
                FindSearchResult();
                guidancePhrase.PrintESC();
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
                // 주어진 네 가지 과 중에서 고르기

                if (choosedIndex == ConstantNumber.EXIT)
                {   // 중간에 ESC를 눌렀을 경우
                    isESC = true;
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.ErasePrint();
                    guidancePhrase.ErasePrint();
                }
                else
                {   
                    if(choosedIndex == 0)
                    {   // 전체를 선택했을 경우
                        totalStorage.searchResult.Major = "";
                        isEnter = true;
                    }
                    else
                    {
                        totalStorage.searchResult.Major = major[choosedIndex];
                        isEnter = true;
                    }
                }
            }
            isESC = false;
        }

        private void SelectLectureGrade()
        {
            choosedIndex = 0;
            isEnter = false;
            isESC = false;

            string[] grade = { "전체", "1학년", "2학년", "3학년", "4학년" };

            char[] gradeString;

            while (!isESC && !isEnter)
            {
                consoleColumn = 28;
                consoleRow = 14;

                choosedIndex = selecterMenu.SelectMenu(grade, choosedIndex, consoleColumn, consoleRow, ConstantNumber.IS_OPTION, 9);
                // 주어진 네 가지 과 중에서 고르기

                if (choosedIndex == ConstantNumber.EXIT)
                {   // 중간에 ESC를 눌렀을 경우
                    isESC = true;
                    Console.SetCursorPosition(consoleColumn, consoleRow);
                    guidancePhrase.ErasePrint();
                    guidancePhrase.ErasePrint();
                }
                else
                {
                    if (choosedIndex == 0)
                    {   // 전체를 선택했을 경우
                        totalStorage.searchResult.Grade = "";
                        isEnter = true;
                    }
                    else
                    {
                        gradeString = grade[choosedIndex].ToCharArray();
                        totalStorage.searchResult.Grade = gradeString[0].ToString();
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
                // 주어진 이수구분 네 가지 중에서 선택했을 경우

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
                    {   // 전체를 선택했을 경우
                        totalStorage.searchResult.CompleteType = "";
                        isEnter = true;
                    }
                    else
                    {
                        totalStorage.searchResult.CompleteType = completeType[choosedIndex];
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

            input = exceptionHandler.IsValidInput(regex, consoleColumn, consoleRow, 36, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

            if(input == ConstantNumber.ESC)
            {   // 중간에 ESC를 눌렀을 경우
                input = ""; 
                isESC = true;
                Console.SetCursorPosition(consoleColumn + 13, consoleRow);
                guidancePhrase.ErasePrint();
                guidancePhrase.ErasePrint();
            }
            isESC = false;
            return input;
        }

        private void FindSearchResult()
        {   // 검색 결과에 해당하는 책을 찾는 함수
            ConsoleKeyInfo keyInfo;

            bool isESC = false;

            lectureDisplay.PrintSearchLectureUI();

            for (int i = 0; i < totalStorage.lecture.Count; i++)
            {
                if (totalStorage.lecture[i].Major.Contains(totalStorage.searchResult.Major)
                && totalStorage.lecture[i].CourseNumber.Contains(totalStorage.searchResult.CourseNumber)
                && totalStorage.lecture[i].LectureTitle.Contains(totalStorage.searchResult.LectureTitle)
                && totalStorage.lecture[i].Professor.Contains(totalStorage.searchResult.Professor)
                && totalStorage.lecture[i].Grade.Contains(totalStorage.searchResult.Grade)
                && totalStorage.lecture[i].CompleteType.Contains(totalStorage.searchResult.CompleteType))
                {   // 검색 결과에 모두 해당한다면
                    lectureDisplay.PrintSearchLecture(totalStorage.lecture[i]);
                }
            }
            lectureDisplay.PrintLine();
        }
    }
}
