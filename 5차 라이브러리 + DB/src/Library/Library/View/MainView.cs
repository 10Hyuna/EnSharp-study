using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class MainView
    {
        private static MainView mainView = null;

        private MainView() { }

        public static MainView SetMainView()
        {
            if (mainView == null)
            {
                mainView = new MainView();
            }
            return mainView;
        }

        public void PrintMain()
        {
            Console.WriteLine("\n\t     ##     #####   ######    #####    ######   #####   ##   ##");
            Console.WriteLine("\t    ##       ##    ###  ##   ##  ##  ###  ##   ##  ##   ## ##");
            Console.WriteLine("\t   ##       ##    ######    ##  ###  ##  ##   ##  ###    ###");
            Console.WriteLine("\t  ##       ##    ###  ##   ######  #######   ######     ##");
            Console.WriteLine("\t ##       ##    ##   ##  ##  ##   ##  ##   ##  ##     ##");
            Console.WriteLine("\t#####  #####   ######   ##   ### ##  ##   ##   ###   ##\n");
        }

        public void PrintBox(int line)
        {
            Console.WriteLine("\t\t┌─────────────────────────────────────┐");
            for (int i = 0; i < line; i++)
            {
                Console.WriteLine("\t\t│                                     │");
            }
            Console.WriteLine("\t\t└─────────────────────────────────────┘");
        }

        public void PrintLoginUI(string objectName)
        {
            PrintMain();
            PrintBox(4);

            int column = 32;
            int row = 10;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("로 그 인");
            Console.SetCursorPosition(column - 12, row + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 뒤로 가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ENTER : 입력하기\n\n");
            Console.ResetColor();
            Console.WriteLine("\t    {0} ID   :", objectName);
            Console.WriteLine("\t{0} PASSWORD :", objectName);
        }

        public void PrintSignUpUI()
        {
            PrintMain();
            PrintBox(5);

            int column = 30;
            int row = 10;

            Console.SetCursorPosition(column, row);
            Console.WriteLine("회 원 가 입");
            Console.SetCursorPosition(column - 10, row + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 뒤로 가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ENTER : 입력하기\n\n");
            Console.ResetColor();

            column = 10;
            row = 15;
            Console.SetCursorPosition(column, row);
            Console.Write("User ID (8 ~ 15 글자 영어, 숫자 포함) :");
            Console.SetCursorPosition(column, row + 1);
            Console.Write("User PW (8 ~ 15 글자 영어, 숫자 포함) :");
            Console.SetCursorPosition(column, row + 2);
            Console.Write("User PW (  PW 확인  ) :");
            Console.SetCursorPosition(column, row + 3);
            Console.Write("User Name (  한글, 영어 포함 1글자 이상  ) :");
            Console.SetCursorPosition(column, row + 4);
            Console.Write("User Age (  자연수 0세 ~ 200세  ) :");
            Console.SetCursorPosition(column, row + 5);
            Console.Write("User PhoneNumber (  01x - xxxx - xxxx  ) :");
            Console.SetCursorPosition(column, row + 6);
            Console.Write("User Address (  도로명 주소 - 00시 00구  ) :");
            Console.SetCursorPosition(column, row + 7);
        }

        public void SuccessSignUp()
        {
            Console.SetWindowSize(76, 15);
            PrintMain();
            PrintBox(4);

            int column = 28;
            int row = 10;

            Console.SetCursorPosition(column, row);
            Console.Write("회 원 가 입 성 공!");
            Console.SetCursorPosition(column , row + 1);
            Console.Write("ENTER를 눌러 주세요");
        }
    }
}
