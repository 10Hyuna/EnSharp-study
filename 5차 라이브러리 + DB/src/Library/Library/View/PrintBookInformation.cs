using Library.Model.DTO;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class PrintBookInformation
    {
        private static PrintBookInformation printBookInformation;
        private GuidancePhrase guidancePhrase;

        private PrintBookInformation() 
        {
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
        }

        public static PrintBookInformation GetPrintBookInformation()
        {
            if(printBookInformation == null)
            {
                printBookInformation = new PrintBookInformation();
            }
            return printBookInformation;
        }

        public void PrintFindingBookUI()
        {
            Console.WriteLine(" 제목으로 찾기   :");
            Console.WriteLine(" 작가명으로 찾기 :");
            Console.WriteLine(" 출판사로 찾기   :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 최소 한 개 이상의 검색어를 입력해 주세요\n");
            Console.ResetColor();
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            GuidancePhrase.SetGuidancePhrase().PrintEnter();
        }

        public void PrintBookList(BookDTO book)
        {
            
            Console.WriteLine("\n============================================================================\n");
            Console.WriteLine("책아이디  : {0}", book.Id);
            Console.WriteLine("책 제목   : {0}", book.Title);
            Console.WriteLine("작가      : {0}", book.Author);
            Console.WriteLine("출판사    : {0}", book.Publisher);
            Console.WriteLine("수량      : {0}", book.Amount);
            Console.WriteLine("가격      : {0}", book.Price);
            Console.WriteLine("출시일    : {0}", book.PublishDate);
            Console.WriteLine("ISBN      : {0}", book.ISBN);
            Console.WriteLine("책 정보   : {0}", book.Information);
        }

        public void PrintUserBookListUI(List<UsersBookDTO> usersBook)
        {
            for(int i = 0; i < usersBook.Count; i++)
            {
                Console.WriteLine("\n============================================================================\n");
                Console.WriteLine("책아이디  : {0}", usersBook[i].Id);
                Console.WriteLine("책 제목   : {0}", usersBook[i].Title);
                Console.WriteLine("작가      : {0}", usersBook[i].Author);
                Console.WriteLine("출판사    : {0}", usersBook[i].Publisher);
                Console.WriteLine("수량      : {0}", usersBook[i].Amount);
                Console.WriteLine("가격      : {0}", usersBook[i].Price);
                Console.WriteLine("출시일    : {0}", usersBook[i].PublishDate);
                Console.WriteLine("ISBN      : {0}", usersBook[i].ISBN);
                Console.WriteLine("책 정보   : {0}", usersBook[i].Information);
                Console.WriteLine("빌린 시간 : {0}", usersBook[i].RentTime);
                Console.WriteLine("반납 시간 : {0}", usersBook[i].ReturnTime);
            }
        }

        public void PrintRentReturnUI(string entryType)
        {
            string printValue = string.Format(Constant.BOOK_ID__UI, entryType);
            Console.Clear();
            Console.WriteLine(printValue);
            Console.WriteLine(" ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("▶ 입력: ");
            Console.WriteLine("\n\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            GuidancePhrase.SetGuidancePhrase().PrintEnter();
        }
        public void PrintRentReturnBookTitle(string entryType)
        {
            string printValue = string.Format(Constant.BOOK_LIST_UI, entryType);
            Console.WriteLine(printValue);
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            Console.WriteLine("\n");
        }
        public void PrintAddTheBookUI()
        {
            int consoleInputRow = 32;
            int consoleInputColumn = 2;
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("도서 추가");
            Console.SetCursorPosition(0, consoleInputColumn + 4);
            GuidancePhrase.SetGuidancePhrase().PrintEnter();
            Console.SetCursorPosition(0, consoleInputColumn + 5);
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            Console.WriteLine("\n");
            Console.WriteLine("\t----------------------------------------------------\n");
            Console.WriteLine("\t책 제목   : ");
            Console.WriteLine("\t작가      : ");
            Console.WriteLine("\t출판사    : ");
            Console.WriteLine("\t수량      : ");
            Console.WriteLine("\t가격      : ");
            Console.WriteLine("\t출시일    : ");
            Console.WriteLine("\tISBN      : ");
            Console.WriteLine("\t책 정보   : \n");
            Console.WriteLine("\t----------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t책 제목 - 영어, 한글, 숫자 ?!+= 1개 이상");
            Console.WriteLine("\t작가    - 영어, 한글 1글자 이상");
            Console.WriteLine("\t출판사  - 영어, 한글, 숫자 1개 이상");
            Console.WriteLine("\t수량    - 1 ~ 999 사이의 자연수");
            Console.WriteLine("\t가격    - 1 ~ 9999999 사이의 자연수");
            Console.WriteLine("\t출시일  - 19xx or 20xx-xx-xx");
            Console.WriteLine("\tISBN    - 정수 9개 + 영어 1개 + 공백 + 정수 13개");
            Console.Write("\t정보    - 최소 1개의 문자 (공백 포함)");
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public void PrintSuccessAddBook()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t               책 추가 성공!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintSuccessRequestBook()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t               책 요청 성공!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintDeleteTheBookUI()
        {
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t               삭제할 책 ID:\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintDeleteTheBook()
        {
            MainView.SetMainView().PrintBox(3);

            int column = 32;
            int row = 2;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("책 수정\n\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            GuidancePhrase.SetGuidancePhrase().PrintEnter();
        }
        public void PrintSuccessDeleteBook()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t                   삭제 성공!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintModifyBookInformationUI()
        {
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t               수정할 책 ID:\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintSuccessModifyBook()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t               정보 수정 완료!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintSuccessRent()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t                  대여 성공!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.SetGuidancePhrase().PrintEsc();
        }

        public void PrintNaverSearch()
        {
            Console.Clear();
            Console.WriteLine("\n 책 키워드 :");
            Console.WriteLine(" 책 개수   :\n");

            GuidancePhrase.SetGuidancePhrase().PrintEsc();
            GuidancePhrase.SetGuidancePhrase().PrintEnter();
        }

        public void PrintNaverSearchResult()
        {
            Console.SetCursorPosition(0, 5);
            Console.Write("                                  ");
            Console.SetCursorPosition(0, 5);
            GuidancePhrase.SetGuidancePhrase().PrintEnterRequest();
        }

        public void PrintEraseRequest()
        {
            Console.SetCursorPosition(0, 5);
            Console.Write("                                  ");
        }

        public void PrintRequestBook()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("                                                                       \n");
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("요청할 책의 제목 :");
        }

        public void PrintAddBookTitle()
        {
            Console.SetCursorPosition(0, 0);
            MainView.SetMainView().PrintBox(3);

            int column = 21;
            int row = 2;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("추가할 책의 제목을 입력하세요");
        }

        public void PrintRequestBookList(List<BookDTO> books)
        {
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine("\n============================================================================\n");
                Console.WriteLine("책 제목   : {0}", books[i].Title);
                Console.WriteLine("작가      : {0}", books[i].Author);
                Console.WriteLine("출판사    : {0}", books[i].Publisher);
                Console.WriteLine("가격      : {0}", books[i].Price);
                Console.WriteLine("출시일    : {0}", books[i].PublishDate);
                Console.WriteLine("ISBN      : {0}", books[i].ISBN);
                Console.WriteLine("책 정보   : {0}", books[i].Information);
            }
        }
    }
}
