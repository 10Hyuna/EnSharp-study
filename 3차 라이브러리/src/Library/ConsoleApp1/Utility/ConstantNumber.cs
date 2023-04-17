using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class ConstantNumber
    {
        public const bool isPassword = true;
        public const bool isNotPassword = false;

        public const int OVERLAP_DATA = 11;

        public const int INVALID_INFORMATION = -2;
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

        public const string idCheck = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string passwordCheck = @"^[0-9a-zA-Z]{8,20}";
        public const string nameCheck = @"^[가-힇a-zA-Z]{1,}";       // 이름 정규식
        public const string ageCheck = @"^[0-9]{1,3}";               // 나이 정규식
        public const string phoneNumberCheck = @"^01[016789]{1}-[0-9]{3,4}-[0-9]{4}";       // 번호 정규식
        public const string addressCheck = @"^[가-힇]{2,4}시 [가-힇]{2}구";                 // 주소 정규식
        //publiconst string addressCheck = @"^[가-힇]{2,4}도 | [가-힇]{2,4}시 ([가-힇]{2,4}(읍|면|동|길|로))"
        public const string containedOneValue = @"^[가-힇a-zA-Z0-9]{1,}";
        public const string containedOneNumber = @"^[0-9]{1,}";
        public const string korean = @"^[가-힇]{1,}";
        public const string title = @"^[가-힇a-zA-Z?!+=]{1,}";
        public const string author = @"^[가-힇a-zA-Z]{1,}";
        public const string amount = @"^[0-9]{1,3}";
        public const string price = @"^[0-9]{1,7}";
        public const string publishDay = @"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";
        public const string month = @"[0-9]{1,2}";
        public const string date = @"[0-9]{1,2}";
        public const string ISBN = @"[0-9a-zA-Z ]{13,}";
        public const string information = @"[0-9a-zA-Z가-힇]{1,}";
    }
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

    enum ACCOUNT
    {
        ID,
        PASSWORD
    }
}
