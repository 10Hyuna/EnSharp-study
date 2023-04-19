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
        TotalStorage totalStorage;
        PrinterBookInformation printerBookInformation;
        UI ui;
        HandlingException handlingException;
        MovingCursorPosition cursor;
        public BookAccessInManager(TotalStorage totalStorage, PrinterBookInformation printerBookInformation, UI ui,
            HandlingException handlingException, MovingCursorPosition cursor)
        {
            this.totalStorage = totalStorage;
            this.printerBookInformation = printerBookInformation;
            this.ui = ui;
            this.handlingException = handlingException;
            this.cursor = cursor;
        }

        int consoleInputRow;
        int consoleInputColumn;

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

        bool isInputESC = false;

        ConsoleKeyInfo keyInfo;

        public void AddTheBook()
        {
            consoleInputRow = 44;
            consoleInputColumn = 12;

            isInputESC = false;
            bool isValidAmount = false;
            bool isValidPrice = false;

            Console.Clear();
            ui.PrintBox(6);
            printerBookInformation.PrintAddTheBookUI();

            title = handlingException.IsValid(ConstantNumber.title, consoleInputRow, consoleInputColumn, 20, false);
            // 추가하고자 하는 책의 정보들 입력
            if (title == null)
                // 중간에 esc를 눌렀을 경우
                return;

            author = handlingException.IsValid(ConstantNumber.author, consoleInputRow, consoleInputColumn + 1, 20, false);
            if (author == null)
                return;
            publisher = handlingException.IsValid(ConstantNumber.containedOneValue, consoleInputRow, consoleInputColumn + 2, 20, false);
            if (publisher == null)
                return;
            while (!isValidAmount)
            {
                amount = handlingException.IsValid(ConstantNumber.amount, consoleInputRow, consoleInputColumn + 3, 20, false);
                if (amount == null)
                    return;
                if (int.Parse(amount) <= 0 || int.Parse(amount) >= 1000)
                    // 양이 주어진 값에 해당하지 않는다면
                {
                    ui.PrintException(ConstantNumber.VALID_VALUE, this.consoleInputRow, this.consoleInputColumn + 3);
                }
                else
                {
                    isValidAmount = true;
                }
            }

            while (!isValidPrice)
            {
                price = handlingException.IsValid(ConstantNumber.price, consoleInputRow, consoleInputColumn + 4, 7, false);
                if (price == null)
                    return;
                if (int.Parse(price) <= 0 || int.Parse(price) >= 100000000)
                    // 가격이 유효하지 않은 값이라면
                {
                    ui.PrintException(ConstantNumber.VALID_VALUE, consoleInputRow, consoleInputColumn + 4);
                }
                else
                {
                    isValidPrice = true;
                }
            }

            publishDay = handlingException.IsValid(ConstantNumber.publishDay, consoleInputRow, consoleInputColumn + 5, 11, false);
            if (publishDay == null)
                return;

            ISBN = handlingException.IsValid(ConstantNumber.ISBN, consoleInputRow, consoleInputColumn + 6, 20, false);
            if (ISBN == null)
                return;

            information = handlingException.IsValid(ConstantNumber.information, consoleInputRow, consoleInputColumn + 7, 20, false);
            if (information == null)
                return;

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                // 정보를 모두 입력하고 엔터를 누른다면 책의 정보 추가
                totalStorage.books.Add(new Book(totalStorage.books.Count + 1, title, author, publisher,
                    amount, price, publishDay, ISBN, information));
            }
            Console.Clear();
            ui.PrintBox(6);
            printerBookInformation.PrintSuccessAddBook();

            while (!isInputESC)
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    this.consoleInputRow = 34;
                    this.consoleInputColumn = 25;
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, this.consoleInputRow, this.consoleInputColumn);
                }
            }
        }

        public void DeleteTheBook()     // 책 삭제
        {
            bool isValidId = false;

            consoleInputRow = 60;
            consoleInputColumn = 3;
            string deleteBookId = "";

            while (!isInputESC)
            {
                Console.Clear();
                printerBookInformation.PrintDeleteTheBookUI();
                for (int i = 0; i < totalStorage.books.Count; i++)
                {
                    Book deleteBook = totalStorage.books[i];
                    id = deleteBook.GetId();
                    title = deleteBook.GeTitle();
                    author = deleteBook.GetAuthor();
                    publisher = deleteBook.GetPublisher();
                    amount = deleteBook.GetAmount();
                    price = deleteBook.GetPrice();
                    publishDay = deleteBook.GetPublishDay();
                    ISBN = deleteBook.GetISBN();
                    information = deleteBook.GetInformation();

                    printerBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);
                }
                Console.SetCursorPosition(0, 0);
                deleteBookId = handlingException.IsValid(ConstantNumber.containedOneValue, consoleInputRow, consoleInputColumn, 4, false);
                // 삭제하고자 하는 책의 아이디 입력

                for (int i = 0; i < totalStorage.books.Count; i++)
                {
                    if (int.Parse(deleteBookId) == totalStorage.books[i].GetId())
                    {
                        totalStorage.books.RemoveAt(i);
                        isValidId = true;
                    }
                }

                if (!isValidId)     // 책의 아이디가 존재하지 않는다면
                {
                    ui.PrintException(ConstantNumber.INVALID_BOOK_ID, consoleInputRow, consoleInputColumn);
                    continue;
                }

                Console.Clear();
                printerBookInformation.PrintSuccessDeleteBook();        // 삭제 성공

                for (int i = 0; i < totalStorage.books.Count; i++)
                {
                    Book deleteBook = totalStorage.books[i];
                    id = deleteBook.GetId();
                    title = deleteBook.GeTitle();
                    author = deleteBook.GetAuthor();
                    publisher = deleteBook.GetPublisher();
                    amount = deleteBook.GetAmount();
                    price = deleteBook.GetPrice();
                    publishDay = deleteBook.GetPublishDay();
                    ISBN = deleteBook.GetISBN();
                    information = deleteBook.GetInformation();

                    printerBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);
                }

                Console.SetCursorPosition(0, 0);

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, consoleInputRow, consoleInputColumn);
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

        private string ModifyBookInformation(int column, string regex, bool isPassword)
        {
            // 책의 정보의 유효성 검사
            consoleInputRow = 68;
            consoleInputColumn = 7 + column;

            string input = "";

            input = handlingException.IsValid(regex, consoleInputRow, consoleInputColumn, 20, isPassword);

            return input;
        }

        public void ModifyBook(int bookIndex)
        {
            // 책의 정보 수정
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
                Console.Clear();
                validInput = 0;

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);
                // 최종적으로 엔터를 누른 곳의 인덱스 반환

                if(selectedMenu == ConstantNumber.EXIT) // esc를 눌렀다면
                {
                    return;
                }

                switch (selectedMenu)
                {
                    case (int)(BOOKINFORMATION.TITLE):
                        title = ModifyBookInformation(0, ConstantNumber.title, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = EnterEsc(title);
                        break;
                    case (int)(BOOKINFORMATION.AUTHOR):
                        author = ModifyBookInformation(1, ConstantNumber.author, ConstantNumber.IS_NOT_PASSWORD); 
                        validInput = EnterEsc(author);
                        break;
                    case (int)(BOOKINFORMATION.PUBLISHER):
                        publisher = ModifyBookInformation(2, ConstantNumber.containedOneValue, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = EnterEsc(publisher);
                        break;
                    case (int)(BOOKINFORMATION.AMOUNT):
                        amount = ModifyBookInformation(3, ConstantNumber.amount, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = EnterEsc(amount);
                        break;
                    case (int)(BOOKINFORMATION.PRICE):
                        price = ModifyBookInformation(4, ConstantNumber.price, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = EnterEsc(price);
                        break;
                    case (int)(BOOKINFORMATION.PUBLISHDAY):
                        publishDay = ModifyBookInformation(5, ConstantNumber.publishDay, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = EnterEsc(publishDay);
                        break;
                    case (int)(BOOKINFORMATION.SUCCESS):        // 수정 완료 칸에서 엔터를 눌렀다면
                        isInputEnter = true;
                        break;
                }
                if (isInputEnter)       // 지금까지 입력되어 있던 모든 값을 저장
                {
                    if (title != "")
                    {
                        totalStorage.books[index].SetTitle(title);
                    }
                    if (author != "")
                    {
                        totalStorage.books[index].SetAuthor(author);
                    }
                    if (publisher != "")
                    {
                        totalStorage.books[index].SetPublisher(publisher);
                    }
                    if (amount != "")
                    {
                        totalStorage.books[index].SetAmount(amount);
                    }
                    if (price != "")
                    {
                        totalStorage.books[index].SetPrice(price);
                    }
                    if (publishDay != "")
                    {
                        totalStorage.books[index].SetPublisher(publishDay);
                    }
                }

                if (validInput == ConstantNumber.EXIT)
                {
                    isInputEnter = true;
                }
            }
        }
        public void EnterMenuModifyTheBook()        // 책의 정보를 수정하는 메뉴로의 진입
        {
            bool isValidId = false;

            int consoleInputRow = 60;
            int consoleInputColumn = 3;
            int bookIndex = 0;

            string modifyBookId = "";
            int modifyBookIdNumber = 0;

            while (!isInputESC)
            {
                Console.Clear();
                printerBookInformation.PrintModifyBookInformationUI();

                for (int i = 0; i < totalStorage.books.Count; i++)
                {
                    Book modifyBook = totalStorage.books[i];
                    id = modifyBook.GetId();
                    title = modifyBook.GeTitle();
                    author = modifyBook.GetAuthor();
                    publisher = modifyBook.GetPublisher();
                    amount = modifyBook.GetAmount();
                    price = modifyBook.GetPrice();
                    publishDay = modifyBook.GetPublishDay();
                    ISBN = modifyBook.GetISBN();
                    information = modifyBook.GetInformation();

                    printerBookInformation.PrintBookList(id, title, author, publisher, amount,
                        price, publishDay, ISBN, information);

                }

                Console.SetCursorPosition(0, 0);
                modifyBookId = handlingException.IsValid(ConstantNumber.containedOneValue, consoleInputRow, consoleInputColumn, 20, false);
                // 수정하고자 하는 책의 아이디 입력
                modifyBookIdNumber = int.Parse(modifyBookId);

                for (int i = 0; i < totalStorage.books.Count; i++)
                {
                    if (totalStorage.books[i].GetId() == modifyBookIdNumber)    // 어느 책이 수정하고자 하는 책인지 찾기
                    {
                        bookIndex = i;
                        isValidId = true;
                        break;
                    }
                }

                if (!isValidId)     // 입력한 책의 아이디가 존재하지 않는다면
                {
                    ui.PrintException(ConstantNumber.INVALID_BOOK_ID, consoleInputRow, consoleInputColumn);
                    continue;
                }
                ModifyBook(bookIndex);
                break;
            }
        }
    }
}
