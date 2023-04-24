using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel.VO
{
    public class USER
    {
        private string credit = "22010323";
        private string password = "password12";

        private int enrolledCredit = 0;
        private int enrolledInterestedCredit = 0;
        private int ableInterestedCredit = 24;
        private int ableEnrollCredit = 21;

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

        public int EnrolledCredit
        {
            get => this.enrolledCredit;
            set => this.enrolledCredit += value;
        }

        public int EnrolledInterestedCredit
        {
            get => this.enrolledInterestedCredit;
            set => this.enrolledInterestedCredit += value;
        }

        public int AbleInterestedCredit
        {
            get => this.ableInterestedCredit;
            set => this.ableInterestedCredit -= value;
        }
        public int AbleEnrolledCredit
        {
            get => this.ableEnrollCredit;
            set => this.ableEnrollCredit -= value;
        }
    }
}
