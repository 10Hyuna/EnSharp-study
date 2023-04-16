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
    class ModeSelector
    {
        TotalStorage totalStorage;
        Book book;
        User user;
        UI ui;
        PrintingBookInformation bookInformation;
        PrintingUserInformation userInformation;
        MovingCurserPosition curser;
        EnteringManagerMode enteringManagerMode;
        EnteringMenuOfUser menuOfUser;
        EnteringMenuOfBook menuOfBook;
        SeleterSignInOrUp choiceBetweenSignInAndSignUp;
        InputFromUser inputFromUser;
        ConstantNumber constantNumber;
        HandlingException handlingException;
        RegexStorage regex;
        ProgressInSignInOrSignUp progressInSignInOrSignUp;

        public ModeSelector()
        {
            totalStorage = new TotalStorage();
            user = new User();
            book = new Book();
            ui = new UI();
            bookInformation = new PrintingBookInformation();
            userInformation = new PrintingUserInformation(ui);
            regex = new RegexStorage();
            inputFromUser = new InputFromUser();
            handlingException = new HandlingException(ui, inputFromUser, regex);
            inputFromUser = new InputFromUser(regex, handlingException);
            curser = new MovingCurserPosition(ui, inputFromUser);
            progressInSignInOrSignUp = new ProgressInSignInOrSignUp(ui, totalStorage, user, curser,
                inputFromUser, bookInformation, handlingException);
            menuOfUser = new EnteringMenuOfUser(totalStorage, userInformation, inputFromUser, ui, handlingException, regex, curser);
            menuOfBook = new EnteringMenuOfBook(totalStorage, bookInformation, inputFromUser, ui, handlingException, regex, curser);
            choiceBetweenSignInAndSignUp = new SeleterSignInOrUp(ui, curser, totalStorage, 
                userInformation, bookInformation, inputFromUser, handlingException, regex,
                progressInSignInOrSignUp, menuOfUser);
            enteringManagerMode = new EnteringManagerMode(ui, curser, totalStorage, bookInformation, 
                userInformation, inputFromUser, handlingException, regex, progressInSignInOrSignUp, menuOfBook, menuOfUser);
        }

        public void SelectModeOfUserOrManager()      // 메인 콘솔창
        {   
            SaveInformationPreviously();

            int WindowCenterWidth = 50;
            int WindowCenterHeight = 17;

            int selectedMenu = 0;

            bool isEnterESC = false;

            string[] menu = { "유저 모드", "매니저 모드" };
            while (!isEnterESC)
            {   
                Console.Clear();
                ui.PrintMain();
                ui.PrintBox(6);

                selectedMenu = curser.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);        // 키보드를 통해 선택한 메뉴의 값이 무엇인지 보고 

                switch(selectedMenu)
                {
                    case (int)(Mode.User):                      // 유저 모드를 선택했다면
                        choiceBetweenSignInAndSignUp.UsingUserMenu();       // 유저 모드로 진입
                        break;
                    case (int)(Mode.Manager):             // 매니저 모드를 선택했다면
                        enteringManagerMode.UsingManagerMenu(); // 매니저 모드로 진입
                        break;
                    case ConstantNumber.EXIT:                   // ESC를 눌렀다면
                        Console.Clear();
                        isEnterESC = true;
                        break;
                }
            }
        }

        private void SaveInformationPreviously()
        {
            totalStorage.manager.Add(new Manager("managerid12", "managerpw12"));
            totalStorage.users.Add(new User("userid12", "userpw12", "김유저", "20", "010-0000-0000", "서울특별시 광진구 아차산로"));

            totalStorage.books.Add(new Book(1, "확률과 랜덤변수 및 랜덤과정", "송홍엽, 정하봉", "교보문고", "1", "32000", "2016-02-18", "979-11-5909-011-0", "수학"));
            totalStorage.books.Add(new Book(2, "논리회로 설계", "송상훈, 한동일", "생능출판", "2", "20000", "2015-12-23", "978-89-7050-860-3", "컴퓨터"));
            totalStorage.books.Add(new Book(3, "신경 끄기의 기술", "마크 맨슨", "갤리온", "1", "15000", "2020-05-10", "978-89-01-32994-3", "자기계발"));
            totalStorage.books.Add(new Book(4, "퇴사 준비생의 런던", "이동진", "백투더퓨처", "1", "15000", "2018-09-18", "979-11-960827-2-7-03320", "에세이"));
        }
    }
}
