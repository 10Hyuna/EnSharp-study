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
        FindBook findBook;

        public BookAccessInUser(UI ui, TotalStorage totalStorage, PrinterBookInformation printerBookInformation,
            InputFromUser inputFromUser, HandlingException handlingException, FindBook findBook)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
            this.printerBookInformation = printerBookInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.findBook = findBook;
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

        int consoleInputRow = 0;
        int consoleInputColumn = 0;
        int affluentBookIndex = -1;
        int userIndex = 0;

        bool isInputESC = false;

        ConsoleKeyInfo keyInfo;

        public int RentTheBook()      // 책 대여 메뉴에 진입했을 때
        {
            int consoleInputRow = 9;
            int consoleInputColumn = 2;

            int bookIdNum;
            string bookId;

            List<string> book;

            isInputESC = false;

            affluentBookIndex = -1;

            bool isLeakedBookAmount = false;
            bool isAlreadyRentBook = false;
            bool isSerchedBook;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)      // 로그인되어 있는 정보가 어느 인덱스인지 찾음
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

                    book = findBook.PrintTheAllBook();       // 책의 정보 입력

                    if (book == null)
                        return -1;

                    isLeakedBookAmount = true;      // 책의 수량이 부족할 경우의 수 확인 용도

                    printerBookInformation.PrintRenttheBookUI();

                    findBook.selectedBook(book[0], book[1], book[2]);
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn - 2);
                    bookId = handlingException.IsValid(ConstantNumber.containedOneNumber, consoleInputRow, consoleInputColumn, 10, false);

                    if (bookId == null)     // 중도에 ESC를 눌러 반환값이 null이라면
                        return -1;

                    bookIdNum = int.Parse(bookId);  // 숫자로 변환

                    isSerchedBook = IsSerchBook(bookIdNum, book);

                    if (!isSerchedBook)
                    {
                        ui.PrintException(ConstantNumber.SERCHED_BOOK, consoleInputRow, consoleInputColumn);
                        continue;
                    }

                    isAlreadyRentBook = IsAlreadyRentBook(userIndex, bookIdNum);    // 이미 대여 중인 책이라면

                    if(isAlreadyRentBook)       // 다른 책을 대여하도록 유도
                    {
                        continue;
                    }

                    isLeakedBookAmount = isLeakedBook(bookIdNum);

                    if (!isLeakedBookAmount)    // 책의 수량이 부족할 경우 다른 책을 대여하도록 유도
                    {
                        continue;
                    }

                    if (affluentBookIndex == -1)    // 유효하지 않은 값이 찾는 책의 인덱스일 경우
                    {
                        ui.PrintException(ConstantNumber.INVALID_INFORMATION, consoleInputRow, consoleInputColumn);
                        continue;
                    }

                    AddBorrowBook(affluentBookIndex, userIndex);
                }
                Console.Clear();
                ui.PrintException(ConstantNumber.SUCCESS_BORROW_BOOK, consoleInputRow, 0);
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
                id = totalStorage.books[i].GetId();
                if (id == bookId)
                {
                    title = totalStorage.books[i].GeTitle();
                    author = totalStorage.books[i].GetAuthor();
                    publisher = totalStorage.books[i].GetPublisher();

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
                if (totalStorage.users[userIndex].BorrowDatas[i].GetId() == bookId)   // 빌린 책 리스트 중 찾는 책의 아이디와
                                                                                          // 일치하는 아이디를 가진 책이 있다면
                {
                    Console.Clear();
                    ui.PrintException(ConstantNumber.ALREADY_RENT_BOOK, 0, 0);     // 이미 대여 중인 책
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
                if (bookId == totalStorage.books[i].GetId())
                {
                    if (int.Parse(totalStorage.books[i].GetAmount()) <= 0)    // 수량이 0 이하인 경우
                    {
                        Console.Clear();
                        ui.PrintException(ConstantNumber.LEAKING_BOOK_AMOUNT, 0, 0);    // 책의 수량이 부족함을 출력
                        isLeakedBookAmount = false;
                    }
                    else
                    {
                        isLeakedBookAmount = true;
                        affluentBookIndex = i;
                        inputAmount = int.Parse(totalStorage.books[i].GetAmount());
                        inputAmount -= 1;
                        amountBook = Convert.ToString(inputAmount);
                        totalStorage.books[i].SetAmount(amountBook);
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
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)
                {
                    id = totalStorage.books[bookIndex].GetId();
                    title = totalStorage.books[bookIndex].GeTitle();
                    author = totalStorage.books[bookIndex].GetAuthor();
                    publisher = totalStorage.books[bookIndex].GetPublisher();
                    amount = totalStorage.books[bookIndex].GetAmount();
                    price = totalStorage.books[bookIndex].GetPrice();
                    publishDay = totalStorage.books[bookIndex].GetPublishDay();
                    ISBN = totalStorage.books[bookIndex].GetISBN();
                    information = totalStorage.books[bookIndex].GetInformation();

                    totalStorage.users[userIndex].BorrowDatas.Add(new BorrowBookList(id, title, author, publisher, amount, price,
                        publishDay, ISBN, information, DateTime.Now.ToString()));
                    break;
                }
            }
        }

        public void CheckTheRentalBook()        // 해당 유저의 대여 목록 출력
        {

            isInputESC = false;
            int userIndex = 0;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)
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
                    id = allBorrowedBook.GetId();
                    title = allBorrowedBook.GetTitle();
                    author = allBorrowedBook.GetAuthor();
                    publisher = allBorrowedBook.GetPublisher();
                    amount = allBorrowedBook.GetAmount();
                    price = allBorrowedBook.GetPrice();
                    publishDay = allBorrowedBook.GetPublishDay();
                    ISBN = allBorrowedBook.GetISBN();
                    information = allBorrowedBook.GetInformation();
                    borrowTime = allBorrowedBook.GetBorrowTime();

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
        public int ReturnTheBook()      // 해당 유저의 책 반납을 도와주는 함수
        {
            consoleInputRow = 8;
            consoleInputColumn = 2;

            isInputESC = false;
            bool isValidBookInformation = false;

            string returnBookID;
            int returnBookIDNumber;
            int returnBookAmount = 0;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)
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
                    id = vaildBook.GetId();
                    title = vaildBook.GetTitle();
                    author = vaildBook.GetAuthor();
                    publisher = vaildBook.GetPublisher();
                    amount = vaildBook.GetAmount();
                    price = vaildBook.GetPrice();
                    publishDay = vaildBook.GetPublishDay();
                    ISBN = vaildBook.GetISBN();
                    information = vaildBook.GetInformation();
                    borrowTime = vaildBook.GetBorrowTime();
                    returnTime = DateTime.Now.ToString();

                    printerBookInformation.PrintReturnBookListUI(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information, borrowTime, returnTime);
                }

                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                returnBookID = inputFromUser.InputStringFromUser(4, false, consoleInputRow, consoleInputColumn);
                // 반납하고자 하는 책의 아이디 입력
                if (returnBookID == null)       // esc를 입력했다면
                {
                    return -1;
                }

                returnBookIDNumber = int.Parse(returnBookID);

                for (int j = totalStorage.users[userIndex].BorrowDatas.Count - 1; j >= 0; j--)
                {
                    if (totalStorage.users[userIndex].BorrowDatas[j].GetId() == returnBookIDNumber)
                    {       // 입력한 아이디와 일치하는 값이 존재하는 대여 책을 찾고
                        BorrowBookList vaildBook = totalStorage.users[userIndex].BorrowDatas[j]; 
                        id = vaildBook.GetId();
                        title = vaildBook.GetTitle();
                        author = vaildBook.GetAuthor();
                        publisher = vaildBook.GetPublisher();
                        amount = vaildBook.GetAmount();
                        price = vaildBook.GetPrice();
                        publishDay = vaildBook.GetPublishDay();
                        ISBN = vaildBook.GetISBN();
                        information = vaildBook.GetInformation();
                        borrowTime = vaildBook.GetBorrowTime();
                        returnTime = DateTime.Now.ToString();

                        returnBookAmount = int.Parse(amount);   
                        returnBookAmount++;     // 대여한 책의 양을 하나 늘림

                        amount = Convert.ToString(returnBookAmount);        

                        isValidBookInformation = true;
                        totalStorage.users[userIndex].ReturnDatas.Add(new ReturnBookList(id, title, author,
                            publisher, amount, price, publishDay, ISBN, information, borrowTime, returnTime));
                        // 반납 목록에 추가

                        totalStorage.users[userIndex].BorrowDatas.Remove(totalStorage.users[userIndex].BorrowDatas[j]);     
                        // 반납 이후 대여 목록에서 삭제
                    }

                    if (totalStorage.books[userIndex].GetId() == returnBookIDNumber)
                    {
                        totalStorage.books[userIndex].SetAmount(Convert.ToString(returnBookAmount));
                    }

                    if (!isValidBookInformation)        // 유효한 책의 정보가 없을 경우
                    {
                        ui.PrintException(ConstantNumber.INVALID_INFORMATION, 0, 0);
                        continue;
                    }

                    Console.Clear();
                    ui.PrintException(ConstantNumber.SUCCESS_RETURN_BOOK, 0, 0);        // 반납 성공
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
        public void ReturnTheBookList()     // 책 반납 목록 출력
        {
            isInputESC = false;

            int userIndex = 0;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)
                {
                    userIndex = i;
                    break;
                }
            }

            while (!isInputESC)
            {
                Console.Clear();
                printerBookInformation.PrintReturnBookTitle();

                for (int j = 0; j < totalStorage.users[userIndex].ReturnDatas.Count; j++)
                {

                    id = totalStorage.users[userIndex].ReturnDatas[j].GetId();
                    title = totalStorage.users[userIndex].ReturnDatas[j].GetTitle();
                    author = totalStorage.users[userIndex].ReturnDatas[j].GetAuthor();
                    publisher = totalStorage.users[userIndex].ReturnDatas[j].GetPublisher();
                    amount = totalStorage.users[userIndex].ReturnDatas[j].GetAmount();
                    price = totalStorage.users[userIndex].ReturnDatas[j].GetPrice();
                    publishDay = totalStorage.users[userIndex].ReturnDatas[j].GetPublishDay();
                    ISBN = totalStorage.users[userIndex].ReturnDatas[j].GetISBN();
                    information = totalStorage.users[userIndex].ReturnDatas[j].GetInformation();
                    borrowTime = totalStorage.users[userIndex].ReturnDatas[j].GetBorrowTime();
                    returnTime = totalStorage.users[userIndex].ReturnDatas[j].GetReturnTime();

                    printerBookInformation.PrintReturnBookListUI(id, title, author, publisher, amount,
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
