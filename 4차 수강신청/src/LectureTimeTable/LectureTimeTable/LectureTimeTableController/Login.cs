using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.LectureTimeTableView;

namespace LectureTimeTable.LectureTimeTableController
{
    class Login
    {
        Design design;

        public Login()
        {
            design = new Design();
        }

        public void EnterLogin()
        {
            Console.SetWindowSize(120, 35);
            design.PrintMain();
        }
    }
}
