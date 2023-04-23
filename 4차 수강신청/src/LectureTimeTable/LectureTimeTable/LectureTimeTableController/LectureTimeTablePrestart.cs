using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController
{
    public class LectureTimeTablePrestart
    {
        private TotalStorage totalStorage;

        public LectureTimeTablePrestart()
        {
            totalStorage = new TotalStorage();
        }

        public void Start()
        {
            Login login = new Login(totalStorage);
            login.EnterLogin();
        }
    }
}
