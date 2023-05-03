using Library.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.View
{
    public class PrintUserInformation
    {
        private static PrintUserInformation printUserInformation;
        private GuidancePhrase guidancePhrase;
        private MainView mainView;
        private PrintUserInformation() 
        {
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            mainView = MainView.SetMainView();
        }

        public static PrintUserInformation GetPrintUserInformation()
        {
            if(printUserInformation == null)
            {
                printUserInformation = new PrintUserInformation();
            }
            return printUserInformation;
        }
        public void PrintManageUser()
        {

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                삭제할 유저 ID:\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(0, 8);
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }
        public void PrintSuccessDeleteUser()
        {
            int consoleInputRow = 53;
            int consoleInputColumn = 3;

            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t                유저 정보 삭제!\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(0, 8);
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public void PrintModiFyUserIdUI()
        {
            Console.WriteLine("\t\t\t\t----------------------------------------------------\n\n");
            Console.WriteLine("\t\t\t\t               수정할 유저 ID:\n\n");
            Console.WriteLine("\t\t\t\t----------------------------------------------------");
            Console.SetCursorPosition(0, 8);
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public void PrintUserList(List<UserDTO> user)
        {
            for (int i = 0; i < user.Count; i++)
            {
                Console.WriteLine("\n=====================================================================================\n");
                Console.WriteLine("유저의 ID          : {0}", user[i].Id);
                Console.WriteLine("유저의 Name        : {0}", user[i].Name);
                Console.WriteLine("유저의 Age         : {0}", user[i].Age);
                Console.WriteLine("유저의 PhoneNumber : {0}", user[i].PhoneNumber);
                Console.WriteLine("유저의 Address     : {0}", user[i].Address);
            }
        }

        public void PrintRentalStateUI()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\t\t\t\t\t     대 여 상 황\n");
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public void PrintUserId(string id)
        {
            Console.WriteLine("\t\t=====================================================================================\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(id);
            Console.ResetColor();
        }

        public void PrintModifyMyInformationUI()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("\t\t\t\t     개 인 정 보 바 꾸 기\n");
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public void PrintDeleteAccountUI()
        {
            const int consoleInputRow = 40;
            const int consoleInputColumn = 15;

            MainView.PrintMain();
            MainView.PrintBox(5);

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
            MainView.PrintMain();
            MainView.PrintBox(5);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("대여 중인 도서가 있어 탈퇴가 불가능합니다.");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("            ESC : 뒤로가기");
        }

        public void PrintSuccessDeleteAccount()
        {
            const int consoleInputRow = 50;
            const int consoleInputColumn = 18;

            MainView.PrintMain();
            MainView.PrintBox(7);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("회원 탈퇴 성공!");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("            ESC : 뒤로가기");
        }
    }
}
