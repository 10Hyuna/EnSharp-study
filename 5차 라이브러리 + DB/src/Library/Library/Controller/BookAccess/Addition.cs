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
    public class Addition
    {
        MainView mainView;
        PrintBookInformation printBookInformation;
        ExceptionHandler exceptionHandler;
        GuidancePhrase guidancePhrase;
        InputFromUser inputFromUser;
        AccessorData accessorData;
        public Addition()
        {
            mainView = MainView.SetMainView();
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            exceptionHandler = ExceptionHandler.GetExceptionHandler();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            inputFromUser = InputFromUser.GetInputFromUser();
            accessorData = AccessorData.GetAccessorData();
        }

        public void AddRequestedBook()
        {
            List<BookDTO> books = new List<BookDTO>();
            BookDTO requestedBook = new BookDTO();
            bool isESC = true;

            string title = "";

            int column = 18;
            int row = 3;

            while (isESC)
            {
                isESC = false;
                Console.SetWindowSize(76, 40);

                Console.Clear();
                PrintBookInformation.GetPrintBookInformation().PrintAddBookTitle();

                books = AccessorData.GetAccessorData().SelectRequestBook();
                Console.SetCursorPosition(0, 6);
                PrintBookInformation.GetPrintBookInformation().PrintRequestBookList(books);

                Console.SetCursorPosition(0, 0);
                title = InputRequestedBookTitle();  // 추가하고자 하는 책의 정보를 입력받을 수 있는 메소드
                if(title == Constant.ESC_STRING)
                {
                    continue;
                }

                requestedBook = AccessorData.GetAccessorData().SelectRequestedBook(title);
                // 입력받은 책의 제목을 포함하는 책 정보를 찾음
                if(requestedBook.Title == null)
                {   // 입력받은 책의 제목을 포함하는 책이 없을 경우 예외 처리
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.INVALID_BOOK, column, row);
                    isESC = true;
                    continue;
                }

                AccessorData.GetAccessorData().InsertBookData(requestedBook);   // 책 추가
                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.ADD_BOOK, requestedBook.Title);    // 책 추가 로그 찍기
                AccessorData.GetAccessorData().DeleteRequestBook(requestedBook.Title);  // 요청된 책 목록에서 책 삭제
                PrintBookInformation.GetPrintBookInformation().PrintSuccessAddBook();
                isESC = true;
            }
        }

        public void AddBook()       // 책 추가
        {
            string successAddBook = "";

            Console.SetWindowSize(73, 40);
            Console.Clear();

            MainView.SetMainView().PrintBox(3);
            PrintBookInformation.GetPrintBookInformation().PrintAddTheBookUI();

            successAddBook = InputBookInformation();        // 추가할 책의 정보를 입력받는 메소드 호출
            if (successAddBook == Constant.ESC_STRING)      // 중간에 ESC를 입력받았다면
            {
                return;         // 뒤로가기
            }
        }

        private string InputRequestedBookTitle()
        {
            string title = null;

            int column = 18;
            int row = 3;

            bool isESC = true;

            while (isESC)
            {
                isESC = false;

                title = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
                // 공백 입력 불가능
                if (title == Constant.ESC_STRING)
                {
                    continue;
                }
                else if (title == "")
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
            }
            return title;
        }

        private string InputBookInformation()
        {
            string inputValue;
            BookDTO book = new BookDTO();

            int column = 20;
            int row = 12;

            book.Title = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD); 
            // 값 입력
            // 공백 입력 불가능하도록 함수 구현

            if (book.Title == Constant.ESC_STRING)      // 중간에 ESC 입력
            {
                return book.Title;
            }

            book.Author = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.AUTHOR, column, row + 1, 20, Constant.IS_NOT_PASSWORD);
            if (book.Author == Constant.ESC_STRING)
            {
                return book.Author;
            }

            book.Publisher = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.ONEVALUE, column, row + 2, 20, Constant.IS_NOT_PASSWORD);
            if(book.Publisher == Constant.ESC_STRING)
            {
                return book.Publisher;
            }

            book.Amount = ValidAmount();
            if(book.Amount == Constant.EXIT_INT)
            {
                return Constant.ESC_STRING;
            }

            book.Price = ValidPrice(20, 16);
            if(book.Price == Constant.EXIT_INT)
            {
                return Constant.ESC_STRING;
            }

            book.PublishDate = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.PUBLISHDATE, column, row + 5, 20, Constant.IS_NOT_PASSWORD);
            if(book.PublishDate == Constant.ESC_STRING)
            {
                return book.PublishDate;
            }

            book.ISBN = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.ISBN, column, row + 6, 20, Constant.IS_NOT_PASSWORD);
            if (book.ISBN == Constant.ESC_STRING)
            {
                return book.ISBN;
            }

            book.Information = ExceptionHandler.GetExceptionHandler().BlockEmptyString(Constant.INFORMATION, column, row + 7, 20, Constant.IS_NOT_PASSWORD);
            if(book.Information == Constant.ESC_STRING)
            {
                return book.Information;
            }

            inputValue = InputFromUser.GetInputFromUser().InputEnterESC();

            if(inputValue == Constant.ESC_STRING)
            {
                return Constant.ESC_STRING;
            }
            AccessorData.GetAccessorData().InsertBookData(book);
            LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.ADD_BOOK, book.Title);
            PrintBookInformation.GetPrintBookInformation().PrintSuccessAddBook();
            InputFromUser.GetInputFromUser().EnteredESC();
            return Constant.SUCCESS.ToString();
        }

        private int ValidPrice(int column, int row)        // 가격 입력받는 부분에서 올바른 값이 들어왔는지 확인하는 메소드
        {
            string price;
            int priceNumber = 0;
            bool isSuccess = true;

            while (isSuccess)
            {
                isSuccess = false;
                price = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.PRICE, column, row, 20, Constant.IS_NOT_PASSWORD);
                if(price == Constant.ESC_STRING)        // 중간에 ESC 입력
                {
                    return Constant.EXIT_INT;
                }
                else if ((!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(price)) || price == "")        // 숫자로 구성된 값이 아닐 때
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isSuccess = true;
                    continue;
                }
                priceNumber = int.Parse(price);
            }
            return priceNumber;
        }
        private int ValidAmount()       // 수량 입력받는 부분에서 올바른 값이 들어 왔지 확인하는 메소드
        {
            int column = 20;
            int row = 15;

            int amount = 0;
            bool isSuccess = true;

            while (isSuccess)
            {
                isSuccess = false;
                amount = ValidPrice(column, row);
                if(amount == Constant.EXIT_INT)
                {
                    return Constant.EXIT_INT;
                }

                if(amount <= 0 || amount >= 1000)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isSuccess = true;
                    continue;
                }
            }
            return amount;
        }
    }
}
