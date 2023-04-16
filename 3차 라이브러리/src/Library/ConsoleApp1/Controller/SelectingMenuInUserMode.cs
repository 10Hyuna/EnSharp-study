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
        MovingCursorPosition cursor;
        TotalStorage totalStorage;
        PrinterUserInformation printuserInformation;
        PrinterBookInformation printbookInformation;
        InputFromUser inputFromUser;
        RegexStorage regex;
        HandlingException handlingException;
        MemberAccessInUser memberAccessInUser;
        BookAccessInUser bookAccessInUser;

        public SelectingMenuInUserMode(UI ui, MovingCursorPosition cursor, TotalStorage totalStorage, 
            PrinterUserInformation userInformation, PrinterBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex)
        {
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalStorage;
            this.printuserInformation = userInformation;
            this.printbookInformation = bookInformation;
            this.inputFromUser = inputFromUser;
            this.regex = regex;
            this.handlingException = handlingException;
            memberAccessInUser = new MemberAccessInUser(ui, cursor, totalStorage, userInformation, bookInformation, inputFromUser, handlingException, regex);
            bookAccessInUser = new BookAccessInUser(ui, cursor, totalStorage, userInformation, bookInformation, inputFromUser, handlingException, regex);
        }
        
        public void SelectMenuInUserMode()
        {               // 유저 모드에서 로그인에 성공했을 경우, 사용할 수 있는 메뉴
            int WindowCenterWidth = 50;
            int WindowCenterHeight = 17;

            Console.Clear();
            ui.PrintUserMenu();
            int selectedMenu = 0;

            int checkingBreak = -1;
            bool isEnteredESC = false;

            string[] menu = { "도서 찾기", "도서 대여", "도서 대여 확인", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제" };
            while (!isEnteredESC)
            {
                checkingBreak = -1;
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(10);

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);
                
                if(selectedMenu == -1)
                {
                    isEnteredESC = true;
                }

                switch (selectedMenu)
                {
                    case (int)(USERMODE.FIND_BOOK):
                        menuOfBook.FindTheBookBySerching();
                        break;
                    case (int)(USERMODE.RENT_BOOK):
                        menuOfBook.RentTheBook();
                        break;
                    case (int)(USERMODE.RENT_BOOK_LIST):
                        menuOfBook.CheckTheRentalBook();
                        break;
                    case (int)(USERMODE.RETURN_BOOK):
                        menuOfBook.ReturnTheBook();
                        break;
                    case (int)(USERMODE.RETURN_BOOK_LIST):
                        menuOfBook.ReturnTheBookList();
                        break;
                    case (int)(USERMODE.MODIFY_MY_INFORMATION):
                        menuOfUser.ModifyMyInformation();
                        break;
                    case (int)(USERMODE.DELETE_ACCOUNT):
                        checkingBreak = menuOfUser.DeleteMyAccount();
                        break;
                }

                if(checkingBreak == 0)
                {
                    isEnteredESC = true;
                }
            }
        }
    }
}
