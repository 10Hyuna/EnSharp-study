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
        {   // 강의 시간에 대한 정보를 조작하는 함수
            string[] splitedLectureTimeInformation;
            string splitedLectureTime;

            Lecture lectureInformation = new Lecture();

            if (TimeAndDate.Length == 0)
            {   // 시간이 비어 있다면
                if (lectureInformation.LectureTimeAndDates == null)
                {
                    lectureInformation.LectureTimeAndDates = new List<LectureTimeAndDate>();
                }

                lectureInformation.LectureTimeAndDates.Add(new LectureTimeAndDate());
                lectureInformation.FirstDay = null;
                lectureInformation.LastDay = null;
                lectureInformation.LectureTimeAndDates[0].StartTime = 0;
                lectureInformation.LectureTimeAndDates[0].EndTime = 0;
                // 모두 빈 값으로 초기화
            }
            else
            {
                splitedLectureTimeInformation = TimeAndDate.Split(',');

                if (splitedLectureTimeInformation.Length == 1)
                {   // 쉼표로 구분되는 문자열이 하나뿐이라면
                    MatchLectureTime(splitedLectureTimeInformation, lectureInformation, lectureIndex);
                    // 강의 시간 두 개가 서로 같은 경우의 수
                }
                else if(splitedLectureTimeInformation.Length == 2)
                {   // 쉼표로 구분되는 문자열이 두 개라면
                    UnmatchLectureTime(splitedLectureTimeInformation, lectureInformation, lectureIndex);
                    // 강의 시간 두 개가 서로 다른 경우의 수
                }
            }
        }

        private void MatchLectureTime(string[] splitedLectureTimeInformation, Lecture lectureInformation, int lectureIndex)
        {
            string splitTime = splitedLectureTimeInformation[0];

            int lectureTime = 0;

            totalStorage.lecture[lectureIndex].FirstDay = splitTime[0].ToString();

            if(splitTime.Length == 13)
            {   // 길이가 13개라면, 강의 날짜와 시간대 모두 한 가지
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
                // 두 번째 강의 날은 없는 날
            }

            else
            {
                // 두 번째 강의도 존재하는 경우의 수 
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
            // 쉼표로 구분해서 자른 문자열은 앞에 공백이 하나 있기 때문에 Trim 메소드로 앞뒤 공백 제거

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
