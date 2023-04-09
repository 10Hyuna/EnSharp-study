using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class DataController
    {

    }

    class BookData
    {

        public List<string> title { get; set; }
        public List<string> author { get; set; }
        public List<string> publisher { get; set; }
        public List<int> amount { get; set; }
        public List<int> price { get; set; }
        public List<string> publishDay { get; set; }
        public List<int> ISBN { get; set; }
        public List<string> information { get; set; }
    }

    class MemberData
    {
        public List<string> id { get; set;}
        public List<string> password { get; set;}
        public List<string> name { get; set;}
        public List<int> age { get; set;}
        public List<string> phoneNumber { get; set;}
        public List<string> address { get; set;}

    }

    class UserData : MemberData
    {
        public void InsertID(string id)
        {
            this.id.Add(id);
        }

        public void InsertPassword(string pw)
        {
            this.password.Add(pw);
        }

        public 
    }

    class ManagerData : MemberData
    {

    }
}
