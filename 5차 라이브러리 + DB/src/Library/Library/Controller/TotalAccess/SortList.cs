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
            List<BookDTO> requestBook = new List<BookDTO>();

            if(entryType == (int)ENTRY.RENTAL)
            {
                books = AccessorData.SelectAllRentBookList(id);
            }
            else if(entryType == (int)ENTRY.RETURN)
            {
                books = AccessorData.SelectAllReturnBook(id);
            }
            else if(entryType == (int)ENTRY.REQUEST)
            {
                requestBook = AccessorData.GetAccessorData().SelectRequestBook();
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
                case (int)ENTRY.REQUEST:
                    AnnounceRequestBookList(requestBook, id);
                    break;
            }
        }

        private void AnnounceBookList(int entryType, string id, List<UsersBookDTO> books)
        {
            if (entryType == (int)(ENTRY.RENTAL))
            {
                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.CHECK_RENT, id);
                PrintBookInformation.GetPrintBookInformation().PrintRentReturnBookTitle(Constant.RENT);
            }
            else
            {
                LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.CHECK_RETURN, id);
                PrintBookInformation.GetPrintBookInformation().PrintRentReturnBookTitle(Constant.RETURN);
            }
            if (books.Count > 0)
            {
                PrintBookInformation.GetPrintBookInformation().PrintUserBookListUI(books);
            }
            else
            {
                if (entryType == (int)(ENTRY.RENTAL))
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NULL_RENT, 1, 5);
                }
                else
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NULL_RETURN, 1, 5);
                }
            }
            InputFromUser.GetInputFromUser().InputEnterESC();
        }

        private void AnnounceRequestBookList(List<BookDTO> books, string id)
        {
            Console.SetWindowSize(76, 40);
            LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, Constant.REQUEST_BOOK, id);
            PrintBookInformation.GetPrintBookInformation().PrintRentReturnBookTitle(Constant.REQUEST);
            PrintBookInformation.GetPrintBookInformation().PrintRequestBookList(books);
            InputFromUser.GetInputFromUser().InputEnterESC();
        }

        private void AnnounceRentBookList()
        {
            List<UserDTO> users = new List<UserDTO>();

            users = AccessorData.SelectAllUserData();

            PrintUserInformation.GetPrintUserInformation().PrintRentalStateUI();
            LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.CHECK_RENT, "managerid12");
            for (int i = 0; i < users.Count; i++)
            {
                List<UsersBookDTO> rentBooks = new List<UsersBookDTO>();

                rentBooks = AccessorData.SelectAllRentBookList(users[i].Id);
                if(rentBooks.Count == 0)
                {
                    continue;
                }

                PrintUserInformation.GetPrintUserInformation().PrintUserId(users[i].Id);
                PrintBookInformation.GetPrintBookInformation().PrintUserBookListUI(rentBooks);
            }
            InputFromUser.GetInputFromUser().InputEnterESC();
        }
    }
}
