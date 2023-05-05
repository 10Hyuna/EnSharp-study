using Library.Model.DAO;
using Library.Model.DTO;
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

        public SortList()
        {
            accessorData = AccessorData.GetAccessorData();
            printBookInformation = PrintBookInformation.GetPrintBookInformation();
            printUserInformation = PrintUserInformation.GetPrintUserInformation();
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
                case (int)ENTRY.RENTAL:
                    AnnounceBookList(entryType, id, books);
                    break;
                case (int)ENTRY.RETURN:
                    AnnounceBookList(entryType, id, books);
                    break;
                case (int)ENTRY.MANAGER:
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
            Console.ReadKey(true);
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
            Console.ReadKey(true);
        }
    }
}
