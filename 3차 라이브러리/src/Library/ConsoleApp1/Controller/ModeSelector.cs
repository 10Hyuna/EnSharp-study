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
using Library.Controller.BookAccessor;
using Library.Controller.MemberAccessor;

namespace Library.Controller
{
    class ModeSelector
    {
        TotalStorage totalStorage;
        UI ui;
        PrinterBookInformation printerBookInformation;
        PrinterUserInformation printerUserInformation;
        MovingCursorPosition cursor;
        EnteringManagerMode enteringManagerMode;
        SeleterSignInOrUp selecterSignInOrUp;
        InputFromUser inputFromUser;
        ConstantNumber constantNumber;
        HandlingException handlingException;
        UserSignUp userSingInOrUp;
        FindBook findBook;
        BookAccessInUser bookAccessInUser;
        BookAccessInManager bookAccessInManager;
        MemberAccessInManager memberAccessInManager;
        MemberAccessInUser memberAccessInUser;
        ModificationUserInformation modificationUserInformation;
        LogIn logIn;
        public ModeSelector()
        {
            totalStorage = new TotalStorage();
            ui = new UI();
            printerBookInformation = new PrinterBookInformation();
            printerUserInformation = new PrinterUserInformation(ui, totalStorage);
            inputFromUser = new InputFromUser();
            cursor = new MovingCursorPosition(ui, inputFromUser);
            handlingException = new HandlingException(ui, inputFromUser);
            modificationUserInformation = new ModificationUserInformation(totalStorage, printerUserInformation,
                handlingException, ui, cursor, inputFromUser);
            inputFromUser = new InputFromUser(handlingException);
            userSingInOrUp = new UserSignUp(ui, totalStorage, cursor,
                inputFromUser, printerBookInformation, handlingException);
            findBook = new FindBook(totalStorage, handlingException, printerBookInformation);
            logIn = new LogIn(totalStorage, inputFromUser, ui);
            bookAccessInManager = new BookAccessInManager(totalStorage, printerBookInformation, ui, handlingException, cursor);
            memberAccessInManager = new MemberAccessInManager(printerUserInformation, totalStorage, handlingException, ui);
            selecterSignInOrUp = new SeleterSignInOrUp(ui, cursor, totalStorage, 
                printerUserInformation, printerBookInformation, inputFromUser, 
                handlingException, userSingInOrUp, findBook, modificationUserInformation, logIn);
            enteringManagerMode = new EnteringManagerMode(ui, cursor, totalStorage, printerBookInformation, 
                printerUserInformation, inputFromUser, handlingException, userSingInOrUp, findBook,
                bookAccessInManager, memberAccessInManager, modificationUserInformation, logIn);
        }

        public void SelectModeOfUserOrManager()      // 유저 모드와 매니저 모드 둘 중 선택하게 해 주는 함수
        {
            Console.CursorVisible = false;
            SaveInformationPreviously();        // 미리 저장되어야 할 정보들 입력

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

                selectedMenu = cursor.SelectCurser(menu, menu.Length, selectedMenu, WindowCenterWidth, WindowCenterHeight);        // 키보드를 통해 선택한 메뉴의 값이 무엇인지 보고 
                
                switch(selectedMenu)
                {
                    case (int)(Mode.USER):                      // 유저 모드를 선택했다면
                        selecterSignInOrUp.SeleteSignInUp();       // 유저 모드로 진입
                        break;
                    case (int)(Mode.MANAGER):             // 매니저 모드를 선택했다면
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
