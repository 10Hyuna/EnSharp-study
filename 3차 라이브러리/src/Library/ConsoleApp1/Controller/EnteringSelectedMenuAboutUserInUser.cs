﻿using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Controller
{
    class EnteringSelectedMenuAboutUserInUser
    {
        TotalInformationStorage totalInformationStorage;
        PrintingUserInformation userInformation;
        InputFromUser inputFromUser;
        UI ui;
        ConstantNumber constantNumber;
        HandlingException handlingException;
        RegexStorage regex;
        MovingCurserPosition curser;
        public EnteringSelectedMenuAboutUserInUser(TotalInformationStorage totalInformationStorage,
            PrintingUserInformation printingUserInformation, InputFromUser inputFromUser, UI ui,
            ConstantNumber constantNumber, HandlingException handlingException, RegexStorage regex,
            MovingCurserPosition curser)
        {
            this.totalInformationStorage = totalInformationStorage;
            this.userInformation = printingUserInformation;
            this.inputFromUser = inputFromUser;
            this.ui = ui;
            this.constantNumber = constantNumber;
            this.handlingException = handlingException;
            this.regex = regex;
            this.curser = curser;
        }

        public void ModifyMyInformation()
        {
            int index = 0;
            int selectedMenu = 0;

            bool isInputEnter = false;

            string[] menu = {"User ID (8~ 15글자 영어, 숫자 포함) :", "User PW (8~ 15글자 영어, 숫자 포함) :",
                "User Name (한글, 영어 포함 2글자 이상 :", "User Age( 자연수 0 ~ 200세 ) :", 
                "User PhoneNumber ( 01x-xxxx-xxxx ) :","User Address ( 도로명 주소 형식 ) :", "회원 정보 수정하기"};
            string id;
            string password;
            string name;
            string age;
            string phoneNumber;
            string address; 

            for(int i=0;i<totalInformationStorage.users.Count;i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    index = i;
                    break;
                }
            }

            while(!isInputEnter)
            {
                Console.Clear();
                ui.PrintBox(4);
                userInformation.PrintModifyMyInformationUI();
                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu);

                
            }
        }

        public int DeleteMyAccount()
        {
            ConsoleKeyInfo keyInfo;

            bool isSuccessDelete = true;
            bool isInputEnter = false;
            int index = 0;
            int breakNumber = -1;

            for (int i = 0; i < totalInformationStorage.users.Count; i++)
            {
                if (totalInformationStorage.users[i].id == totalInformationStorage.loggedInUserId)
                {
                    index = i;
                    break;
                }
            }

            while(!isInputEnter)
            {
                Console.Clear();
                userInformation.PrintDeleteAccountUI();

                keyInfo = Console.ReadKey(true);

                if(keyInfo.Key == ConsoleKey.Enter)
                {
                    if(totalInformationStorage.users[index].borrowDatas.Count == 0)
                    {
                        ProgressDeletingAccount(index);
                        isInputEnter = true;
                        Console.Clear();
                        userInformation.PrintSuccessDeleteAccount();
                    }
                    else
                    {
                        userInformation.PrintNotWorkedDeleteAccout(); 
                        isSuccessDelete = false;
                    }
                }
                else if(keyInfo.Key == ConsoleKey.Escape)
                {
                    breakNumber = 0;
                    break;
                }
                else
                {
                    ui.PrintException(ConstantNumber.notMatchedCondition);
                    continue;
                }

                if(!isSuccessDelete)
                {   
                    keyInfo = Console.ReadKey(true);
                    if(keyInfo.Key == ConsoleKey.Escape)
                    {
                        isInputEnter = true;
                        continue;
                    }
                    else
                    {
                        Console.SetCursorPosition(40, 18);
                        ui.PrintException(ConstantNumber.notMatchedCondition);
                    }
                }
            }
            return breakNumber;
        }

        private void ProgressDeletingAccount(int index)
        {
            totalInformationStorage.users.RemoveAt(index);
        }
    }
}
