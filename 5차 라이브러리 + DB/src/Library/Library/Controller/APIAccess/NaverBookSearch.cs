using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.APIAccess
{
    public class NaverBookSearch
    {

        public void EnterNaverSearch()
        {
            string bookInformation;
            int bookCount;

            List<BookDTO> books = new List<BookDTO>();

            Console.SetWindowSize(76, 40);

            PrintBookInformation.GetPrintBookInformation().PrintNaverSearch();
            bookInformation = EnterBookInformation();
            bookCount = EnterBookCount();
            PrintBookInformation.GetPrintBookInformation().PrintNaverSearchResult();
            books = SearchBook(bookInformation, bookCount);
            for(int i = 0; i < books.Count; i++)
            {
                PrintBookInformation.GetPrintBookInformation().PrintBookList(books[i]);
            }
            Console.ReadKey(true);
        }

        private string EnterBookInformation()
        {
            string bookInformation = null;

            bool isESC = true;

            int column = 14;
            int row = 1;
           
            while(isESC)
            {
                isESC = false;

                bookInformation = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
                
                if(bookInformation == Constant.ESC_STRING)
                {
                    continue;
                }

                else if(bookInformation == " " || bookInformation == "")
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }                
                isESC = false;
            }
            return bookInformation;
        }

        private int EnterBookCount()
        {
            bool isESC = true;
            string count;

            int bookCount = 0;
            int column = 14;
            int row = 2;

            while (isESC)
            {
                count = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);

                if (count == Constant.ESC_STRING)
                {
                    continue;
                }
                else if (!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(count))
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                bookCount = Convert.ToInt32(count);

                if (bookCount > 100 || bookCount < 0)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_COUNT, column, row);
                    isESC = true;
                    continue;
                }
                isESC = false;
            }
            return bookCount;
        }
        private List<BookDTO> SearchBook(string bookInformation, int bookCount)
        {
            bool isESC = true;
            List<BookDTO> books = new List<BookDTO>();

            books = DataParse.GetDataParse().ReturnSearchResult(bookInformation, bookCount);

            return books;
        }
    }
}
