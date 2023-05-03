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
        public void SearchBook(int entryType)
        {
            bool isNotESC = true;

            int row = 6;

            while(isNotESC)
            {
                Console.SetWindowSize(100, 30);
                Console.Clear();
                PrintBookInformation.PrintFindingBookUI();

                List<BookDTO> books = AccessorData.AllBookData();

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
                {
                    isNotESC = false;
                    continue;
                }
                else if(searchResult.Title == "" && searchResult.Author == "" && searchResult.Publisher == "")
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_KEYWORD, 0, row);
                    continue;
                }

                books = AccessorData.SelectBookData(searchResult.Title, searchResult.Author, searchResult.Publisher);

                if(books.Count == 0)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_SEARCH_BOOK, 0, row);
                    continue;
                }
                if(entryType == (int)USERMENU.FIND)
                {
                    Console.Clear();
                    GuidancePhrase.PrintEsc();
                }
                else
                {
                    PrintBookInformation.PrintRenttheBookUI();
                }
                for(int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.PrintBookList(books[i]);
                }
                isNotESC = !InputFromUser.EnteredESC();
            }
        }

        private SearchResult InputBookKeyWord(SearchResult searchResult)
        {
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
