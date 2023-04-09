using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    class MemberFunction
    {
        HandlingException handlingException = new HandlingException();

        public void SignInMember(DataController dataController, UI ui, CurserController curser, BookFunction bookFunction)
        {
            const int ConsoleInputRow = 32;
            const int ConsoleInputColumn = 23;

            bool isValidAccount = false;

            int index = 0;

            string ID;
            string PW;

            while (!isValidAccount)
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                ID = Console.ReadLine();
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                PW = Console.ReadLine();

                for (int i = 0; i < dataController.members.Count; i++)
                {
                    if (dataController.members[i].id == ID)
                    {
                        if (dataController.members[i].password == PW)
                        {
                            isValidAccount = true;
                            index = i;
                            break;
                        }
                    }
                }
                if(!isValidAccount)
                {
                    ui.IsValidAccount(ConsoleInputRow - 10, ConsoleInputColumn + 2);
                }
            }
            SelectMenuInUserMode(index, dataController, ui, handlingException, curser, bookFunction);
        }
        public void SignUpMember(DataController dataController, UI ui)
        {
            const int ConsoleInputRow = 77;
            const int ConsoleInputColumn = 22;

            bool isValidInput = false;
            bool isSamePW = false;

            Regex IDCheck = new Regex(@"^[0-9a-zA-Z]{8,20}");
            string ID = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn);
            string PW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 1);
            while (!isSamePW)
            {
                string checkPW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 2);
                if (PW == checkPW)
                {
                    isSamePW = true;
                }
                else
                {
                    Console.Write("비밀번호의 값이 서로 다릅니다.");
                    PW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 1);
                }
            }

            isValidInput = false;
            Regex nameCheck = new Regex(@"^[가-힣a-zA-Z]{1,}");
            string name = handlingException.IsValid(nameCheck, ConsoleInputRow, ConsoleInputColumn + 3);

            Regex ageCheck = new Regex(@"^[0-9]{1,3}");
            string age = handlingException.IsValid(ageCheck, ConsoleInputRow, ConsoleInputColumn + 4);
            while (!isValidInput)
            {
                if (int.Parse(age) <= 200)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.Write("주어진 조건에 맞는 값을 입력해 주세요.");
                    age = handlingException.IsValid(ageCheck, ConsoleInputRow, ConsoleInputColumn + 4);
                }
            }
            isValidInput = false;

            Regex phoneNumCheck = new Regex(@"01{1}[016789]{1}-[0-9]{3,4}-[0-9]{4}");
            string phoneNumber = handlingException.IsValid(phoneNumCheck, ConsoleInputRow, ConsoleInputColumn + 5);

            Regex addressCheck = new Regex(@"[가-힣]{2,4}시 [가-힣]{2}구");
            string address = handlingException.IsValid(addressCheck, ConsoleInputRow, ConsoleInputColumn + 6);
            UserData userData = new UserData(ID, PW, name, age, phoneNumber, address);
        }
        private void SelectMenuInUserMode(int index, DataController dataController, UI ui, HandlingException handlingException, CurserController curser, BookFunction bookFunction)
        {
            Console.Clear();
            ui.PrintUserMenu();
            int selectedMenu = 0;

            const int findingTheBook = 0;
            const int rentingTheBook = 1;
            const int checkingTheRentalBook = 2;
            const int returningTheBook = 3;
            const int returningTheBookList = 4;
            const int modifyingInformationOfUser = 5;
            const int delectingAccount = 6;
            const int exit = -1;

            string[] menu = { "도서 찾기", "도서 대여", "도서 대여 확인", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제" };
            do
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(10);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, ui);

                if (selectedMenu == findingTheBook)
                {
                    Console.Clear();
                    FindTheBook(ui, dataController);
                }

                else if (selectedMenu == rentingTheBook)
                {
                    RentTheBook(ui, dataController);
                }

                else if (selectedMenu == checkingTheRentalBook)
                {
                    CheckRentalBook(ui, dataController);
                }

                else if (selectedMenu == returningTheBook)
                {
                    ReturnTheBook(ui, dataController);
                }

                else if (selectedMenu == returningTheBookList)
                {
                    ReturnTheBookList(ui, dataController);
                }

                else if (selectedMenu == modifyingInformationOfUser)
                {
                    ModifyMyInformation(ui, dataController);
                }

                else if (selectedMenu == delectingAccount)
                {
                    DeleteMyAccount(ui, dataController);
                }

                else if (selectedMenu == exit)
                {
                    Console.Clear();
                }
            } while (selectedMenu != exit);
        }

        private void FindTheBook(UI ui, DataController dataController)
        {

            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            string title;
            string author;
            string publisher;

            ui.PrintFindingBookUI(dataController);

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            title = Console.ReadLine();
            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
            author = Console.ReadLine();
            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 2);
            publisher = Console.ReadLine();


        }

        private void RentTheBook(UI ui, DataController dataController)
        {

        }

        private void CheckRentalBook(UI ui, DataController dataController)
        {

        }

        private void ReturnTheBook(UI ui, DataController dataController)
        {

        }

        private void ReturnTheBookList(UI ui, DataController dataController)
        {

        }

        private void ModifyMyInformation(UI ui, DataController dataController)
        {

        }

        private void DeleteMyAccount(UI ui, DataController dataController)
        {

        }
    }
}
