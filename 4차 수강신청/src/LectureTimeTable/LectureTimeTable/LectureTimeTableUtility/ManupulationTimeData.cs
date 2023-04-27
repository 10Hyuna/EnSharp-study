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

        public void manuplateTime(string TimeAndDate, int lectureIndex)
        {
            string[] splitedLectureTimeInformation;
            string splitedLectureTime;

            Lecture lectureInformation = new Lecture();

            if (TimeAndDate.Length == 0)
            {
                if (lectureInformation.LectureTimeAndDates == null)
                {
                    lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
                }

                lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
                lectureInformation.FirstDay = null;
                lectureInformation.LastDay = null;
                lectureInformation.LectureTimeAndDates[0].StartTime = 0;
                lectureInformation.LectureTimeAndDates[0].EndTime = 0;
            }
            else
            {
                splitedLectureTimeInformation = TimeAndDate.Split(',');

                if (splitedLectureTimeInformation.Length == 1)
                {
                    MatchLectureTime(splitedLectureTimeInformation, lectureInformation, lectureIndex);
                }
                else if(splitedLectureTimeInformation.Length == 2)
                {
                    UnmatchLectureTime(splitedLectureTimeInformation, lectureInformation, lectureIndex);
                }
            }
        }

        private void MatchLectureTime(string[] splitedLectureTimeInformation, Lecture lectureInformation, int lectureIndex)
        {
            string splitTime = splitedLectureTimeInformation[0].Trim();

            int lectureTime = 0;

            totalStorage.lecture[lectureIndex].FirstDay = splitTime[0].ToString();

            if(splitTime.Length == 13)
            {
                if (lectureInformation.LectureTimeAndDates == null)
                {
                    lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
                }
                lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
                lectureTime = (int.Parse(splitTime[2].ToString()) * 10 + int.Parse(splitTime[3].ToString())) * 60 
                    + (int.Parse(splitTime[5].ToString())) * 10 + int.Parse(splitTime[6].ToString());
                lectureInformation.LectureTimeAndDates[0].StartTime = lectureTime;

                lectureTime = (int.Parse(splitTime[8].ToString()) * 10 + int.Parse(splitTime[9].ToString())) * 60 
                    + (int.Parse(splitTime[11].ToString())) * 10 + int.Parse(splitTime[12].ToString());
                lectureInformation.LectureTimeAndDates[0].EndTime = lectureTime;

                totalStorage.lecture[lectureIndex].LastDay = "";
            }

            else
            {
                totalStorage.lecture[lectureIndex].LastDay = splitTime[2].ToString();

                if (lectureInformation.LectureTimeAndDates == null)
                {
                    lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
                }

                lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
                lectureTime = (int.Parse(splitTime[4].ToString()) * 10 + int.Parse(splitTime[5].ToString())) * 60 
                    + (int.Parse(splitTime[7].ToString())) * 10 + int.Parse(splitTime[8].ToString());
                lectureInformation.LectureTimeAndDates[0].StartTime = lectureTime;

                lectureTime = (int.Parse(splitTime[10].ToString()) * 10 + int.Parse(splitTime[11].ToString())) * 60 
                    + (int.Parse(splitTime[13].ToString())) * 10 + int.Parse(splitTime[14].ToString());
                lectureInformation.LectureTimeAndDates[0].EndTime = lectureTime;
            }
            totalStorage.lecture[lectureIndex].LectureTimeAndDates = lectureInformation.LectureTimeAndDates;
        }

        private void UnmatchLectureTime(string[] splitedLectureTimeInformation, Lecture lectureInformation, int lectureIndex)
        {
            string splitFirstTime = splitedLectureTimeInformation[0].Trim();
            string splitThirdTime = splitedLectureTimeInformation[1].Trim();

            int lectureTime = 0;

            totalStorage.lecture[lectureIndex].FirstDay = splitFirstTime[0].ToString();
            totalStorage.lecture[lectureIndex].LastDay = splitThirdTime[1].ToString();

            if (lectureInformation.LectureTimeAndDates == null)
            {
                lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
            }

            lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
            lectureTime = (int.Parse(splitFirstTime[2].ToString()) * 10 + int.Parse(splitFirstTime[3].ToString())) * 60 
                + int.Parse(splitFirstTime[5].ToString()) * 10 + int.Parse(splitFirstTime[6].ToString());
            lectureInformation.LectureTimeAndDates[0].StartTime = lectureTime;

            lectureTime = (int.Parse(splitFirstTime[8].ToString()) * 10 + int.Parse(splitFirstTime[9].ToString())) * 60
                + int.Parse(splitFirstTime[11].ToString()) * 10 + int.Parse(splitFirstTime[12].ToString());
            lectureInformation.LectureTimeAndDates[0].EndTime = lectureTime;

            if (lectureInformation.LectureTimeAndDates == null)
            {
                lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
            }

            lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
            lectureTime = (int.Parse(splitThirdTime[2].ToString()) * 10 + int.Parse(splitThirdTime[3].ToString())) * 60
                + int.Parse(splitThirdTime[5].ToString()) * 10 + int.Parse(splitThirdTime[6].ToString());
            lectureInformation.LectureTimeAndDates[1].StartTime = lectureTime;

            lectureTime = (int.Parse(splitThirdTime[8].ToString()) * 10 + int.Parse(splitThirdTime[9].ToString())) * 60
                + int.Parse(splitThirdTime[11].ToString()) * 10 + int.Parse(splitThirdTime[12].ToString());
            lectureInformation.LectureTimeAndDates[1].EndTime = lectureTime;
            
            totalStorage.lecture[lectureIndex].LectureTimeAndDates = lectureInformation.LectureTimeAndDates;
        }
    }
}
