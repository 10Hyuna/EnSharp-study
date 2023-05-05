using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.TotalAccess
{
    public class SortList
    {

        AccessorData accessorData;
        PrintBookInformation printBookInformation;
        PrintUserInformation printUserInformation;
        InputFromUser inputFromUser;

        public SortList()
        {
            accessorData = AccessorData.GetAccessorData();
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            printUserInformation = PrintUserInformation.GetPrintUserInformation();
            inputFromUser = InputFromUser.GetInputFromUser();
        }

        public void AnnounceBookState(int entryType, string id)
        {
            Console.Clear();
            List<UsersBookDTO> books = new List<UsersBookDTO>();

            if(entryType == (int)ENTRY.RENTAL)
            {
                books = AccessorData.SelectAllRentBookList(id);
            }
            else if(entryType == (int)ENTRY.RETURN)
            {
                books = AccessorData.SelectAllReturnBook(id);
            }
            switch(entryType)
            {
                case (int)ENTRY.RENTAL:     // 유저 모드에서 대여 내역을 확인하고자 한다면
                    AnnounceBookList(entryType, id, books);
                    break;                  
                case (int)ENTRY.RETURN:     // 유저 모드에서 반납 내역을 확인하고자 한다면
                    AnnounceBookList(entryType, id, books);
                    break;
                case (int)ENTRY.MANAGER:    // 매니저 모드에서 대여 내역을 확인하고자 한다면
                    AnnounceRentBookList();
                    break;
            }
        }

        private void AnnounceBookList(int entryType, string id, List<UsersBookDTO> books)
        {
            if(books.Count > 0)
            {
                if(entryType == (int)(ENTRY.RENTAL))
                {
                    PrintBookInformation.PrintRentalBookTitle();
                }
                else
                {
                    PrintBookInformation.PrintReturnBookTitle();
                }
                PrintBookInformation.PrintUserBookListUI(books);
            }
            InputFromUser.InputEnterESC();
        }

        private void AnnounceRentBookList()
        {
            List<UserDTO> users = new List<UserDTO>();

            users = AccessorData.SelectAllUserData();

            PrintUserInformation.PrintRentalStateUI();

            for (int i = 0; i < users.Count; i++)
            {
                List<UsersBookDTO> rentBooks = new List<UsersBookDTO>();
                rentBooks = AccessorData.SelectAllRentBookList(users[i].Id);

                PrintUserInformation.PrintUserId(users[i].Id);
                PrintBookInformation.PrintUserBookListUI(rentBooks);
            }
            InputFromUser.InputEnterESC();
        }
    }
}
