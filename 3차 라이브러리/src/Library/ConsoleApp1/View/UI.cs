using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;

namespace Library.View
{
    class UI
    {
        ConstantNumber constantNumber;
        public UI(ConstantNumber constant)
        {
            this.constantNumber = constant;
        }
        public void PrintMain()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t   ####        ####    ########      #######              ###        #######       ####   ####");
            Console.WriteLine("\t    ##          ##      ##     ##     ##    ##            ###         ##     ##     ##     ##");
            Console.WriteLine("\t    ##          ##      ##    ###     ##     ##          ## ##        ##      ##     ##   ##");
            Console.WriteLine("\t    ##          ##      ##   ##       ##    ##          ##   ##       ##     ##       ## ##");
            Console.WriteLine("\t    ##          ##      ##   ##       ## ###           #########      ##  ###          ###");
            Console.WriteLine("\t    ##          ##      ##     ###    ##    ##        ##       ##     ####   ##        ##");
            Console.WriteLine("\t    ##          ##      ##      ###   ##      ##     ##         ##    ##       ##      ##");
            Console.WriteLine("\t   ########    ####    #########      ##       ###  ##           ##  ####       ###   ####");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t ENTER : 선택\t\t\tESC : 뒤로가기");
        }

        public void PrintBox(int index)
        {
            Console.WriteLine("\t________________________________________________________________________________________________\t\t");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine("\t|                                                                                               |");
            }
            Console.WriteLine("\t________________________________________________________________________________________________\t\t");
        }
        public void PrintLogin()
        {
            PrintMain();
            PrintBox(6);
            const int WindowCenterRow = 58;
            const int WindowCenterColumn = 17;

            const int ConsoleInputRow = 30;
            const int ConsoleInputColumn = 23;

            Console.SetCursorPosition(WindowCenterRow, WindowCenterColumn);
            Console.WriteLine("  로 그 인");
            Console.SetCursorPosition(WindowCenterRow - 8, WindowCenterColumn + 2);
            Console.WriteLine("ESC : 뒤로 가기   ENTER : 입력하기");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t    User ID   : ");
            Console.WriteLine("\tUser Password : ");
        }

        public void IsValidAccount(int row, int column)
        {
            Console.Clear();
            PrintLogin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(row, column);
            Console.WriteLine("가입 정보가 없습니다.");
            Console.ResetColor();
        }
        public void PrintUserMenu()
        {
            PrintMain();
            PrintBox(9);
        }
        public void PrintManagerMenu()
        {
            PrintMain();
            PrintBox(8);
        }

        public void PrintSignUpUI()
        {
            const int WindowCenterRow = 55;
            const int WindowCenterColumn = 17;

            const int ConsoleInputRow = 30;
            const int ConsoleInputColumn = 23;

            PrintMain();
            PrintBox(6);

            Console.SetCursorPosition(WindowCenterRow, WindowCenterColumn);
            Console.WriteLine("회 원 가 입");
            Console.SetCursorPosition(WindowCenterRow - 8, WindowCenterColumn + 2);
            Console.WriteLine("ESC : 뒤로 가기   ENTER : 입력하기");
            for (int i = 0; i < 7; i++)
            {
                Console.SetCursorPosition(ConsoleInputRow, i + ConsoleInputColumn);
                if (i == 0)
                {
                    Console.WriteLine("User ID (8 ~ 15 글자 영어, 숫자 포함) : ");
                }
                else if (i == 1)
                {
                    Console.WriteLine("User PW (8 ~ 15 글자 영어, 숫자 포함) : ");
                }
                else if (i == 2)
                {
                    Console.WriteLine("User PW (  PW 확인  ) : ");
                }
                else if (i == 3)
                {
                    Console.WriteLine("User Name (  한글, 영어 포함 1글자 이상  ) : ");
                }
                else if (i == 4)
                {
                    Console.WriteLine("User Age (  자연수 0세 ~ 200세  ) : ");
                }
                else if (i == 5)
                {
                    Console.WriteLine("User PhoneNumber (  01x - xxxx - xxxx  ) : ");
                }
                else if (i == 6)
                {
                    Console.WriteLine("User Address (  도로명 주소 - 00시 00구  ) : ");
                }
            }
        }

        public void PrintSuccessSignup()
        {
            const int WindowCenterRow = 55;
            const int WindowCenterColumn = 17;

            Console.SetCursorPosition(WindowCenterRow, WindowCenterColumn);
            Console.WriteLine("회 원 가 입 성 공 !!");
            Console.SetCursorPosition(WindowCenterRow, WindowCenterColumn + 2);
            Console.WriteLine(" ENTER를 눌러주세요.");
        }

        public void PrintException(int condition)
        {
            if(condition==constantNumber.isNotMatchedCondition)
            {
                Console.WriteLine("주어진 조건에 맞는 값을 입력해 주세요.");
            }
            if(condition==constantNumber.isNotMatchedCondition)
            {
                Console.WriteLine("비밀번호의 값이 서로 다릅니다.");
            }
        }
    }
}
