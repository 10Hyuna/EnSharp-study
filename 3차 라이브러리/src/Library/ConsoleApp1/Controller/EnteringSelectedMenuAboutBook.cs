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
        PrintingBookInformation printingBookInformation;
        public EnteringSelectedMenuAboutBook(TotalInformationStorage totalInformationStorage, PrintingBookInformation printingBookInformation)
        {
            totalInformationStorage = new TotalInformationStorage();
            this.printingBookInformation = printingBookInformation;
        }
        public void SelectedBookList(int ConsoleInputRow, int ConsoleInputColumn) // 찾고자 하는 책의 정보를 입력하는 함수
        {
            string title;
            string author;
            string publisher;

            ConsoleKeyInfo keyInfo;

            bool isInputESC = false;
            int selectedKey;

            while (!isInputESC)
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                title = Console.ReadLine();     // 제목 입력
                if (title == null) // 값이 null일 경우
                {
                    title = "";
                }
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                author = Console.ReadLine();    // 작가 입력
                if (author == null)
                {
                    author = "";
                }
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 2);
                publisher = Console.ReadLine();
                if (publisher == null)
                {
                    publisher = "";
                }

                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    bookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
                }
                bookInformation.PrintFindingBookUI();
                for (int i = 0; i < totalInformationStorage.books.Count; i++)
                {
                    if (totalInformationStorage.books[i].title.Contains(title) && totalInformationStorage.books[i].author.Contains(author) && totalInformationStorage.books[i].publisher.Contains(publisher))
                    {
                        bookInformation.PrintBookList(totalInformationStorage.books[i].id, totalInformationStorage.books[i].title,
                            totalInformationStorage.books[i].author, totalInformationStorage.books[i].publisher, totalInformationStorage.books[i].amount,
                            totalInformationStorage.books[i].price, totalInformationStorage.books[i].publishDay, totalInformationStorage.books[i].ISBN,
                            totalInformationStorage.books[i].information);
                    }
                }     // 입력받은 값과 일치하는 정보를 출력해 주는 함수

                selectedKey = inputFromUser.SelectKey(0, 0);
                if (selectedKey == 11)
                {
                    isInputESC = true;
                }
            }
        }
        public void FindTheBook(UI ui, TotalInformationStorage dataController)      // 책 찾기 메뉴에 진입했을 경우
        {

            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            while (!isCheckedExit)
            {
                Console.Clear();
                ui.PrintFindingBookUI(dataController);
                ui.PrintAllBookList(dataController);
                SelectedBookList(dataController, ui, ConsoleInputRow, ConsoleInputColumn);

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)        // ESC 키를 입력한다면
                {
                    isCheckedExit = true;
                }
            } 
        }
    }
}
