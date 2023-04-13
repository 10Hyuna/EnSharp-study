using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;
using Library.View;

namespace Library.Controller
{
    class SelectingSignInOrUp
    {
        UI ui;
        MovingCurserPosition curser;
        TotalInformationStorage totalInformationStorage;
        ProgressInSignInOrSignUp progressInSignInOrSignUp;
        SelectingMenuInUserMode userMode;
        PrintingBookInformation printbookInformation;
        PrintingUserInformation printuserInformation;
        InputFromUser inputFromUser;
        RegexStorage regex;
        HandlingException handlingException;
        EnteringMenuOfUser menuOfUser;

        public SelectingSignInOrUp(UI ui, MovingCurserPosition curser, TotalInformationStorage totalInformationStorage, 
            PrintingUserInformation userInformation, PrintingBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, ProgressInSignInOrSignUp progressInSignInOrSignUp,
            EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalInformationStorage = totalInformationStorage;
            this.printbookInformation = bookInformation;
            this.printuserInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
            this.progressInSignInOrSignUp = progressInSignInOrSignUp;
            this.menuOfUser = menuOfUser;
            userMode = new SelectingMenuInUserMode(ui, curser, totalInformationStorage, userInformation, 
                bookInformation, inputFromUser, handlingException, regex, menuOfUser);
        }

        public void UsingUserMenu()
        {       // 유저 모드에 진입했을 경우
            int selectedMenu = 0;
            int index;
            int noError;

            bool isEnterCheck = false;

            ConsoleKeyInfo keyInfo;

            const int signIn = 0;
            const int signUp = 1;
            const int exit = -1;
            const int enter = 10;

            string[] menu = { "로그인", "회원가입" };

            while (selectedMenu != ConstantNumber.EXIT)    // ESC를 누르지 않는 한 계속 반복
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu);        // 키보드를 통한 진입과 선택으로 최종 엔터키를 입력한 뒤
                                                                                                // 선택된 인덱스가 무엇인지 출력

                if (selectedMenu == signUp)             // 회원가입을 선택했을 경우
                {
                    Console.Clear();
                    ui.PrintSignUpUI();
                    noError = progressInSignInOrSignUp.SignUpMember();        // 회원가입 함수로 진입
                    
                    if(noError == exit)
                    {
                        continue;
                    }

                    while (!isEnterCheck)       // 엔터키를 입력하지 않는 동안 무한반복
                    {
                        Console.Clear();
                        ui.PrintMain();
                        ui.PrintSuccessSignup();

                        keyInfo = Console.ReadKey(true);

                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            isEnterCheck = true;
                        }
                    }
                }
                else if (selectedMenu == signIn)        // 로그인을 선택했을 경우
                {
                    Console.Clear();
                    ui.PrintLogin();
                    index = progressInSignInOrSignUp.SignInMember(false);      // 로그인 함수로 진입
                    if(index == exit)
                    {
                        continue;
                    }
                    userMode.SelectMenuInUserMode();
                }
            }
        }
    }
}
