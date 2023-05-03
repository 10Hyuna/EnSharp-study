using Library.Controller.BookAccess;
using Library.Controller.MemberAccess;
using Library.Controller.TotalAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.SelectorMode
{
    public class ManagerMode
    {
        Login login;
        Searcher searcher;
        SortList sortList;
        DeleterInformation deleterInformation;

        public ManagerMode(Login login, Searcher searcher, SortList sortList, DeleterInformation deleterInformation)
        {
            this.login = login;
            this.searcher = searcher;
            this.sortList = sortList;
            this.deleterInformation = deleterInformation;
        }
    }
}
