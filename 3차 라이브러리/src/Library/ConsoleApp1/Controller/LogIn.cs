using Library.Model;
using Library.Utility;
using Library.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    class LogIn
    {

        TotalStorage totalStorage;
        InputFromUser inputFromUser;
        UI ui;
        MySQLAccessor mySQLAccessor;

        public LogIn(TotalStorage totalStorage, InputFromUser inputFromUser, UI ui)
        {
            this.totalStorage = totalStorage;
            this.inputFromUser = inputFromUser;
            this.ui = ui;
            mySQLAccessor = MySQLAccessor.SetmySQLAccessor();
        }

        public List<string> SignInMember()  // 로그인
        {
            const int id = 0;
            const int password = 1;
            int ConsoleInputRow = 25;
            int ConsoleInputColumn = 23;

            bool isPassword = true;
            bool isNotPassword = false;
            bool isValidAccount = false;

            int userIndex = 0;
            int managerIndex = 0;

            List<string> accounts = new List<string>();

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn);

            accounts.Add(inputFromUser.InputStringFromUser(15, isNotPassword, ConsoleInputRow, ConsoleInputColumn));        // id 입력
            if (accounts[(int)USERINFORMATION.ID] == null)      // esc를 눌렀다면
                return null;

            Console.SetCursorPosition(ConsoleInputRow, ConsoleInputColumn + 1);
            accounts.Add(inputFromUser.InputStringFromUser(15, isPassword, ConsoleInputRow, ConsoleInputColumn + 1));       //password 입력
            if (accounts[(int)USERINFORMATION.PASSWORD] == null)
                return null;

            return accounts;
        }

        public bool SerchValidAccount(List<string> account)
        {
            const int ConsoleInputRow = 15;
            const int ConsoleInputColumn = 21;

            bool isValidAccount = false;
            int userIndex = 0;
            string columnName;
            string checkIdQuery = string.Format("SELECT * FROM user_list WHERE id='{0}'", account[(int)USERINFORMATION.ID]);

            MySqlDataReader searchAccount = mySQLAccessor.AccessReturnData(checkIdQuery, (int)INPUTDATA.USER);

            while (searchAccount.Read())
            {
                if (account[(int)USERINFORMATION.ID] == (string)searchAccount["id"] &&
                    account[(int)USERINFORMATION.PASSWORD] == (string)searchAccount["password"])
                {
                    totalStorage.loggedInUserId = account[(int)USERINFORMATION.ID];
                    isValidAccount = true;
                }
            }
            mySQLAccessor.CloseConnection();

            if (!isValidAccount)        // 일치하는 정보가 없다면
            {
                ui.IsValidAccount(ConsoleInputRow, ConsoleInputColumn + 5);
                Console.ReadKey(true);
            }

            return isValidAccount;
            //for (int i = 0; i < totalStorage.users.Count; i++)      // 저장되어 있는 회원 정보만큼 반복하며
            //{
            //    if (totalStorage.users[i].GetId() == account[(int)(USERINFORMATION.ID)] &&
            //        totalStorage.users[i].GetPassword() == account[(int)(USERINFORMATION.PASSWORD)])   // 일치하는 ID가 있을 때
            //    {
            //        totalStorage.loggedInUserId = account[(int)(USERINFORMATION.ID)];
            //        isValidAccount = true;      // 존재하는 계정의
            //        userIndex = i;                  // 인덱스 값을 저장해 두고
            //        break;                      // 반복문 탈출
            //    }
            //}
        }
    }
}
