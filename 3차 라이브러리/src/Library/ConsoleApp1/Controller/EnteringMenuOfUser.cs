using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Controller
{
    class EnteringMenuOfUser
    {
        TotalInformationStorage totalInformationStorage;
        PrintingUserInformation userInformation;
        InputFromUser inputFromUser;
        UI ui;
        HandlingException handlingException;
        RegexStorage regex;
        MovingCurserPosition curser;
        public EnteringMenuOfUser(TotalInformationStorage totalInformationStorage,
            PrintingUserInformation printingUserInformation, InputFromUser inputFromUser, UI ui,
            HandlingException handlingException, RegexStorage regex, MovingCurserPosition curser)
        {
            this.totalInformationStorage = totalInformationStorage;
            this.userInformation = printingUserInformation;
            this.inputFromUser = inputFromUser;
            this.ui = ui;
            this.handlingException = handlingException;
            this.regex = regex;
            this.curser = curser;
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }

        bool isInputESC;
        ConsoleKeyInfo keyInfo;

        int consoleInputRow;
        int consoleInputColumn;
        private string ModifyId()
        {
            consoleInputRow = 68;
            consoleInputColumn = 7;

            string input = "";

            input = handlingException.IsValid(regex.idCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyPassword()
        {
            consoleInputRow = 68;
            consoleInputColumn = 8;

            string input = "";

            input = handlingException.IsValid(regex.passwordCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyName()
        {
            consoleInputRow = 68;
            consoleInputColumn = 9;

            string input = "";

            input = handlingException.IsValid(regex.nameCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyAge()
        {
            consoleInputRow = 68;
            consoleInputColumn = 10;

            string input = "";

            input = handlingException.IsValid(regex.ageCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }
        private string ModifyPhoneNumber()
        {
            consoleInputRow = 68;
            consoleInputColumn = 11;

            string input = "";

            input = handlingException.IsValid(regex.phoneNumberCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;

        }
        private string ModifyAddress()
        {
            consoleInputRow = 68;
            consoleInputColumn = 12;

            string input = "";

            input = handlingException.IsValid(regex.addressCheck, consoleInputRow, consoleInputColumn, 20, false);

            return input;
        }

        private int EnterEsc(string input)
        {
            if(input == null)
            {
                return ConstantNumber.EXIT;
            }
            return ConstantNumber.SUCCESS;
        }
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

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
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
                userInformation.PrintModifyMyInformationUI();

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);

                switch(selectedMenu)
                {
                    case ConstantNumber.MODIFYID:
                        id = ModifyId();
                        validInput = EnterEsc(id);
                        break;
                    case ConstantNumber.MODIFYPASSWORD:
                        password = ModifyPassword();
                        validInput = EnterEsc(password);
                        break;
                    case ConstantNumber.MODIFYNAME:
                        name = ModifyName();
                        validInput = EnterEsc(name);
                        break;
                    case ConstantNumber.MODIFYAGE:
                        age = ModifyAge();
                        validInput = EnterEsc(age);
                        break;
                    case ConstantNumber.MODIFYPHONENUMBER:
                        phoneNumber = ModifyPhoneNumber();
                        validInput = EnterEsc(phoneNumber);
                        break;
                    case ConstantNumber.MODIFTADDRESS:
                        address = ModifyAddress();
                        validInput = EnterEsc(address);
                        break;
                    case ConstantNumber.MODIFYSUCCESS:
                        isInputEnter = true;
                        break;
                }
                if(isInputEnter)
                {
                    if (id != "")
                    {
                        totalInformationStorage.users[index].id = id;
                    }
                    if(password != "")
                    {
                        totalInformationStorage.users[index].password = password;
                    }
                    if(name != "")
                    {
                        totalInformationStorage.users[index].name = name;
                    }
                    if(age != "")
                    {
                        totalInformationStorage.users[index].age = age;
                    }
                    if(phoneNumber != "")
                    {
                        totalInformationStorage.users[index].phoneNumber = phoneNumber;
                    }
                    if(address != "")
                    {
                        totalInformationStorage.users[index].address = address;
                    }
                }

                if(validInput == ConstantNumber.EXIT)
                {
                    isInputEnter = true;
                }
            }
        }

        public int DeleteMyAccount()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            ConsoleKeyInfo keyInfo;

            bool isSuccessDelete = true;
            bool isInputEnter = false;
            int index = 0;
            int breakNumber = -1;

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    index = i;
                    break;
                }
            }

            while (!isInputEnter)
            {
                Console.Clear();
                userInformation.PrintDeleteAccountUI();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (totalInformationStorage.users[index].borrowDatas.Count == 0)
                    {
                        totalInformationStorage.users.RemoveAt(index);
                        isInputEnter = true;
                        Console.Clear();
                        userInformation.PrintSuccessDeleteAccount();
                    }
                    else
                    {
                        userInformation.PrintNotWorkedDeleteAccout();
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
                    ui.PrintException(ConstantNumber.NOTMATCHEDCONDITION);
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
                        ui.PrintException(ConstantNumber.NOTMATCHEDCONDITION);
                    }
                }
            }
            return breakNumber;
        }

        public void ManageUserInformation()
        {
            int consoleInputRow = 60;
            int consoleInputColumn = 10;

            bool isInputESC = false;
            bool isInvalidId = false;

            string userId = "";

            string id = "";
            string name = "";
            string age = "";
            string phoneNumber = "";
            string address = "";

            while (!isInputESC)
            {
                Console.Clear();
                userInformation.PrintManageUser();

                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                for(int i=0; i < totalInformationStorage.users.Count; i++)
                {
                    id = totalInformationStorage.users[i].id;
                    name = totalInformationStorage.users[i].name;
                    age = totalInformationStorage.users[i].age;
                    phoneNumber = totalInformationStorage.users[i].phoneNumber;
                    address = totalInformationStorage.users[i].address;

                    userInformation.PrintUserList(id, name, age, phoneNumber, address);

                }
                userId = handlingException.IsValid(regex.idCheck, consoleInputRow + 3, consoleInputColumn - 7, 20, false);
                if (userId == null)
                    return;

                for(int i = 0; i<totalInformationStorage.users.Count; i++)
                {
                    if (totalInformationStorage.users[i].id == userId)
                    {
                        isInvalidId = true;
                        totalInformationStorage.users.RemoveAt(i);
                    }
                }

                if(!isInvalidId)
                {
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                    Console.ForegroundColor = ConsoleColor.Red;
                    ui.PrintException(ConstantNumber.INVALIDUSERID);
                    Console.ResetColor();
                    continue;
                }

                Console.Clear();
                userInformation.PrintSuccessDeleteUser();

                for (int i = 0; i < totalInformationStorage.users.Count; i++)
                {
                    userInformation.PrintUserList(totalInformationStorage.users[i].id, totalInformationStorage.users[i].name,
                        totalInformationStorage.users[i].age, totalInformationStorage.users[i].phoneNumber,
                        totalInformationStorage.users[i].address);
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOTMATCHEDCONDITION);
                }
            }
        }
        private void RentalStateInBorrowBook(int index)
        {
            int id = 0;
            string title = "";
            string author = "";
            string publisher = "";
            string amount = "";
            string price = "";
            string publishDay = "";
            string ISBN = "";
            string information = "";
            string borrowTime = "";
            string returnTime = "";

            for (int j = 0; j < totalInformationStorage.users[index].borrowDatas.Count; j++)
            {
                id = totalInformationStorage.users[index].borrowDatas[j].id;
                title = totalInformationStorage.users[index].borrowDatas[j].title;
                author = totalInformationStorage.users[index].borrowDatas[j].author;
                publisher = totalInformationStorage.users[index].borrowDatas[j].publisher;
                amount = totalInformationStorage.users[index].borrowDatas[j].amount;
                price = totalInformationStorage.users[index].borrowDatas[j].price;
                publishDay = totalInformationStorage.users[index].borrowDatas[j].publishDay;
                ISBN = totalInformationStorage.users[index].borrowDatas[j].ISBN;
                information = totalInformationStorage.users[index].borrowDatas[j].information;
                borrowTime = totalInformationStorage.users[index].borrowDatas[j].borrowTime;

                userInformation.PrintUserId(totalInformationStorage.users[j].id);
                userInformation.PrintRentalList(id, title, author, publisher, amount, price, publishDay,
                    ISBN, information, borrowTime, returnTime);
            }
        }
        public void RentalState()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            isInputESC = false;

            while (!isInputESC)
            {
                Console.Clear();
                ui.PrintBox(4);
                userInformation.PrintRentalStateUI();

                for(int i =0; i < totalInformationStorage.users.Count;i++)
                {
                    RentalStateInBorrowBook(i);
                }

                if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
        }
    }
}
