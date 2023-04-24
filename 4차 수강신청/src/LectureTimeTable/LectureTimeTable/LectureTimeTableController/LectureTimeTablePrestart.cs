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
            // 로그인, 로그아웃 이후에도 데이터가 유지될 수 있도록 바깥에서 관리
        }

        public void Start()
        {   // 로그인으로 진입
            Login login = new Login(totalStorage);
            login.EnterLogin();
        }
    }
}
