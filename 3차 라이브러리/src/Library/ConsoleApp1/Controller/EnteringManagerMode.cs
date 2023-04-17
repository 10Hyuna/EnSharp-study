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
        ManagerSignIn managerSignIn;
        FindBook findBook;

        public EnteringManagerMode(UI ui, MovingCursorPosition cursor, TotalStorage totalInformationStorage, 
            PrinterBookInformation bookInformation, PrinterUserInformation userInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, UserSignInOrUp progressInSignInOrSignUp,
            FindBook findBook)
        {
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalInformationStorage;
            this.bookInformation = bookInformation;
            this.userInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
            this.findBook = findBook;
            managerMode = new SelectingMenuInManagerMode(ui, totalInformationStorage, cursor, regex, handlingException,
                inputFromUser, bookInformation, userInformation, findBook);
            managerSignIn = new ManagerSignIn(ui, totalStorage);
        }
        public void UsingManagerMenu()
        {
            bool isInputEnter = false;

            int selectedMenu = 0;
            int index;

            while(!isInputEnter)
            {
                Console.Clear();
                ui.PrintLogin();

                isInputEnter = managerSignIn.SignInManager();        // 로그인 함수에 진입
                if(isInputEnter)     // ESC를 누르지 않았다면
                {
                    managerMode.SelecMenuManagerMode();     // 매니저 모드에 진입
                }
            }
        }
    }
}
