using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableModel.VO;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using LectureTimeTable.LectureTimeTableController.MainMenu;

namespace LectureTimeTable.LectureTimeTableController
{
    class Login
    {
        Design design;
        InputFromUser inputFromUser;
        SelecterMenu selecterMenu;
        MenuAndOption menuAndOption;
        ExceptionHandler exceptionHandler;
        GuidancePhrase guidancePhrase;
        USER user;
        MenuSelection menuSelection;
        CourseHistory courseHistory;

        public Login()
        {
            design = new Design();
            inputFromUser = new InputFromUser();
            menuAndOption = new MenuAndOption();
            selecterMenu = new SelecterMenu(menuAndOption ,inputFromUser);
            guidancePhrase = new GuidancePhrase();
            exceptionHandler = new ExceptionHandler(inputFromUser, guidancePhrase);
            menuSelection = new MenuSelection(menuAndOption, exceptionHandler, 
                design, selecterMenu);
            user = new USER();
        }

        int consoleColumn;
        int consoleRow;

        int inputId = 0;
        int inputPassword = 0;
        int menuIndex = 0;

        bool isValid;
        bool isUp = false;
        bool isDown = false;

        string id = "";
        string password = "";

        public void EnterLogin()
        {
            consoleColumn = 70;
            consoleRow = 30;
            bool isESC = false;

            Console.SetWindowSize(120, 35);

            string[] loginMenu = { "학번 (8자 이상) : ", "비밀번호 : " };

            Console.Clear();
            design.PrintMain();

            while (!isESC)
            {
                consoleColumn = 70;
                consoleRow = 30;

                if (id == ConstantNumber.ESC || password == ConstantNumber.ESC)  // 중간에 ESC를 
                {
                    isESC = true;
                }
                if (user.Id == id && user.Password == password)
                {
                    id = "";
                    password = "";

                    inputId = 0;
                    inputPassword = 0;

                    menuSelection.SelectMenu();

                    Console.Clear();
                    design.PrintMain();
                }
                else if (inputId + inputPassword == 2)
                {
                    Console.SetCursorPosition(87, 30);
                    guidancePhrase.ErasePrint();

                    Console.SetCursorPosition(81, 31);
                    guidancePhrase.ErasePrint();

                    inputId = 0;
                    inputPassword = 0;

                    guidancePhrase.PrintException(ConstantNumber.FAILURE_LOGIN, consoleColumn, consoleRow + 3);

                    menuIndex = 0;
                }
                else if(inputId == 1 && inputPassword != 1 && (!isUp && !isDown))
                {
                    menuIndex++;
                }
                else if (inputPassword == 1 && inputId != 1 && (!isUp && !isDown))
                {
                    menuIndex--;
                }

                selecterMenu.SetColorMenu(loginMenu, menuIndex, consoleColumn, consoleRow);

                isUp = false;
                isDown = false;

                switch (menuIndex)
                {
                    case (int)LOGIN.CREDIT: // 선택한 인덱스가 학번 부분이라면
                        EnterCreditNumber();
                        break;
                    case (int)LOGIN.PASSWORD:   // 선택한 인덱스가 비밀번호라면
                        EnterPassword();
                        break;
                }
            }
        }

        private void EnterCreditNumber()
        {
            consoleColumn = 75;
            consoleRow = 30;

            isValid = false;

            id = exceptionHandler.IsValid(ConstantNumber.idCheck, consoleColumn, consoleRow, 8, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_ID);
            
            if (id == ConstantNumber.UP)
            {
                InputUp();
            }
            else if(id == ConstantNumber.DOWN)
            {
                InputUp();
            }
            else if (id != ConstantNumber.ESC && id != "")
            {
                inputId = 1;
            }
        }

        private void EnterPassword()
        {
            consoleColumn = 68;
            consoleRow = 31;

            password = exceptionHandler.IsValid(ConstantNumber.passwordCheck, consoleColumn, consoleRow, 20, ConstantNumber.IS_PASSWORD, ConstantNumber.IS_NOT_ID);
            
            if (password == ConstantNumber.UP)
            {
                InputUp();
            }
            else if (password == ConstantNumber.DOWN)
            {
                InputDown();
            }
            else if (password != "ESC" && password != "")
            {
                inputPassword = 1;
            }
        }

        private void InputUp()
        {
            isUp = true;

            menuIndex--;
            if (menuIndex < 0)
            {
                menuIndex = 1;
            }
        }

        private void InputDown()
        {
            isDown = true;

            menuIndex++;
            if (menuIndex > 1)
            {
                menuIndex = 0;
            }
        }
    }
}
