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
        EnteringMenuOfBook menuOfBook;
        RegexStorage regex;
        HandlingException handlingException;
        EnteringMenuOfUser menuOfUser;

        public SelectingMenuInUserMode(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingUserInformation userInformation, PrintingBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.printuserInformation = userInformation;
            this.printbookInformation = bookInformation;
            this.inputFromUser = inputFromUser;
            this.regex = regex;
            this.handlingException = handlingException;
            this.menuOfUser = menuOfUser;
            menuOfBook = new EnteringMenuOfBook(totalInformationStorage, bookInformation,
                inputFromUser, ui, handlingException, regex, curser);
            
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

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);
                
                if(selectedMenu == -1)
                {
                    isEnteredESC = true;
                }

                switch (selectedMenu)
                {
                    case ConstantNumber.FINDTHEBOOK:
                        menuOfBook.FindTheBookBySerching();
                        break;
                    case ConstantNumber.RENTTHEBOOK:
                        menuOfBook.RentTheBook();
                        break;
                    case ConstantNumber.CHECKTHERETALBOOK:
                        menuOfBook.CheckTheRentalBook();
                        break;
                    case ConstantNumber.RETURNTHEBOOK:
                        menuOfBook.ReturnTheBook();
                        break;
                    case ConstantNumber.RETURNBOOKLIST:
                        menuOfBook.ReturnTheBookList();
                        break;
                    case ConstantNumber.MODIFYMYINFORMATION:
                        menuOfUser.ModifyMyInformation();
                        break;
                    case ConstantNumber.DELETEACCOUNT:
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
