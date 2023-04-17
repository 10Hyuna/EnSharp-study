using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Utility
{
    class RegexStorage
    {
        public const string idCheck = @"^[0-9a-zA-Z]{8,20}";       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public const string passwordCheck = @"^[0-9a-zA-Z]{8,20}";
        public const string nameCheck = @"^[가-힇a-zA-Z]{1,}";       // 이름 정규식
        public const string ageCheck = @"^[0-9]{1,3}";               // 나이 정규식
        public const string phoneNumberCheck = @"^01[016789]{1}-[0-9]{3,4}-[0-9]{4}";       // 번호 정규식
        public const string addressCheck = @"^[가-힇]{2,4}시 [가-힇]{2}구";                 // 주소 정규식
        //publiconst stringex addressCheck = new Regex(@"^[가-힇]{2,4}도 | [가-힇]{2,4}시 ([가-힇]{2,4}(읍|면|동|길|로))")
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
