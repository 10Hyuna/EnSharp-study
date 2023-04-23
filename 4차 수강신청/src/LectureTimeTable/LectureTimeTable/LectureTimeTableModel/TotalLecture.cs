using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class TotalLecture
    {
        private int id;
        private string major;
        private string courseNumber;
        private string classNumber;
        private string lectureTitle;
        private string completeType;
        private string grade;
        private string credit;
        private string dateAndTime;
        private string lectureRoom;
        private string professor;
        private string language;

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }

        public string Major
        {
            get => this.major;
            set => this.major = value;
        }

        public string CourseNumber
        {
            get => this.courseNumber; 
            set => this.courseNumber = value;
        }

        public string ClassNumber
        {
            get => this.classNumber;
            set => this.classNumber = value;
        }

        public string LectureTitle
        {
            get => this.lectureTitle;
            set => this.lectureTitle = value;
        }

        public string CompleteType
        {
            get => this.completeType; 
            set => this.completeType = value;
        }

        public string Grade
        {
            get => this.grade;
            set => this.grade = value;
        }

        public string Credit
        {
            get => this.credit; 
            set => this.credit = value;
        }
        public string DateAndTime
        {
            get => this.dateAndTime; 
            set => this.dateAndTime = value;
        }

        public string LectureRoom
        {
            get => this.lectureRoom;
            set => this.lectureRoom = value;
        }

        public string Professor
        {
            get => this.professor;
            set => this.professor = value;
        }

        public string Language
        {
            get => this.language;
            set => this.language = value;
        }
    }

    public class EnrolledLecture : TotalLecture
    {

    }

    public class InterestedLecture : TotalLecture
    {

    }
}
