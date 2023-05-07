using System;
using System.Collections.Generic;
using System.Data;
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

        public const string LOG_SAVE_FORMAT = "로그 아이디 : {0} // 로그 시간 : {1} // 로그 사용자 : {2} // 로그 정보 : {3} // 로그 행위 : {4}";

        public const string USER_NAME = "유저";
        public const string MANAGER_NAME = "관리자";

        public const string LOGIN = "로그인";
        public const string SIGNUP = "회원가입";
        public const string SUCCESS_RENT = "책 대여";
        public const string CHECK_RENT = "대여 내역 확인";
        public const string SUCCESS_RETURN = "책 반납";
        public const string CHECK_RETURN = "반납 내역 확인";
        public const string MODIFY_USER_INFORMATION = "유저 정보 수정";
        public const string DELETE_USER_ACCOUNT = "계정 삭제";
        public const string NAVER_SEARCH = "네이버 검색";
        public const string REQUEST_BOOK = "책 요청 내역";
        public const string ADD_BOOK = "책 추가";
        public const string DELETE_BOOK_INFROMATION = "책 삭제";
        public const string MODIFY_BOOK = "책 수정";
        public const string MANAGEMENT_ACCOUNT = "회원 관리";
        public const string LOG_MODIFY = "로그 수정";
        public const string LOG_SAVE = "로그 저장";
        public const string LOG_DELETE = "로그 삭제";
        public const string LOG_RESET = "로그 초기화";

        public const string BOOK_ID__UI = "{0}할 책의 ID를 입력해 주세요";
        public const string BOOK_LIST_UI = "\n{0} 책의 리스트\n";

        public const string RENT = "대여";
        public const string RETURN = "반납";
        public const string REQUEST = "요청";

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
        public const string ADDRESS1 = @"^[가-힇]{2,4}시 [가-힇]{2}구";                 // 주소 정규식
        public const string ADDRESS = @"^([가-힇]{2,}(도|시) | ([가-힇]{2,}(시)) ([가-힣]{2,}(로|길).[\d]+)|([가-힣]+(읍|면|동)\s)[\d]+)";
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
        public const string INSERT_REQUEST_BOOK = "INSERT INTO request_book (title, author, publisher, price, publishdate, isbn, information) VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}')";
        public const string INSERT_RENT_BOOK = "INSERT INTO user_rent_book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')";
        public const string INSERT_RETURN_BOOK = "INSERT INTO user_return_book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')";
        public const string INSERT_LOG = "INSERT INTO log (time, user, information, action) VALUES('{0}', '{1}', '{2}', '{3}')";
        public const string DELETE_USER = "DELETE FROM user_list WHERE id = '{0}'";
        public const string DELETE_BOOK = "DELETE FROM book_list WHERE id = {0}";
        public const string DELETE_RENT_BOOK_WITH = "DELETE FROM user_rent_book WHERE book_id = {0}";
        public const string DELETE_RETURN_BOOK = "DELETE FROM user_return_book WHERE book_id = {0}";
        public const string DELETE_RENT_BOOK = "DELETE FROM user_rent_book WHERE user_id = '{0}' AND book_id = {1}";
        public const string DELETE_REQUEST_BOOK = "DELETE FROM request_book WHERE title = '{0}'";
        public const string DELETE_ONE_LOG = "DELETE FROM log WHERE id = {0}";
        public const string DELETE_LOG = "DELETE FROM log";
        public const string SELECT_LOG = "SELECT * FROM log";
        public const string SELECT_USER = "SELECT * FROM user_list WHERE id = '{0}'";
        public const string SELECT_ALL_USER = "SELECT * FROM user_list";
        public const string SELECT_MANAGER = "SELECT * FROM manager_list WHERE id = '{0}'";
        public const string SELECT_ALL_BOOK = "SELECT * FROM book_list";
        public const string SELECT_REQUEST_BOOK = "SELECT * FROM request_book";
        public const string SELECT_REQUESTED_BOOK = "SELECT * FROM request_book WHERE title LIKE CONCAT('%', '{0}', '%')";
        public const string SELECT_BOOK = "SELECT * FROM book_list WHERE (title LIKE CONCAT('%', '{0}', '%') OR '{0}' = '') AND (author LIKE CONCAT('%', '{1}', '%') OR '{1}' = '') AND (publisher LIKE CONCAT('%', '{2}', '%') OR '{2}' = '')";
        public const string SELECT_PARTLY_BOOK = "SELECT * FROM book_list WHERE id = {0}";
        public const string SELECT_RENT_BOOK = "SELECT * FROM user_rent_book WHERE user_id = '{0}'";
        public const string SELECT_USER_RENT_BOOK = "SELECT * FROM user_rent_book WHERE user_id = '{0}' AND book_id = {1}";
        public const string SELECT_ALL_RETURN_BOOK = "SELECT * FROM user_return_book WHERE user_id = '{0}'";
        public const string SELECT_RETURNED_BOOK = "SELECT * FROM user_return_book WHERE user_id = '{0}' AND book_id = {1}";
        public const string UPDATE_USER_INT = "UPDATE user_list SET {0} = {1} WHERE id = '{2}'";
        public const string UPDATE_USER_STRING = "UPDATE user_list SET {0} = '{1}' WHERE id ='{2}'";
        public const string UPDATE_BOOK_STRING = "UPDATE book_list SET {0} = {1} WHERE id = {2}";
        public const string UPDATE_BOOK_INT = "UPDATE book_list SET {0} = '{1}' WHERE id = {2}";

        public const string URL = "https://openapi.naver.com/v1/search/book?query={0}&display={1}";
        public const string CLIENT_ID = "7odha65bGppJqSbN3p71";
        public const string CLIENT_SECRET = "or3JK6km4_";
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
    NULL_RETURN,
    NOT_MATCH_SEARCH,
    NOT_MATCH_COUNT,
    ALREADY_REQUEST,
    INVALID_BOOK,
    NULL_FILE
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
    MANAGER,
    REQUEST
}

enum USERMENU
{
    FIND,
    RENT,
    RENT_LIST,
    RETURN,
    RETURN_LIST,
    MODIFY_MY_INFORMATION,
    DELETE_ACCOUNT,
    NAVER_SEARCH,
    REQUEST_LIST
}

enum MANAGERMODE
{
    FIND,
    ADD,
    DELETE,
    MODIFY,
    MANAGEMENT,
    LIST,
    NAVER_SEARCH,
    LOG_MANAGEMENT,
    REQUEST_BOOK
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

enum LOG
{
    MODIFY,
    SAVE,
    DELETE,
    RESET
}