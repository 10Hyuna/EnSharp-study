using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;
using Library.View;

namespace Library.Controller
{
    class EnteringManagerMode
    {
        UI ui;
        MovingCursorPosition cursor;
        TotalStorage totalStorage;
        PrinterBookInformation bookInformation;
        PrinterUserInformation userInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        RegexStorage regex;
        UserSignInOrUp progressInSignInOrSignUp;
        SelectingMenuInManagerMode managerMode;
        EnteringMenuOfBook menuOfBook;
        EnteringMenuOfUser menuOfUser;
        ManagerSignIn managerSignIn;

        public EnteringManagerMode(UI ui, MovingCursorPosition cursor, TotalStorage totalInformationStorage, 
            PrinterBookInformation bookInformation, PrinterUserInformation userInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, UserSignInOrUp progressInSignInOrSignUp,
            EnteringMenuOfBook menuOfBook, EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalInformationStorage;
            this.bookInformation = bookInformation;
            this.userInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
            this.menuOfBook = menuOfBook;
            this.menuOfUser = menuOfUser;
            managerMode = new SelectingMenuInManagerMode(ui, totalInformationStorage, cursor, regex, handlingException,
                inputFromUser, bookInformation, userInformation, menuOfBook, menuOfUser);
            managerSignIn = new ManagerSignIn(ui, totalStorage);
        }
        public void UsingManagerMenu()
        {
            bool isInputEnter = false;

            int selectedMenu = 0;
            int index;

            while(selectedMenu != ConstantNumber.EXIT)
            {
                Console.Clear();
                ui.PrintLogin();

                selectedMenu = managerSignIn.SignUpMember();        // 로그인 함수에 진입
                if(selectedMenu != ConstantNumber.EXIT)     // ESC를 누르지 않았다면
                {
                    managerMode.SelecMenuManagerMode();     // 매니저 모드에 진입
                }
            }
        }
    }
}
