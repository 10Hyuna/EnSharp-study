using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;

namespace Library.Controller
{
    class BookAccessInUser
    {
        UI ui;
        TotalStorage totalStorage;
        PrinterBookInformation printerBookInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        RegexStorage regex;

        public BookAccessInUser(UI ui, TotalStorage totalStorage, PrinterBookInformation printerBookInformation,
            InputFromUser inputFromUser, HandlingException handlingException, RegexStorage regex)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
            this.printerBookInformation = printerBookInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
        }

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

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }

        int consoleInputRow = 0;
        int consoleInputColumn = 0;
        int affluentBookIndex = -1;
        int userIndex = 0;

        bool isInputESC = false;

        ConsoleKeyInfo keyInfo;

        public int RentTheBook()      // 책 대여 메뉴에 진입했을 때
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            int consoleInputRow = 9;
            int consoleInputColumn = 2;

            int bookIdNum;
            string bookId;

            List<string> book;

            isInputESC = false;

            bool isLeakedBookAmount = false;
            bool isAlreadyRentBook = false;
            bool isSerchedBook;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)      // 로그인되어 있는 정보가 어느 인덱스인지 찾음
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                while (affluentBookIndex == -1)
                {
                    isSerchedBook = false;
                    Console.Clear();

                    book = PrintTheAllBook();       // 책의 정보 입력

                    if (book == null)
                        return -1;

                    isLeakedBookAmount = true;      // 책의 수량이 부족할 경우의 수 확인 용도

                    printerBookInformation.PrintRenttheBookUI();

                    selectedBook(book[0], book[1], book[2]);
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                    bookId = handlingException.IsValid(ConstantNumber.containedOneNumber, consoleInputRow, consoleInputColumn, 10, false);

                    if (bookId == null)     // 중도에 ESC를 눌러 반환값이 null이라면
                        return -1;

                    bookIdNum = int.Parse(bookId);  // 숫자로 변환

                    isSerchedBook = IsSerchBook(bookIdNum, book);

                    if (isSerchedBook)
                    {
                        ui.PrintException(ConstantNumber.SERCHED_BOOK);
                        continue;
                    }

                    isAlreadyRentBook = IsAlreadyRentBook(userIndex, bookIdNum);

                    isLeakedBookAmount = isLeakedBook(bookIdNum);

                    if (!isLeakedBookAmount)    // 책의 수량이 부족할 경우 다른 책을 대여하도록 유도
                    {
                        continue;
                    }

                    if (affluentBookIndex == -1)    // 유효하지 않은 값이 찾는 책의 인덱스일 경우
                    {
                        ui.PrintException(ConstantNumber.INVALID_INFORMATION);
                        continue;
                    }

                    AddBorrowBook(affluentBookIndex, userIndex);
                }
                Console.Clear();
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                ui.PrintException(ConstantNumber.SUCCESS_BORROW_BOOK);
                printerBookInformation.PrintEsc();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isInputESC = true;
                }
            }                       // 반복문 탈출
            return 0;
        }

        public bool IsSerchBook(int bookId, List<string> book)
        {
            bool isSerchedBook = false;
            for (int i = 0; i < totalStorage.books.Count; i++)
            {
                id = totalStorage.books[i].GetBookId();
                if (id == bookId)
                {
                    title = totalStorage.books[i].GetBookTitle();
                    author = totalStorage.books[i].GetBookAuthor();
                    publisher = totalStorage.books[i].GetBookPublisher();

                    if (title.Contains(book[0])
                        && author.Contains(book[1])
                        && publisher.Contains(book[2]))
                    {
                        isSerchedBook = true;
                    }
                }
            }
            return isSerchedBook;
        }

        private bool IsAlreadyRentBook(int userIndex, int bookId)
        {
            bool isAlreadyRentBook = false;

            for (int i = 0; i < totalStorage.users[userIndex].BorrowDatas.Count; i++)
            {
                if (totalStorage.users[userIndex].BorrowDatas[i].GetBookId() == bookId)   // 빌린 책 리스트 중 찾는 책의 아이디와
                                                                                          // 일치하는 아이디를 가진 책이 있다면
                {
                    ui.PrintException(ConstantNumber.ALREADY_RENT_BOOK);     // 이미 대여 중인 책
                    isAlreadyRentBook = true;
                    break;
                }
            }

            return isAlreadyRentBook;
        }

        private bool isLeakedBook(int bookId)
        {
            bool isLeakedBookAmount = false;
            int inputAmount;
            string amountBook;

            for (int i = 0; i < totalStorage.books.Count; i++)
            {
                if (bookId == totalStorage.books[i].GetBookId())
                {
                    if (int.Parse(totalStorage.books[i].GetBookAmount()) <= 0)    // 수량이 0 이하인 경우
                    {
                        Console.Clear();
                        ui.PrintException(ConstantNumber.LEAKING_BOOK_AMOUNT);    // 책의 수량이 부족함을 출력
                        isLeakedBookAmount = false;
                    }
                    else
                    {
                        isLeakedBookAmount = true;
                        affluentBookIndex = i;
                        inputAmount = int.Parse(totalStorage.books[i].GetBookAmount());
                        inputAmount -= 1;
                        amountBook = Convert.ToString(inputAmount);
                        totalStorage.books[i].SetBookAmount(amountBook);
                    }
                    break;
                }
            }
            return isLeakedBookAmount;
        }

        private void AddBorrowBook(int bookIndex, int userIndex)
        {
            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)
                {
                    id = totalStorage.books[bookIndex].GetBookId();
                    title = totalStorage.books[bookIndex].GetBookTitle();
                    author = totalStorage.books[bookIndex].GetBookAuthor();
                    publisher = totalStorage.books[bookIndex].GetBookPublisher();
                    amount = totalStorage.books[bookIndex].GetBookAmount();
                    price = totalStorage.books[bookIndex].GetBookPrice();
                    publishDay = totalStorage.books[bookIndex].GetBookPublishDay();
                    ISBN = totalStorage.books[bookIndex].GetBookISBN();
                    information = totalStorage.books[bookIndex].GetBookInformation();

                    totalStorage.users[userIndex].BorrowDatas.Add(new BorrowBookList(id, title, author, publisher, amount, price,
                        publishDay, ISBN, information, DateTime.Now.ToString()));
                    break;
                }
            }
        }

        public void CheckTheRentalBook()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            isInputESC = false;
            int userIndex = 0;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();
                printerBookInformation.PrintRentalBookTitle();

                for (int j = 0; j < totalStorage.users[userIndex].BorrowDatas.Count; j++)
                {
                    BorrowBookList allBorrowedBook = totalStorage.users[userIndex].BorrowDatas[j];
                    id = allBorrowedBook.GetBorrowId();
                    title = allBorrowedBook.GetBorrowTitle();
                    author = allBorrowedBook.GetBorrowAuthor();
                    publisher = allBorrowedBook.GetBorrowPublisher();
                    amount = allBorrowedBook.GetBorrowAmount();
                    price = allBorrowedBook.GetBorrowPrice();
                    publishDay = allBorrowedBook.GetBorrowPublishDay();
                    ISBN = allBorrowedBook.GetBorrowISBN();
                    information = allBorrowedBook.GetBorrowInformation();
                    borrowTime = allBorrowedBook.GetBorrowBorrowTime();

                    printerBookInformation.PrintRentalBookListUI(id, title, author, publisher, amount,
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
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            consoleInputRow = 8;
            consoleInputColumn = 2;

            isInputESC = false;
            bool isValidBookInformation = false;

            string returnBookID;
            int returnBookIDNumber;
            int returnBookAmount = 0;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();

                printerBookInformation.PrintReturnTheBookUI();
                for (int j = 0; j < totalStorage.users[userIndex].BorrowDatas.Count; j++)
                {
                    BorrowBookList vaildBook = totalStorage.users[userIndex].BorrowDatas[j];
                    id = vaildBook.GetBorrowId();
                    title = vaildBook.GetBorrowTitle();
                    author = vaildBook.GetBorrowAuthor();
                    publisher = vaildBook.GetBorrowPublisher();
                    amount = vaildBook.GetBorrowAmount();
                    price = vaildBook.GetBorrowPrice();
                    publishDay = vaildBook.GetBorrowPublishDay();
                    ISBN = vaildBook.GetBorrowISBN();
                    information = vaildBook.GetBorrowInformation();
                    borrowTime = vaildBook.GetBorrowBorrowTime();
                    returnTime = DateTime.Now.ToString();

                    printerBookInformation.PrintReturnBookListUI(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information, borrowTime, returnTime);
                }

                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                returnBookID = inputFromUser.InputStringFromUser(4, false, consoleInputRow, consoleInputColumn);
                if (returnBookID == null)
                {
                    return -1;
                }

                returnBookIDNumber = int.Parse(returnBookID);

                for (int j = totalStorage.users[userIndex].BorrowDatas.Count - 1; j >= 0; j--)
                {
                    if (totalStorage.users[userIndex].BorrowDatas[j].GetBorrowId() == returnBookIDNumber)
                    {
                        BorrowBookList vaildBook = totalStorage.users[userIndex].BorrowDatas[j]; 
                        id = vaildBook.GetBorrowId();
                        title = vaildBook.GetBorrowTitle();
                        author = vaildBook.GetBorrowAuthor();
                        publisher = vaildBook.GetBorrowPublisher();
                        amount = vaildBook.GetBorrowAmount();
                        price = vaildBook.GetBorrowPrice();
                        publishDay = vaildBook.GetBorrowPublishDay();
                        ISBN = vaildBook.GetBorrowISBN();
                        information = vaildBook.GetBorrowInformation();
                        borrowTime = vaildBook.GetBorrowBorrowTime();
                        returnTime = DateTime.Now.ToString();

                        returnBookAmount = int.Parse(amount);
                        returnBookAmount++;

                        amount = Convert.ToString(returnBookAmount);

                        isValidBookInformation = true;
                        totalStorage.users[userIndex].ReturnDatas.Add(new ReturnBookList(id, title, author,
                            publisher, amount, price, publishDay, ISBN, information, borrowTime, returnTime));

                        totalStorage.users[userIndex].BorrowDatas.Remove(totalStorage.users[userIndex].BorrowDatas[j]);
                    }

                    if (totalStorage.books[userIndex].GetBookId() == returnBookIDNumber)
                    {
                        totalStorage.books[userIndex].SetBookAmount(Convert.ToString(returnBookAmount));
                    }

                    if (!isValidBookInformation)
                    {
                        ui.PrintException(ConstantNumber.INVALID_INFORMATION);
                        continue;
                    }

                    Console.Clear();
                    ui.PrintException(ConstantNumber.SUCCESS_RETURN_BOOK);
                    printerBookInformation.PrintEsc();

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
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

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
    }
}
