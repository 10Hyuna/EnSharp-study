using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Library.Controller.MemberAccessor
{
    class MemberAccessInUser
    {
        UI ui;
        MovingCursorPosition cursor;
        TotalStorage totalStorage;
        PrinterUserInformation userinformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        PrinterUserInformation printerUserInformation;

        public MemberAccessInUser(UI ui, MovingCursorPosition cursor, TotalStorage totalStorage,
               PrinterUserInformation userInformation, InputFromUser inputFromUser,
               HandlingException handlingException)
        {
            this.ui = ui;
            this.cursor = cursor;
            this.totalStorage = totalStorage;
            printerUserInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
        }

        bool isInputESC;
        ConsoleKeyInfo keyInfo;

        int consoleInputRow;
        int consoleInputColumn;


        public int DeleteMyAccount()        // 회원 탈퇴하는 함수
        {

            ConsoleKeyInfo keyInfo;

            bool isSuccessDelete = true;
            bool isInputEnter = false;
            int index = 0;
            int breakNumber = -1;

            for (int i = 0; i < totalStorage.users.Count; i++)
            {
                if (totalStorage.users[i].GetId() == totalStorage.loggedInUserId)       // 로그인 중인 아이디가 어느 인덱스에 존재하는지 확인
                {
                    index = i;
                    break;
                }
            }

            while (!isInputEnter)
            {
                Console.Clear();
                printerUserInformation.PrintDeleteAccountUI();

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (totalStorage.users[index].BorrowDatas.Count == 0)       // 대여 중인 책이 없다면
                    {
                        totalStorage.users.RemoveAt(index);     // 유저 정보 삭제
                        isInputEnter = true;
                        Console.Clear();
                        printerUserInformation.PrintSuccessDeleteAccount();
                    }
                    else
                    {
                        printerUserInformation.PrintNotWorkedDeleteAccout();        // 대여 중인 책이 있어 탈퇴 불가
                        isSuccessDelete = false;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Escape)      // esc를 누른다면
                {
                    breakNumber = 0;
                    break;
                }
                else            // 조건에 맞지 않는 값을 입력한다면
                {
                    ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, 40, 24);
                    continue;
                }

                if (!isSuccessDelete)       // 회원탈퇴가 되지 않았다면 다시 입력 기회 부여
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isInputEnter = true;
                        continue;
                    }
                    else
                    {
                        ui.PrintException(ConstantNumber.NOT_MATCHED_CONDITION, 40, 18);
                    }
                }
            }
            return breakNumber;
        }
    }
}
