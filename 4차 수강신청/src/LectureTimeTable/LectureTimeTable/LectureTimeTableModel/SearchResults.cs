using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class SearchResults
    {
        private string major;
        private string completeType;
        private string lectureTitle;
        private string professor;
        private string grade;
        private string courseNumber;

        public string Major
        {
            get
            {
                return major;
            }
            set
            {
                major = value;
            }
        }

        public string CompleteType
        {
            get
            {
                return completeType;
            }
            set
            {
                completeType = value;
            }
        }

        public string LectureTitle
        {
            get
            {
                return lectureTitle;
            }
            set
            {
                lectureTitle = value;
            }
        }

        public string Professor
        {
            get
            {
                return professor;
            }
            set
            {
                professor = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }

        public string CourseNumber
        {
            get
            {
                return courseNumber;
            }
            set
            {
                courseNumber = value;
            }
        }
    }
}
