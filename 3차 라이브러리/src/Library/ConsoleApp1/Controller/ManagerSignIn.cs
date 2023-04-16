using Library.Model;
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

        public int SignInManager()
        {
            return base.SignInMember();
        }
    }
}
