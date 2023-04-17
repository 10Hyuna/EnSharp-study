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
        PrinterUserInformation printerUserInformation;

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

        bool isInputESC;
        ConsoleKeyInfo keyInfo;

        int consoleInputRow;
        int consoleInputColumn;

        public void ModifyMyInformation()
        {
            int WindowCenterWidth = 30;
            int WindowCenterHeight = 7;

            int index = 0;
            int selectedMenu = 0;
            int validInput = 0;

            bool isInputEnter = false;

            string[] menu = {"User ID (8~ 15글자 영어, 숫자 포함) :", "User PW (8~ 15글자 영어, 숫자 포함) :",
                "User Name (한글, 영어 포함 2글자 이상 :", "User Age( 자연수 0 ~ 200세 ) :",
                "User PhoneNumber ( 01x-xxxx-xxxx ) :","User Address ( 도로명 주소 형식 ) :", "회원 정보 수정하기"};

            string id = "";
            string password = "";
            string name = "";
            string age = "";
            string phoneNumber = "";
            string address = "";

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)
                {
                    index = i;
                    break;
                }
            }

            while (!isInputEnter)
            {
                validInput = 0;

                Console.Clear();
                ui.PrintBox(4);
                printerUserInformation.PrintModifyMyInformationUI();

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);

                switch (selectedMenu)
                {
                    case (int)(USERINFORMATION.ID):
                        id = ModifyInformation(0, ConstantNumber.idCheck);
                        validInput = inputFromUser.EnterEsc(id);
                        break;
                    case (int)(USERINFORMATION.PASSWORD):
                        password = ModifyInformation(1, ConstantNumber.passwordCheck);
                        validInput = inputFromUser.EnterEsc(password);
                        break;
                    case (int)(USERINFORMATION.NAME):
                        name = ModifyInformation(2, ConstantNumber.nameCheck);
                        validInput = inputFromUser.EnterEsc(name);
                        break;
                    case (int)(USERINFORMATION.AGE):
                        age = ModifyInformation(3, ConstantNumber.ageCheck);
                        validInput = inputFromUser.EnterEsc(age);
                        break;
                    case (int)(USERINFORMATION.PHONENUMBER):
                        phoneNumber = ModifyInformation(4, ConstantNumber.phoneNumberCheck);
                        validInput = inputFromUser.EnterEsc(phoneNumber);
                        break;
                    case (int)(USERINFORMATION.ADDRESS):
                        address = ModifyInformation(5, ConstantNumber.addressCheck);
                        validInput = inputFromUser.EnterEsc(address);
                        break;
                    case (int)(USERINFORMATION.SUCCESS):
                        isInputEnter = true;
                        break;
                }
                if (isInputEnter)
                {
                    if (id != "")
                    {
                        totalStorage.users[index].SetUserId(id);
                    }
                    if (password != "")
                    {
                        totalStorage.users[index].SetUserPassword(password);
                    }
                    if (name != "")
                    {
                        totalStorage.users[index].SetUserName(name);
                    }
                    if (age != "")
                    {
                        totalStorage.users[index].SetUserAge(age);
                    }
                    if (phoneNumber != "")
                    {
                        totalStorage.users[index].SetUserPhoneNumber(phoneNumber);
                    }
                    if (address != "")
                    {
                        totalStorage.users[index].SetUserAddress(address);
                    }
                }

                if (validInput == ConstantNumber.EXIT)
                {
                    isInputEnter = true;
                }
            }
        }
        private string ModifyInformation(int column, string regex)
        {
            consoleInputRow = 68;
            consoleInputColumn = 7 + column;

            string input = "";

            input = handlingException.IsValid(regex, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }

        public int DeleteMyAccount()
        {

            ConsoleKeyInfo keyInfo;

            bool isSuccessDelete = true;
            bool isInputEnter = false;
            int index = 0;
            int breakNumber = -1;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetUserId() == totalStorage.loggedInUserId)
                {
                    index = i;
                    break;
                }
            }

            while (!isInputEnter)
            {
                Console.Clear();
                printerUserInformation.PrintDeleteAccountUI();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (totalStorage.users[index].BorrowDatas.Count == 0)
                    {
                        totalStorage.users.RemoveAt(index);
                        isInputEnter = true;
                        Console.Clear();
                        printerUserInformation.PrintSuccessDeleteAccount();
                    }
                    else
                    {
                        printerUserInformation.PrintNotWorkedDeleteAccout();
                        isSuccessDelete = false;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    breakNumber = 0;
                    break;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION);
                    continue;
                }

                if (!isSuccessDelete)
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isInputEnter = true;
                        continue;
                    }
                    else
                    {
                        Console.SetCursorPosition(40, 18);
                        ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION);
                    }
                }
            }
            return breakNumber;
        }
    }
}
