using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class Constant
    {

        public const bool IS_PASSWORD = true;
        public const bool IS_NOT_PASSWORD = false;
        public const int DELETE_ACCOUNT = 0;
        public const int FAIL_INT = -5;
        public const int EXIT_INT = -10;
        public const int ENTER_INT = 10;

        public const string ESC_STRING = "ESC";
        public const string ENTER_STRING = "ENTER";

        public const string USERENTRY = "USER";
        public const string MANAGERENTRY = "MANAGER";

        public const string ID_FAIL = "ID_FAIL";
        public const string PW_FAIL = "PW_FAIL";

        public const string IDCHECK = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string PASSWORDCHECK = @"^[0-9a-zA-Z!?@#$%^&*~]{8,20}";
        public const string KOREAN = @"^[가-힇]{1,}";
        public const string CHARACTER = @"^[가-힇A-Za-z]{1,}";
        public const string NUMBER = @"^[0-9]{1}";

        public const string INSERT_USER = "INSERT INTO user_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        public const string INSERT_BOOK = "INSERT INTO book_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        public const string INSERT_RENT_BOOK = "INSERT INTO user_rent_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        public const string INSERT_RETURN_BOOK = "INSERT INTO user_return_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        public const string DELETE = "DELETE FROM {0} WHERE id = '{1}'";
        public const string SELECT_USER = "SELECT * FROM user_list WHERE id = '{0}'";
        public const string SELECT_BOOK = "SELECT * FROM book_list WHERE title = '{0}' AND author = '{1}' AND publisher = '{2}'";
        public const string SELECT_RENT_BOOK = "SELECT * FROM user_rent_list WHERE book_id = '{0}'";
        public const string SELECT_RETURN_BOOK = "SELECT * FROM user_return_list WHERE book_id = {0}'";
        public const string UPDATE_USER = "UPDATE user_list SET {0} = '{1}' WHERE {2} = '{3}'";
    }
}

enum ACCOUNT
{
    ID,
    PASSWORD
}
enum EXCEPTION
{
    NOT_MATCH_CONDITION,
    ID_FAIL,
    PW_FAIL,

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