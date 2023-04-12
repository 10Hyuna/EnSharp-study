using Library.Model;
using Library.Model.DTO;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    class EnteringSelectedMenuAboutBook
    {
        TotalInformationStorage totalInformationStorage;
        PrintingBookInformation printBookInformation;
        InputFromUser inputFromUser;
        public EnteringSelectedMenuAboutBook(TotalInformationStorage totalInformationStorage, PrintingBookInformation printBookInformation,
            InputFromUser inputFromUser)
        {
            this.printBookInformation = printBookInformation;
            this.inputFromUser = inputFromUser;
            this.totalInformationStorage = totalInformationStorage;
        }

        public void FindTheBookBySerching() // 찾고자 하는 책의 정보를 입력하는 함수
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
                printBookInformation.PrintFindingBookUI();
                selectedBook(book[0], book[1], book[2]);

                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                keyInfo = Console.ReadKey();
                
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
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
            author = inputFromUser.InputStringFromUser(20, false, ConsoleInputRow, ConsoleInputColumn + 1);    // 작가 입력
            publisher = inputFromUser.InputStringFromUser(20, false, ConsoleInputRow, ConsoleInputColumn + 2);

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

        public void RentTheBook()      // 책 대여 메뉴에 진입했을 때
        {
            const int ConsoleInputRow = 20;
            const int ConsoleInputColumn = 0;

            string bookID;

            List<string> book;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            while (!isCheckedExit)
            {
                book = PrintTheAllBook();

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isCheckedExit = true;
                }

            }                       // 반복문 탈출

            PrintTheAllBook();
            printBookInformation.PrintRenttheBookUI();

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            bookID = Console.ReadLine();        // 빌리고자 하는 책의 아이디 입력
        }

        public void CheckTheRentalBook()
        {

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
