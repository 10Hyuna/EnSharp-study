﻿using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.TotalAccess
{
    public class ModificationInformation
    {
        MainView mainView;
        PrintUserInformation printUserInformation;
        MenuIndexSelector menuIndexSelector;
        AccessorData accessorData;
        GuidancePhrase guidancePhrase;

        public ModificationInformation()
        {
            mainView = MainView.SetMainView();
            printUserInformation = PrintUserInformation.GetPrintUserInformation();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            accessorData = AccessorData.GetAccessorData();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
        }

        public void ModifyInformation(int entryType, string id)
        {
            Console.Clear();
            MainView.PrintBox(3);
            PrintUserInformation.PrintModifyMyInformationUI();

            switch (entryType)
            {
                case (int)MODE.USER:
                    SelectIndex(id);
                    break;
                case (int)MODE.MANAGER:
                    EnterManagerMode();
                    break;
            }
        }

        public void ModifyBookInformation()
        {
            int column = 30;
            int row = 3;

            string bookId;
            int bookNumber;

            bool isSuccessModify = true;

            List<BookDTO> books = new List<BookDTO>();

            while (isSuccessModify)
            {
                Console.Clear();
                Console.SetWindowSize(76, 40);
                PrintBookInformation.PrintModifyBookInformationUI();

                books = AccessorData.AllBookData();

                for(int i = 0; i < books.Count; i++)
                {
                    PrintBookInformation.PrintBookList(books[i]);
                }

                Console.SetCursorPosition(0, 0);

                bookId = SearchId((int)MODE.MANAGER);
                if(bookId == Constant.ESC_STRING)
                {
                    return;
                }
                else if (!ExceptionHandler.IsStringAllNumber(bookId))
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                bookNumber = int.Parse(bookId);

                isSuccessModify = IsValidNumber(bookNumber);
                if(!isSuccessModify)
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NULL_KEYWORD, column, row);
                    continue;
                }
                InputModifyInformation(bookNumber);
                isSuccessModify = false;
            }
        }

        private bool IsValidNumber(int number)
        {
            BookDTO book = new BookDTO();
            book = AccessorData.SelectPartlyBook(number);

            if (book.Title == null)
            {
                return false;
            }
            return true;
        }

        private void InputModifyInformation(int bookNumber)
        {
            string[] menu = {"책 제목 (영어, 한글, 숫자 1개 이상 ) :", "작가 (영어, 한글 1개 이상)           :",
                "출판사 (영어, 한글, 숫자 1개 이상)   :", "수량 ( 1 ~ 999 )                     :",
                "가격 ( 1 ~ 9999999 )                 :","출시일 ( 19xx or 20xx-xx-xx )        :", "책 정보 수정하기"};

            bool isNotESC = true;

            int column = 3;
            int row = 9;

            int validInput = 0;
            int selectedIndex = 0;
            string amount;
            string price;

            BookDTO book = new BookDTO();
            book.Id = bookNumber;

            Console.Clear();
            Console.SetWindowSize(76, 30);
            PrintBookInformation.PrintDeleteTheBook();

            while (isNotESC)
            {
                validInput = 0;

                selectedIndex = MenuIndexSelector.SelectMenuIndex(menu, selectedIndex, column, row);
                if(selectedIndex == Constant.EXIT_INT)
                {
                    return;
                }

                switch (selectedIndex)
                {
                    case (int)BOOKINFO.TITLE:
                        book.Title = ModifyInformation(0, Constant.TITLE, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(book.Title);
                        break;
                    case (int)BOOKINFO.AUTHOR:
                        book.Author = ModifyInformation(1, Constant.AUTHOR, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(book.Author);
                        break;
                    case (int)BOOKINFO.PUBLISHER:
                        book.Publisher= ModifyInformation(2, Constant.ONEVALUE, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(book.Publisher);
                        break;
                    case (int)BOOKINFO.AMOUNT:
                        amount = ModifyInformation(3, Constant.AMOUNT, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(amount);
                        book.Amount = CheckNumber(validInput, amount);
                        break;
                    case (int)BOOKINFO.PRICE:
                        price = ModifyInformation(4, Constant.PRICE, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(price);
                        book.Price = CheckNumber(validInput, price);
                        break;
                    case (int)BOOKINFO.PUBLISHDAY:
                        book.PublishDate = ModifyInformation(5, Constant.PUBLISHDATE, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(book.PublishDate);
                        break;
                    case (int)BOOKINFO.SUCCESS:
                        UpdateBookInformation(book);
                        isNotESC = false;
                        break;
                }
                if (!isNotESC)
                {
                    PrintUserInformation.PrintSuccessModify();
                }
                if (validInput == Constant.EXIT_INT)
                {
                    isNotESC = true;
                }
            }
        }

        private void UpdateBookInformation(BookDTO book)
        {
            if(book.Title != null)
            {
                AccessorData.UpdateBookStringData(book.Id, "title", book.Title);
            }
            if(book.Author != null)
            {
                AccessorData.UpdateBookStringData(book.Id, "author", book.Author);
            }
            if (book.Publisher != null)
            {
                AccessorData.UpdateBookStringData(book.Id, "publisher", book.Publisher);
            }
            if(book.Amount != 0)
            {
                AccessorData.UpdateBookIntData(book.Id, "amount", book.Amount);
            }
            if(book.Price != 0)
            {
                AccessorData.UpdateBookIntData(book.Id, "price", book.Price);
            }
            if (book.PublishDate != null)
            {
                AccessorData.UpdateBookStringData(book.Id, "publishdate", book.PublishDate);
            }
        }

        private void EnterManagerMode()
        {
            int column = 30;
            int row = 10;
            List<UserDTO> users= new List<UserDTO>();
            users = AccessorData.SelectAllUserData();

            PrintUserInformation.PrintModiFyUserIdUI();
            PrintUserInformation.PrintUserList(users);
            string id = SearchId((int)MODE.USER);
            if (id == null)
            {
                GuidancePhrase.PrintException((int)EXCEPTION.ID_FAIL, column, row);
            }
            else if(id == Constant.ESC_STRING)
            {
                return;
            }
            SelectIndex(id);
        }


        private void SelectIndex(string id)
        {
            UserDTO user = new UserDTO();
            string[] menu = {"User PW (8~ 15글자 영어, 숫자 포함)   :", "User Name (한글, 영어 포함 2글자 이상 :", "User Age( 자연수 0 ~ 200세 )          :",
                "User PhoneNumber ( 01x-xxxx-xxxx )    :","User Address ( 도로명 주소 형식 )     :", "회원 정보 수정하기"};

            int validInput;
            int selectedMenu = 0;
            int column = 2;
            int row = 9;

            string age = "";

            bool isNotESC = true;
            List<UserDTO> users = new List<UserDTO>();
            users.Add(AccessorData.SelectUserData(id));

            while (isNotESC)
            {
                Console.SetWindowSize(76, 30);
                validInput = 0;
                Console.SetCursorPosition(2, 15);
                PrintUserInformation.PrintUserList(users);
                selectedMenu = MenuIndexSelector.SelectMenuIndex(menu, selectedMenu, column, row);

                if (selectedMenu == Constant.EXIT_INT)
                {
                    return;
                }

                switch (selectedMenu)
                {
                    case (int)MODIFY.PASSWORD:
                        user.Password = ModifyInformation(0, Constant.PASSWORD, Constant.IS_PASSWORD);
                        validInput = EnterEsc(user.Password);
                        break;
                    case (int)MODIFY.NAME:
                        user.Name = ModifyInformation(1, Constant.NAME, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(user.Name);
                        break;
                    case (int)MODIFY.AGE:
                        age = ModifyInformation(2, Constant.AGE, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(age);
                        user.Age = CheckNumber(validInput, age);
                        break;
                    case (int)MODIFY.PHONENUMBER:
                        user.PhoneNumber = ModifyInformation(3, Constant.PHONENUMBER, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(user.PhoneNumber);
                        break;
                    case (int)MODIFY.ADDRESS:
                        user.Address = ModifyInformation(4, Constant.ADDRESS, Constant.IS_NOT_PASSWORD);
                        validInput = EnterEsc(user.Address);
                        break;
                    case (int)MODIFY.SUCCESS:
                        UpdateInformation(user, id);
                        isNotESC = false;
                        break;
                }
                if (!isNotESC)
                {
                    PrintUserInformation.PrintSuccessModify();
                }
                if(validInput == Constant.EXIT_INT)
                {
                    isNotESC = true;
                }
            }
        }

        private string SearchId(int entryType)
        {
            int column = 45;
            int row = 3;
            string regexForm;

            if(entryType == (int)MODE.MANAGER)
            {
                regexForm = Constant.NUMBER;
            }
            else
            {
                regexForm = Constant.ID;
            }
            string id = ExceptionHandler.IsValidInput(regexForm, column, row, 15, Constant.IS_NOT_PASSWORD);

            return id;
        }

        private string ModifyInformation(int consoleRow, string regex, bool isPassword)     // 입력된 정보의 유효성 검사
        {
            int Column = 42;
            int row = 9 + consoleRow;

            string input = "";

            input = ExceptionHandler.IsValidInput(regex, Column, row, 20, isPassword);
            if (input == Constant.ESC_STRING)
            {
                input = null;
            }
            return input;
        }

        public int EnterEsc(string input)
        {
            if (input == null)      // esc가 입력되었다면
            {
                return Constant.EXIT_INT;     // esc 입력을 표시하는 값 반환
            }
            else if (!ExceptionHandler.IsStringAllNumber(input))
            {
                return Constant.IS_NOT_NUMBER;
            }
            return Constant.SUCCESS;
        }

        private void UpdateInformation(UserDTO user, string id)
        {
            if (user.Password != null)
            {
                AccessorData.UpdateStringUserData(id, "password", user.Password);
            }
            if (user.Name != null)
            {
                AccessorData.UpdateStringUserData(id, "name", user.Name);
            }
            if (user.Age != 0)
            {
                AccessorData.UpdateIntUserData(id, "age", user.Age);
            }
            if (user.PhoneNumber != null)
            {
                AccessorData.UpdateStringUserData(id, "phonenumber", user.PhoneNumber);
            }
            if (user.Address != null)
            {
                AccessorData.UpdateStringUserData(id, "address", user.Address);
            }
        }

        private int CheckNumber(int validInput, string input)
        {
            if(validInput != Constant.IS_NOT_NUMBER)
                return int.Parse(input);
            return 0;
        }
    }
}
