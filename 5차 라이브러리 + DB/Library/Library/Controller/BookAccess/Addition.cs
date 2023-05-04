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

        public void AddBook()
        {
            string successAddBook = "";
            bool isNotESC = true;

            Console.SetWindowSize(73, 40);
            Console.Clear();

            MainView.PrintBox(3);
            PrintBookInformation.PrintAddTheBookUI();

            successAddBook = InputBookInformation();
            if (successAddBook == Constant.ESC_STRING)
            {
                return;
            }
        }

        private string InputBookInformation()
        {
            string inputValue;
            BookDTO book = new BookDTO();

            int column = 20;
            int row = 12;

            book.Title = ExceptionHandler.IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
            if (book.Title == Constant.ESC_STRING)
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

            book.Price = ValidPrice();
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
            return Constant.SUCCESS.ToString();
        }

        private int ValidPrice()
        {
            int column = 20;
            int row = 16;

            string price;
            int priceNumber = 0;
            bool isNotSuccess = true;

            while (isNotSuccess)
            {
                price = ExceptionHandler.IsValidInput(Constant.PRICE, column, row, 20, Constant.IS_NOT_PASSWORD);
                if(price == Constant.ESC_STRING)
                {
                    return Constant.EXIT_INT;
                }
                else if (!ExceptionHandler.IsStringAllNumber(price))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                priceNumber = int.Parse(price);
                isNotSuccess = false;
            }
            return priceNumber;
        }
        private int ValidAmount()
        {
            int column = 20;
            int row = 15;

            string amount;
            int amountCount = 0;
            bool isNotSuccess = true;

            while (isNotSuccess)
            {
                amount = ExceptionHandler.IsValidInput(Constant.AMOUNT, column, row, 3, Constant.IS_NOT_PASSWORD);
                if(amount == Constant.ESC_STRING)
                {
                    return Constant.EXIT_INT;
                }
                else if (!ExceptionHandler.IsStringAllNumber(amount))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                else if(int.Parse(amount) <= 0 || int.Parse(amount) >= 1000)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                amountCount = int.Parse(amount);
                isNotSuccess = false;
            }
            return amountCount;
        }
    }
}
