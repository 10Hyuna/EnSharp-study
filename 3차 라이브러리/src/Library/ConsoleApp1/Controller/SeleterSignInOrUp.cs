using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Utility;
using Library.View;

namespace Library.Controller
{
    class SeleterSignInOrUp
    {
        UI ui;
        MovingCursorPosition curser;
        TotalStorage totalStorage;
        UserSignInOrUp progressInSignInOrSignUp;
        SelectingMenuInUserMode userMode;
        PrinterBookInformation printbookInformation;
        PrinterUserInformation printuserInformation;
        InputFromUser inputFromUser;
        RegexStorage regex;
        HandlingException handlingException;
        EnteringMenuOfUser menuOfUser;

        public SeleterSignInOrUp(UI ui, MovingCursorPosition curser, TotalStorage totalStorage,
            PrinterUserInformation userInformation, PrinterBookInformation bookInformation, InputFromUser inputFromUser,
            HandlingException handlingException, RegexStorage regex, UserSignInOrUp progressInSignInOrSignUp,
            EnteringMenuOfUser menuOfUser)
        {
            this.ui = ui;
            this.curser = curser;
            this.totalStorage = totalStorage;
            this.printbookInformation = bookInformation;
            this.printuserInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.regex = regex;
            this.progressInSignInOrSignUp = progressInSignInOrSignUp;
            this.menuOfUser = menuOfUser;
            userMode = new SelectingMenuInUserMode(ui, curser, totalStorage, userInformation,
                bookInformation, inputFromUser, handlingException, regex, menuOfUser);
        }
        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e) //ctrl + z 등 단축키를 통해
        {
            e.Cancel = true;
        }

        public void SeleteSignInUp()
        {       // 유저 모드에 진입했을 경우
            Console.CancelKeyPress += new ConsoleCancelEventHandler(Console_CancelKeyPress);

            int WindowCenterWidth = 50;
            int WindowCenterHeight = 17;

            int selectedMenu = 0;
            int modeIndex = 0;

            bool isEnteredESC = false;
            string[] menu = { "로그인", "회원가입" };

            while (selectedMenu != ConstantNumber.EXIT)    // ESC를 누르지 않는 한 계속 반복
            {
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);
                // 키보드를 통한 진입과 선택으로 최종 엔터키를 입력한 뒤
                // 선택된 인덱스가 무엇인지 출력

                if (selectedMenu == (int)(Sign.SIGNIN))   // 로그인을 선택했을 경우
                {
                    isEnteredESC = EnteringSignUp(modeIndex);
                    
                    if (isEnteredESC == false)
                    {
                        continue;
                    }    
                    userMode.SelectMenuInUserMode();
                }
                
                else if(selectedMenu == (int)(Sign.SIGNUP))
                {
                    isEnteredESC = EnteringSignIn(modeIndex);

                    if (isEnteredESC == false)
                    {
                        continue;
                    }
                }
            }
        }

        private bool EnteringSignUp(int modeIndex)
        {
            Console.Clear();
            ui.PrintLogin();
            modeIndex = progressInSignInOrSignUp.SignInMember();      // 로그인 함수로 진입

            if (modeIndex == ConstantNumber.EXIT)      // 로그인 함수 속에서 ESC를 입력받았을 경우
            {
                return false;
            }
            userMode.SelectMenuInUserMode();

            return true;
        }

        private bool EnteringSignIn(int modeIndex)
        {
            bool isEnterCheck = false;

            ConsoleKeyInfo keyInfo;

            Console.Clear();
            ui.PrintSignUpUI();
            modeIndex = progressInSignInOrSignUp.SignUpMember();        // 회원가입 함수로 진입

            if (modeIndex == ConstantNumber.EXIT)
            {
                return false;
            }

            Console.Clear();
            ui.PrintMain();
            ui.PrintSuccessSignup();

            while (!isEnterCheck)       // 엔터키를 입력하지 않는 동안 무한반복
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isEnterCheck = true;
                }
            }
            return true;
        }
    }
}
