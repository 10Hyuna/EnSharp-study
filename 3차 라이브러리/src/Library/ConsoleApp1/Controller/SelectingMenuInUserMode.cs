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
        EnteringMenuOfUser selectedMenuAboutBook;
        RegexStorage regex;
        HandlingException handlingException;
        EnteringMenuOfBook selectedMenuAboutUserInUser;

        public SelectingMenuInUserMode(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingUserInformation userInformation, PrintingBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.printuserInformation = userInformation;
            this.printbookInformation = bookInformation;
            this.inputFromUser = inputFromUser;
            this.regex = regex;
            this.handlingException = handlingException;
            selectedMenuAboutBook = new EnteringMenuOfUser(totalInformationStorage, bookInformation,
                inputFromUser, ui, handlingException, regex);
            selectedMenuAboutUserInUser = new EnteringMenuOfBook(totalInformationStorage, userInformation,
                inputFromUser, ui, handlingException, regex, curser);
        }
        
        public void SelectMenuInUserMode()
        {               // 유저 모드에서 로그인에 성공했을 경우, 사용할 수 있는 메뉴
            Console.Clear();
            ui.PrintUserMenu();
            int selectedMenu = 0;

            int checkingBreak = -1;
            bool isEnteredESC = false;

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
                    case ConstantNumber.FINDTHEBOOK:
                        selectedMenuAboutBook.FindTheBookBySerching();
                        break;
                    case ConstantNumber.RENTTHEBOOK:
                        selectedMenuAboutBook.RentTheBook();
                        break;
                    case ConstantNumber.CHECKTHERETALBOOK:
                        selectedMenuAboutBook.CheckTheRentalBook();
                        break;
                    case ConstantNumber.RETURNTHEBOOK:
                        selectedMenuAboutBook.ReturnTheBook();
                        break;
                    case ConstantNumber.RETURNBOOKLIST:
                        selectedMenuAboutBook.ReturnTheBookList();
                        break;
                    case ConstantNumber.MODIFYMYINFORMATION:
                        selectedMenuAboutUserInUser.ModifyMyInformation();
                        break;
                    case ConstantNumber.DELETEACCOUNT:
                        checkingBreak = selectedMenuAboutUserInUser.DeleteMyAccount();
                        break;
                }

                if(checkingBreak != 0)
                {
                    isEnteredESC = true;
                }
            }
        }
    }
}
