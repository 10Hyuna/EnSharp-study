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
        TotalStorage totalStorage;
        PrinterUserInformation printerUserInformation;
        InputFromUser inputFromUser;
        UI ui;
        HandlingException handlingException;
        RegexStorage regex;
        MovingCursorPosition cursor;
        public EnteringMenuOfUser(TotalStorage totalStorage,
            PrinterUserInformation printerUserInformation, InputFromUser inputFromUser, UI ui,
            HandlingException handlingException, RegexStorage regex, MovingCursorPosition cursor)
        {
            this.totalStorage = totalStorage;
            this.printerUserInformation = printerUserInformation;
            this.inputFromUser = inputFromUser;
            this.ui = ui;
            this.handlingException = handlingException;
            this.regex = regex;
            this.cursor = cursor;
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }

        bool isInputESC;
        ConsoleKeyInfo keyInfo;

        int consoleInputRow;
        int consoleInputColumn;

        private string ModifyInformation(int column, Regex regex)
        {
            consoleInputRow = 68;
            consoleInputColumn = 7 + column;

            string input = "";

            input = handlingException.IsValid(regex, consoleInputRow, consoleInputColumn, 20, false);

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

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].id == totalStorage.loggedInUserId)
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

                switch(selectedMenu)
                {
                    case (int)(USERINFORMATION.ID):
                        id = ModifyInformation(0, regex.idCheck);
                        validInput = EnterEsc(id);
                        break;
                    case (int)(USERINFORMATION.PASSWORD):
                        password = ModifyInformation(1, regex.passwordCheck);
                        validInput = EnterEsc(password);
                        break;
                    case (int)(USERINFORMATION.NAME):
                        name = ModifyInformation(2, regex.nameCheck);
                        validInput = EnterEsc(name);
                        break;
                    case (int)(USERINFORMATION.AGE):
                        age = ModifyInformation(3, regex.ageCheck);
                        validInput = EnterEsc(age);
                        break;
                    case (int)(USERINFORMATION.PHONENUMBER):
                        phoneNumber = ModifyInformation(4, regex.phoneNumberCheck);
                        validInput = EnterEsc(phoneNumber);
                        break;
                    case (int)(USERINFORMATION.ADDRESS):
                        address = ModifyInformation(5, regex.addressCheck);
                        validInput = EnterEsc(address);
                        break;
                    case (int)(USERINFORMATION.SUCCESS):
                        isInputEnter = true;
                        break;
                }
                if(isInputEnter)
                {
                    if (id != "")
                    {
                        totalStorage.users[index].id = id;
                    }
                    if(password != "")
                    {
                        totalStorage.users[index].password = password;
                    }
                    if(name != "")
                    {
                        totalStorage.users[index].name = name;
                    }
                    if(age != "")
                    {
                        totalStorage.users[index].age = age;
                    }
                    if(phoneNumber != "")
                    {
                        totalStorage.users[index].phoneNumber = phoneNumber;
                    }
                    if(address != "")
                    {
                        totalStorage.users[index].address = address;
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

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].id == totalStorage.loggedInUserId)
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
                    if (totalStorage.users[index].borrowDatas.Count == 0)
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
                printerUserInformation.PrintManageUser();

                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                for(int i=0; i < totalStorage.users.Count; i++)
                {
                    id = totalStorage.users[i].id;
                    name = totalStorage.users[i].name;
                    age = totalStorage.users[i].age;
                    phoneNumber = totalStorage.users[i].phoneNumber;
                    address = totalStorage.users[i].address;

                    printerUserInformation.PrintUserList(id, name, age, phoneNumber, address);

                }
                userId = handlingException.IsValid(regex.idCheck, consoleInputRow + 3, consoleInputColumn - 7, 20, false);
                if (userId == null)
                    return;

                for(int i = 0; i<totalStorage.users.Count; i++)
                {
                    if (totalStorage.users[i].id == userId)
                    {
                        isInvalidId = true;
                        totalStorage.users.RemoveAt(i);
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
                printerUserInformation.PrintSuccessDeleteUser();

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    printerUserInformation.PrintUserList(totalStorage.users[i].id, totalStorage.users[i].name,
                        totalStorage.users[i].age, totalStorage.users[i].phoneNumber,
                        totalStorage.users[i].address);
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

            for (int j = 0; j < totalStorage.users[index].borrowDatas.Count; j++)
            {
                id = totalStorage.users[index].borrowDatas[j].id;
                title = totalStorage.users[index].borrowDatas[j].title;
                author = totalStorage.users[index].borrowDatas[j].author;
                publisher = totalStorage.users[index].borrowDatas[j].publisher;
                amount = totalStorage.users[index].borrowDatas[j].amount;
                price = totalStorage.users[index].borrowDatas[j].price;
                publishDay = totalStorage.users[index].borrowDatas[j].publishDay;
                ISBN = totalStorage.users[index].borrowDatas[j].ISBN;
                information = totalStorage.users[index].borrowDatas[j].information;
                borrowTime = totalStorage.users[index].borrowDatas[j].borrowTime;

                printerUserInformation.PrintUserId(totalStorage.users[j].id);
                printerUserInformation.PrintRentalList(id, title, author, publisher, amount, price, publishDay,
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
                printerUserInformation.PrintRentalStateUI();

                for(int i =0; i < totalStorage.users.Count;i++)
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
