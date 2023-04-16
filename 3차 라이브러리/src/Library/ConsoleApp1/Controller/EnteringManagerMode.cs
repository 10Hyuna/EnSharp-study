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
        PrintingBookInformation bookInformation;
        PrintingUserInformation userInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        RegexStorage regex;
        ProgressInSignInOrSignUp progressInSignInOrSignUp;
        SelectingMenuInManagerMode managerMode;
        EnteringMenuOfBook menuOfBook;
        EnteringMenuOfUser menuOfUser;
        ManagerSignIn managerSignIn;

        public EnteringManagerMode(UI ui, MovingCursorPosition cursor, TotalStorage totalInformationStorage, 
            PrintingBookInformation bookInformation, PrintingUserInformation userInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, ProgressInSignInOrSignUp progressInSignInOrSignUp,
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
            this.progressInSignInOrSignUp = progressInSignInOrSignUp;
            this.menuOfBook = menuOfBook;
            this.menuOfUser = menuOfUser;
            managerMode = new SelectingMenuInManagerMode(ui, totalInformationStorage, cursor, regex, handlingException,
                inputFromUser, bookInformation, userInformation, menuOfBook, menuOfUser);
            managerSignIn = new(ui, total)
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

                index = progressInSignInOrSignUp.ManagerSignIn();        // 로그인 함수에 진입
                if(index == ConstantNumber.EXIT)        // 도중에 ESC를 눌러 반환된 값이 온다면
                {
                    selectedMenu = ConstantNumber.EXIT;     
                }
                else            // ESC를 누르지 않았다면
                {
                    managerMode.SelecMenuManagerMode();     // 매니저 모드에 진입
                }
            }
        }
    }
}
