using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.BookAccessor
{
    class FindBook
    {
        TotalStorage totalStorage;
        HandlingException handlingException;
        PrinterBookInformation printerBookInformation;

        public FindBook(TotalStorage totalStorage, HandlingException handlingException, PrinterBookInformation printerBookInformation)
        {
            this.totalStorage = totalStorage;
            this.handlingException = handlingException;
            this.printerBookInformation = printerBookInformation;
        }

        bool isInputESC = false;

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

        public int FindTheBookBySerching() // 찾고자 하는 책의 정보를 입력하는 함수
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            List<string> book;          // 찾을 책의 정보를 저장할 리스트
            isInputESC = false;

            ConsoleKeyInfo keyInfo;

            while (!isInputESC)
            {
                Console.Clear();

                book = PrintTheAllBook();
                if (book == null)       // ESC를 눌러 반환값이 null이라면
                    return -1;

                printerBookInformation.PrintFindingBookUI();
                selectedBook(book[0], book[1], book[2]);    // 찾고자 하는 책의 정보를 기반으로 책을 찾음

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

            Console.Clear();
            printerBookInformation.PrintFindingBookUI();

            for (int i = 0; i < totalStorage.books.Count; i++)
            {
                Book findBook = totalStorage.books[i];
                id = findBook.GetId();
                title = findBook.GeTitle();
                author = findBook.GetAuthor();
                publisher = findBook.GetPublisher();
                amount = findBook.GetAmount();
                price = findBook.GetPrice();
                publishDay = findBook.GetPublishDay();
                ISBN = findBook.GetISBN();
                information = findBook.GetInformation();

                printerBookInformation.PrintBookList(id, title, author, publisher, amount,
                    price, publishDay, ISBN, information);
            }

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            inputTitle = handlingException.IsValid(ConstantNumber.containedOneValue, ConsoleInputRow, ConsoleInputColumn, 20, false); // 제목 입력
            if (inputTitle == null)     // ESC를 눌러 반환값이 null이라면
                return null;

            inputAuthor = handlingException.IsValid(ConstantNumber.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 1, 20, false);    // 작가 입력
            if (inputAuthor == null)
                return null;

            inputPublisher = handlingException.IsValid(ConstantNumber.containedOneValue, ConsoleInputRow, ConsoleInputColumn + 2, 20, false);     // 출판사 입력
            if (inputPublisher == null)
                return null;

            Console.Clear();

            return new List<string> { inputTitle, inputAuthor, inputPublisher };
        }

        public void selectedBook(string inputTitle, string inputAuthor, string inputPublisher)      // 주어진 책의 정보들과 일치하는
                                                                                                    // 문자가 있는 책 출력
        {
            for (int i = 0; i < totalStorage.books.Count; i++)
            {

                title = totalStorage.books[i].GeTitle();
                author = totalStorage.books[i].GetAuthor();
                publisher = totalStorage.books[i].GetPublisher();

                if (title.Contains(inputTitle)
                    && author.Contains(inputAuthor)
                    && publisher.Contains(inputPublisher))
                {
                    id = totalStorage.books[i].GetId();
                    publisher = totalStorage.books[i].GetPublisher();
                    amount = totalStorage.books[i].GetAmount();
                    price = totalStorage.books[i].GetPrice();
                    publishDay = totalStorage.books[i].GetPublishDay();
                    ISBN = totalStorage.books[i].GetISBN();
                    information = totalStorage.books[i].GetInformation();
                    printerBookInformation.PrintBookList(id, title, author, publisher,
                        amount, price, publishDay, ISBN, information);
                }
            }
        }
    }
}
