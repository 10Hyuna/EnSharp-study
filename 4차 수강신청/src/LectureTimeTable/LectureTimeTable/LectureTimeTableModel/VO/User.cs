using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel.VO
{
    public class USER
    {
        private string credit = "22010323";
        private string password = "password12";

        public string Id
        {
            get
            {
                return this.credit;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
        }
    }
}
