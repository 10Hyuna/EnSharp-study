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
        MovingCursorPosition cursror;
        TotalStorage totalStorage;
        UserSignUp userSignInOrUp;
        SelectingMenuInUserMode userMode;
        PrinterBookInformation printbookInformation;
        PrinterUserInformation printuserInformation;
        InputFromUser inputFromUser;
        HandlingException handlingException;
        FindBook findBook;
        ModificationUserInformation modificationUserInformation;
        LogIn logIn;
        public SeleterSignInOrUp(UI ui, MovingCursorPosition cursor, TotalStorage totalStorage,
            PrinterUserInformation userInformation, PrinterBookInformation bookInformation, 
            InputFromUser inputFromUser, HandlingException handlingException,
            UserSignUp userSignInOrUp, FindBook findBook, ModificationUserInformation modificationUserInformation,
            LogIn logIn)
        {
            this.ui = ui;
            this.cursror = cursor;
            this.totalStorage = totalStorage;
            this.printbookInformation = bookInformation;
            this.printuserInformation = userInformation;
            this.inputFromUser = inputFromUser;
            this.handlingException = handlingException;
            this.userSignInOrUp = userSignInOrUp;
            this.findBook = findBook;
            this.modificationUserInformation = modificationUserInformation;
            this.logIn = logIn;
            userMode = new SelectingMenuInUserMode(ui, cursor, totalStorage, userInformation,
                bookInformation, inputFromUser, handlingException, findBook, modificationUserInformation);
        }

        public void SeleteSignInUp()
        {       // 유저 모드에 진입했을 경우

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

                selectedMenu = cursror.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);
                // 키보드를 통한 진입과 선택으로 최종 엔터키를 입력한 뒤
                // 선택된 인덱스가 무엇인지 출력

                if (selectedMenu == (int)(Sign.SIGNIN))   // 로그인을 선택했을 경우
                {
                    isEnteredESC = EnteringSignUp(modeIndex);
                    
                    if (!isEnteredESC)
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
            List<string> account;
            bool isSuccessLogin = false;

            while (!isSuccessLogin)
            {
                Console.Clear();
                ui.PrintLogin();

                account = logIn.SignInMember();      // 로그인 함수로 진입
                if (account == null)      // 로그인 함수 속에서 ESC를 입력받았을 경우
                {
                    return false;
                }

                isSuccessLogin = logIn.SerchValidAccount(account);      // 유효한 계정이라면 true가 리턴되어 반복문 탈출
            }

            userMode.SelectMenuInUserMode();        // 유저 모드로 진입

            return true;
        }

        private bool EnteringSignIn(int modeIndex)
        {
            bool isEnterCheck = false;

            ConsoleKeyInfo keyInfo;

            Console.Clear();
            ui.PrintSignUpUI();
            modeIndex = userSignInOrUp.SignUpMember();        // 회원가입 함수로 진입

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
