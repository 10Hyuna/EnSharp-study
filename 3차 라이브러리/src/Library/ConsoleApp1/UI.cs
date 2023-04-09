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
            Console.WriteLine("\t   ####        ####    ########      #######              ###        #######       ####   ####");
            Console.WriteLine("\t    ##          ##      ##     ##     ##    ##            ###         ##     ##     ##     ##");
            Console.WriteLine("\t    ##          ##      ##    ###     ##     ##          ## ##        ##      ##     ##   ##");
            Console.WriteLine("\t    ##          ##      ##   ##       ##    ##          ##   ##       ##     ##       ## ##");
            Console.WriteLine("\t    ##          ##      ##   ##       ## ###           #########      ##  ###          ###");
            Console.WriteLine("\t    ##          ##      ##     ###    ##    ##        ##       ##     ####   ##        ##");
            Console.WriteLine("\t    ##          ##      ##      ###   ##      ##     ##         ##    ##       ##      ##");
            Console.WriteLine("\t   ########    ####    #########      ##       ###  ##           ##  ####       ###   ####");
            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t ENTER : 선택\t\t\t\tESC : 뒤로가기");
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("|                                                                                               |");
            }
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
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

        public int SelectMenu(int selectMenu, int endMenu)
        {
            for(int i = 0; i < endMenu; i++)
            {
                if (i == selectMenu)
                    return i;
            }
            Console.WriteLine("");
            return -1;
        }

        public int SelectKey(int endMenu)
        {
            int selectedMenu = 0;
            ConsoleKeyInfo keyInfo;

            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.PageUp)
            {
                selectedMenu--;
                if (selectedMenu < 0)
                {
                    selectedMenu = endMenu;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.PageDown)
            {
                selectedMenu++;
                if (selectedMenu >= endMenu)
                {
                    selectedMenu = 0;
                }
                return selectedMenu;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
