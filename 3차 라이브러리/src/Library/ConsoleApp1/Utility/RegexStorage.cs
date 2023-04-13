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
        public Regex phoneNumCheck = new Regex(@"01{1}[016789]{1}-[0-9]{3,4}-[0-9]{4}");       // 번호 정규식
        public Regex addressCheck = new Regex(@"[가-힇]{2,4}시 [가-힇]{2}구");                 // 주소 정규식
        public Regex containedOneCharacter = new Regex(@"[가-힇a-zA-Z0-9]{1,}");
        public Regex containedOneNumber = new Regex(@"[0-9]{1,}");
    }
}
