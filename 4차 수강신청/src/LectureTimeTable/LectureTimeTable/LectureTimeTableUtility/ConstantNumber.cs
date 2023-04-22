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

        public const int NOT_MATCH_CONDITION = 0;
        public const int FAILURE_LOGIN = 1;
        public const int ENTER_STRING = 2;

        public const string idCheck = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string passwordCheck = @"^[0-9a-zA-Z]{8,20}";
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
    CLASS,
    COURSE_NUMBER,
    SEARCH
}
