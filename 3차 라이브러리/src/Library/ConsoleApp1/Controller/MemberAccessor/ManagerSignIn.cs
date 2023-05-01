using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.MemberAccessor
{
    class ManagerSignIn : UserSignUp
    {
        UI ui;
        TotalStorage totalStorage;
        LogIn logIn;
        public ManagerSignIn(UI ui, TotalStorage totalStorage, LogIn logIn)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
            this.logIn = logIn;
        }

        public bool SignInManager()     // 매니저 로그인 함수
        {
            List<string> account;
            bool isSuccessLogin = false;

            account = logIn.SignInMember();
            if (account == null)     // 중간에 esc를 눌렀다면
            {
                return false;
            }

            isSuccessLogin = IsValidAccount(account);       // 계정의 유효성 검사
            return isSuccessLogin;
        }

        private bool IsValidAccount(List<string> account)
        {
            if (account[(int)ACCOUNT.ID] == totalStorage.manager[0].Id
                && account[(int)ACCOUNT.PASSWORD] == totalStorage.manager[0].Password)
            {
                return true;        // 저장된 매니저의 정보와 일치한다면 true 반환
            }
            return false;
        }
    }
}
