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
            lecture = new List<LectureVO>();
            searchResult = new SearchResultsDTO();
            user = new USER();
            enrolledLectures = new List<LectureVO>();
            interestedLectures = new List<LectureVO>();
        }

        public List<LectureVO> lecture;
        public SearchResultsDTO searchResult;
        public USER user;
        public List<LectureVO> enrolledLectures;
        public List<LectureVO> interestedLectures;
    }
}
