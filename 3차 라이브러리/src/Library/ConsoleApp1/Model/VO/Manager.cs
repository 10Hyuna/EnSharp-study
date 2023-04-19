using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Model.VO
{
    class Manager
    {
        public Manager() { }
        protected string id;
        protected string password;

        public string GetId()
        {
            return this.id;
        }

        public string GetPassword()
        {
            return this.password;
        }
        public Manager(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
    }
}
