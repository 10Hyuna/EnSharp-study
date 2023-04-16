﻿using Library.Model;
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
        MovingCursorPosition curser;
        RegexStorage regex;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        PrinterBookInformation printBookInformation;
        PrinterUserInformation printUserInformation;
        EnteringMenuOfBook menuOfBook;
        EnteringMenuOfUser menuOfUser;
        public SelectingMenuInManagerMode(UI ui, TotalStorage totalInformationStorage, MovingCursorPosition curser,
            RegexStorage regex, HandlingException handlingException, InputFromUser inputFromUser, 
            PrinterBookInformation printBookInformation, PrinterUserInformation printUserInformation, 
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

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);

                if(selectedMenu == ConstantNumber.EXIT)      // 중도에 ESC를 눌러 반환된 값이 있다면
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
                        menuOfBook.EnterMenuModifyTheBook();
                        break;
                    case ConstantNumber.MANAGEUSER:
                        menuOfUser.ManageUserInformation();
                        break;
                    case ConstantNumber.RENTALSTATE:
                        menuOfUser.RentalState();
                        break;
                }
            }
        }
    }
}
