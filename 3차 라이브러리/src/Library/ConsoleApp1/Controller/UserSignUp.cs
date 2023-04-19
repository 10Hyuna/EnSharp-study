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
    class UserSignUp
    {
        UI ui;
        TotalStorage totalStorage;
        MovingCursorPosition cursor;
        HandlingException handlingException;
        InputFromUser inputFromUser;
        PrinterBookInformation printBookInformation;

        public UserSignUp() { }

        public UserSignUp(UI ui, TotalStorage totalStorage, MovingCursorPosition cursor,
            InputFromUser inputFromUser, PrinterBookInformation printBookInformation, HandlingException handlingException)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
            this.cursor = cursor;
            this.inputFromUser = inputFromUser;
            this.printBookInformation = printBookInformation;
            this.handlingException = handlingException;
        }
        public int SignUpMember()      // 회원가입
        {
            int ConsoleInputRow = 70;
            int ConsoleInputColumn = 23;

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

            while (!isOverlapData)      // 아이디 중복 체크
            {
                Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);

                id = handlingException.IsValid(ConstantNumber.idCheck, ConsoleInputRow, ConsoleInputColumn, 15, false);
                if (id == null)     // 중간에 esc 입력되었다면
                    return -1;
                for (int i = 0; i < totalStorage.users.Count; i++)      // 회원 정보 훑어 보며
                {
                    if (totalStorage.users[i].GetId() == id)            // 입력한 아이디와 일치한다면
                    {
                        isOverlapData = true;                           // 중복 데이터 체크
                        break;
                    }
                }
                if (isOverlapData)          // 중복 데이터라면
                {
                    isOverlapData = false;  // 반복문에서 탈출하면 안 되기 때문에 다시 false 입력
                    ui.PrintException(ConstantNumber.OVERLAP_DATA, ConsoleInputRow, ConsoleInputColumn);        // 중복 아이디 안내 문구
                }
                else
                {
                    isOverlapData = true;
                }
            }

            password = handlingException.IsValid(ConstantNumber.passwordCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, true);      // 비밀번호 입력
            if (password == null)
                return ConstantNumber.EXIT;

            while (!isSamePW)       // 비밀번호를 확인하는 문자열을 입력받았을 때 그 문자열이 비밀번호와 같지 않다면 계속 반복
            {
                checkPassword = handlingException.IsValid(ConstantNumber.passwordCheck, ConsoleInputRow - 15, ConsoleInputColumn + 2, 15, true);
                if (checkPassword == null)
                    return ConstantNumber.EXIT;

                if (password == checkPassword)      // 비밀번호와 같다면
                {
                    isSamePW = true;
                }
                else
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_PASSWORD, ConsoleInputRow, ConsoleInputColumn + 1);
                    password = handlingException.IsValid(ConstantNumber.idCheck, ConsoleInputRow, ConsoleInputColumn + 1, 15, true);       // 비밀번호를 잘못 입력했을 경우를 대비
                    
                    if (password == null)
                        return ConstantNumber.EXIT;
                }
            }

            isValidInput = false;
            name = handlingException.IsValid(ConstantNumber.nameCheck, ConsoleInputRow + 5, ConsoleInputColumn + 3, 20, false);
            if (name == null)
                return ConstantNumber.EXIT;

            age = handlingException.IsValid(ConstantNumber.ageCheck, ConsoleInputRow - 4, ConsoleInputColumn + 4, 20, false);
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
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, ConsoleInputRow - 4, ConsoleInputColumn + 4) ;
                    age = handlingException.IsValid(ConstantNumber.ageCheck, ConsoleInputRow - 4, ConsoleInputColumn + 4, 20, false);
                }
            }
            isValidInput = false;

            phoneNumber = handlingException.IsValid(ConstantNumber.phoneNumberCheck, ConsoleInputRow + 3, ConsoleInputColumn + 5, 20, false);
            if (phoneNumber == null)
                return ConstantNumber.EXIT;

            address = handlingException.IsValid(ConstantNumber.addressCheck, ConsoleInputRow + 5, ConsoleInputColumn + 6, 20, false);
            if (address == null)
                return ConstantNumber.EXIT;

            totalStorage.users.Add(new User(id, password, name, age, phoneNumber, address));    // 위의 조건을 모두 통과한 값일 경우 정보 저장

            return ConstantNumber.SUCCESS;
        }
    }
}
