﻿using Library.Model.DTO;
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
        public static void PrintManageUser()
        {
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t             삭제할 유저 ID:\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }
        public static void PrintSuccessDeleteUser()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t         유저 정보 삭제 완료!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.PrintEsc();
        }

        public static void PrintModiFyUserIdUI()
        {
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t             수정할 유저 ID:\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public static void PrintSuccessModify()
        {
            Console.SetWindowSize(76, 8);
            Console.Clear();
            Console.WriteLine("\n\t    ------------------------------------------------\n");
            Console.WriteLine("\t\t         유저 정보 수정 완료!\n");
            Console.WriteLine("\t    ------------------------------------------------\n");
            GuidancePhrase.PrintEsc();
        }

        public static void PrintUserList(List<UserDTO> user)
        {
            for (int i = 0; i < user.Count; i++)
            {
                Console.WriteLine("\n============================================================================\n");
                Console.WriteLine("유저의 ID          : {0}", user[i].Id);
                Console.WriteLine("유저의 Name        : {0}", user[i].Name);
                Console.WriteLine("유저의 Age         : {0}", user[i].Age);
                Console.WriteLine("유저의 PhoneNumber : {0}", user[i].PhoneNumber);
                Console.WriteLine("유저의 Address     : {0}", user[i].Address);
            }
        }

        public static void PrintRentalStateUI()
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("     대 여 상 황\n");
            GuidancePhrase.PrintEsc();
            GuidancePhrase.PrintEnter();
        }

        public static void PrintUserId(string id)
        {
            Console.WriteLine("====================================================");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(" {0}", id);
            Console.ResetColor();
        }

        public static void PrintModifyMyInformationUI()
        {
            Console.SetCursorPosition(0, 0);
            MainView.PrintBox(3);
            Console.SetCursorPosition(26, 2);
            Console.WriteLine("개 인 정 보 바 꾸 기\n\n\n");
        }

        public static void PrintDeleteAccountUI()
        {
            const int consoleInputRow = 26;
            const int consoleInputColumn = 10;

            MainView.PrintMain();
            MainView.PrintBox(5);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("회원탈퇴 하시겠습니까?");
            Console.SetCursorPosition(consoleInputRow - 3, consoleInputColumn + 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter : 예");
            Console.SetCursorPosition(consoleInputRow + 12, consoleInputColumn + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 아니오");
            Console.ResetColor();
        }

        public static void PrintNotWorkedDeleteAccout()
        {
            const int consoleInputRow = 20;
            const int consoleInputColumn = 13;

            Console.Clear();
            MainView.PrintMain();
            MainView.PrintBox(5);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("대여 중인 도서가 있어 정보 삭제가 불가능합니다.");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("            ESC : 뒤로가기");
        }

        public static void PrintSuccessDeleteAccount()
        {
            const int consoleInputRow = 35;
            const int consoleInputColumn = 10;

            MainView.PrintMain();
            MainView.PrintBox(5);

            Console.SetCursorPosition(consoleInputRow, consoleInputColumn);
            Console.WriteLine("회원 탈퇴 성공!");
            Console.SetCursorPosition(consoleInputRow, consoleInputColumn + 2);
            Console.WriteLine("ESC : 뒤로가기");
        }
    }
}
