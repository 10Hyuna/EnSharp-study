using Library.Model;
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

            string title;
            string author;
            string publisher;

            Console.Clear();
            printBookInformation.PrintFindingBookUI();

            for (int i = 0; i < totalInformationStorage.books.Count; i++)
            {
                printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                        totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                        totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                        totalInformationStorage.books[i].information);
            }

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            title = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn, 20, false);// 제목 입력
            if (title == null)
                return null;

            author = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 1, 20, false);    // 작가 입력
            if (author == null)
                return null;

            publisher = handlingException.IsValid(regex.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 2, 20, false);
            if (publisher == null)
                return null;

            Console.Clear();

            return new List<string> { title, author, publisher };
        }

        public void selectedBook(string title, string author, string publisher)
        {
            for (int i = 0; i < totalInformationStorage.books.Count; i++)
            {
                if (totalInformationStorage.books[i].title.Contains(title) && totalInformationStorage.books[i].author.Contains(author) && totalInformationStorage.books[i].publisher.Contains(publisher))
                {
                    printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                        totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                        totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                        totalInformationStorage.books[i].information);
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
                    printBookInformation.PrintRentalBookListUI(totalInformationStorage.users[userIndex].borrowDatas[j].id,
                        totalInformationStorage.users[userIndex].borrowDatas[j].title, totalInformationStorage.users[userIndex].borrowDatas[j].author,
                        totalInformationStorage.users[userIndex].borrowDatas[j].publisher, totalInformationStorage.users[userIndex].borrowDatas[j].amount,
                        totalInformationStorage.users[userIndex].borrowDatas[j].price, totalInformationStorage.users[userIndex].borrowDatas[j].publishDay,
                        totalInformationStorage.users[userIndex].borrowDatas[j].ISBN, totalInformationStorage.users[userIndex].borrowDatas[j].information,
                        totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime);
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
                    printBookInformation.PrintReturnBookListUI(totalInformationStorage.users[userIndex].borrowDatas[j].id,
                        totalInformationStorage.users[userIndex].borrowDatas[j].title, totalInformationStorage.users[userIndex].borrowDatas[j].author,
                        totalInformationStorage.users[userIndex].borrowDatas[j].publisher, totalInformationStorage.users[userIndex].borrowDatas[j].amount,
                        totalInformationStorage.users[userIndex].borrowDatas[j].price, totalInformationStorage.users[userIndex].borrowDatas[j].publishDay,
                        totalInformationStorage.users[userIndex].borrowDatas[j].ISBN, totalInformationStorage.users[userIndex].borrowDatas[j].information,
                        totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime, DateTime.Now.ToString());
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
                        returnBookAmount = int.Parse(totalInformationStorage.users[userIndex].borrowDatas[j].amount);
                        returnBookAmount++;
                        totalInformationStorage.users[userIndex].borrowDatas[j].amount = Convert.ToString(returnBookAmount);

                        isValidBookInformation = true;

                        totalInformationStorage.users[userIndex].returnDatas.Add(new ReturnBookList(totalInformationStorage.users[userIndex].borrowDatas[j].id,
                            totalInformationStorage.users[userIndex].borrowDatas[j].title, totalInformationStorage.users[userIndex].borrowDatas[j].author,
                            totalInformationStorage.users[userIndex].borrowDatas[j].publisher, totalInformationStorage.users[userIndex].borrowDatas[j].amount,
                            totalInformationStorage.users[userIndex].borrowDatas[j].price, totalInformationStorage.users[userIndex].borrowDatas[j].publishDay,
                            totalInformationStorage.users[userIndex].borrowDatas[j].ISBN, totalInformationStorage.users[userIndex].borrowDatas[j].information,
                            totalInformationStorage.users[userIndex].borrowDatas[j].borrowTime, DateTime.Now.ToString()));
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
                    printBookInformation.PrintReturnBookListUI(totalInformationStorage.users[userIndex].returnDatas[j].id,
                        totalInformationStorage.users[userIndex].returnDatas[j].title, totalInformationStorage.users[userIndex].returnDatas[j].author,
                        totalInformationStorage.users[userIndex].returnDatas[j].publisher, totalInformationStorage.users[userIndex].returnDatas[j].amount,
                        totalInformationStorage.users[userIndex].returnDatas[j].price, totalInformationStorage.users[userIndex].returnDatas[j].publishDay,
                        totalInformationStorage.users[userIndex].returnDatas[j].ISBN, totalInformationStorage.users[userIndex].returnDatas[j].information,
                        totalInformationStorage.users[userIndex].returnDatas[j].borrowTime, totalInformationStorage.users[userIndex].returnDatas[j].returnTime);
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
            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintDeleteTheBookUI();
                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
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
                    printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
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

        public void ModifyTheBook()
        {

        }

        public void RentalState()
        {

        }
    }
}
