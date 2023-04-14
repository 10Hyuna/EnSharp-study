using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using Library.Model.VO;
using System.Diagnostics.Metrics;

namespace Library.Controller
{
    class UsingLibrary
    {
        TotalInformationStorage totalInformationStorage;
        UI ui;
        PrintingBookInformation bookInformation;
        PrintingUserInformation userInformation;
        MovingCurserPosition curser;
        EnteringManagerMode enteringManagerMode;
        EnteringMenuOfUser menuOfUser;
        EnteringMenuOfBook menuOfBook;
        SelectingSignInOrUp choiceBetweenSignInAndSignUp;
        InputFromUser inputFromUser;
        ConstantNumber constantNumber;
        HandlingException handlingException;
        RegexStorage regex;
        ProgressInSignInOrSignUp progressInSignInOrSignUp;

        public UsingLibrary()
        {
            totalInformationStorage = new TotalInformationStorage();
            constantNumber = new ConstantNumber();
            ui = new UI(constantNumber);
            bookInformation = new PrintingBookInformation();
            userInformation = new PrintingUserInformation(ui);
            regex = new RegexStorage();
            inputFromUser = new InputFromUser();
            handlingException = new HandlingException(ui, inputFromUser, constantNumber, regex);
            inputFromUser = new InputFromUser(regex, handlingException);
            curser = new MovingCurserPosition(ui, inputFromUser, constantNumber);
            progressInSignInOrSignUp = new ProgressInSignInOrSignUp(ui, totalInformationStorage, curser,
                inputFromUser, bookInformation, handlingException);
            menuOfUser = new EnteringMenuOfUser(totalInformationStorage, userInformation, inputFromUser, ui, handlingException, regex, curser);
            menuOfBook = new EnteringMenuOfBook(totalInformationStorage, bookInformation, inputFromUser, ui, handlingException, regex, curser);
            choiceBetweenSignInAndSignUp = new SelectingSignInOrUp(ui, curser, totalInformationStorage, 
                userInformation, bookInformation, inputFromUser, handlingException, regex,
                progressInSignInOrSignUp, menuOfUser);
            enteringManagerMode = new EnteringManagerMode(ui, curser, totalInformationStorage, bookInformation, 
                userInformation, inputFromUser, handlingException, regex, progressInSignInOrSignUp, menuOfBook, menuOfUser);
        }

        public void SelectModeOfUserOrManager()      // 메인 콘솔창
        {   
            SaveInformationPreviously();

            int WindowCenterWidth = 50;
            int WindowCenterHeight = 17;

            int selectedMenu = 0;

            bool isEnterESC = false;

            const int userMenuEnter = 0;        // 클래스로 모으기
            const int managerMenuEnter = 1;
            const int exit = -1;

            string[] menu = { "유저 모드", "매니저 모드" };
            while (!isEnterESC)
            {   
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);        // 키보드를 통해 선택한 메뉴의 값이 무엇인지 보고 

                if (selectedMenu == userMenuEnter)      // 유저 모드를 선택했다면
                {
                    choiceBetweenSignInAndSignUp.UsingUserMenu();       // 유저 모드로 진입
                }

                else if (selectedMenu == managerMenuEnter)      // 매니저 모드를 선택했다면
                {
                    enteringManagerMode.UsingManagerMenu(); // 매니저 모드로 진입
                }
                else if (selectedMenu == exit)      // ESC를 눌렀다면
                {
                    Console.Clear();
                    isEnterESC = true;
                }       // switch-case
            }
        }

        private void SaveInformationPreviously()
        {
            totalInformationStorage.manager.Add(new ManagerInformation("managerid12", "managerpw12"));
            totalInformationStorage.users.Add(new UserInformation("userid12", "userpw12", "김유저", "20", "010-0000-0000", "서울특별시 광진구 아차산로"));

            totalInformationStorage.books.Add(new BookInformation(1, "확률과 랜덤변수 및 랜덤과정", "송홍엽, 정하봉", "교보문고", "1", "32000", "2016-02-18", "979-11-5909-011-0", "수학"));
            totalInformationStorage.books.Add(new BookInformation(2, "논리회로 설계", "송상훈, 한동일", "생능출판", "2", "20000", "2015-12-23", "978-89-7050-860-3", "컴퓨터"));
            totalInformationStorage.books.Add(new BookInformation(3, "신경 끄기의 기술", "마크 맨슨", "갤리온", "1", "15000", "2020-05-10", "978-89-01-32994-3", "자기계발"));
            totalInformationStorage.books.Add(new BookInformation(4, "퇴사 준비생의 런던", "이동진", "백투더퓨처", "1", "15000", "2018-09-18", "979-11-960827-2-7-03320", "에세이"));
        }
    }
}
