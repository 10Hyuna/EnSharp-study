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
            Console.WriteLine("\n\n");
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
            const int WindowCenterWidth = 53;
            const int WindowCenterHeight = 18;

            PrintMain();

            Console.SetCursorPosition(WindowCenterHeight, WindowCenterHeight);
            Console.WriteLine("\t\t\t\t");
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
