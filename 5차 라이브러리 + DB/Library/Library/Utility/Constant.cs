using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class Constant
    {
        public const int DELETE_ACCOUNT = 0;
        public const int FAIL_INT = -5;
        public const int EXIT_INT = -10;
        public const int ENTER_INT = 10;

        public const string ESC_STRING = "ESC";
        public const string ENTER_STRING = "ENTER";

        public const string IDCHECK = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string PASSWORDCHECK = @"^[0-9a-zA-Z]{8,20}";
        public const string KOREAN = @"^[가-힇]{1,}";
        public const string CHARACTER = @"^[가-힇A-Za-z]{1,}";
        public const string NUMBER = @"^[0-9]{1}";

    }
}

enum EXCEPTION
{
    NOT_MATCH_CONDITION,

}
enum MODE
{
    USER,
    MANAGER
}

enum USERENTRY
{
    SIGNIN,
    SIGNUP
}

enum USERMENU
{
    FIND,
    RENT,
    RENT_LIST,
    RETURN,
    RETURN_LIST,
    MODIFY_MY_INFORMATION,
    DELETE_ACCOUNT
}