using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class SearchResultsDTO
    {
        private string major = "";
        private string completeType = "";
        private string lectureTitle = "";
        private string professor = "";
        private string grade = "";
        private string courseNumber = "";

        public SearchResultsDTO() { }

        public SearchResultsDTO(string major, string completeType, string lectureTitle, string professor, string grade, string courseNumber)
        {
            this.major = major;
            this.completeType = completeType;
            this.lectureTitle = lectureTitle;
            this.professor = professor;
            this.grade = grade;
            this.courseNumber = courseNumber;
        }

        public string Major
        {
            get => this.major; 
            set => this.major = value;
        }

        public string CompleteType
        {
            get => this.completeType;
            set => this.completeType = value;
        }

        public string LectureTitle
        {
            get => this.lectureTitle;
            set => this.lectureTitle = value;
        }

        public string Professor
        {
            get => this.professor;
            set => this.professor = value;
        }

        public string Grade
        {
            get => this.grade; 
            set => this.grade = value;
        }

        public string CourseNumber
        {
            get => this.courseNumber; 
            set => this.courseNumber = value;
        }
    }
}
