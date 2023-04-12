using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public EnteringManagerMode(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingBookInformation bookInformation, PrintingUserInformation userInformation, InputFromUser inputFromUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.bookInformation = bookInformation;
            this.userInformation = userInformation;
            this.inputFromUser = inputFromUser;
        }
        public void UsingManagerMenu()
        {
            ui.PrintLogin();
        }
    }
}
