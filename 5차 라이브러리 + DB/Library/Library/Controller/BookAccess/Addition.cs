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

        public void AddBook()       // 책 추가
        {
            string successAddBook = "";
            bool isNotESC = true;

            Console.SetWindowSize(73, 40);
            Console.Clear();

            MainView.PrintBox(3);
            PrintBookInformation.PrintAddTheBookUI();

            successAddBook = InputBookInformation();        // 추가할 책의 정보를 입력받는 메소드 호출
            if (successAddBook == Constant.ESC_STRING)      // 중간에 ESC를 입력받았다면
            {
                return;         // 뒤로가기
            }
        }

        private string InputBookInformation()
        {
            string inputValue;
            BookDTO book = new BookDTO();

            int column = 20;
            int row = 12;

            book.Title = ExceptionHandler.IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD); 
            // 값 입력
            if (book.Title == Constant.ESC_STRING)      // 중간에 ESC 입력
            {
                return book.Title;
            }

            book.Author = ExceptionHandler.IsValidInput(Constant.AUTHOR, column, row + 1, 20, Constant.IS_NOT_PASSWORD);
            if (book.Author == Constant.ESC_STRING)
            {
                return book.Author;
            }

            book.Publisher = ExceptionHandler.IsValidInput(Constant.ONEVALUE, column, row + 2, 20, Constant.IS_NOT_PASSWORD);
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

            book.PublishDate = ExceptionHandler.IsValidInput(Constant.PUBLISHDATE, column, row + 5, 20, Constant.IS_NOT_PASSWORD);
            if(book.PublishDate == Constant.ESC_STRING)
            {
                return book.PublishDate;
            }

            book.ISBN = ExceptionHandler.IsValidInput(Constant.ISBN, column, row + 6, 20, Constant.IS_NOT_PASSWORD);
            if (book.ISBN == Constant.ESC_STRING)
            {
                return book.ISBN;
            }

            book.Information = ExceptionHandler.IsValidInput(Constant.INFORMATION, column, row + 7, 20, Constant.IS_NOT_PASSWORD);
            if(book.Information == Constant.ESC_STRING)
            {
                return book.Information;
            }

            inputValue = InputFromUser.InputEnterESC();

            if(inputValue == Constant.ESC_STRING)
            {
                return Constant.ESC_STRING;
            }
            AccessorData.InsertBookData(book);
            PrintBookInformation.PrintSuccessAddBook();
            InputFromUser.EnteredESC();
            return Constant.SUCCESS.ToString();
        }

        private int ValidPrice(int column, int row)        // 가격 입력받는 부분에서 올바른 값이 들어왔는지 확인하는 메소드
        {
            string price;
            int priceNumber = 0;
            bool isNotSuccess = true;

            while (isNotSuccess)
            {
                price = ExceptionHandler.IsValidInput(Constant.PRICE, column, row, 20, Constant.IS_NOT_PASSWORD);
                if(price == Constant.ESC_STRING)        // 중간에 ESC 입력
                {
                    return Constant.EXIT_INT;
                }
                else if ((!ExceptionHandler.IsStringAllNumber(price)) || price == "")        // 숫자로 구성된 값이 아닐 때
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
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
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                isNotSuccess = false;
            }
            return amount;
        }
    }
}
