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
        MovingCurserPosition curser;
        TotalInformationStorage totalInformationStorage;
        PrintingBookInformation bookInformation;
        PrintingUserInformation userInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        RegexStorage regex;
        ProgressInSignInOrSignUp progressInSignInOrSignUp;
        SelectingMenuInManagerMode managerMode;
        EnteringMenuOfBook menuOfBook;
        EnteringMenuOfUser menuOfUser;

        public EnteringManagerMode(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingBookInformation bookInformation, PrintingUserInformation userInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, ProgressInSignInOrSignUp progressInSignInOrSignUp,
            EnteringMenuOfBook menuOfBook, EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.bookInformation = bookInformation;
            this.userInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
            this.progressInSignInOrSignUp = progressInSignInOrSignUp;
            this.menuOfBook = menuOfBook;
            this.menuOfUser = menuOfUser;
            managerMode = new SelectingMenuInManagerMode(ui, totalInformationStorage, curser, regex, handlingException,
                inputFromUser, bookInformation, userInformation, menuOfBook, menuOfUser);
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

                index = progressInSignInOrSignUp.SignInMember(true);
                if(index == ConstantNumber.EXIT)
                {
                    selectedMenu = ConstantNumber.EXIT;
                }
                else
                {
                    managerMode.SelecMenuManagerMode();
                }
            }
        }
    }
}
