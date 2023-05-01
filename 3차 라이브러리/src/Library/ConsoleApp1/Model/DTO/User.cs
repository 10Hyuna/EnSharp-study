using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    public class User
    {

        public User() { }

        private string loggedInId;
        protected string id;
        protected string password;
        protected string name;
        protected string age;
        protected string phoneNumber;
        protected string address;
        protected List<BorrowBookList> borrowDatas = new List<BorrowBookList>();
        protected List<ReturnBookList> returnDatas = new List<ReturnBookList>();

        public string LoggedInId
        {
            get => this.loggedInId;
            set => this.loggedInId = value;
        }
        public void SetId(string id)
        {
            this.id = id;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetName(string Name)
        {
            this.name = name;
        }

        public void SetAge(string Age)
        {
            this.age = Age;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SetAddress(string Address)
        {
            this.address = Address;
        }

        public string GetId()
        {
            return this.id;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetAge()
        {
            return this.age;
        }

        public string GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        public string GetAddress()
        {
            return this.address;
        }

        public List<BorrowBookList> BorrowDatas
        {
            get
            {
                return this.borrowDatas;
            }

            set
            { 
                this.borrowDatas = value;
            }
        }

        public List<ReturnBookList> ReturnDatas
        {
            get
            {
                return this.returnDatas;
            }

            set
            {
                this.returnDatas = value;
            }
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

        public User (string id, string password)
        {
            this.id = id;
            this.password = password;
        }
    }
}
