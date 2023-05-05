using Library.Model.DAO;
using Library.Model.DTO;
using Library.Utility;
using Library.View;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.MemberAccess
{
    public class SignUp
    {
        MainView mainView;
        GuidancePhrase guidancePhrase;
        MenuIndexSelector menuIndexSelector;
        InputFromUser inputFromUser;
        AccessorData accessorData;

        public SignUp() 
        {
            mainView = MainView.SetMainView();
            guidancePhrase = GuidancePhrase.SetGuidancePhrase();
            menuIndexSelector = MenuIndexSelector.GetMenuIndexSelector();
            inputFromUser = InputFromUser.GetInputFromUser();
            accessorData = AccessorData.GetAccessorData();
        }

        public void EntrySignUp()
        {
            int successSignUp;
            string inputValue;
            bool isNotEnter = true;

            Console.Clear();
            Console.SetWindowSize(73, 40);

            MainView.PrintSignUpUI();

            successSignUp = AddUser();      // 회원가입하려는 유저의 정보를 입력하는 메소드

            if(successSignUp == Constant.EXIT_INT)
            {       // 중간에 esc를 눌렀다면
                return;
            }

            Console.Clear();
            MainView.SuccessSignUp();       // 회원가입 성공

            while (isNotEnter)
            {
                inputValue = InputFromUser.InputEnterESC();

                if(inputValue == Constant.ENTER_STRING)
                {
                    isNotEnter = false;
                }
            }
        }

        private int AddUser()       // 회원가입 정보 입력
        {
            int column = 50;
            int row = 15;

            string pwCheck;

            bool isNotOverlapData = true;
            bool isDifferntPW = true;

            UserDTO user = new UserDTO();

            user.Id = CheckOverlapData();
            if(user.Id == Constant.ESC_STRING)
            {
                return Constant.EXIT_INT;
            }

            user.Password = CheckMatchData();
            if (user.Password == Constant.ESC_STRING)
            {
                return Constant.EXIT_INT;
            }

            user.Name = ExceptionHandler.IsValidInput(Constant.NAME, column + 5, row + 3, 20, Constant.IS_NOT_PASSWORD);
            if(user.Name == Constant.ESC_STRING)
            {
                return Constant.EXIT_INT;
            }

            user.Age = CheckValidAge();
            if(user.Age == Constant.EXIT_INT)
            {
                return Constant.EXIT_INT;
            }

            user.PhoneNumber = ExceptionHandler.IsValidInput(Constant.PHONENUMBER, column + 3, row + 5, 20, Constant.IS_NOT_PASSWORD);
            if(user.PhoneNumber == Constant.ESC_STRING)
            {
                return Constant.EXIT_INT;
            }

            user.Address = ExceptionHandler.IsValidInput(Constant.ADDRESS, column + 5, row + 6, 20, Constant.IS_NOT_PASSWORD);
            if(user.Address == Constant.ESC_STRING)
            {
                return Constant.EXIT_INT;
            }

            AccessorData.InsertUserData(user);
            return Constant.SUCCESS;
        }

        private string CheckOverlapData()       // 아이디가 중복되는 데이터인지 확인
        {
            int column = 50;
            int row = 15;

            string id = "";
            bool isNotOverlapData = true;
            UserDTO overlapUser = null;

            while (isNotOverlapData)
            {
                id = ExceptionHandler.IsValidInput(Constant.ID, column, row, 15, Constant.IS_NOT_PASSWORD);
                if(id == Constant.ESC_STRING)
                {
                    return Constant.ESC_STRING;
                }

                overlapUser = AccessorData.SelectUserData(id);

                if (overlapUser.Id == null)
                {
                    isNotOverlapData = false;
                }
                else
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.OVERLAP_DATA, column, row);
                }
            }

            return id;
        }
        private string CheckMatchData()     // 입력받은 두 비밀번호 값이 서로 일치하는지 확인
        {
            int column = 50;
            int row = 16;

            string password = "";
            string pwCheck = "";
            bool isDifferentPassword = true;

            password = ExceptionHandler.IsValidInput(Constant.PASSWORD, column, row, 15, Constant.IS_PASSWORD);
            if(password == Constant.ESC_STRING)
            {
                return Constant.ESC_STRING;
            }

            while (isDifferentPassword)
            {
                pwCheck = ExceptionHandler.IsValidInput(Constant.PASSWORD, column - 16, row + 1, 15, Constant.IS_PASSWORD);
                if(pwCheck == Constant.ESC_STRING)
                {
                    return Constant.ESC_STRING;
                }

                if(password == pwCheck)
                {
                    isDifferentPassword = false;
                }
                else
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_PASSWORD, column - 16, row + 1);
                }
            }

            return password;
        }

        private int CheckValidAge()     // 나이 입력 창에서 숫자로만 구성된 값이 입력된 게 맞는지 확인
        {
            int column = 45;
            int row = 19;

            bool isValidInput = true;

            string age = "";
            int ageNumber = 0;

            while(isValidInput)
            {
                age = ExceptionHandler.IsValidInput(Constant.AGE, column, row, 5, Constant.IS_NOT_PASSWORD);

                if (age == Constant.ESC_STRING)
                {
                    return Constant.EXIT_INT;
                }

                else if ((!ExceptionHandler.IsStringAllNumber(age)) || age == "")
                {
                    GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    continue;
                }
                else
                {
                    ageNumber = int.Parse(age);
                    if (ageNumber < 0 || ageNumber > 200)
                    {
                        GuidancePhrase.PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                        continue;
                    }
                }
                isValidInput = false;
            }
            return int.Parse(age);
        }
    }
}
