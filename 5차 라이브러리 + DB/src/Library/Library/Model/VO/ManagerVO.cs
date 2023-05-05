using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.VO
{
    public class ManagerVO
    {
        private string id = "";
        private string password = "";

        public ManagerVO(string id, string password)
        {
            this.id = id;
            this.password = password;
        }

        public string Id
        {
            get => this.id;
        }

        public string Password
        {
            get => this.password;
        }
    }
}
