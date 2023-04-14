using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    class ConstantNumber
    {
        public const int NOTMATCHEDCONDITION = 1;
        public const int NOTMATCHEDPASSWORD = 2;
        public const int NOTMATCHEDID = 3;
        public const int VALIDVALUE = 4;
        public const int EXIT = -1;
        public const int SUCCESS = 0;
        public const int INVALIDINFORMATION = -1;
        public const int LEAKINGBOOKAMOUNT = 3;
        public const int SUCCESSBORROWBOOK = 4;
        public const int SUCCESSRETURNBOOK = 5;
        public const int ALREADYRENTBOOK = 6;
        public const int INVALIDBOOKID = 7;
        public const int INVALIDUSERID = 8;

        public const int FINDTHEBOOK = 0;
        public const int RENTTHEBOOK = 1;
        public const int ADDTHEBOOK = 1;
        public const int CHECKTHERETALBOOK = 2;
        public const int DELETETHEBOOK = 2;
        public const int MODIFYBOKKINFORMATION = 3;
        public const int RETURNTHEBOOK = 3;
        public const int MANAGEUSER = 4;
        public const int RETURNBOOKLIST = 4;
        public const int RENTALSTATE = 5;
        public const int MODIFYMYINFORMATION = 5;
        public const int DELETEACCOUNT = 6;

        public const int MODIFYID = 0;
        public const int MODIFYPASSWORD = 1;
        public const int MODIFYNAME = 2;
        public const int MODIFYAGE = 3;
        public const int MODIFYPHONENUMBER = 4;
        public const int MODIFTADDRESS = 5;
        public const int MODIFYSUCCESS = 6;

        public const int MODIFYTITLE = 0;
        public const int MODIFYAUTHOR = 1;
        public const int MODIFYPUBLISHER = 2;
        public const int MODIFYAMOUNT = 3;
        public const int MODIFYPRICE = 4;
        public const int MODIFTPUBLISHDAY = 5;
    }
}
