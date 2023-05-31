using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.APIAccess
{
    public class NaverBookSearch
    {

        private RequestmentBook requestmentBook;
        public NaverBookSearch()
        {
            requestmentBook = new RequestmentBook();
        }

        public void EnterNaverSearch(int entryType, string userId)
        {   // 네이버 API의 연결을 통해 책 검색
            string bookInformation;
            int bookCount;

            string isESC;

            bool isEnterESC = true;

            List<BookDTO> books = new List<BookDTO>();

            Console.SetWindowSize(76, 40);

            PrintBookInformation.GetPrintBookInformation().PrintNaverSearch();

            while (isEnterESC)
            {
                bookInformation = EnterBookInformation();   // 찾고자 하는 책의 정보를 입력받는 메소드 호출
                if (bookInformation == Constant.ESC_STRING)
                {
                    isEnterESC = false;
                    continue;
                }

                bookCount = EnterBookCount();       // 찾을 책의 수량을 입력받는 메소드 호출
                if (bookCount == Constant.EXIT_INT)
                {
                    isEnterESC = false;
                    continue;
                }

                PrintBookInformation.GetPrintBookInformation().PrintNaverSearchResult();
                books = SearchBook(bookInformation, bookCount);     // 네이버 API 연결을 통해 책을 검색하는 메소드 호출
                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, bookInformation, Constant.NAVER_SEARCH);   // 책을 검색한 로그 찍기
                PrintBookInformation.GetPrintBookInformation().PrintRequestBookList(books);
                Console.SetCursorPosition(0, 0);

                if(entryType == (int)MODE.MANAGER)
                {       // 매니저 모드에서 진입했다면
                    PrintBookInformation.GetPrintBookInformation().PrintEraseRequest();        // 책 요청은 불가능하기 때문에 UI에서 책 요청 지우기
                    isESC = InputFromUser.GetInputFromUser().InputEnterESC();
                    return;
                }
                isESC = InputFromUser.GetInputFromUser().InputEnterESC();
                EnterRequestMenu(isESC, books, userId);
            }
        }

        private string EnterBookInformation()
        {
            string bookInformation = null;

            bool isESC = true;

            int column = 13;
            int row = 1;
           
            while(isESC)
            {
                isESC = false;

                bookInformation = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
                // 책 정보를 입력받는 메소드 호출
                if(bookInformation == Constant.ESC_STRING)
                {
                    return Constant.ESC_STRING;
                }

                else if(bookInformation == " " || bookInformation == "")    // 공백이 입력됐을 경우 예외처리
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
            int column = 13;
            int row = 2;

            while (isESC)
            {
                count = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);
                // 책의 수량을 입력받는 메소드 호출
                if (count == Constant.ESC_STRING)
                {
                    return Constant.EXIT_INT;
                }
                else if (!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(count) || count == "")
                {   // 숫자로 이루어지지 않았거나 엔터 값이 들어가 있을 경우 예외 처리
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                bookCount = Convert.ToInt32(count);

                if (bookCount > 100 || bookCount < 0)
                {   // 0부터 100 사이의 값이 아닐 경우 예외 처리
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
            // 입력받은 값을 네이버 API에 전송해 그걸 바탕으로 검색 값 받아오기
            return books;
        }

        private void EnterRequestMenu(string enterValue, List<BookDTO> books, string userId)
        {
            switch(enterValue)
            {
                case Constant.ESC_STRING:
                    return;
                case Constant.ENTER_STRING:
                    requestmentBook.RequestBook(books, userId);     // 엔터를 눌렀을 경우에만 책 요청 메뉴로 진입 가능
                    break;
            }
        }
    }
}
