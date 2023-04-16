using Library.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    class PrinterBookInformation
    {
        public void PrintEsc()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ResetColor();
        }

        public void PrintEnter()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기");
            Console.ResetColor();
        }
        public void PrintFindingBookUI()
        {
            Console.WriteLine(" 제목으로 찾기   :");
            Console.WriteLine(" 작가명으로 찾기 :");
            Console.WriteLine(" 출판사로 찾기   :");
            Console.WriteLine();
            PrintEsc();
            PrintEnter();
        }
        public void PrintRentalBookTitle()
        {
            Console.WriteLine("\n   빌린 책의 리스트\n");
            PrintEsc();
            Console.WriteLine("\n\n\n");
        }

        public void PrintBookList(int id, string title, string author, string publisher, string amount,
            string price, string publishDay, string ISBN, string information)
        {
            Console.WriteLine("\n=====================================================================================\n");
            Console.WriteLine("책아이디  : {0}", id);
            Console.WriteLine("책 제목   : {0}", title);
            Console.WriteLine("작가      : {0}", author);
            Console.WriteLine("출판사    : {0}", publisher);
            Console.WriteLine("수량      : {0}", amount);
            Console.WriteLine("가격      : {0}", price);
            Console.WriteLine("출시일    : {0}", publishDay);
            Console.WriteLine("ISBN      : {0}", ISBN);
            Console.WriteLine("책 정보   : {0}", information);
        }

        public void PrintRenttheBookUI()
        { 
            Console.Clear();
            Console.WriteLine(" 빌릴 책의 ID를 입력해 주세요.");
            Console.WriteLine(" ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("▶ 입력: ");
            Console.WriteLine("\n\n");
            PrintEsc();
            PrintEnter();
        }
        public void PrintRentalBookListUI(int id, string title, string author, string publisher, string amount,
             string price, string publishDay, string ISBN, string information, string borrowTime)
        {
            Console.WriteLine("\n=====================================================================================\n");
            Console.WriteLine("책아이디  : {0}", id);
            Console.WriteLine("책 제목   : {0}", title);
            Console.WriteLine("작가      : {0}", author);
            Console.WriteLine("출판사    : {0}", publisher);
            Console.WriteLine("수량      : {0}", amount);
            Console.WriteLine("가격      : {0}", price);
            Console.WriteLine("출시일    : {0}", publishDay);
            Console.WriteLine("ISBN      : {0}", ISBN);
            Console.WriteLine("책 정보   : {0}", information);
            Console.WriteLine("빌린시간  : {0}", borrowTime);
        }

        public void PrintReturnTheBookUI()
        {
            Console.Clear();
            Console.WriteLine(" 반납할 책의 ID를 입력해 주세요.");
            Console.WriteLine(" ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("▶ 입력: ");
            Console.WriteLine("\n\n");
            PrintEsc();
            PrintEnter();
        }
        public void PrintReturnBookTitle() 
        {
            Console.WriteLine("\n   반납 책의 리스트\n");
            PrintEsc();
            Console.WriteLine("\n\n\n");
        }
        public void PrintReturnBookListUI(int id, string title, string author, string publisher, string amount,
            string price, string publishDay, string ISBN, string information, string borrowTime, string returnTime)
        {
            Console.WriteLine("\n=====================================================================================\n");
            Console.WriteLine("책아이디  : {0}", id);
            Console.WriteLine("책 제목   : {0}", title);
            Console.WriteLine("작가      : {0}", author);
            Console.WriteLine("출판사    : {0}", publisher);
            Console.WriteLine("수량      : {0}", amount);
            Console.WriteLine("가격      : {0}", price);
            Console.WriteLine("출시일    : {0}", publishDay);
            Console.WriteLine("ISBN      : {0}", ISBN);
            Console.WriteLine("책 정보   : {0}", information);
            Console.WriteLine("빌린시간  : {0}", borrowTime);
            Console.WriteLine("반납시간  : {0}", returnTime);
        }

        public void PrintAddTheBookUI()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("도서 추가");
            Console.SetCursorPosition(consoleInputRow - 15, consoleInputColumn + 2);
            PrintEnter();
            Console.SetCursorPosition(consoleInputRow + 2, consoleInputColumn + 2);
            PrintEsc();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------\n");
            Console.WriteLine("\t\t\t\t책 제목   : ");
            Console.WriteLine("\t\t\t\t작가      : ");
            Console.WriteLine("\t\t\t\t출판사    : ");
            Console.WriteLine("\t\t\t\t수량      : ");
            Console.WriteLine("\t\t\t\t가격      : ");
            Console.WriteLine("\t\t\t\t출시일    : ");
            Console.WriteLine("\t\t\t\tISBN      : ");
            Console.WriteLine("\t\t\t\t책 정보   : \n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t책 제목 - 영어, 한글, 숫자 ?!+= 1개 이상");
            Console.WriteLine("\t\t\t작가    - 영어, 한글 1글자 이상");
            Console.WriteLine("\t\t\t출판사  - 영어, 한글, 숫자 1개 이상");
            Console.WriteLine("\t\t\t수량    - 1 ~ 999 사이의 자연수");
            Console.WriteLine("\t\t\t가격    - 1 ~ 9999999 사이의 자연수");
            Console.WriteLine("\t\t\t출시일  - 19xx or 20xx-xx-xx");
            Console.WriteLine("\t\t\tISBN    - 정수 9개 + 영어 1개 + 공백 + 정수 13개");
            Console.Write("\t\t\t정보    - 최소 1개의 문자 (공백 포함)");
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public void PrintSuccessAddBook()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("도서 추가");
            Console.SetCursorPosition(consoleInputRow - 15, consoleInputColumn + 2);
            PrintEnter();
            Console.SetCursorPosition(consoleInputRow + 2, consoleInputColumn + 2);
            PrintEsc();
            Console.WriteLine("\n\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                   책 추가 성공!\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------\n");
        }

        public void PrintDeleteTheBookUI()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t               삭제할 책 ID:\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(consoleInputRow - 15, consoleInputColumn + 5);
            PrintEnter();
            Console.SetCursorPosition(consoleInputRow + 2, consoleInputColumn + 5);
            PrintEsc();
        }

        public void PrintSuccessDeleteBook()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                    삭제 성공!\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 5);
            PrintEsc();
        }
        public void PrintModifyBookInformationUI()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t               수정할 책 ID:\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(consoleInputRow - 15, consoleInputColumn + 5);
            PrintEnter();
            Console.SetCursorPosition(consoleInputRow + 2, consoleInputColumn + 5);
            PrintEsc();
        }

        public void PrintSuccessModifyBook()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                    삭제 성공!\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 5);
            PrintEsc();
        }
    }
}
