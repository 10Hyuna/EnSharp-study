using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    class PrintingUserInformation
    {
        UI ui;
        public PrintingUserInformation(UI ui)
        {
            this.ui = ui;
        }

        public void PrintManageUser()
        {

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t               삭제할 유저 ID:\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(37, 8);
            Console.WriteLine("ESC : 뒤로 가기   ENTER : 입력하기");
        }
        public void PrintSuccessDeleteUser()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                    유저 정보 삭제!\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 5);
            Console.Write("ESC : 뒤로가기");
        }

        public void PrintUserList(string id, string name, string age,
            string phoneNumber, string address)
        {
            Console.WriteLine("\n=====================================================================================\n");
            Console.WriteLine("유저의 ID          : {0}", id);
            Console.WriteLine("유저의 Name        : {0}", name);
            Console.WriteLine("유저의 Age         : {0}", age);
            Console.WriteLine("유저의 PhoneNumber : {0}", phoneNumber);
            Console.WriteLine("유저의 Address     : {0}", address);
        }

        public void PrintRentalStateUI()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\t\t\t\t\t     대 여 상 황");
            Console.WriteLine("\t\t\t\tESC : 뒤로가기     ENTER : 선택하기\n\n");
        }

        public void PrintUserId(string id)
        {
            Console.WriteLine("\n\t=====================================================================================\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine (id);
            Console.ResetColor();
        }

        public void PrintRentalList(int id, string title, string author, string publisher, 
            string amount, string price, string publishDay, string ISBN, string information,
            string borrowTime, string returnTime)
        {
            Console.WriteLine("\n=====================================================================================\n");
            Console.WriteLine("책 아이디  : {0}", id);
            Console.WriteLine("책 제목    : {0}", title);
            Console.WriteLine("작가       : {0}", author);
            Console.WriteLine("출판사     : {0}", publisher);
            Console.WriteLine("수량       : {0}", amount);
            Console.WriteLine("가격       : {0}", price);
            Console.WriteLine("출시일     : {0}", publishDay);
            Console.WriteLine("ISBN       : {0}", ISBN);
            Console.WriteLine("책 정보    : {0}", information);
            Console.WriteLine("빌린 시간  : {0}", borrowTime);
            if (returnTime == "")
                return;
            Console.WriteLine("반납 시간  : {0}", returnTime);
        }
        public void PrintModifyMyInformationUI()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\t\t\t     개 인 정 보 바 꾸 기\n");
            Console.WriteLine("\t\t\t\tESC : 뒤로가기     ENTER : 선택하기\n\n");
        }

        public void PrintDeleteAccountUI()
        {
            const int consoleInputRow = 40;
            const int consoleInputColumn = 18;

            ui.PrintMain();
            ui.PrintBox(7);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("회원탈퇴 하시겠습니까?");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("Enter : 예   ESC : 아니오");
        }

        public void PrintNotWorkedDeleteAccout()
        {
            const int consoleInputRow = 33;
            const int consoleInputColumn = 18;

            Console.Clear();
            ui.PrintMain();
            ui.PrintBox(7);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("대여 중인 도서가 있어 탈퇴가 불가능합니다.");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("            ESC : 뒤로가기");
        }

        public void PrintSuccessDeleteAccount()
        {
            const int consoleInputRow = 25;
            const int consoleInputColumn = 20;

            ui.PrintMain();
            ui.PrintBox(7);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("회원 탈퇴 성공!");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("            ESC : 뒤로가기");
        }
    }
}
