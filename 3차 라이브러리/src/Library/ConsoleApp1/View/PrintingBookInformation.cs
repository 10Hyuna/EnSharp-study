using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    class PrintingBookInformation
    {
        public void PrintFindingBookUI()
        {
            Console.WriteLine(" 제목으로 찾기   :");
            Console.WriteLine(" 작가명으로 찾기 :");
            Console.WriteLine(" 출판사로 찾기   :");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기");
            Console.ResetColor();
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

        public void PrintRenttheBookUI(TotalInformationStorage dataController)
        {
            Console.WriteLine(" 빌릴 책의 ID를 입력해 주세요.");
            Console.WriteLine(" ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기");
            Console.ResetColor();
        }
        public void PrintAddTheBookUI()
        {

        }

        public void PrintDeleteTheBookUI()
        {

        }

        public void PrintModifyAboutBookInformationUI()
        {

        }
        public void PrintReturnThebookUI()
        {

        }
        public void PrintReturnBookListUI()
        {

        }
    }
}
