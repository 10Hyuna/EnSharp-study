using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;
using Library.View;
using Library.Model.VO;
using Library.Model.DTO;

namespace Library.Controller
{
    class EnteringUserMode
    {
        UI ui;
        TotalInformationStorage totalInformationStorage;
        MovingCurserPosition curser;
        RegexStorage regex;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        ConstantNumber constantNumber;
        PrintingBookInformation printBookInformation;
        public EnteringUserMode(UI ui, TotalInformationStorage totalInformationStorage, MovingCurserPosition curser,
            InputFromUser inputFromUser, ConstantNumber constantNumber, PrintingBookInformation printBookInformation)
        {
            this.ui = ui;
            this.totalInformationStorage = totalInformationStorage;
            this.curser = curser;
            this.inputFromUser = inputFromUser;
            this.constantNumber = constantNumber;
            this.printBookInformation = printBookInformation;
            regex = new RegexStorage();
            handlingException = new HandlingException(inputFromUser, ui, constantNumber);
        }

        public int SignInMember()  // 로그인
        {
            const int ConsoleInputRow = 25;
            const int ConsoleInputColumn = 23;

            bool isValidAccount = false;

            int index = 0;

            string id;
            string password;

            while (!isValidAccount)     // 계정 정보가 유효하지 않을 경우 계속 반복
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                id = inputFromUser.InputStringFromUser(15, false, ConsoleInputRow, ConsoleInputColumn);
                if (id == null)
                    return -1;
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                password = inputFromUser.InputStringFromUser(15, true, ConsoleInputRow, ConsoleInputColumn + 1);
                if (password == null)
                    return -1;

                for (int i = 0; i < totalInformationStorage.users.Count; i++)      // 저장되어 있는 회원 정보만큼 반복하며
                {
                    if (totalInformationStorage.users[i].id == id)     // 일치하는 ID가 있을 때
                    {
                        if (totalInformationStorage.users[i].password == password)   // PW까지 일치한다면
                        {
                            isValidAccount = true;      // 존재하는 계정의
                            index = i;                  // 인덱스 값을 저장해 두고
                            break;                      // 반복문 탈출
                        }
                    }
                }
                if (!isValidAccount)
                {
                    ui.IsValidAccount(ConsoleInputRow - 10, ConsoleInputColumn + 2);
                }
            }
            return index;
        }
        public int SignUpMember()      // 회원가입
        {
            const int ConsoleInputRow = 72;
            const int ConsoleInputColumn = 23;

            bool isValidInput = false;
            bool isSamePW = false;

            string id;
            string password;
            string checkPassword;
            string name;
            string age;
            string phoneNumber;
            string address;

            id = handlingException.IsValid(regex.idCheck, ConsoleInputRow, ConsoleInputColumn, 15, false);
            if (id == null)
                return -1;

            password = handlingException.IsValid(regex.passwordCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, true);
            if (password == null)
                return -1;

            while (!isSamePW)       // 비밀번호를 확인하는 문자열을 입력받았을 때 그 문자열이 비밀번호와 같지 않다면 계속 반복
            {
                checkPassword = handlingException.IsValid(regex.passwordCheck, ConsoleInputRow, ConsoleInputColumn + 2, 15, true);
                if (checkPassword == null)
                    return -1;

                if (password == checkPassword)      // 비밀번호와 같다면
                {
                    isSamePW = true;
                }
                else
                {
                    ui.PrintException(constantNumber.notMatchedPassword);
                    password = handlingException.IsValid(regex.idCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, false);       // 비밀번호를 잘못 입력했을 경우를 대비
                    if (password == null)
                        return -1;
                }
            }

            isValidInput = false;
            name = handlingException.IsValid(regex.nameCheck, ConsoleInputRow, ConsoleInputColumn + 3, 20, false);
            if (name == null)
                return -1;

            age = handlingException.IsValid(regex.ageCheck, ConsoleInputRow, ConsoleInputColumn + 4, 20, false);
            if (age == null)
                return -1;

            while (!isValidInput)       // 200세 이상을 정규식으로 확인하지 못해 따로 확인
            {
                if (int.Parse(age) <= 200)
                {
                    isValidInput = true;
                }
                else
                {
                    ui.PrintException(constantNumber.notMatchedCondition);
                    age = handlingException.IsValid(regex.ageCheck, ConsoleInputRow, ConsoleInputColumn + 4, 20, false);
                }
            }
            isValidInput = false;

            phoneNumber = handlingException.IsValid(regex.phoneNumCheck, ConsoleInputRow, ConsoleInputColumn + 5, 20, false);
            if (phoneNumber == null)
                return -1;

            address = handlingException.IsValid(regex.addressCheck, ConsoleInputRow, ConsoleInputColumn + 6, 20, false);
            if (address == null)
                return -1;

            totalInformationStorage.users.Add(new UserInformation(id, password, name, age, phoneNumber, address));    // 위의 조건을 모두 통과한 값일 경우 정보 저장
            return 0;
        }

        private void CheckRentalBook(UI ui, TotalInformationStorage dataController)
        {

        }

        private void ReturnTheBook(UI ui, TotalInformationStorage dataController)
        {

        }

        private void ReturnTheBookList(UI ui, TotalInformationStorage dataController)
        {

        }

        private void ModifyMyInformation(UI ui, TotalInformationStorage dataController)
        {

        }

        private void DeleteMyAccount(UI ui, TotalInformationStorage dataController)
        {

        }
    }
}
