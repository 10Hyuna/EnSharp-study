using Library.Model.DTO;
using Library.Model;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Utility;
using System.Text.RegularExpressions;

namespace Library.Controller
{
    class BookAccessInManager
    {
        public BookAccessInManager()
        {

        }

        private void RentalStateInBorrowBook(int index)
        {
            int id = 0;
            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";
            string ISBN = "";
            string information = "";
            string borrowTime = "";
            string returnTime = "";

            for (int j = 0; j < totalStorage.users[index].BorrowDatas.Count; j++)
            {
                BorrowBookList rentalBook = totalStorage.users[index].BorrowDatas[j];
                id = rentalBook.GetBorrowId();
                title = rentalBook.GetBorrowTitle();
                author = rentalBook.GetBorrowAuthor();
                publisher = rentalBook.GetBorrowPublisher();
                amount = rentalBook.GetBorrowAmount();
                price = rentalBook.GetBorrowPrice();
                publishDay = rentalBook.GetBorrowPublishDay();
                ISBN = rentalBook.GetBorrowISBN();
                information = rentalBook.GetBorrowInformation();
                borrowTime = rentalBook.GetBorrowBorrowTime();

                printerUserInformation.PrintUserId(totalStorage.users[index].GetUserId());
                printerUserInformation.PrintRentalList(id, title, author, publisher, amount, price, publishDay,
                    ISBN, information, borrowTime, returnTime);
            }
        }

        public void AddTheBook()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            const int ConsoleInputRow = 44;
            const int ConsoleInputColumn = 12;

            isInputESC = false;

            string title;
            string author;
            string publisher;
            string amount;
            string price;
            string publishDay;
            string ISBN;
            string information;

            Console.Clear();
            ui.PrintBox(6);
            printBookInformation.PrintAddTheBookUI();

            title = handlingException.IsValid(regex.title, ConsoleInputRow, ConsoleInputColumn, 20, false);
            if (title == null)
                return;

            author = handlingException.IsValid(regex.author, ConsoleInputRow, ConsoleInputColumn + 1, 20, false);
            if (author == null)
                return;
            publisher = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 2, 20, false);
            if (publisher == null)
                return;

            amount = handlingException.IsValid(regex.amount, ConsoleInputRow, ConsoleInputColumn + 3, 20, false);
            if (amount == null)
                return;
            if (int.Parse(amount) <= 0 || int.Parse(amount) >= 1000)
            {
                ui.PrintException(ConstantNumber.VALIDVALUE);
            }

            price = handlingException.IsValid(regex.price, ConsoleInputRow, ConsoleInputColumn + 4, 7, false);
            if (price == null)
                return;
            if (int.Parse(price) <= 0 || int.Parse(price) >= 100000000)
            {
                ui.PrintException(ConstantNumber.VALIDVALUE);
            }
            publishDay = handlingException.IsValid(regex.publishDay, ConsoleInputRow, ConsoleInputColumn + 5, 11, false);
            if (publishDay == null)
                return;

            ISBN = handlingException.IsValid(regex.ISBN, ConsoleInputRow, ConsoleInputColumn + 6, 20, false);
            if (ISBN == null)
                return;
            information = handlingException.IsValid(regex.information, ConsoleInputRow, ConsoleInputColumn + 7, 20, false);
            if (information == null)
                return;

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                totalInformationStorage.books.Add(new Book(totalInformationStorage.books.Count, title, author, publisher,
                    amount, price, publishDay, ISBN, information));
            }
            Console.Clear();
            ui.PrintBox(6);
            printBookInformation.PrintSuccessAddBook();

            while (isInputESC)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                }
                else
                {
                    Console.SetCursorPosition(34, 25);
                    ui.PrintException(ConstantNumber.NOTMATCHEDCONDITION);
                }
            }
        }

        public void DeleteTheBook()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            bool isValidId = false;

            int consoleInputRow = 60;
            int consoleInputColumn = 3;
            string deleteBookId = "";

            int id = 0;
            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";
            string ISBN = "";
            string information = "";

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintDeleteTheBookUI();
                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    id = totalInformationStorage.books[i].id;
                    title = totalInformationStorage.books[i].title;
                    author = totalInformationStorage.books[i].author;
                    publisher = totalInformationStorage.books[i].publisher;
                    amount = totalInformationStorage.books[i].amount;
                    price = totalInformationStorage.books[i].price;
                    publishDay = totalInformationStorage.books[i].publishDay;
                    ISBN = totalInformationStorage.books[i].ISBN;
                    information = totalInformationStorage.books[i].information;

                    printBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);
                }
                Console.SetCursorPosition(0, 0);
                deleteBookId = handlingException.IsValid(regex.containedOneValue, consoleInputRow, consoleInputColumn, 4, false);

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    if (int.Parse(deleteBookId) == totalInformationStorage.books[i].id)
                    {
                        totalInformationStorage.books.RemoveAt(i);
                        isValidId = true;
                    }
                }

                if (!isValidId)
                {
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                    Console.ForegroundColor = ConsoleColor.Red;
                    ui.PrintException(ConstantNumber.INVALIDBOOKID);
                    Console.ResetColor();
                    continue;
                }

                Console.Clear();
                printBookInformation.PrintSuccessDeleteBook();

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    id = totalInformationStorage.books[i].id;
                    title = totalInformationStorage.books[i].title;
                    author = totalInformationStorage.books[i].author;
                    publisher = totalInformationStorage.books[i].publisher;
                    amount = totalInformationStorage.books[i].amount;
                    price = totalInformationStorage.books[i].price;
                    publishDay = totalInformationStorage.books[i].publishDay;
                    ISBN = totalInformationStorage.books[i].ISBN;
                    information = totalInformationStorage.books[i].information;

                    printBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOTMATCHEDCONDITION);
                }
            }
        }
        private int EnterEsc(string input)
        {
            if (input == null)
            {
                return ConstantNumber.EXIT;
            }
            return ConstantNumber.SUCCESS;
        }
        private string ModifyTitle()
        {
            consoleInputRow = 68;
            consoleInputColumn = 7;

            string input = "";

            input = handlingException.IsValid(regex.title, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyAuthor()
        {
            consoleInputRow = 68;
            consoleInputColumn = 8;

            string input = "";

            input = handlingException.IsValid(regex.author, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyPublisher()
        {
            consoleInputRow = 68;
            consoleInputColumn = 9;

            string input = "";

            input = handlingException.IsValid(regex.containedOneValue, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyAmount()
        {
            consoleInputRow = 68;
            consoleInputColumn = 10;

            string input = "";

            input = handlingException.IsValid(regex.amount, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyPrice()
        {
            consoleInputRow = 68;
            consoleInputColumn = 11;

            string input = "";

            input = handlingException.IsValid(regex.price, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyPublishDay()
        {
            consoleInputRow = 68;
            consoleInputColumn = 12;

            string input = "";

            input = handlingException.IsValid(regex.publishDay, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        public void ModifyBook(int bookIndex)
        {
            int index = 0;
            int selectedMenu = 0;
            int validInput = 0;

            int WindowCenterWidth = 30;
            int WindowCenterHeight = 7;

            bool isInputEnter = false;

            string[] menu = {"책 제목 (영어, 한글, 숫자 1개 이상 ) :", "작가 (영어, 한글 1개 이상) :",
                "출판사 (영어, 한글, 숫자 1개 이상) :", "수량 ( 1 ~ 999 ) :",
                "가격 ( 1 ~ 9999999 ) :","출시일 ( 19xx or 20xx-xx-xx ) :", "책 정보 수정하기"};

            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";

            while (!isInputEnter)
            {
                validInput = 0;

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);

                switch (selectedMenu)
                {
                    case ConstantNumber.MODIFYTITLE:
                        title = ModifyTitle();
                        validInput = EnterEsc(title);
                        break;
                    case ConstantNumber.MODIFYAUTHOR:
                        author = ModifyAuthor();
                        validInput = EnterEsc(author);
                        break;
                    case ConstantNumber.MODIFYPUBLISHER:
                        publisher = ModifyPublisher();
                        validInput = EnterEsc(publisher);
                        break;
                    case ConstantNumber.MODIFYAMOUNT:
                        amount = ModifyAmount();
                        validInput = EnterEsc(amount);
                        break;
                    case ConstantNumber.MODIFYPRICE:
                        price = ModifyPrice();
                        validInput = EnterEsc(price);
                        break;
                    case ConstantNumber.MODIFTPUBLISHDAY:
                        publishDay = ModifyPublishDay();
                        validInput = EnterEsc(publishDay);
                        break;
                    case ConstantNumber.MODIFYSUCCESS:
                        isInputEnter = true;
                        break;
                }
                if (isInputEnter)
                {
                    if (title != "")
                    {
                        totalInformationStorage.books[index].title = title;
                    }
                    if (author != "")
                    {
                        totalInformationStorage.books[index].author = author;
                    }
                    if (publisher != "")
                    {
                        totalInformationStorage.books[index].publisher = publisher;
                    }
                    if (amount != "")
                    {
                        totalInformationStorage.books[index].amount = amount;
                    }
                    if (price != "")
                    {
                        totalInformationStorage.books[index].price = price;
                    }
                    if (publishDay != "")
                    {
                        totalInformationStorage.books[index].publishDay = publishDay;
                    }
                }

                if (validInput == ConstantNumber.EXIT)
                {
                    isInputEnter = true;
                }
            }
        }
        public void EnterMenuModifyTheBook()
        {
            bool isValidId = false;

            int consoleInputRow = 60;
            int consoleInputColumn = 3;
            int bookIndex = 0;

            string modifyBookId = "";
            int modifyBookIdNumber = 0;

            int id = 0;
            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";
            string ISBN = "";
            string information = "";

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintModifyBookInformationUI();

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    id = totalInformationStorage.books[i].id;
                    title = totalInformationStorage.books[i].title;
                    author = totalInformationStorage.books[i].author;
                    publisher = totalInformationStorage.books[i].publisher;
                    amount = totalInformationStorage.books[i].amount;
                    price = totalInformationStorage.books[i].price;
                    publishDay = totalInformationStorage.books[i].publishDay;
                    ISBN = totalInformationStorage.books[i].ISBN;
                    information = totalInformationStorage.books[i].information;

                    printBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);

                }

                Console.SetCursorPosition(0, 0);
                modifyBookId = handlingException.IsValid(regex.containedOneValue, consoleInputRow, consoleInputColumn, 20, false);
                modifyBookIdNumber = int.Parse(modifyBookId);

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    if (totalInformationStorage.books[i].id == modifyBookIdNumber)
                    {
                        bookIndex = i;
                        isValidId = true;
                        break;
                    }
                }

                if (!isValidId)
                {
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                    Console.ForegroundColor = ConsoleColor.Red;
                    ui.PrintException(ConstantNumber.INVALIDBOOKID);
                    Console.ResetColor();
                    continue;
                }
                ModifyBook(bookIndex);
                break;
            }
        }
    }
}
