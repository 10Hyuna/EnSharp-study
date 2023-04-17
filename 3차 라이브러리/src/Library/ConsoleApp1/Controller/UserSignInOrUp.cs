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
using System.Reflection.Metadata.Ecma335;
using System.Reflection;

namespace Library.Controller
{
    class UserSignInOrUp
    {
        UI ui;
        TotalStorage totalStorage;
        User user;
        MovingCursorPosition cursor;
        RegexStorage regex;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        PrinterBookInformation printBookInformation;
        Manager manager;

        public UserSignInOrUp() { }

        public UserSignInOrUp(UI ui, TotalStorage totalStorage, User user, MovingCursorPosition cursor,
            InputFromUser inputFromUser, PrinterBookInformation printBookInformation, HandlingException handlingException)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
            this.user = user;
            this.cursor = cursor;
            this.inputFromUser = inputFromUser;
            this.printBookInformation = printBookInformation;
            this.handlingException = handlingException;
            regex = new RegexStorage();
            manager = new Manager();
        }

        public List<string> SignInMember()  // 로그인
        {
            const int id = 0;
            const int password = 1;

            int ConsoleInputRow = 25;
            int ConsoleInputColumn = 23;

            bool isPassword = true;
            bool isNotPassword = false;
            bool isValidAccount = false;

            int userIndex = 0;
            int managerIndex = 0;

            List<string> accounts = new List<string>();

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
            accounts[(int)(USERINFORMATION.ID)] = inputFromUser.InputStringFromUser(15, isNotPassword, ConsoleInputRow, ConsoleInputColumn);
            if (accounts[(int)(USERINFORMATION.ID)] == null)
                return null;

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
            accounts[(int)(USERINFORMATION.PASSWORD)] = inputFromUser.InputStringFromUser(15, isPassword, ConsoleInputRow, ConsoleInputColumn + 1);
            if (accounts[(int)(USERINFORMATION.PASSWORD)] == null)
                return null;

            return accounts;
        }

        public bool SerchValidAccount(List<string> account)
        {
            const int ConsoleInputRow = 15;
            const int ConsoleInputColumn = 21;

            int userIndex = 0;

            bool isValidAccount = false;

            for (int i = 0; i < totalStorage.users.Count; i++)      // 저장되어 있는 회원 정보만큼 반복하며
            {
                if (totalStorage.users[i].GetUserId() == account[(int)(USERINFORMATION.ID)] &&
                    totalStorage.users[i].GetUserPassword() == account[(int)(USERINFORMATION.PASSWORD)])   // 일치하는 ID가 있을 때
                {
                    totalStorage.loggedInUserId = account[(int)(USERINFORMATION.ID)];
                    isValidAccount = true;      // 존재하는 계정의
                    userIndex = i;                  // 인덱스 값을 저장해 두고
                    break;                      // 반복문 탈출
                }
            }

            if (!isValidAccount)
            {
                ui.IsValidAccount(ConsoleInputRow, ConsoleInputColumn);
            }

            return isValidAccount;
        }
        public int SignUpMember()      // 회원가입
        {
            int ConsoleInputRow = 72;
            int ConsoleInputColumn = 22;

            bool isValidInput = false;
            bool isOverlapData = false;
            bool isSamePW = false;

            string id = "";
            string password;
            string checkPassword;
            string name;
            string age;
            string phoneNumber;
            string address;

            while (!isOverlapData)
            {
                id = handlingException.IsValid(regex.idCheck, ConsoleInputRow, ConsoleInputColumn, 15, false);
                if (id == null)
                    return -1;
                for (int i = 0; i < totalStorage.users.Count; i++)
                {
                    if (totalStorage.users[i].GetUserId() == id)
                    {
                        isOverlapData = true;
                        break;
                    }
                }
                if (isOverlapData)
                {
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);
                    ui.PrintException(ConstantNumber.OVERLAP_DATA);
                    continue;
                }
            }

            password = handlingException.IsValid(regex.passwordCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, true);
            if (password == null)
                return ConstantNumber.EXIT;

            while (!isSamePW)       // 비밀번호를 확인하는 문자열을 입력받았을 때 그 문자열이 비밀번호와 같지 않다면 계속 반복
            {
                checkPassword = handlingException.IsValid(regex.passwordCheck, ConsoleInputRow - 17, ConsoleInputColumn + 2, 15, true);
                if (checkPassword == null)
                    return ConstantNumber.EXIT;

                if (password == checkPassword)      // 비밀번호와 같다면
                {
                    isSamePW = true;
                }
                else
                {
                    Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
                    ui.PrintException(ConstantNumber.NOT_MATCHED_PASSWORD);
                    password = handlingException.IsValid(regex.idCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, true);       // 비밀번호를 잘못 입력했을 경우를 대비
                    
                    if (password == null)
                        return ConstantNumber.EXIT;
                }
            }

            isValidInput = false;
            name = handlingException.IsValid(regex.nameCheck, ConsoleInputRow + 3, ConsoleInputColumn + 3, 20, false);
            if (name == null)
                return ConstantNumber.EXIT;

            age = handlingException.IsValid(regex.ageCheck, ConsoleInputRow - 6, ConsoleInputColumn + 4, 20, false);
            if (age == null)
                return ConstantNumber.EXIT;

            while (!isValidInput)       // 200세 이상을 정규식으로 확인하지 못해 따로 확인
            {
                if (int.Parse(age) <= 200)
                {
                    isValidInput = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION);
                    age = handlingException.IsValid(regex.ageCheck, ConsoleInputRow - 8, ConsoleInputColumn + 4, 20, false);
                }
            }
            isValidInput = false;

            phoneNumber = handlingException.IsValid(regex.phoneNumberCheck, ConsoleInputRow + 1, ConsoleInputColumn + 5, 20, false);
            if (phoneNumber == null)
                return ConstantNumber.EXIT;

            address = handlingException.IsValid(regex.addressCheck, ConsoleInputRow + 3, ConsoleInputColumn + 6, 20, false);
            if (address == null)
                return ConstantNumber.EXIT;

            totalStorage.users.Add(new User(id, password, name, age, phoneNumber, address));    // 위의 조건을 모두 통과한 값일 경우 정보 저장

            return ConstantNumber.SUCCESS;
        }
    }
}
