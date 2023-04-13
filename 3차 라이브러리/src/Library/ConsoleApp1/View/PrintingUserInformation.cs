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

        public void PrintManageAboutUserInformation()
        {

        }

        public void PrintRentalStateUI()
        {

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
