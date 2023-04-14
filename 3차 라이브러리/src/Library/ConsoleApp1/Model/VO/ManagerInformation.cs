using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Model.VO
{
    class ManagerInformation
    {
        public ManagerInformation() { }
        public ManagerInformation(string id, string password)
        {
            this.id = id;
            this.password = password;
        }
        public string id { get; }
        public string password { get; }

    }
}
