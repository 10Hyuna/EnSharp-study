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
using Library.Model.DTO;

namespace Library.Controller
{
    class EnteringSelectedMenuAboutBook
    {
        TotalInformationStorage totalInformationStorage;
        PrintingBookInformation printBookInformation;
        InputFromUser inputFromUser;
        UI ui;
        ConstantNumber constantNumber;
        RegexStorage regex;

        public EnteringSelectedMenuAboutBook(TotalInformationStorage totalInformationStorage, PrintingBookInformation printBookInformation,
            InputFromUser inputFromUser, UI ui, ConstantNumber constantNumber, RegexStorage regex)
        {
            this.printBookInformation = printBookInformation;
            this.inputFromUser = inputFromUser;
            this.totalInformationStorage = totalInformationStorage;
            this.ui = ui;
            this.constantNumber = constantNumber;
            this.regex = regex;
        }

        public int FindTheBookBySerching() // 찾고자 하는 책의 정보를 입력하는 함수
        {
            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            List<string> book;

            bool isInputESC = false;
            int selectedKey;

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
            title = inputFromUser.InputStringFromUser(20, false, ConsoleInputRow, ConsoleInputColumn);    // 제목 입력
            if (title == null)
                return null;
            author = inputFromUser.InputStringFromUser(20, false, ConsoleInputRow, ConsoleInputColumn + 1);    // 작가 입력
            if (author == null)
                return null;
            publisher = inputFromUser.InputStringFromUser(20, false, ConsoleInputRow, ConsoleInputColumn + 2);
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
            const int consoleInputRow = 8;
            const int consoleInputColumn = 2;

            int index = -1;
            int bookIdNum;
            int amount;

            string bookId;
            string amountBook;

            List<string> book;

            bool isCheckedExit = false;
            bool isSecondExit = false;
            bool isLeakedBookAmount = false;

            ConsoleKeyInfo keyInfo;

            while (!isCheckedExit)
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

                    bookId = inputFromUser.InputStringFromUser(10, false, consoleInputRow, consoleInputColumn);
                    if (bookId == null)
                        return -1;

                    bookIdNum = int.Parse(bookId);

                    for(int i = 0; i < totalInformationStorage.books.Count; i++)
                    {
                        if (bookIdNum == totalInformationStorage.books[i].id)
                        {
                            if (int.Parse(totalInformationStorage.books[i].amount) <= 0)
                            {
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
                        if (totalInformationStorage.users[i].id==totalInformationStorage.loggedInUserId)
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
                ui.PrintException(constantNumber.successBorrowBook);
                printBookInformation.PrintEsc();
                printBookInformation.PrintEnter();

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isCheckedExit = true;
                }
            }                       // 반복문 탈출
            return 0;
        }

        public void CheckTheRentalBook()
        {
            ConsoleKeyInfo keyInfo;

            bool isEnteredEsc = false;

            while (!isEnteredEsc)
            {
                Console.Clear();
                printBookInformation.PrintRentalBookTitle();
                for (int i = 0; i < totalInformationStorage.users.Count; i++)
                {
                    for(int j = 0; j < totalInformationStorage.users[i].borrowDatas.Count; j++)
                    {
                            printBookInformation.PrintRentalBookList(totalInformationStorage.users[i].borrowDatas[j].id,
                                totalInformationStorage.users[i].borrowDatas[j].title, totalInformationStorage.users[i].borrowDatas[j].author,
                                totalInformationStorage.users[i].borrowDatas[j].publisher, totalInformationStorage.users[i].borrowDatas[j].amount,
                                totalInformationStorage.users[i].borrowDatas[j].price, totalInformationStorage.users[i].borrowDatas[j].publishDay,
                                totalInformationStorage.users[i].borrowDatas[j].ISBN, totalInformationStorage.users[i].borrowDatas[j].information,
                                totalInformationStorage.users[i].borrowDatas[j].time);
                    } 
                }

                keyInfo = Console.ReadKey();

                if(keyInfo.Key == ConsoleKey.Escape)
                {
                    isEnteredEsc = true;
                }
            }
        }

        public void ReturnTheBook()
        {

        }
        private void ReturnTheBookList()
        {

        }
        private void ModifyInformationOfUser()
        {

        }

        private void DeleteAccount()
        {

        }
    }
}
