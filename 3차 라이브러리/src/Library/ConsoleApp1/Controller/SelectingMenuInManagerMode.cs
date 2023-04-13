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
        TotalInformationStorage totalInformationStorage;
        MovingCurserPosition curser;
        RegexStorage regex;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        PrintingBookInformation printBookInformation;
        PrintingUserInformation printUserInformation;
        EnteringMenuOfBook menuOfBook;
        EnteringMenuOfUser menuOfUser;
        public SelectingMenuInManagerMode(UI ui, TotalInformationStorage totalInformationStorage, MovingCurserPosition curser,
            RegexStorage regex, HandlingException handlingException, InputFromUser inputFromUser, 
            PrintingBookInformation printBookInformation, PrintingUserInformation printUserInformation, 
            EnteringMenuOfBook menuOfBook, EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.totalInformationStorage = totalInformationStorage;
            this.curser = curser;
            this.regex = regex;
            this.handlingException = handlingException;
            this.inputFromUser = inputFromUser;
            this.printBookInformation = printBookInformation;
            this.printUserInformation = printUserInformation;
            this.menuOfBook = menuOfBook;
            this.menuOfUser = menuOfUser;
        }

        public void SelecMenuManagerMode()
        {
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

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu);

                if(selectedMenu == -1)
                {
                    isEnteredESC = true;
                }

                switch(selectedMenu)
                {
                    case ConstantNumber.FINDTHEBOOK:
                        menuOfBook.FindTheBookBySerching();
                        break;
                    case ConstantNumber.ADDTHEBOOK:
                        menuOfBook.AddTheBook();
                        break;
                    case ConstantNumber.DELETETHEBOOK:
                        menuOfBook.DeleteTheBook();
                        break;
                    case ConstantNumber.MODIFYBOKKINFORMATION:
                        menuOfBook.ModifyTheBook();
                        break;
                    case ConstantNumber.MANAGEUSER:
                        menuOfUser.ManageUserInformation();
                        break;
                    case ConstantNumber.RENTALSTATE:
                        menuOfBook.RentalState();
                        break;
                }
            }
        }
    }
}
