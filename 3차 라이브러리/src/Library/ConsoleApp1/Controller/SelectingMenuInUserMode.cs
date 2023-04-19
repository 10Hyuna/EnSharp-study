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
        PrinterUserInformation printUserInformation;
        PrinterBookInformation printBookInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        MemberAccessInUser memberAccessInUser;
        BookAccessInUser bookAccessInUser;
        FindBook findBook;
        ModificationUserInformation modificationUserInformation;

        public SelectingMenuInUserMode(UI ui, MovingCursorPosition cursor, TotalStorage totalStorage, 
            PrinterUserInformation userInformation, PrinterBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, FindBook findBook, ModificationUserInformation modificationUserInformation)
        {
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalStorage;
            this.printUserInformation = userInformation;
            this.printBookInformation = bookInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.findBook = findBook;
            this.modificationUserInformation = modificationUserInformation;
            memberAccessInUser = new MemberAccessInUser(ui, cursor, totalStorage, userInformation,
                inputFromUser, handlingException);
            bookAccessInUser = new BookAccessInUser(ui, totalStorage, bookInformation,
                inputFromUser, handlingException, findBook);
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
                
                if(selectedMenu == -1)          // esc를 눌렀다면
                {
                    isEnteredESC = true;
                }

                switch (selectedMenu)       // 선택한 메뉴의 인덱스가 무엇인지에 따라
                {
                    case (int)(USERMODE.FIND_BOOK):     // 케이스문 안으로 진입
                        findBook.FindTheBookBySerching();
                        break;
                    case (int)(USERMODE.RENT_BOOK):
                        bookAccessInUser.RentTheBook();
                        break;
                    case (int)(USERMODE.RENT_BOOK_LIST):
                        bookAccessInUser.CheckTheRentalBook();
                        break;
                    case (int)(USERMODE.RETURN_BOOK):
                        bookAccessInUser.ReturnTheBook();
                        break;
                    case (int)(USERMODE.RETURN_BOOK_LIST):
                        bookAccessInUser.ReturnTheBookList();
                        break;
                    case (int)(USERMODE.MODIFY_MY_INFORMATION):
                        modificationUserInformation.ModifyInformation();
                        break;
                    case (int)(USERMODE.DELETE_ACCOUNT):
                        checkingBreak = memberAccessInUser.DeleteMyAccount();
                        break;
                }

                if(checkingBreak == 0)      // 계정을 삭제했다면
                {
                    isEnteredESC = true;        // 반복문을 탈출함과 동시에 유저 모드에서 나가짐
                }
            }
        }
    }
}
