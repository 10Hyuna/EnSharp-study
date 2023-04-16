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
        public Regex idCheck = new Regex(@"^[0-9a-zA-Z]{8,20}");       // 아이디와 비밀번호의 패턴을 뜻하는 정규식
        public Regex passwordCheck = new Regex(@"^[0-9a-zA-Z]{8,20}");
        public Regex nameCheck = new Regex(@"^[가-힇a-zA-Z]{1,}");       // 이름 정규식
        public Regex ageCheck = new Regex(@"^[0-9]{1,3}");               // 나이 정규식
        public Regex phoneNumberCheck = new Regex(@"^01[016789]{1}-[0-9]{3,4}-[0-9]{4}");       // 번호 정규식
        public Regex addressCheck = new Regex(@"^[가-힇]{2,4}시 [가-힇]{2}구");                 // 주소 정규식
        //public Regex addressCheck = new Regex(@"^[가-힇]{2,4}도 | [가-힇]{2,4}시 ([가-힇]{2,4}(읍|면|동|길|로))")
        public Regex containedOneValue = new Regex(@"^[가-힇a-zA-Z0-9]{1,}");
        public Regex containedOneNumber = new Regex(@"^[0-9]{1,}");
        public Regex korean = new Regex(@"^[가-힇]{1,}");
        public Regex title = new Regex(@"^[가-힇a-zA-Z?!+=]{1,}");
        public Regex author = new Regex(@"^[가-힇a-zA-Z]{1,}");
        public Regex amount = new Regex(@"^[0-9]{1,3}");
        public Regex price = new Regex(@"^[0-9]{1,7}");
        public Regex publishDay = new Regex(@"^(19|20)\d{2}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$");
        public Regex month = new Regex(@"[0-9]{1,2}");
        public Regex date = new Regex(@"[0-9]{1,2}");
        public Regex ISBN = new Regex(@"[0-9a-zA-Z ]{13,}");
        public Regex information = new Regex(@"[0-9a-zA-Z가-힇]{1,}");
    }
}
