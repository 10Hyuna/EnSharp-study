using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    class ManagerSignIn : UserSignInOrUp
    {
        UI ui;
        TotalStorage totalStorage;
        public ManagerSignIn(UI ui, TotalStorage totalStorage)
        {
            this.ui = ui;
            this.totalStorage = totalStorage;
        }

        public bool SignInManager()
        {
            List<string> account;
            bool isSuccessLogin = false;

            while(!isSuccessLogin)
            {
                account =  base.SignInMember();
                if(account == null)
                {
                    return false;
                }

                isSuccessLogin = IsValidAccount(account);
            }
            return isSuccessLogin;
        }

        private bool IsValidAccount(List<string> account)
        {
            if (account[(int)(ACCOUNT.ID)] == totalStorage.manager[0].GetManagerId()
                && account[(int)(ACCOUNT.PASSWORD)] == totalStorage.manager[0].GetManagerPassword())
            {
                return true;
            }
            return false;
        }
    }
}
