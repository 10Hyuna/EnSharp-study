using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    class User
    {

        public User() { }

        protected string id;
        protected string password;
        protected string name;
        protected string age;
        protected string phoneNumber;
        protected string address;
        protected List<BorrowBookList> borrowDatas = new List<BorrowBookList>();
        protected List<ReturnBookList> returnDatas = new List<ReturnBookList>();

        public void SetUserId(string id)
        {
            this.id = id;
        }

        public void SetUserPassword(string password)
        {
            this.password = password;
        }

        public void SetUserName(string Name)
        {
            this.name = name;
        }

        public void SetUserAge(string Age)
        {
            this.age = Age;
        }

        public void SetUserPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SetUserAddress(string Address)
        {
            this.address = Address;
        }

        public string GetUserId()
        {
            return this.id;
        }

        public string GetUserPassword()
        {
            return this.password;
        }

        public string GetUserName()
        {
            return this.name;
        }

        public string GetUSerAge()
        {
            return this.age;
        }

        public string GetUserPhoneNumber()
        {
            return this.phoneNumber;
        }

        public string GetUserAddress()
        {
            return this.address;
        }
        public User(string id, string password, string name, string age, string phoneNumber, string address)  // 유저의 정보 입력
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
    }
}
