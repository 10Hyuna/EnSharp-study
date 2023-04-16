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
        public const bool isPassword = true;
        public const bool isNotPassword = false;

        public const int OVERLAP_DATA = 11;

        public const int INVALIDINFORMATION = -2;
        public const int EXIT = -1;
        public const int SUCCESS = 0;
        public const int NOT_MATCHED_CONDITION = 1;
        public const int NOT_MATCHED_PASSWORD = 2;
        public const int NOT_MATCHED_ID = 3;
        public const int SUCCESS_BORROW_BOOK = 4;
        public const int SUCCESS_RETURN_BOOK = 5;
        public const int ALREADY_RENT_BOOK = 6;
        public const int INVALID_BOOK_ID = 7;
        public const int INVALID_USER_ID = 8;

        public const int VALID_VALUE = 10;
        public const int SERCHED_BOOK = 20;
        public const int LEAKING_BOOK_AMOUNT = 30;
    }

    enum Mode
    {
        USER,
        MANAGER
    }

    enum Sign
    {
        SIGNIN,
        SIGNUP
    }
    enum MANAGERMODE
    {
        FIND_BOOK,
        ADD_BOOK,
        DLETE_BOOK,
        MODIFY_BOOK_INFORMATION,
        MANAGE_USER,
        RENTAL_STATE
    }

    enum USERMODE
    {
        FIND_BOOK,
        RENT_BOOK,
        RENT_BOOK_LIST,
        RETURN_BOOK,
        RETURN_BOOK_LIST,
        MODIFY_MY_INFORMATION,
        DELETE_ACCOUNT
    }
    enum USERINFORMATION
    {
        ID,
        PASSWORD,
        NAME,
        AGE,
        PHONENUMBER,
        ADDRESS,
        SUCCESS
    }

    enum BOOKINFORMATION
    {
        TITLE,
        AUTHOR,
        PUBLISHER,
        AMOUNT,
        PRICE,
        PUBLISHDAY
    }
}
