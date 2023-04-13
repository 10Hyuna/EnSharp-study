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
        EnteringMenuOfUser bookMenuSelect;
        public SelectingMenuInManagerMode(UI ui, TotalInformationStorage totalInformationStorage, MovingCurserPosition curser,
            RegexStorage regex, HandlingException handlingException, InputFromUser inputFromUser, 
            PrintingBookInformation printBookInformation, PrintingUserInformation printUserInformation)
        {
            this.ui = ui;
            this.totalInformationStorage = totalInformationStorage;
            this.curser = curser;
            this.regex = regex;
            this.handlingException = handlingException;
            this.inputFromUser = inputFromUser;
            this.printBookInformation = printBookInformation;
            this.printUserInformation = printUserInformation;
            bookMenuSelect = new EnteringMenuOfUser(totalInformationStorage, printBookInformation,
                inputFromUser, ui, handlingException, regex);
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
                    //case ConstantNumber.FINDTHEBOOK:
                    //    bookMenuSelect.FindTheBookBySerching();
                    //    break;
                    //case ConstantNumber.ADDTHEBOOK:
                    //    bookMenuSelect.
                }
            }
        }
    }
}
