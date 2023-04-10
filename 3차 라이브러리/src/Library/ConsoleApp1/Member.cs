using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    class Member
    {
        HandlingException handlingException = new HandlingException();

        public void SignInMember(DataController dataController, UI ui, CurserController curser, BookFunction bookFunction)  // 로그인
        {
            const int ConsoleInputRow = 32;
            const int ConsoleInputColumn = 23;

            bool isValidAccount = false;

            int index = 0;

            string ID;
            string PW;

            while (!isValidAccount)     // 계정 정보가 유효하지 않을 경우 계속 반복
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                ID = Console.ReadLine();
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                PW = Console.ReadLine();

                for (int i = 0; i < dataController.members.Count; i++)      // 저장되어 있는 회원 정보만큼 반복하며
                {
                    if (dataController.members[i].id == ID)     // 일치하는 ID가 있을 때
                    {
                        if (dataController.members[i].password == PW)   // PW까지 일치한다면
                        {
                            isValidAccount = true;      // 존재하는 계정의
                            index = i;                  // 인덱스 값을 저장해 두고
                            break;                      // 반복문 탈출
                        }
                    }
                }
                if(!isValidAccount)
                {
                    ui.IsValidAccount(ConsoleInputRow - 10, ConsoleInputColumn + 2);
                }
            }
            SelectMenuInUserMode(index, dataController, ui, handlingException, curser, bookFunction);       // 유저 모드일 때 진입할 수 있는 메뉴로 진입
        }
        public void SignUpMember(DataController dataController, UI ui)      // 회원가입
        {
            const int ConsoleInputRow = 77;
            const int ConsoleInputColumn = 22;

            bool isValidInput = false;
            bool isSamePW = false;

            Regex IDCheck = new Regex(@"^[0-9a-zA-Z]{8,20}");       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
            string ID = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn);
            string PW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 1);
            while (!isSamePW)       // 비밀번호를 확인하는 문자열을 입력받았을 때 그 문자열이 비밀번호와 같지 않다면 계속 반복
            {
                string checkPW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 2);
                if (PW == checkPW)      // 비밀번호와 같다면
                {
                    isSamePW = true;
                }
                else
                {
                    Console.Write("비밀번호의 값이 서로 다릅니다.");
                    PW = handlingException.IsValid(IDCheck, ConsoleInputRow, ConsoleInputColumn + 1);       // 비밀번호를 잘못 입력했을 경우를 대비
                }
            }

            isValidInput = false;
            Regex nameCheck = new Regex(@"^[가-힇a-zA-Z]{1,}");       // 이름 정규식
            string name = handlingException.IsValid(nameCheck, ConsoleInputRow, ConsoleInputColumn + 3);

            Regex ageCheck = new Regex(@"^[0-9]{1,3}");               // 나이 정규식
            string age = handlingException.IsValid(ageCheck, ConsoleInputRow, ConsoleInputColumn + 4);
            while (!isValidInput)       // 200세 이상을 정규식으로 확인하지 못해 따로 확인
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

            Regex phoneNumCheck = new Regex(@"01{1}[016789]{1}-[0-9]{3,4}-[0-9]{4}");       // 번호 정규식
            string phoneNumber = handlingException.IsValid(phoneNumCheck, ConsoleInputRow, ConsoleInputColumn + 5);

            Regex addressCheck = new Regex(@"[가-힇]{2,4}시 [가-힇]{2}구");                 // 주소 정규식
            string address = handlingException.IsValid(addressCheck, ConsoleInputRow, ConsoleInputColumn + 6);
            dataController.members.Add(new MemberData(ID, PW, name, age, phoneNumber, address));    // 위의 조건을 모두 통과한 값일 경우 정보 저장
        }
        private void SelectMenuInUserMode(int index, DataController dataController, UI ui, HandlingException handlingException, CurserController curser, BookFunction bookFunction)
        {               // 유저 모드에서 로그인에 성공했을 경우, 사용할 수 있는 메뉴
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
                    Console.Clear();
                    RentTheBook(ui, dataController);
                }

                else if (selectedMenu == checkingTheRentalBook)
                {
                    Console.Clear();
                    CheckRentalBook(ui, dataController);
                }

                else if (selectedMenu == returningTheBook)
                {
                    Console.Clear();
                    ReturnTheBook(ui, dataController);
                }

                else if (selectedMenu == returningTheBookList)
                {
                    Console.Clear();
                    ReturnTheBookList(ui, dataController);
                }

                else if (selectedMenu == modifyingInformationOfUser)
                {
                    Console.Clear();
                    ModifyMyInformation(ui, dataController);
                }

                else if (selectedMenu == delectingAccount)
                {
                    Console.Clear();
                    DeleteMyAccount(ui, dataController);
                }

                else if (selectedMenu == exit)
                {
                    Console.Clear();
                }
            } while (selectedMenu != exit);     // ESC를 입력하기 전까지는 계속 반복
        }

        private void SelectedBookList(DataController dataController, UI ui, int ConsoleInputRow, int ConsoleInputColumn) // 찾고자 하는 책의 정보를 입력하는 함수
        { 
            string title;
            string author;
            string publisher;

            ConsoleKeyInfo keyInfo;

            bool isInputESC = false;
            int selectedKey;

            while (!isInputESC)
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                title = Console.ReadLine();     // 제목 입력
                if (title == null) // 값이 null일 경우
                {
                    title = "";
                }
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                author = Console.ReadLine();    // 작가 입력
                if (author == null)
                {
                    author = "";
                }
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 2);
                publisher = Console.ReadLine();
                if (publisher == null)
                {
                    publisher = "";
                }

                Console.Clear();
                ui.PrintFindingBookUI(dataController);
                ui.PrintBookList(dataController, title, author, publisher);     // 입력받은 값과 일치하는 정보를 출력해 주는 함수

                selectedKey = ui.SelectKey(0, 0);
                if (selectedKey == 11)
                {
                    isInputESC = true;
                }
            }
            //if()
            //{
            //    Console.SetCursorPosition(1, 3);
            //    Console.WriteLine("일치하는 항목이 없습니다.");
            //}

        }
        private void FindTheBook(UI ui, DataController dataController)      // 책 찾기 메뉴에 진입했을 경우
        {

            const int ConsoleInputRow = 19;
            const int ConsoleInputColumn = 0;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                ui.PrintFindingBookUI(dataController);
                ui.PrintAllBookList(dataController);
                SelectedBookList(dataController, ui, ConsoleInputRow, ConsoleInputColumn);

                keyInfo = Console.ReadKey();

                if(keyInfo.Key == ConsoleKey.Escape)        // ESC 키를 입력한다면
                {
                    isCheckedExit = true;   
                }

            } while (!isCheckedExit);       // 반복문 탈출
        }

        private void RentTheBook(UI ui, DataController dataController)      // 책 대여 메뉴에 진입했을 때
        {
            const int ConsoleInputRow = 20;
            const int ConsoleInputColumn = 0;

            string bookID;

            bool isCheckedExit = false;

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                ui.PrintFindingBookUI(dataController);
                ui.PrintAllBookList(dataController);
                SelectedBookList(dataController, ui, ConsoleInputRow, ConsoleInputColumn);

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)       // ESC를 입력한다면
                {
                    isCheckedExit = true;
                }

            } while (!isCheckedExit);                       // 반복문 탈출

            FindTheBook(ui, dataController);                
            ui.PrintRenttheBookUI(dataController);

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            bookID = Console.ReadLine();        // 빌리고자 하는 책의 아이디 입력

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
