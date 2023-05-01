using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
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
        SeletorSignInOrUp selecterSignInOrUp;
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
            selecterSignInOrUp = new SeletorSignInOrUp(ui, cursor, totalStorage, 
                printerUserInformation, printerBookInformation, inputFromUser, 
                handlingException, userSingInOrUp, findBook, modificationUserInformation, logIn);
            enteringManagerMode = new EnteringManagerMode(ui, cursor, totalStorage, printerBookInformation, 
                printerUserInformation, inputFromUser, handlingException, userSingInOrUp, findBook,
                bookAccessInManager, memberAccessInManager, modificationUserInformation, logIn);
        }

        public void SelectModeOfUserOrManager()      // 유저 모드와 매니저 모드 둘 중 선택하게 해 주는 함수
        {
            Console.CursorVisible = false;

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
    }
}
