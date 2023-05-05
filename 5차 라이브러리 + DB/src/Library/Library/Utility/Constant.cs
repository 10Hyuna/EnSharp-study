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
        public const int IS_NOT_NUMBER = 1;
        public const int FAIL_INT = -5;
        public const int EXIT_INT = -10;
        public const int ENTER_INT = 10;
        public const int SUCCESS = 20;

        public const string ESC_STRING = "ESC";
        public const string ENTER_STRING = "ENTER";

        public const string USERENTRY = "      USER";
        public const string MANAGERENTRY = "MANAGER";

        public const string ID_FAIL = "ID_FAIL";
        public const string PW_FAIL = "PW_FAIL";

        public const string SERVER = "localhost";
        public const string PORT = "3306";
        public const string DATABASE = "en#library";
        public const string UID = "root";
        public const string PW = "0000";

        public const string ID = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string PASSWORD = @"^[0-9a-zA-Z!?@#$%^&*~]{8,20}";
        public const string KOREAN = @"^[가-힇]{1,}";
        public const string CHARACTER = @"^[가-힇A-Za-z]{1,}";
        public const string NUMBER = @"^[0-9]{1}";
        public const string NAME = @"^[가-힇a-zA-Z]{1,}";       // 이름 정규식
        public const string AGE = @"^[0-9]{1,3}";               // 나이 정규식
        public const string PHONENUMBER = @"^01[016789]{1}-[0-9]{3,4}-[0-9]{4}$";       // 번호 정규식
        public const string ADDRESS = @"^[가-힇]{2,4}시 [가-힇]{2}구";                 // 주소 정규식
        //publiconst string addressCheck = @"^[가-힇]{2,4}도 | [가-힇]{2,4}시 ([가-힇]{2,4}(읍|면|동|길|로))"
        public const string ONEVALUE = @"^[가-힇a-zA-Z0-9]{1,}";
        public const string TITLE = @"^[가-힇a-zA-Z?!+=]{1,}";
        public const string AUTHOR = @"^[가-힇a-zA-Z]{1,}";
        public const string AMOUNT = @"^[0-9]{1,3}";
        public const string PRICE = @"^[0-9]{1,7}";
        public const string PUBLISHDATE = @"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$";
        public const string ISBN = @"[0-9a-zA-Z- ]{13,}";
        public const string INFORMATION = @"[0-9a-zA-Z가-힇]{1,}";

        public const string INSERT_USER = "INSERT INTO user_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
        public const string INSERT_BOOK = "INSERT INTO book_list (title, author, publisher, amount, price, publishdate, ISBN, information) VALUES('{0}', '{1}', '{2}', {3}, {4}, '{5}', '{6}', '{7}')";
        public const string INSERT_RENT_BOOK = "INSERT INTO user_rent_book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')";
        public const string INSERT_RETURN_BOOK = "INSERT INTO user_return_book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')";
        public const string DELETE_USER = "DELETE FROM user_list WHERE id = '{0}'";
        public const string DELETE_BOOK = "DELETE FROM book_list WHERE id = {0}";
        public const string DELETE_RENT_BOOK = "DELETE FROM user_rent_book WHERE user_id = '{0}' AND book_id = {1}";
        public const string SELECT_USER = "SELECT * FROM user_list WHERE id = '{0}'";
        public const string SELECT_ALL_USER = "SELECT * FROM user_list";
        public const string SELECT_MANAGER = "SELECT * FROM manager_list WHERE id = '{0}'";
        public const string SELECT_ALL_BOOK = "SELECT * FROM book_list";
        public const string SELECT_BOOK = "SELECT * FROM book_list WHERE (title LIKE CONCAT('%', '{0}', '%') OR '{0}' = '') AND (author LIKE CONCAT('%', '{1}', '%') OR '{1}' = '') AND (publisher LIKE CONCAT('%', '{2}', '%') OR '{2}' = '')";
        public const string SELECT_PARTLY_BOOK = "SELECT * FROM book_list WHERE id = {0}";
        public const string SELECT_RENT_BOOK = "SELECT * FROM user_rent_book WHERE user_id = '{0}'";
        public const string SELECT_USER_RENT_BOOK = "SELECT * FROM user_rent_book WHERE user_id = '{0}' AND book_id = {1}";
        //public const string SELECT_RETURN_BOOK = "SELECT * FROM user_return_book WHERE book_id = {0}'";
        public const string SELECT_ALL_RETURN_BOOK = "SELECT * FROM user_return_book WHERE user_id = '{0}'";
        public const string SELECT_RETURNED_BOOK = "SELECT * FROM user_return_book WHERE user_id = '{0}' AND book_id = {1}";
        public const string UPDATE_USER_INT = "UPDATE user_list SET {0} = {1} WHERE id = '{2}'";
        public const string UPDATE_USER_STRING = "UPDATE user_list SET {0} = '{1}' WHERE id ='{2}'";
        public const string UPDATE_BOOK_STRING = "UPDATE book_list SET {0} = {1} WHERE id = {2}";
        public const string UPDATE_BOOK_INT = "UPDATE book_list SET {0} = '{1}' WHERE id = {2}";
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
    OVERLAP_DATA,
    NOT_MATCH_PASSWORD,
    NULL_KEYWORD,
    NULL_SEARCH_BOOK,
    LEAK_AMOUNT,
    ALREADY_RENT,
    NULL_RENT,
    NOT_MATCH_SEARCH
}
enum MODE
{
    USER,
    MANAGER
}

enum USERENTRY
{
    SIGNIN,
    SIGNUP,
}

enum ENTRY
{
    RENTAL,
    RETURN,
    MANAGER
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

enum MANAGERMODE
{
    FIND,
    ADD,
    DELETE,
    MODIFY,
    MANAGEMENT,
    LIST
}

enum MODIFY
{
    PASSWORD,
    NAME,
    AGE,
    PHONENUMBER,
    ADDRESS,
    SUCCESS
}

enum MODIFICATION
{
    INFORMATION,
    ACCOUNT
}

enum BOOKINFO
{
    TITLE,
    AUTHOR,
    PUBLISHER,
    AMOUNT,
    PRICE,
    PUBLISHDAY,
    SUCCESS
}