using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Library.Controller
{
    class MemberAccessInUser
    {
        UI ui;
        MovingCursorPosition cursor;
        TotalStorage totalStorage;
        PrinterUserInformation userinformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        RegexStorage regex;

        public MemberAccessInUser(UI ui, MovingCursorPosition cursor, TotalStorage totalStorage, 
               PrinterUserInformation userInformation, InputFromUser inputFromUser, 
               HandlingException handlingException, RegexStorage regex)
        { 
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalStorage;
            this.userinformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
        }


    }
}
