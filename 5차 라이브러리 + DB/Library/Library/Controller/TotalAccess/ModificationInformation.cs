using Library.Model.DAO;
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

        }

        private void EnterManagerMode()
        {
            int column = 30;
            int row = 10;
            List<UserDTO> users= new List<UserDTO>();
            users=AccessorData.SelectAllUserData();

            PrintUserInformation.PrintModiFyUserIdUI();
            PrintUserInformation.PrintUserList(users);
            string id = SearchId();
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
                        CheckNumber(user, age);
                        validInput = EnterEsc(age);
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

        private string SearchId()
        {
            int column = 40;
            int row = 3;
            string id = ExceptionHandler.IsValidInput(Constant.ID, column, row, 15, Constant.IS_NOT_PASSWORD);

            return id;
        }

        private string ModifyInformation(int column, string regex, bool isPassword)     // 입력된 정보의 유효성 검사
        {
            int consoleInputRow = 42;
            int consoleInputColumn = 9 + column;

            string input = "";

            input = ExceptionHandler.IsValidInput(regex, consoleInputRow, consoleInputColumn, 20, isPassword);

            return input;
        }

        public int EnterEsc(string input)
        {
            if (input == null)      // esc가 입력되었다면
            {
                return Constant.EXIT_INT;     // esc 입력을 표시하는 값 반환
            }
            return Constant.SUCCESS;
        }

        private void UpdateInformation(UserDTO user, string userId)
        {
            UpdatePassword(user, userId);
            UpdateName(user, userId);
            UpdateAge(user, userId);
            UpdatePhoneNumber(user, userId);
            UpdateAddress(user, userId);
        }

        private void UpdatePassword(UserDTO user, string id)
        {
            if (user.Password != null)
            {
                AccessorData.UpdateStringUserData(id, "password", user.Password);
            }
        }

        private void UpdateName(UserDTO user, string id)
        {
            if (user.Name != null)
            {
                AccessorData.UpdateStringUserData(id, "name", user.Name);
            }
        }

        private void UpdateAge(UserDTO user, string id)
        {
            if (user.Age != 0)
            {
                AccessorData.UpdateIntUserData(id, "age", user.Age);
            }
        }

        private void UpdatePhoneNumber(UserDTO user, string id)
        {
            if (user.PhoneNumber != null)
            {
                AccessorData.UpdateStringUserData(id, "phonenumber", user.PhoneNumber);
            }
        }

        private void UpdateAddress(UserDTO user, string id)
        {
            if (user.Address != null)
            {
                AccessorData.UpdateStringUserData(id, "address", user.Address);
            }
        }

        private void CheckNumber(UserDTO user, string age)
        {
            if (ExceptionHandler.IsStringAllNumber(age))
            {
                user.Age = int.Parse(age);
            }
        }
    }
}
