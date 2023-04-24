using LectureTimeTable.LectureTimeTableModel.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class TotalStorage
    {
        public TotalStorage()
        {
            lecture = new List<Lecture>();
            searchResult = new SearchResults();
            user = new USER();
            enrolledLectures = new List<Lecture>();
            interestedLectures = new List<Lecture>();
        }

        public List<Lecture> lecture;
        public SearchResults searchResult;
        public USER user;
        public List<Lecture> enrolledLectures;
        public List<Lecture> interestedLectures;
    }
}
