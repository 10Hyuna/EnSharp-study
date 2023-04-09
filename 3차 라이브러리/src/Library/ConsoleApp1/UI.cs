using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class UI
    {
        public void PrintMain()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t\t   ####        ####    ########      #######              ###        #######       ####   ####");
            Console.WriteLine("\t\t    ##          ##      ##     ##     ##    ##            ###         ##     ##     ##     ##");
            Console.WriteLine("\t\t    ##          ##      ##    ###     ##     ##          ## ##        ##      ##     ##   ##");
            Console.WriteLine("\t\t    ##          ##      ##   ##       ##    ##          ##   ##       ##     ##       ## ##");
            Console.WriteLine("\t\t    ##          ##      ##   ##       ## ###           #########      ##  ###          ###");
            Console.WriteLine("\t\t    ##          ##      ##     ###    ##    ##        ##       ##     ####   ##        ##");
            Console.WriteLine("\t\t    ##          ##      ##      ###   ##      ##     ##         ##    ##       ##      ##");
            Console.WriteLine("\t\t   ########    ####    #########      ##       ###  ##           ##  ####       ###   ####");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\t\t ENTER : 선택\t\t\t\tESC : 뒤로가기");
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("\t\t|                                                                                               |");
            }
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
            Console.WriteLine("\t\t\t\t\t     ↑ 또는 ↓ 키를 눌러 메뉴를 이동하세요.");
        }

        public void PrintLogin()
        {

        }

        public void PrintUserMenu()
        {

        }
        public void PrintManagerMenu()
        {

        }
        public void PrintFindingBookUI()
        {

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

        public void PrintManageAboutUserInformation()
        {

        }

        public void PrintRentalStateUI()
        {

        }

        public void PrintSignUpUI()
        {
            const int WindowCenterRow = 55;
            const int WindowCenterColumn = 17;

            const int ConsoleInputRow = 30;
            const int ConsoleInputColumn = 23;

            PrintMain();

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

        public void PrintRenttheBookUI()
        {

        }

        public void PrintReturnThebookUI()
        {

        }
        public void PrintReturnBookListUI()
        {

        }

        public void PrintModifyMyInformationUI()
        {

        }

        public void PrintDeleteAccountUI()
        {

        }

        public int SelectKey(int endMenu, int selectedMenu)
        {
            ConsoleKeyInfo keyInfo;

            
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenu;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenu++;
                if (selectedMenu > endMenu)
                {
                    selectedMenu = 0;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                return 10;
            }
            else if(keyInfo.Key == ConsoleKey.Escape)
            {
                return 11;
            }
            else
            {
                return -1;
            }
        }
    }
}
