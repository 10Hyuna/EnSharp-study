using Library.Model;
using Library.Model.DTO;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SelectedBookList() // 찾고자 하는 책의 정보를 입력하는 함수
        {
            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            string title;
            string author;
            string publisher;

            bool isInputESC = false;
            int selectedKey;

            while (!isInputESC)
            {
                Console.Clear();
                
                FindTheBook();

                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                title = Console.ReadLine();     // 제목 입력
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                author = Console.ReadLine();    // 작가 입력
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 2);
                publisher = Console.ReadLine();

                Console.Clear();

                printBookInformation.PrintFindingBookUI();

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    if (totalInformationStorage.books[i].title.Contains(title) && totalInformationStorage.books[i].author.Contains(author) && totalInformationStorage.books[i].publisher.Contains(publisher))
                    {
                        printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
                    }
                }     // 입력받은 값과 일치하는 정보를 출력해 주는 함수

                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                Console.ReadKey();

                selectedKey = inputFromUser.SelectKey(0, 0);
                if (selectedKey == 11)
                {
                    isInputESC = true;
                }
            }
        }

        public void FindTheBook()      // 책 찾기 메뉴에 진입했을 경우
        {

            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            printBookInformation.PrintFindingBookUI();
            for (int i = 0; i < totalInformationStorage.books.Count; i++)
            {
                printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                        totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                        totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                        totalInformationStorage.books[i].information);
                //}

                //while (!isCheckedExit)
                //{
                //    Console.Clear();
                //    printBookInformation.PrintFindingBookUI();
                //    for (int i = 0; i < totalInformationStorage.books.Count; i++)
                //    {
                //        printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                //                totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                //                totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                //                totalInformationStorage.books[i].information);
                //    }

                //    keyInfo = Console.ReadKey();

                //    if (keyInfo.Key == ConsoleKey.Escape)        // ESC 키를 입력한다면
                //    {
                //        isCheckedExit = true;
                //    }
            }
        }

        public void RentTheBook()      // 책 대여 메뉴에 진입했을 때
        {
            const int ConsoleInputRow = 20;
            const int ConsoleInputColumn = 0;

            string bookID;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            while (!isCheckedExit)
            {
                Console.Clear();
                printBookInformation.PrintFindingBookUI();
                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    printBookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
                }
                SelectedBookList();

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isCheckedExit = true;
                }

            }                       // 반복문 탈출

            FindTheBook();
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
