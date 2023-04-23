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
            Lecture totalLecture = new Lecture();
            SearchResults searchResults = new SearchResults();
        }

        public List<Lecture> totalLecture = new List<Lecture>();
        public List<SearchResults> searchResult = new List<SearchResults>();

    }
}
