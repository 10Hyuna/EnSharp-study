using System;
using System.Collections.Generic;
using System.Data.Common;
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
        }
        
        public void PrintBox(int index)
        {
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine("\t\t|                                                                                               |");
            }
            Console.WriteLine("\t\t________________________________________________________________________________________________\t\t");
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
            Console.WriteLine("\t\t    User ID   : ");
            Console.WriteLine("\t\tUser Password : ");
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

        }
        public void PrintFindingBookUI(DataController dataController)
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
            PrintBookList(dataController);
        }

        public void PrintBookList(DataController dataController)
        {
            for(int i = 0; i < dataController.books.Count; i++)
            {
                Console.WriteLine("\n=====================================================================================\n");
                Console.WriteLine("책아이디  : ", dataController.books[i].ID);
                Console.WriteLine("책 제목   : ", dataController.books[i].title);
                Console.WriteLine("작가      : ", dataController.books[i].author);
                Console.WriteLine("출판사    : ", dataController.books[i].publisher);
                Console.WriteLine("수량      : ", dataController.books[i].amount);
                Console.WriteLine("가격      : ", dataController.books[i].price);
                Console.WriteLine("출시일    : ", dataController.books[i].publishDay);
                Console.WriteLine("ISBN      : ", dataController.books[i].ISBN);
                Console.WriteLine("책 정보   : ", dataController.books[i].information);
            }
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

        public void PrintRenttheBookUI(DataController dataController)
        {
            Console.WriteLine(" 빌릴 책의 ID를 입력해 주세요.");
            Console.WriteLine(" ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ESC : 뒤로가기");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ENTER : 선택하기");
            Console.ResetColor();
            PrintBookList(dataController);
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
