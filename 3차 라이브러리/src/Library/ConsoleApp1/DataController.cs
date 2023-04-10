using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class DataController        // 데이터 관리
    {
        public List<BookData> books = new List<BookData>();
        public List<MemberData> members = new List<MemberData>();
    }

    class BookData          // 책 정보
    { 
        public int ID;
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string publishDay { get; set; }
        public string ISBN { get; set; }
        public string information { get; set; }

        public BookData(int id, string title, string author, string publisher, string amount, string price, string publishDay, string ISBN, string information)   // 책 정보를 입력
        {
            this.ID = id;
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.amount = amount;
            this.price = price;
            this.publishDay = publishDay;
            this.ISBN = ISBN;
            this.information = information;
        }
    }

    class MemberData        // 회원 정보
    {
        public string id { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string age { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }

        public List<BorrowData> borrowDatas = new List<BorrowData>();

        public List<ReturnData> returnDatas = new List<ReturnData>();
        public MemberData(string id, string password, string name, string age, string phoneNumber, string address)  // 유저의 정보 입력
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
        public MemberData(string id, string password)       // 매니저의 정보 입력
        {
            this.id = id;
            this.password = password;
        }
    }

    class BorrowData
    {
    }

    class ReturnData
    {

    }
}
