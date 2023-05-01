using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Model.DTO
{
    public class Manager
    {
        public Manager() { }
        protected string id;
        protected string password;

        public string Id
        {
            get => this.id;
            set => this.id = value;
        }

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public Manager(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
    }
}
