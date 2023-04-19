using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    class SelectingMenuInManagerMode
    {
        UI ui;
        TotalStorage totalInformationStorage;
        MovingCursorPosition cursor;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        PrinterBookInformation printBookInformation;
        PrinterUserInformation printUserInformation;
        FindBook findBook;
        MemberAccessInManager memberAccessInManager;
        BookAccessInManager bookAccessInManager;
        ModificationUserInformation modificationUserInformation;

        public SelectingMenuInManagerMode(UI ui, TotalStorage totalInformationStorage, MovingCursorPosition cursor,
            HandlingException handlingException, InputFromUser inputFromUser, 
            PrinterBookInformation printBookInformation, PrinterUserInformation printUserInformation, 
            FindBook findBook, BookAccessInManager bookAccessInManager, MemberAccessInManager memberAccessInManager,
            ModificationUserInformation modificationUserInformation)
        {
            this.ui = ui;
            this.totalInformationStorage = totalInformationStorage;
            this.cursor = cursor;
            this.handlingException = handlingException;
            this.inputFromUser = inputFromUser;
            this.printBookInformation = printBookInformation;
            this.printUserInformation = printUserInformation;
            this.findBook = findBook;
            this.memberAccessInManager = memberAccessInManager;
            this.bookAccessInManager = bookAccessInManager;
            this.modificationUserInformation = modificationUserInformation;
        }

        public void SelecMenuManagerMode()
        {
            int WindowCenterWidth = 50;
            int WindowCenterHeight = 17;

            Console.Clear();
            ui.PrintManagerMenu();
            int selectedMenu = 0;

            bool isEnteredESC = false;

            string[] menu = { "도서찾기", "도서추가", "도서삭제", "도서수정", "회원관리", "대여상황" };

            while(!isEnteredESC)
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(9);

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);

                if(selectedMenu == ConstantNumber.EXIT)      // 중도에 ESC를 눌러 반환된 값이 있다면
                {
                    isEnteredESC = true;
                }

                switch(selectedMenu)        // 엔터를 입력한 최종 인덱스가 무엇인지에 따라
                {
                    case (int)(MANAGERMODE.FIND_BOOK):      // 케이스문 진입
                        findBook.FindTheBookBySerching();
                        break;
                    case (int)(MANAGERMODE.ADD_BOOK):
                        bookAccessInManager.AddTheBook();
                        break;
                    case (int)(MANAGERMODE.DLETE_BOOK):
                        bookAccessInManager.DeleteTheBook();
                        break;
                    case (int)(MANAGERMODE.MODIFY_BOOK_INFORMATION):
                        bookAccessInManager.EnterMenuModifyTheBook();
                        break;
                    case (int)(MANAGERMODE.MANAGE_USER):
                        modificationUserInformation.ManageUserInformation();
                        break;
                    case (int)(MANAGERMODE.RENTAL_STATE):
                        memberAccessInManager.RentalState();
                        break;
                }
            }
        }
    }
}
