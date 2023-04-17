using Library.Model;
using Library.Model.DTO;
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
    class MemberAccessInManager
    {
        PrinterUserInformation printerUserInformation;
        TotalStorage totalStorage;
        HandlingException handlingException;
        RegexStorage regex;
        UI ui;
        public MemberAccessInManager(PrinterUserInformation printerUserInformation, TotalStorage totalStorage, 
            HandlingException handlingException, RegexStorage regex, UI ui)
        {
            this.printerUserInformation = printerUserInformation;
            this.totalStorage = totalStorage;
            this.handlingException = handlingException;
            this.regex = regex;
            this.ui = ui;
        }

        ConsoleKeyInfo keyInfo;

        bool isInputESC = false;

        public void ManageUserInformation()
        {
            int consoleInputRow = 60;
            int consoleInputColumn = 10;

            isInputESC = false;
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
                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    User modifyInformation = totalStorage.users[i];

                    id = modifyInformation.GetUserId();
                    name = modifyInformation.GetUserName();
                    age = modifyInformation.GetUserAge();
                    phoneNumber = modifyInformation.GetUserPhoneNumber();
                    address = modifyInformation.GetUserAddress();

                    printerUserInformation.PrintUserList(id, name, age, phoneNumber, address);

                }
                userId = handlingException.IsValid(ConstantNumber.idCheck, consoleInputRow + 3, consoleInputColumn - 7, 20, false);
                if (userId == null)
                    return;

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    if (totalStorage.users[i].GetUserId() == userId)
                    {
                        isInvalidId = true;
                        totalStorage.users.RemoveAt(i);
                    }
                }

                if (!isInvalidId)
                {
                    Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
                    Console.ForegroundColor = ConsoleColor.Red;
                    ui.PrintException(ConstantNumber.INVALID_USER_ID);
                    Console.ResetColor();
                    continue;
                }

                Console.Clear();
                printerUserInformation.PrintSuccessDeleteUser();

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    User findUser = totalStorage.users[i];

                    printerUserInformation.PrintUserList(findUser.GetUserId(), findUser.GetUserName(),
                    findUser.GetUserAge(), findUser.GetUserPhoneNumber(),
                        findUser.GetUserAddress());
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION);
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

            for (int j = 0; j < totalStorage.users[index].BorrowDatas.Count; j++)
            {
                BorrowBookList rentalBook = totalStorage.users[index].BorrowDatas[j];
                id = rentalBook.GetBorrowId();
                title = rentalBook.GetBorrowTitle();
                author = rentalBook.GetBorrowAuthor();
                publisher = rentalBook.GetBorrowPublisher();
                amount = rentalBook.GetBorrowAmount();
                price = rentalBook.GetBorrowPrice();
                publishDay = rentalBook.GetBorrowPublishDay();
                ISBN = rentalBook.GetBorrowISBN();
                information = rentalBook.GetBorrowInformation();
                borrowTime = rentalBook.GetBorrowBorrowTime();

                printerUserInformation.PrintUserId(totalStorage.users[index].GetUserId());
                printerUserInformation.PrintRentalList(id, title, author, publisher, amount, price, publishDay,
                    ISBN, information, borrowTime, returnTime);
            }
        }
        public void RentalState()
        {
            isInputESC = false;

            while (!isInputESC)
            {
                Console.Clear();
                ui.PrintBox(4);
                printerUserInformation.PrintRentalStateUI();

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    RentalStateInBorrowBook(i);
                }

                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
            }
        }
    }
}
