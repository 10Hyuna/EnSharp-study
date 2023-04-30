using Library.Model.DTO;
using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.MemberAccessor
{
    class ModificationUserInformation
    {
        TotalStorage totalStorage;
        PrinterUserInformation printerUserInformation;
        HandlingException handlingException;
        UI ui;
        MovingCursorPosition cursor;
        InputFromUser inputFromUser;

        public ModificationUserInformation(TotalStorage totalStorage, PrinterUserInformation printerUserInformation,
            HandlingException handlingException, UI ui, MovingCursorPosition cursor, InputFromUser inputFromUser)
        {
            this.totalStorage = totalStorage;
            this.printerUserInformation = printerUserInformation;
            this.handlingException = handlingException;
            this.ui = ui;
            this.cursor = cursor;
            this.inputFromUser = inputFromUser;
        }

        int consoleInputRow;
        int consoleInputColumn;

        string id = "";
        string password = "";
        string name = "";
        string age = "";
        string phoneNumber = "";
        string address = "";

        ConsoleKeyInfo keyInfo;

        public void ModifyInformation()
        {           // 매니저 모드와 유저 모드 두 곳에서 모두 유저 정보를 수정할 수 있도록 함수화
            const int ConsoleInputRow = 30;
            const int ConsoleInputColumn = 7;

            int index = 0;
            int selectedMenu = 0;
            int validInput = 0;

            bool isInputEnter = false;

            string[] menu = {"User ID (8~ 15글자 영어, 숫자 포함) :", "User PW (8~ 15글자 영어, 숫자 포함) :",
                "User Name (한글, 영어 포함 2글자 이상 :", "User Age( 자연수 0 ~ 200세 ) :",
                "User PhoneNumber ( 01x-xxxx-xxxx ) :","User Address ( 도로명 주소 형식 ) :", "회원 정보 수정하기"};


            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)       // 어느 아이디가 로그인되어 있는 아이디인지 확인
                {
                    index = i;
                    break;
                }
            }

            Console.Clear();
            ui.PrintBox(4);
            printerUserInformation.PrintModifyMyInformationUI();

            while (!isInputEnter)       // 엔터가 입력되기 전까지 반복
            {
                validInput = 0;

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, ConsoleInputRow, ConsoleInputColumn);

                if (selectedMenu == ConstantNumber.EXIT)        // 중간에 esc를 눌렀다면
                {
                    return;
                }

                switch (selectedMenu)       // 입력한 인덱스 값이 어떤 것인지에 따라 수정할 수 있는 정보가 달라짐
                {
                    case (int)USERINFORMATION.ID:
                        id = ModifyInformation(0, ConstantNumber.idCheck, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = inputFromUser.EnterEsc(id);
                        break;
                    case (int)USERINFORMATION.PASSWORD:
                        password = ModifyInformation(1, ConstantNumber.passwordCheck, ConstantNumber.IS_PASSWORD);
                        validInput = inputFromUser.EnterEsc(password);
                        break;
                    case (int)USERINFORMATION.NAME:
                        name = ModifyInformation(2, ConstantNumber.nameCheck, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = inputFromUser.EnterEsc(name);
                        break;
                    case (int)USERINFORMATION.AGE:
                        age = ModifyInformation(3, ConstantNumber.ageCheck, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = inputFromUser.EnterEsc(age);
                        break;
                    case (int)USERINFORMATION.PHONENUMBER:
                        phoneNumber = ModifyInformation(4, ConstantNumber.phoneNumberCheck, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = inputFromUser.EnterEsc(phoneNumber);
                        break;
                    case (int)USERINFORMATION.ADDRESS:
                        address = ModifyInformation(5, ConstantNumber.addressCheck, ConstantNumber.IS_NOT_PASSWORD);
                        validInput = inputFromUser.EnterEsc(address);
                        break;
                    case (int)USERINFORMATION.SUCCESS:            // 정보 수정하기 칸에서 엔터를 눌렀다면
                        isInputEnter = true;        // 반복문을 탈출할 수 있도록
                        break;
                    case ConstantNumber.EXIT:
                        break;
                }
                if (isInputEnter)       // 정보 수정하기 칸에서 엔터를 눌러 isInputEnter 변수가 true가 되었다면 
                {                       // 입력받은 정보들 수정
                    if (id != "")
                    {
                        totalStorage.users[index].SetId(id);
                    }
                    if (password != "")
                    {
                        totalStorage.users[index].SetPassword(password);
                    }
                    if (name != "")
                    {
                        totalStorage.users[index].SetName(name);
                    }
                    if (age != "")
                    {
                        totalStorage.users[index].SetAge(age);
                    }
                    if (phoneNumber != "")
                    {
                        totalStorage.users[index].SetPhoneNumber(phoneNumber);
                    }
                    if (address != "")
                    {
                        totalStorage.users[index].SetAddress(address);
                    }
                }

                if (validInput == ConstantNumber.EXIT)
                {
                    isInputEnter = true;
                }
            }
        }
        private string ModifyInformation(int column, string regex, bool isPassword)     // 입력된 정보의 유효성 검사
        {
            consoleInputRow = 70;
            consoleInputColumn = 7 + column;

            string input = "";

            input = handlingException.IsValid(regex, consoleInputRow, consoleInputColumn, 20, isPassword);

            return input;
        }

        private void SelectModifyUserId()       // 매니저 모드에서 어느 유저의 정보를 수정할 것인지 선택하게 해 주는 함수
        {
            consoleInputRow = 60;
            consoleInputColumn = 10;

            bool isInputESC = false;
            bool isInvalidId = false;
            string userId;

            while (!isInvalidId)
            {
                Console.Clear();
                printerUserInformation.PrintModiFyUserIdUI();
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);

                printerUserInformation.PrintUserList();

                userId = handlingException.IsValid(ConstantNumber.idCheck, consoleInputRow + 3, consoleInputColumn - 7, 20, ConstantNumber.IS_NOT_PASSWORD);
                if (userId == null)
                    return;

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    if (totalStorage.users[i].GetId() == userId)        // 입력받은 아이디와 일치하는 아이디 값을 찾고
                    {
                        totalStorage.loggedInUserId = userId;       // 로그인 중인 아이디에 입력받은 아이디와 일치하는 아이디를 넣어 줌
                        isInvalidId = true;
                    }
                }

                if (!isInvalidId)       // 회원 정보 중 일치하는 아이디가 없다면
                {
                    ui.PrintException(ConstantNumber.INVALID_USER_ID, consoleInputRow, consoleInputColumn);
                    continue;
                }
            }

        }
        public void ManageUserInformation()     // 매니저 모드에서 유저의 정보를 수정할 것인지 정보를 삭제할 것인지 고르게 해 주는 함수
        {
            int selectedMenu = 0;
            bool isEnterESC = false;

            string[] menu = { "유저 정보 수정", "유저 삭제" };

            while (!isEnterESC)
            {
                consoleInputRow = 50;
                consoleInputColumn = 17;

                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, consoleInputRow, consoleInputColumn);

                if (selectedMenu == ConstantNumber.EXIT)     // 중간에 esc를 눌렀다면
                {
                    return;
                }

                switch (selectedMenu)
                {
                    case (int)MODIFICATION.USERINFORMATION:
                        SelectModifyUserId();
                        ModifyInformation();
                        break;
                    case (int)MODIFICATION.USERACCOUNT:
                        DeleteUserAccount();
                        break;
                }
            }

        }

        private void DeleteUserAccount()        // 유저의 정보를 삭제하는 함수
        {
            consoleInputRow = 60;
            consoleInputColumn = 10;

            bool isInputESC = false;
            bool isInvalidId = false;

            string userId;

            while (!isInputESC)
            {
                Console.Clear();
                printerUserInformation.PrintManageUser();
                Console.SetCursorPosition(consoleInputRow, consoleInputColumn);

                printerUserInformation.PrintUserList();

                userId = handlingException.IsValid(ConstantNumber.idCheck, consoleInputRow + 3, consoleInputColumn - 7, 20, false);
                // 삭제하려는 유저의 아이디 입력
                if (userId == null)     // 중도에 esc를 눌렀다면
                    return;

                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    if (totalStorage.users[i].GetId() == userId)        // 유저 정보 중 일치하는 아이디가 있다면
                    {
                        isInvalidId = true;
                        totalStorage.users.RemoveAt(i);     // 정보 삭제
                    }
                }

                if (!isInvalidId)       // 일치하는 아이디가 없었다면
                {
                    ui.PrintException(ConstantNumber.INVALID_USER_ID, consoleInputRow, consoleInputColumn);
                    continue;
                }

                Console.Clear();
                printerUserInformation.PrintSuccessDeleteUser();

                printerUserInformation.PrintUserList();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isInputESC = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, 40, 24);
                }
            }

        }
    }
}
