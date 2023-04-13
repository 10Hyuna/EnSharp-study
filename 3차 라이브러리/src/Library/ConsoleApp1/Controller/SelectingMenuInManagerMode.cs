using Library.Model;
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
        PrintingUserInformation printingUserInformation;
        public SelectingMenuInManagerMode(UI ui, TotalInformationStorage totalInformationStorage, MovingCurserPosition curser,
            RegexStorage regex, HandlingException handlingException, InputFromUser inputFromUser, 
            PrintingBookInformation printingBookInformation, PrintingUserInformation printingUserInformation)
        {

        }
    }
}
