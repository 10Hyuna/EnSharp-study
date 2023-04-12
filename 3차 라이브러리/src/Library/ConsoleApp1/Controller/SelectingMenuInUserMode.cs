using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    class SelectingMenuInUserMode
    {
        UI ui;
        MovingCurserPosition curser;
        TotalInformationStorage totalInformationStorage;
        PrintingUserInformation printuserInformation;
        PrintingBookInformation printbookInformation;
        InputFromUser inputFromUser;
        EnteringSelectedMenuAboutBook selectedMenuAboutBook;

        public SelectingMenuInUserMode(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingUserInformation userInformation, PrintingBookInformation bookInformation, InputFromUser inputFromUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.printuserInformation = userInformation;
            this.printbookInformation = bookInformation;
            this.inputFromUser = inputFromUser;
            selectedMenuAboutBook = new EnteringSelectedMenuAboutBook(totalInformationStorage, bookInformation, inputFromUser);
        }

        public void SelectMenuInUserMode(int index)
        {               // 유저 모드에서 로그인에 성공했을 경우, 사용할 수 있는 메뉴
            Console.Clear();
            ui.PrintUserMenu();
            int selectedMenu = 0;
            bool isEnteredESC = false;

            const int findingTheBook = 0;
            const int rentingTheBook = 1;
            const int checkingTheRentalBook = 2;
            const int returningTheBook = 3;
            const int returningTheBookList = 4;
            const int modifyingInformationOfUser = 5;
            const int delectingAccount = 6;
            const int exit = -1;

            string[] menu = { "도서 찾기", "도서 대여", "도서 대여 확인", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제" };
            while (!isEnteredESC)
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(10);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu);
                
                if(selectedMenu == -1)
                {
                    isEnteredESC = true;
                }

                switch (selectedMenu)
                {
                    case findingTheBook:
                        selectedMenuAboutBook.SelectedBookList();
                        break;
                    case rentingTheBook:
                        selectedMenuAboutBook.RentTheBook();
                        break;
                    case checkingTheRentalBook:
                        selectedMenuAboutBook.CheckTheRentalBook();
                        break;
                    case returningTheBookList:
                        selectedMenuAboutBook.ReturnTheBook();
                        break;
                    case modifyingInformationOfUser:

                        break;
                    case delectingAccount:

                        break;
                }

            }
        }
    }
}
