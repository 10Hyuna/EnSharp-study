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
    class EnteringSelectedMenuAboutBookInUser
    {
        TotalInformationStorage totalInformationStorage;
        PrintingBookInformation printBookInformation;
        InputFromUser inputFromUser;
        UI ui;
        ConstantNumber constantNumber;
        HandlingException handlingException;
        RegexStorage regex;

        public EnteringSelectedMenuAboutBookInUser(TotalInformationStorage totalInformationStorage, 
            PrintingBookInformation printBookInformation, InputFromUser inputFromUser, UI ui, 
            ConstantNumber constantNumber, HandlingException handlingException, RegexStorage regex)
        {
            this.printBookInformation = printBookInformation;
            this.inputFromUser = inputFromUser;
            this.totalInformationStorage = totalInformationStorage;
            this.ui = ui;
            this.constantNumber = constantNumber;
            this.handlingException = handlingException;
            this.regex = regex;
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

                keyInfo = Console.ReadKey();
                
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
            title = handlingException.IsValid(regex.containedOneCharacter, ConsoleInputRow, ConsoleInputColumn, 20, false);// 제목 입력
            if (title == null)
                return null;

            author = handlingException.IsValid(regex.containedOneCharacter, ConsoleInputRow, ConsoleInputColumn + 1, 20, false);    // 작가 입력
            if (author == null)
                return null;

            publisher = handlingException.IsValid(regex.containedOneCharacter, ConsoleInputRow, ConsoleInputColumn + 2, 20, false);
            if (publisher == null)
                return null;

            Console.Clear();

            return new List<string>{ title, author, publisher };
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

            int index = -1;
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
                while (index == -1)
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

                    for(int i=0;i<totalInformationStorage.users.Count;i++)
                    {
                        if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                        {
                            for(int j = 0; j < totalInformationStorage.users[i].borrowDatas.Count;j++)
                            {
                                if (totalInformationStorage.users[i].borrowDatas[j].id == bookIdNum)
                                {
                                    ui.PrintException(constantNumber.alreadyRentBook);
                                    isAlreadyRentBook = true;
                                    break;
                                }
                            }
                        }
                    }

                    for(int i = 0; i < totalInformationStorage.books.Count; i++)
                    {
                        if (bookIdNum == totalInformationStorage.books[i].id)
                        {
                            if (int.Parse(totalInformationStorage.books[i].amount) <= 0)
                            {
                                Console.Clear();
                                ui.PrintException(constantNumber.leakingbookAmount);
                                isLeakedBookAmount = false;
                                break;
                            }

                            isLeakedBookAmount = true;
                            index = i;
                            amount = int.Parse(totalInformationStorage.books[i].amount);
                            amount -= 1;
                            amountBook = Convert.ToString(amount);
                            totalInformationStorage.books[i].amount = amountBook;
                            break;
                        }
                    }

                    if(!isLeakedBookAmount)
                    {
                        continue;
                    }

                    if(index == -1)
                    {
                        ui.PrintException(constantNumber.invalidInformation);
                        continue;
                    }

                    for(int i = 0; i < totalInformationStorage.users.Count; i++)
                    {
                        if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                        {
                            totalInformationStorage.users[i].borrowDatas.Add(new BorrowBookList(totalInformationStorage.books[index].id,
                                totalInformationStorage.books[index].title, totalInformationStorage.books[index].author,
                                totalInformationStorage.books[index].publisher, totalInformationStorage.books[index].amount,
                                totalInformationStorage.books[index].price, totalInformationStorage.books[index].publishDay,
                                totalInformationStorage.books[index].ISBN, totalInformationStorage.books[index].information,
                                DateTime.Now.ToString()));
                            break;
                        }
                    }
                }
                Console.Clear();
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                ui.PrintException(constantNumber.successBorrowBook);
                printBookInformation.PrintEsc();

                keyInfo = Console.ReadKey();

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

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintRentalBookTitle();
                for (int i = 0; i < totalInformationStorage.users.Count; i++)
                {
                    for(int j = 0; j < totalInformationStorage.users[i].borrowDatas.Count; j++)
                    {
                            printBookInformation.PrintRentalBookListUI(totalInformationStorage.users[i].borrowDatas[j].id,
                                totalInformationStorage.users[i].borrowDatas[j].title, totalInformationStorage.users[i].borrowDatas[j].author,
                                totalInformationStorage.users[i].borrowDatas[j].publisher, totalInformationStorage.users[i].borrowDatas[j].amount,
                                totalInformationStorage.users[i].borrowDatas[j].price, totalInformationStorage.users[i].borrowDatas[j].publishDay,
                                totalInformationStorage.users[i].borrowDatas[j].ISBN, totalInformationStorage.users[i].borrowDatas[j].information,
                                totalInformationStorage.users[i].borrowDatas[j].borrowTime);
                    } 
                }
                Console.SetCursorPosition(0, 0);

                keyInfo = Console.ReadKey();

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
            
            while(!isInputESC)
            {
                Console.Clear();

                printBookInformation.PrintReturnTheBookUI();
                for (int i = 0; i < totalInformationStorage.users.Count; i++)
                {
                    for (int j = 0; j < totalInformationStorage.users[i].borrowDatas.Count; j++)
                    {
                        printBookInformation.PrintReturnBookListUI(totalInformationStorage.users[i].borrowDatas[j].id,
                            totalInformationStorage.users[i].borrowDatas[j].title, totalInformationStorage.users[i].borrowDatas[j].author,
                            totalInformationStorage.users[i].borrowDatas[j].publisher, totalInformationStorage.users[i].borrowDatas[j].amount,
                            totalInformationStorage.users[i].borrowDatas[j].price, totalInformationStorage.users[i].borrowDatas[j].publishDay,
                            totalInformationStorage.users[i].borrowDatas[j].ISBN, totalInformationStorage.users[i].borrowDatas[j].information,
                            totalInformationStorage.users[i].borrowDatas[j].borrowTime, DateTime.Now.ToString());
                    }
                }
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                returnBookID = inputFromUser.InputStringFromUser(4, false, consoleInputRow, consoleInputColumn);
                if(returnBookID == null)
                {
                    return -1;
                }

                returnBookIDNumber = int.Parse(returnBookID);

                for(int i = totalInformationStorage.users.Count - 1; i >= 0 ; i--)
                {
                    for(int j = totalInformationStorage.users[i].borrowDatas.Count - 1; j >= 0; j--)
                    {
                        if (totalInformationStorage.users[i].borrowDatas[j].id == returnBookIDNumber)
                        {
                            returnBookAmount = int.Parse(totalInformationStorage.users[i].borrowDatas[j].amount);
                            returnBookAmount++;
                            totalInformationStorage.users[i].borrowDatas[j].amount = Convert.ToString(returnBookAmount);

                            isValidBookInformation = true;

                            totalInformationStorage.users[i].returnDatas.Add(new ReturnBookList(totalInformationStorage.users[i].borrowDatas[j].id,
                                totalInformationStorage.users[i].borrowDatas[j].title, totalInformationStorage.users[i].borrowDatas[j].author,
                                totalInformationStorage.users[i].borrowDatas[j].publisher, totalInformationStorage.users[i].borrowDatas[j].amount,
                                totalInformationStorage.users[i].borrowDatas[j].price, totalInformationStorage.users[i].borrowDatas[j].publishDay,
                                totalInformationStorage.users[i].borrowDatas[j].ISBN, totalInformationStorage.users[i].borrowDatas[j].information,
                                totalInformationStorage.users[i].borrowDatas[j].borrowTime, DateTime.Now.ToString()));
                            totalInformationStorage.users[i].borrowDatas.Remove(totalInformationStorage.users[i].borrowDatas[j]);
                        }
                    }
                    if (totalInformationStorage.books[i].id == returnBookIDNumber)
                    {
                        totalInformationStorage.books[i].amount = Convert.ToString(returnBookAmount);
                    }
                }
                if(!isValidBookInformation)
                {
                    ui.PrintException(constantNumber.invalidInformation);
                    continue;
                }

                Console.Clear();
                ui.PrintException(constantNumber.successReturnBook);
                printBookInformation.PrintEsc();

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
            return 0;
        }
        public void ReturnTheBookList()
        {
            isInputESC = false;

            while (!isInputESC)
            {
                Console.Clear();
                printBookInformation.PrintReturnBookTitle();
                for (int i = 0; i < totalInformationStorage.users.Count; i++)
                {
                    for (int j = 0; j < totalInformationStorage.users[i].returnDatas.Count; j++)
                    {
                        printBookInformation.PrintReturnBookListUI(totalInformationStorage.users[i].returnDatas[j].id,
                            totalInformationStorage.users[i].returnDatas[j].title, totalInformationStorage.users[i].returnDatas[j].author,
                            totalInformationStorage.users[i].returnDatas[j].publisher, totalInformationStorage.users[i].returnDatas[j].amount,
                            totalInformationStorage.users[i].returnDatas[j].price, totalInformationStorage.users[i].returnDatas[j].publishDay,
                            totalInformationStorage.users[i].returnDatas[j].ISBN, totalInformationStorage.users[i].returnDatas[j].information,
                            totalInformationStorage.users[i].returnDatas[j].borrowTime, totalInformationStorage.users[i].returnDatas[j].returnTime);
                    }
                }

                Console.SetCursorPosition(0, 0);
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
        }
    }
}
