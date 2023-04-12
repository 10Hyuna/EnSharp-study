using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    class UserInformation
    {

        public UserInformation() { }
        public UserInformation(string id, string password, string name, string age, string phoneNumber, string address)  // 유저의 정보 입력
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }

        public List<BorrowBookList> borrowDatas = new List<BorrowBookList>();

        public List<BorrowBookList> returnDatas = new List<BorrowBookList>();

    }
}
