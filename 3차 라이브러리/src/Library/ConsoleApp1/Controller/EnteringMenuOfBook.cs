﻿using Library.Model;
using Library.Model.DTO;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Library.Utility;
using System.Data;

namespace Library.Controller
{
    class EnteringMenuOfBook
    {
        TotalInformationStorage totalInformationStorage;
        PrintingBookInformation printBookInformation;
        InputFromUser inputFromUser;
        UI ui;
        HandlingException handlingException;
        RegexStorage regex;
        MovingCurserPosition curser;

        public EnteringMenuOfBook(TotalInformationStorage totalInformationStorage,
            PrintingBookInformation printBookInformation, InputFromUser inputFromUser, UI ui,
            HandlingException handlingException, RegexStorage regex, MovingCurserPosition curser)
        {
            this.printBookInformation = printBookInformation;
            this.inputFromUser = inputFromUser;
            this.totalInformationStorage = totalInformationStorage;
            this.ui = ui;
            this.handlingException = handlingException;
            this.regex = regex;
            this.curser = curser;
        }

        ConsoleKeyInfo keyInfo;
        bool isInputESC = false;

        public int FindTheBookBySerching() // 찾고자 하는 책의 정보를 입력하는 함수
        {
            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            List<string> book;
            isInputESC = false;

            ConsoleKeyInfo keyInfo;

            while (!isInputESC)
            {
                Console.Clear();

                book = PrintTheAllBook();
                if (book == null)
                    return -1;

                printBookInformation.PrintFindingBookUI();
                selectedBook(book[0], book[1], book[2]);

                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
            return 0;
        }

        public List<string> PrintTheAllBook()      // 책 찾기 메뉴에 진입했을 경우
        {
            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            string inputTitle;
            string inputAuthor;
            string inputPublisher;

            int id = 0;
            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";
            string ISBN = "";
            string information = "";

            Console.Clear();
            printBookInformation.PrintFindingBookUI();

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

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            inputTitle = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn, 20, false);// 제목 입력
            if (inputTitle == null)
                return null;

            inputAuthor = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 1, 20, false);    // 작가 입력
            if (inputAuthor == null)
                return null;

            inputPublisher = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 2, 20, false);
            if (inputPublisher == null)
                return null;

            Console.Clear();

            return new List<string> { inputTitle, inputAuthor, inputPublisher };
        }

        public void selectedBook(string inputTitle, string inputAuthor, string inputPublisher)
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

            for (int i = 0; i < totalInformationStorage.books.Count; i++)
            {
                if (totalInformationStorage.books[i].title.Contains(inputTitle) 
                    && totalInformationStorage.books[i].author.Contains(inputAuthor) 
                    && totalInformationStorage.books[i].publisher.Contains(inputPublisher))
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

                    printBookInformation.PrintBookList(id, title, author, publisher,
                        amount, price, publishDay, ISBN, information);
                }
            }
        }

        public int RentTheBook()      // 책 대여 메뉴에 진입했을 때
        {
            const int consoleInputRow = 9;
            const int consoleInputColumn = 2;

            int bookIndex = -1;
            int userIndex = 0;

            int bookIdNum;
            int amount;

            string bookId;
            string amountBook;

            List<string> book;

            isInputESC = false;
            bool isLeakedBookAmount = false;
            bool isAlreadyRentBook = false;

            while (!isInputESC)
            {
                while (bookIndex == -1)
                {
                    Console.Clear();

                    book = PrintTheAllBook();

                    if (book == null)
                        return -1;

                    isLeakedBookAmount = true;

                    printBookInformation.PrintRenttheBookUI();

                    selectedBook(book[0], book[1], book[2]);
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                    bookId = handlingException.IsValid(regex.containedOneNumber, consoleInputRow, consoleInputColumn, 10, false);
                    if (bookId == null)
                        return -1;

                    bookIdNum = int.Parse(bookId);

                    for (int i = 0; i < totalInformationStorage.users.Count; i++)
                    {
                        if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                        {
                            userIndex = i;
                            for (int j = 0; j < totalInformationStorage.users[i].borrowDatas.Count; j++)
                            {
                                if (totalInformationStorage.users[i].borrowDatas[j].id == bookIdNum)
                                {
                                    ui.PrintException(ConstantNumber.ALREADYRENTBOOK);
                                    isAlreadyRentBook = true;
                                    break;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < totalInformationStorage.books.Count; i++)
                    {
                        if (bookIdNum == totalInformationStorage.books[i].id)
                        {
                            if (int.Parse(totalInformationStorage.books[i].amount) <= 0)
                            {
                                Console.Clear();
                                ui.PrintException(ConstantNumber.LEAKINGBOOKAMOUNT);
                                isLeakedBookAmount = false;
                                break;
                            }

                            isLeakedBookAmount = true;
                            bookIndex = i;
                            amount = int.Parse(totalInformationStorage.books[i].amount);
                            amount -= 1;
                            amountBook = Convert.ToString(amount);
                            totalInformationStorage.books[i].amount = amountBook;
                            break;
                        }
                    }

                    if (!isLeakedBookAmount)
                    {
                        continue;
                    }

                    if (bookIndex == -1)
                    {
                        ui.PrintException(ConstantNumber.INVALIDINFORMATION);
                        continue;
                    }

                    for (int i = 0; i < totalInformationStorage.users.Count; i++)
                    {
                        if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                        {
                            totalInformationStorage.users[userIndex].borrowDatas.Add(new BorrowBookList(totalInformationStorage.books[bookIndex].id,
                                totalInformationStorage.books[bookIndex].title, totalInformationStorage.books[bookIndex].author,
                                totalInformationStorage.books[bookIndex].publisher, totalInformationStorage.books[bookIndex].amount,
                                totalInformationStorage.books[bookIndex].price, totalInformationStorage.books[bookIndex].publishDay,
                                totalInformationStorage.books[bookIndex].ISBN, totalInformationStorage.books[bookIndex].information,
                                DateTime.Now.ToString()));
                            break;
                        }
                    }
                }
                Console.Clear();
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                ui.PrintException(ConstantNumber.SUCCESSBORROWBOOK);
                printBookInformation.PrintEsc();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isInputESC = true;
                }
            }                       // 반복문 탈출
            return 0;
        }

        public void CheckTheRentalBook()
        {
            isInputESC = false;
            int userIndex = 0;

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

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintRentalBookTitle();

                for (int j = 0; j < totalInformationStorage.users[userIndex].borrowDatas.Count; j++)
                {
                    id = totalInformationStorage.users[userIndex].borrowDatas[j].id;
                    title = totalInformationStorage.users[userIndex].borrowDatas[j].title;
                    author = totalInformationStorage.users[userIndex].borrowDatas[j].author;
                    publisher = totalInformationStorage.users[userIndex].borrowDatas[j].publisher;
                    amount = totalInformationStorage.users[userIndex].borrowDatas[j].amount;
                    price = totalInformationStorage.users[userIndex].borrowDatas[j].price;
                    publishDay = totalInformationStorage.users[userIndex].borrowDatas[j].publishDay;
                    ISBN = totalInformationStorage.users[userIndex].borrowDatas[j].ISBN;
                    information = totalInformationStorage.users[userIndex].borrowDatas[j].information;
                    borrowTime = totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime;

                    printBookInformation.PrintRentalBookListUI(id, title, author, publisher, amount, 
                        price, publishDay, ISBN, information, borrowTime);
                }
                Console.SetCursorPosition(0, 0);

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
        }

        public int ReturnTheBook()
        {
            const int consoleInputRow = 8;
            const int consoleInputColumn = 2;

            isInputESC = false;
            bool isValidBookInformation = false;

            string returnBookID;
            int returnBookIDNumber;
            int returnBookAmount = 0;
            int userIndex = 0;

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

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();

                printBookInformation.PrintReturnTheBookUI();
                for (int j = 0; j < totalInformationStorage.users[userIndex].borrowDatas.Count; j++)
                {
                    id = totalInformationStorage.users[userIndex].borrowDatas[j].id;
                    title = totalInformationStorage.users[userIndex].borrowDatas[j].title;
                    author = totalInformationStorage.users[userIndex].borrowDatas[j].author;
                    publisher = totalInformationStorage.users[userIndex].borrowDatas[j].publisher;
                    amount = totalInformationStorage.users[userIndex].borrowDatas[j].amount;
                    price = totalInformationStorage.users[userIndex].borrowDatas[j].price;
                    publishDay = totalInformationStorage.users[userIndex].borrowDatas[j].publishDay;
                    ISBN = totalInformationStorage.users[userIndex].borrowDatas[j].ISBN;
                    information = totalInformationStorage.users[userIndex].borrowDatas[j].information;
                    borrowTime = totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime;
                    returnTime = DateTime.Now.ToString();

                    printBookInformation.PrintReturnBookListUI(id, title, author, publisher, amount, 
                        price, publishDay, ISBN, information, borrowTime, returnTime);
                }
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                returnBookID = inputFromUser.InputStringFromUser(4, false, consoleInputRow, consoleInputColumn);
                if (returnBookID == null)
                {
                    return -1;
                }

                returnBookIDNumber = int.Parse(returnBookID);

                for (int j = totalInformationStorage.users[userIndex].borrowDatas.Count - 1; j >= 0; j--)
                {
                    if (totalInformationStorage.users[userIndex].borrowDatas[j].id == returnBookIDNumber)
                    {
                        id = totalInformationStorage.users[userIndex].borrowDatas[j].id;
                        title = totalInformationStorage.users[userIndex].borrowDatas[j].title;
                        author = totalInformationStorage.users[userIndex].borrowDatas[j].author;
                        publisher = totalInformationStorage.users[userIndex].borrowDatas[j].publisher;
                        amount = totalInformationStorage.users[userIndex].borrowDatas[j].amount;
                        price = totalInformationStorage.users[userIndex].borrowDatas[j].price;
                        publishDay = totalInformationStorage.users[userIndex].borrowDatas[j].publishDay;
                        ISBN = totalInformationStorage.users[userIndex].borrowDatas[j].ISBN;
                        information = totalInformationStorage.users[userIndex].borrowDatas[j].information;
                        borrowTime = totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime;
                        returnTime = DateTime.Now.ToString();

                        returnBookAmount = int.Parse(amount);
                        returnBookAmount++;

                        amount = Convert.ToString(returnBookAmount);

                        isValidBookInformation = true;
                        totalInformationStorage.users[userIndex].returnDatas.Add(new ReturnBookList(id, title, author, 
                            publisher, amount, price, publishDay, ISBN, information, borrowTime, returnTime));

                        totalInformationStorage.users[userIndex].borrowDatas.Remove(totalInformationStorage.users[userIndex].borrowDatas[j]);
                    }

                    if (totalInformationStorage.books[userIndex].id == returnBookIDNumber)
                    {
                        totalInformationStorage.books[userIndex].amount = Convert.ToString(returnBookAmount);
                    }

                    if (!isValidBookInformation)
                    {
                        ui.PrintException(ConstantNumber.INVALIDINFORMATION);
                        continue;
                    }

                    Console.Clear();
                    ui.PrintException(ConstantNumber.SUCCESSRETURNBOOK);
                    printBookInformation.PrintEsc();

                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isInputESC = true;
                    }
                }
            }
            return 0;
        }
        public void ReturnTheBookList()
        {
            isInputESC = false;

            int userIndex = 0;

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

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintReturnBookTitle();

                for (int j = 0; j < totalInformationStorage.users[userIndex].returnDatas.Count; j++)
                {
                    id = totalInformationStorage.users[userIndex].returnDatas[j].id;
                    title = totalInformationStorage.users[userIndex].returnDatas[j].title;
                    author = totalInformationStorage.users[userIndex].returnDatas[j].author;
                    publisher = totalInformationStorage.users[userIndex].returnDatas[j].publisher;
                    amount = totalInformationStorage.users[userIndex].returnDatas[j].amount;
                    price = totalInformationStorage.users[userIndex].returnDatas[j].price;
                    publishDay = totalInformationStorage.users[userIndex].returnDatas[j].publishDay;
                    ISBN = totalInformationStorage.users[userIndex].returnDatas[j].ISBN;
                    information = totalInformationStorage.users[userIndex].returnDatas[j].information;
                    borrowTime = totalInformationStorage.users[userIndex].returnDatas[j].borrowTime;
                    returnTime = totalInformationStorage.users[userIndex].returnDatas[j].returnTime;

                    printBookInformation.PrintReturnBookListUI(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information, borrowTime, returnTime);
                }

                Console.SetCursorPosition(0, 0);
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
        }
        public void AddTheBook()
        {
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

            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                totalInformationStorage.books.Add(new BookInformation(totalInformationStorage.books.Count, title, author, publisher,
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
            string input = "";

            return input;
        }
        private string ModifyAuthor()
        {
            string input = "";

            return input;
        }
        private string ModifyPublisher()
        {
            string input = "";

            return input;
        }
        private string ModifyAmount()
        {
            string input = "";

            return input;
        }
        private string ModifyPrice()
        {
            string input = "";

            return input;
        }
        private string ModifyPublishDay()
        {
            string input = "";

            return input;
        }
        public void ModifyBook(int bookIndex)
        {
            int index = 0;
            int selectedMenu = 0;
            int validInput = 0;

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

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu);

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

            while(isInputESC)
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
            }
        }
    }
}
