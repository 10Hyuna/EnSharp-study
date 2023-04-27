using LectureTimeTable.LectureTimeTableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableUtility
{
    public class ManupulationTimeData
    {

        private TotalStorage totalStorage;

        public ManupulationTimeData(TotalStorage totalStorage)
        {
            this.totalStorage = totalStorage;
        }

        public void manuplateTime(string TimeAndDate)
        {
            string[] splitedLectureTimeInformation;
            string splitedLectureTime;

            LectureTimeAndDate lectureTimeAndDate = new LectureTimeAndDate();

            if(TimeAndDate.Length == 0)
            {
                lectureTimeAndDate.StartTime = 0;
                lectureTimeAndDate.EndTime = 0;
                lectureTimeAndDate.FirstDay = "";
                lectureTimeAndDate.LastDay = "";
            }

            splitedLectureTimeInformation = TimeAndDate.Split(',');

            if (splitedLectureTimeInformation.Length == 1)
            {
                MatchLectureTime(splitedLectureTimeInformation);
            }
            else if(splitedLectureTimeInformation.Length == 2)
            {
                UnmatchLectureTime(splitedLectureTimeInformation);
            }
        }

        private void MatchLectureTime(string[] splitedLectureTimeInformation)
        {
            string splitTime = splitedLectureTimeInformation[0].Trim();


        }

        private void UnmatchLectureTime(string[] splitedLectureTimeInformation)
        {
            string splitTime = splitedLectureTimeInformation[0].Trim();


        }
    }
}
