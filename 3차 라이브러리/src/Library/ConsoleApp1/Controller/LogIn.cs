using Library.Model;
using Library.Model.DAO;
using Library.Model.DTO;
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
        AccessorData accessorData;

        public LogIn(TotalStorage totalStorage, InputFromUser inputFromUser, UI ui)
        {
            this.totalStorage = totalStorage;
            this.inputFromUser = inputFromUser;
            this.ui = ui;
            accessorData = AccessorData.GetAccessorData();
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

        public bool SearchValidAccount(List<string> account)
        {
            const int ConsoleInputRow = 15;
            const int ConsoleInputColumn = 21;

            bool isValidAccount = false;
            int userIndex = 0;
            string columnName;

            User user = accessorData.SelectUserData(account[(int)USERINFORMATION.ID]);

            if(user.GetPassword() == account[(int)USERINFORMATION.PASSWORD])
            {
                isValidAccount = true;
                totalStorage.loggedInUserId = account[(int)USERINFORMATION.ID];
            }
            return isValidAccount;
        }
    }
}
