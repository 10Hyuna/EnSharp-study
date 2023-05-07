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

            Console.SetWindowSize(76, 40);
            Console.Clear();

            PrintBookInformation.GetPrintBookInformation().PrintAddBookTitle();

            while (isESC)
            {
                isESC = false;

                books = AccessorData.GetAccessorData().SelectRequestBook();
                Console.SetCursorPosition(0, 6);
                PrintBookInformation.GetPrintBookInformation().PrintRequestBookList(books);

                Console.SetCursorPosition(0, 0);
                title = InputRequestedBookTitle();
                if(title == Constant.ESC_STRING)
                {
                    continue;
                }

                requestedBook = AccessorData.GetAccessorData().SelectRequestedBook(title);

                if(requestedBook.Title == null)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.INVALID_BOOK, column, row);
                    isESC = true;
                    continue;
                }

                AccessorData.GetAccessorData().InsertBookData(requestedBook);
                AccessorData.GetAccessorData().DeleteRequestBook(requestedBook.Title);
                PrintBookInformation.GetPrintBookInformation().PrintSuccessAddBook();
                isESC = true;
            }
        }

        public void AddBook()       // 책 추가
        {
            string successAddBook = "";
            bool isNotESC = true;

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

                title = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
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

            book.Title = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD); 
            // 값 입력
            if (book.Title == Constant.ESC_STRING)      // 중간에 ESC 입력
            {
                return book.Title;
            }

            book.Author = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.AUTHOR, column, row + 1, 20, Constant.IS_NOT_PASSWORD);
            if (book.Author == Constant.ESC_STRING)
            {
                return book.Author;
            }

            book.Publisher = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.ONEVALUE, column, row + 2, 20, Constant.IS_NOT_PASSWORD);
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

            book.PublishDate = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.PUBLISHDATE, column, row + 5, 20, Constant.IS_NOT_PASSWORD);
            if(book.PublishDate == Constant.ESC_STRING)
            {
                return book.PublishDate;
            }

            book.ISBN = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.ISBN, column, row + 6, 20, Constant.IS_NOT_PASSWORD);
            if (book.ISBN == Constant.ESC_STRING)
            {
                return book.ISBN;
            }

            book.Information = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.INFORMATION, column, row + 7, 20, Constant.IS_NOT_PASSWORD);
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
            PrintBookInformation.GetPrintBookInformation().PrintSuccessAddBook();
            InputFromUser.GetInputFromUser().EnteredESC();
            return Constant.SUCCESS.ToString();
        }

        private int ValidPrice(int column, int row)        // 가격 입력받는 부분에서 올바른 값이 들어왔는지 확인하는 메소드
        {
            string price;
            int priceNumber = 0;
            bool isNotSuccess = true;

            while (isNotSuccess)
            {
                price = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.PRICE, column, row, 20, Constant.IS_NOT_PASSWORD);
                if(price == Constant.ESC_STRING)        // 중간에 ESC 입력
                {
                    return Constant.EXIT_INT;
                }
                else if ((!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(price)) || price == "")        // 숫자로 구성된 값이 아닐 때
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                priceNumber = int.Parse(price);
                isNotSuccess = false;
            }
            return priceNumber;
        }
        private int ValidAmount()       // 수량 입력받는 부분에서 올바른 값이 들어 왔지 확인하는 메소드
        {
            int column = 20;
            int row = 15;

            int amount = 0;
            bool isNotSuccess = true;

            while (isNotSuccess)
            {
                amount = ValidPrice(column, row);

                if(amount <= 0 || amount >= 1000)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                isNotSuccess = false;
            }
            return amount;
        }
    }
}
