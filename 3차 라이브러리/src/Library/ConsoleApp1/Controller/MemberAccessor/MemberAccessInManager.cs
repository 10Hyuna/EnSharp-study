using Library.Model;
using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Controller.MemberAccessor
{
    class MemberAccessInManager
    {
        PrinterUserInformation printerUserInformation;
        TotalStorage totalStorage;
        HandlingException handlingException;
        UI ui;
        AccessorData accessorData;

        public MemberAccessInManager(PrinterUserInformation printerUserInformation, TotalStorage totalStorage,
            HandlingException handlingException, UI ui)
        {
            this.printerUserInformation = printerUserInformation;
            this.totalStorage = totalStorage;
            this.handlingException = handlingException;
            this.ui = ui;
            accessorData = AccessorData.GetAccessorData();
        }

        ConsoleKeyInfo keyInfo;

        bool isInputESC = false;

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

        private void RentalStateInBorrowBook(int index)         // 유저의 대여 현황을 확인하게 해 주는 함수
        {
            //ReturnBookList returnBookList = accessorData.
            //for (int j = 0; j < totalStorage.users[index].BorrowDatas.Count; j++)
            //{
                //BorrowBookList rentalBook = totalStorage.users[index].BorrowDatas[j];
                //id = rentalBook.GetId();
                //title = rentalBook.GetTitle();
                //author = rentalBook.GetAuthor();
                //publisher = rentalBook.GetPublisher();
                //amount = rentalBook.GetAmount();
                //price = rentalBook.GetPrice();
                //publishDay = rentalBook.GetPublishDay();
                //ISBN = rentalBook.GetISBN();
                //information = rentalBook.GetInformation();
                //borrowTime = rentalBook.GetBorrowTime();

                //printerUserInformation.PrintUserId(totalStorage.users[index].GetId());      // 유저의 아이디 우선 출력
                //printerUserInformation.PrintRentalList(id, title, author, publisher, amount, price, publishDay,
                    //ISBN, information, borrowTime, returnTime);     // 그 유저의 대여 책의 정보 출력
            //}
        }
        public void RentalState()       // 대여 상황을 알려 주는 함수
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
