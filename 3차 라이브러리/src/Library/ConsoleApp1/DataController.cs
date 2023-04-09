using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class DataController
    {
        public List<BookData> books = new List<BookData>();
        public List<MemberData> members = new List<MemberData>();
    }

    class BookData
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }
        public string amount { get; set; }
        public string price { get; set; }
        public string publishDay { get; set; }
        public string ISBN { get; set; }
        public string information { get; set; }
    }

    class MemberData
    {
        public string id { get; set;}
        public string password { get; set;}
        public string name { get; set;}
        public string age { get; set;}
        public string phoneNumber { get; set;}
        public string address { get; set;}
    }

    class UserData : MemberData
    {

        public UserData(string id, string password, string name, string age, string phoneNumber, string address)
        {
            this.id = id;
            this.password = password;
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }
    }

    class ManagerData : MemberData
    {
        public ManagerData(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
    }
}
