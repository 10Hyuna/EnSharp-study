using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableUtility
{
    class ConstantNumber
    {
        public const string ESC = "ESC";
        public const string UP = "UP";
        public const string DOWN = "DOWN";

        public const int FAILE = -5;
        public const int EXIT = -10;
        public const int ENTER = 10;

        public const bool IS_PASSWORD = true;
        public const bool IS_NOT_PASSWORD = false;

        public const bool IS_ID = true;
        public const bool IS_NOT_ID = false;

        public const bool IS_SELECTED = true;
        public const bool IS_NOT_SELECTED = false;

        public const bool IS_OPTION = true;
        public const bool IS_MENU = false;

        public const bool IS_LOOKUP = true;
        public const bool IS_INTERESTED = false;
        public const bool IS_ENROLLED = true;

        public const string IDCHECK = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string PASSWORDCHECK = @"^[0-9a-zA-Z]{8,20}";
        public const string KOREAN = @"^[가-힇]{1,}";
        public const string NUMBER = @"^[0-9]{1}";
        public const string COURSER_NUMBER = @"^[0-9]{4,8}";
    }
}

    enum LOGIN
    {
        CREDIT,
        PASSWORD
    }

enum ENROLMENTLECTURE
{
    INQUIRY,
    INTERESTEDLECTURE,
    ENROLMENT,
    SEARCHLIST
}

enum INQUIRY
{
    MAJOR,
    COMPLETE_TYPE,
    LECTURE_TITLE,
    PROFESSOR,
    GRADE,
    COURSE_NUMBER,
    SEARCH
}

enum MAJOR
{
    COMPUTER,
    SOFTWARE,
    INTELLIGENCE,
    ENGINEERING
}

enum INTERESTED
{
    SEARCH,
    LIST,
    TIMETABLE,
    DELECT
}

enum EXCEPTION
{
    NOT_MATCH_CONDITION,
    FAILURE_LOGIN,
    ENTER_STRING,
    FREE_CREDIT,
    NULL_LECTURE,
    OVERLAP_LECTURE,
    OVERLAP_TIME,
    MAX_CREDIT,
    NULL_STORAGE,

}