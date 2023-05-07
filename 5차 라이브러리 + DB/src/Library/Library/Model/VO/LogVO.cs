using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.VO
{
    public class LogVO
    {
        private int id;
        private string time;
        private string user;
        private string information;
        private string action;

        public LogVO() { }
        public LogVO(int id, string time, string user, string information, string action)
        {
            this.id = id;
            this.time = time;
            this.user = user;
            this.information = information;
            this.action = action;
        }

        public LogVO(string time, string user, string information, string action)
        {
            this.time = time;
            this.user = user;
            this.information = information;
            this.action = action;
        }

        public int Id
        {
            get => this.id;
        }

        public string Time
        {
            get => this.time;
        }

        public string User
        {
            get => this.user;
        }

        public string Information
        {
            get => this.information;
        }

        public string Action
        {
            get => this.action;
        }
    }
}
