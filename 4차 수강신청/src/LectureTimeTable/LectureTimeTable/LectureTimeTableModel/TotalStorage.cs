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
            Lecture lecture = new Lecture();
            SearchResults searchResults = new SearchResults();
            USER user = new USER();
            EnrolledLecture enrolledLecture = new EnrolledLecture();
            InterestedLecture interestedLecture = new InterestedLecture();

        }

        public List<Lecture> lecture = new List<Lecture>();
        public List<SearchResults> searchResult = new List<SearchResults>();
        public List<USER> user = new List<USER>();
        public List<EnrolledLecture> enrolledLectures = new List<EnrolledLecture>();
        public List<InterestedLecture> interestedLectures = new List<InterestedLecture>();
    }
}
