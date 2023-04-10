using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class SavedInformation
    {

        public SavedInformation(DataController dataController)      // 미리 저장된 정보들
        {
            dataController.members.Add(new MemberData("managerid12", "managerpw12"));
            dataController.members.Add(new MemberData("userid12", "userpw12", "김유저", "010-9808-4116", "23", "서울특별시 광진구 아차산로"));

            dataController.books.Add(new BookData(1, "확률과 랜덤변수 및 랜덤과정", "송홍엽, 정하봉", "교보문고", "1", "32000", "2016-02-18", "979-11-5909-011-0", "수학"));
            dataController.books.Add(new BookData(2, "논리회로 설계", "송상훈, 한동일", "생능출판", "2", "20000","2015-12-23", "978-89-7050-860-3", "컴퓨터"));
            dataController.books.Add(new BookData(3, "신경 끄기의 기술", "마크 맨슨", "갤리온", "1", "15000", "2020-05-10", "978-89-01-32994-3", "자기계발"));
            dataController.books.Add(new BookData(4, "퇴사 준비생의 런던", "이동진", "백투더퓨처", "1", "15000", "2018-09-18", "979-11-960827-2-7-03320", "에세이"));
        }
    }
}
