using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableModel.VO;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using LectureTimeTable.LectureTimeTableController.MainMenu;
using LectureTimeTable.LectureTimeTableModel;

namespace LectureTimeTable.LectureTimeTableController
{
    class Login
    {
        private ExcelLoader excelLoader;
        private MainView design;
        private InputFromUser inputFromUser;
        private LectureTimeTableUtility.MenuIndexSelecter selecterMenu;
        private MenuAndOption menuAndOption;
        private ExceptionHandler exceptionHandler;
        private GuidancePhrase guidancePhrase;
        private MenuSelector menuSelection;
        private CourseHistory courseHistory;
        private TotalStorage totalStorage;
        private ManupulationTimeData manupulationTimeData;
        private int consoleColumn;
        private int consoleRow;
        private int inputId = 0;
        private int inputPassword = 0;
        private int menuIndex = 0;
        private bool isValid;
        private bool isUp = false;
        private bool isDown = false;
        private string id = "";
        private string password = "";
        public Login(TotalStorage totalStorage)
        {
            this.totalStorage = totalStorage;
            design = new MainView();
            inputFromUser = new InputFromUser();
            menuAndOption = new MenuAndOption();
            guidancePhrase = new GuidancePhrase();
            exceptionHandler = new ExceptionHandler(inputFromUser, guidancePhrase);
            excelLoader = new ExcelLoader(exceptionHandler, totalStorage);
            selecterMenu = new LectureTimeTableUtility.MenuIndexSelecter(menuAndOption, inputFromUser);
            menuSelection = new MenuSelector(menuAndOption, exceptionHandler, 
                design, selecterMenu, guidancePhrase, totalStorage);
            manupulationTimeData = new ManupulationTimeData(totalStorage);
        }


        public void EnterLogin()
        {
            consoleColumn = 80;
            consoleRow = 30;
            bool isESC = false;

            Console.SetWindowSize(120, 35);

            excelLoader.LoadExcelFile();
            for(int i = 0; i < totalStorage.lecture.Count; i++)
            {
                manupulationTimeData.manuplateTime(totalStorage.lecture[i].DateAndTime, i);
            }

            string[] loginMenu = { "학번 (8자 이상) : ", "비밀번호 : " };

            Console.Clear();
            design.PrintMain();

            while (!isESC)
            {
                consoleColumn = 70;
                consoleRow = 30;

                if (id == ConstantNumber.ESC || password == ConstantNumber.ESC)
                {   // 중간에 ESC를 눌렀을 경우
                    isESC = true;
                }
                if (totalStorage.user.Id == id && totalStorage.user.Password == password)
                {   // 아이디 비밀번호 모두 일치
                    id = "";
                    password = "";

                    inputId = 0;
                    inputPassword = 0;

                    menuSelection.SelectMenu();

                    Console.Clear();
                    design.PrintMain();
                }
                else if (inputId + inputPassword == 2)
                {   // 값은 모두 입력되었지만 일치하는 값이 저장되어 있지 않음
                    id = "";
                    password = "";

                    Console.SetCursorPosition(95, 30);
                    guidancePhrase.ErasePrint();

                    Console.SetCursorPosition(94, 31);
                    guidancePhrase.ErasePrint();

                    inputId = 0;
                    inputPassword = 0;

                    guidancePhrase.PrintException((int)EXCEPTION.FAILURE_LOGIN, consoleColumn, consoleRow + 3);

                    menuIndex = 0;
                }
                else if(inputId == 1 && inputPassword != 1 && (!isUp && !isDown))
                {   // 아이디만 입력
                    menuIndex++;
                    Console.SetCursorPosition(88, 30);
                    menuAndOption.PrintMenu(id, 8);
                }
                else if (inputPassword == 1 && inputId != 1 && (!isUp && !isDown))
                {   // 비밀번호만 입력
                    menuIndex--;
                    Console.SetCursorPosition(76, 31);
                    menuAndOption.PrintMenu(password, 8);
                }
                selecterMenu.SetColorMenu(loginMenu, menuIndex, consoleColumn, consoleRow, 13);

                isUp = false;
                isDown = false;

                switch (menuIndex)
                {
                    case (int)LOGIN.CREDIT: // 선택한 인덱스가 학번 부분이라면
                        EnterId();
                        break;
                    case (int)LOGIN.PASSWORD:   // 선택한 인덱스가 비밀번호라면
                        EnterPassword();
                        break;
                }
            }
        }

        private void EnterId()
        {
            consoleColumn = 75;
            consoleRow = 30;

            isValid = false;

            id = exceptionHandler.IsValidInput(ConstantNumber.IDCHECK, consoleColumn, consoleRow, 8, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_ID);
            
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

            password = exceptionHandler.IsValidInput(ConstantNumber.PASSWORDCHECK, consoleColumn, consoleRow, 20, ConstantNumber.IS_PASSWORD, ConstantNumber.IS_NOT_ID);
            
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
