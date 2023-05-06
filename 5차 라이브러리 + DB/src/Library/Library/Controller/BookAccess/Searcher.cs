using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.BookAccess
{
    public class Searcher
    {
        PrintBookInformation printBookInformation;
        AccessorData accessorData;
        ExceptionHandler exceptionHandler;
        InputFromUser inputFromUser;

        public Searcher()
        {
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            accessorData = AccessorData.GetAccessorData();
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            inputFromUser = InputFromUser.GetInputFromUser();
        }
        public List<BookDTO> SearchBook(int entryType)      // 책 검색하는 메소드
        {
            bool isNotESC = true;

            int row = 6;
            List<BookDTO> books = null;
            while (isNotESC)
            {
                Console.SetWindowSize(100, 30);
                Console.Clear();
                PrintBookInformation.PrintFindingBookUI();

                books = AccessorData.AllBookData();         // 모든 책에 대한 데이터

                for(int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.PrintBookList(books[i]);
                }
                Console.SetCursorPosition(0, 0);

                SearchResult searchResult = new SearchResult();
                searchResult = InputBookKeyWord(searchResult);

                if(searchResult.Title == Constant.ESC_STRING 
                    || searchResult.Author == Constant.ESC_STRING
                    || searchResult.Publisher == Constant.ESC_STRING)
                {       // 중간에 ESC가 입력되었다면
                    isNotESC = false;
                    books[0].Title = Constant.ESC_STRING;
                    continue;
                }

                else if(searchResult.Title == "" && searchResult.Author == "" && searchResult.Publisher == "")
                {       // 아무 값도 입력되지 않았다면
                    continue;
                }

                books = AccessorData.SelectBookData(searchResult.Title, searchResult.Author, searchResult.Publisher);
                // 검색 결과와 일치하는 책 찾기
                if(books.Count == 0)
                {   // 검색 결과와 일치하는 값이 없다면
                    Console.Clear();
                    PrintBookInformation.PrintFindingBookUI();
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_SEARCH_BOOK, 1, row + 2);
                    continue;
                }
                if(entryType == (int)USERMENU.FIND
                    || entryType == (int)MANAGERMODE.FIND)
                {   // 책 찾기 모드에서 들어왔다면
                    Console.Clear();
                    GuidancePhrase.PrintEsc();
                }
                else
                {   // 책 빌리는 메뉴에서 들어왔다면
                    PrintBookInformation.PrintRentReturnUI(Constant.RENT);
                }
                for(int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.PrintBookList(books[i]);
                    isNotESC = false;
                }
                if (entryType == (int)USERMENU.FIND
                    || entryType == (int)MANAGERMODE.FIND)
                {
                    isNotESC = !InputFromUser.EnteredESC();
                }
            }
            return books;
        }

        private SearchResult InputBookKeyWord(SearchResult searchResult)
        {       // 책 검색 키워드 입력
            int column = 19;
            int row = 0;

            searchResult.Title = ExceptionHandler.IsValidInput(Constant.ONEVALUE, column, row, 50, Constant.IS_NOT_PASSWORD);
            if(searchResult.Title == Constant.ESC_STRING) 
            {
                return searchResult;
            }

            searchResult.Author = ExceptionHandler.IsValidInput(Constant.ONEVALUE, column, row + 1, 50, Constant.IS_NOT_PASSWORD);
            if (searchResult.Author == Constant.ESC_STRING)
            {
                return searchResult;
            }

            searchResult.Publisher = ExceptionHandler.IsValidInput(Constant.ONEVALUE, column, row + 2, 50, Constant.IS_NOT_PASSWORD);
            if (searchResult.Publisher == Constant.ESC_STRING)
            {
                return searchResult;
            }

            return searchResult;
        }
    }
}
