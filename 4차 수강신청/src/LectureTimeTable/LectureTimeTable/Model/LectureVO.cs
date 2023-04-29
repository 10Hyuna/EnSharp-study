using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class LectureVO
    {
        private int id;
        private string major;
        private string courseNumber;
        private string lectureTitle;
        private string classNumber;
        private string completeType;
        private string grade;
        private string credit;
        private string dateAndTime;
        private string lectureRoom;
        private string professor;
        private string language;
        private string firstDay;
        private string lastDay;
        private List<LectureTimeAndDate> lectureTimeAndDates;

        public LectureVO() { }
        public LectureVO(int id, string major, string courseNumber, string classNumber, string lectureTitle, string completeType, string grade, string credit, string dateAndTime, 
            string lectureRoom, string professor, string language, List<LectureTimeAndDate> lectureTimeAndDates)
        {
            this.id = id;
            this.major = major;
            this.courseNumber = courseNumber;
            this.classNumber = classNumber;
            this.lectureTitle = lectureTitle;
            this.completeType = completeType;
            this.grade = grade;
            this.credit = credit;
            this.dateAndTime = dateAndTime;
            this.lectureRoom = lectureRoom;
            this.professor = professor;
            this.language = language;
            this.lectureTimeAndDates = lectureTimeAndDates;

            if(this.lectureTimeAndDates != null)
            {
                this.lectureTimeAndDates = new List<LectureTimeAndDate>();
            }
        }

        public int Id
        {
            get => this.id;
        }

        public string Major
        {
            get => this.major;
        }

        public string CourseNumber
        {
            get => this.courseNumber;
        }

        public string ClassNumber
        {
            get => this.classNumber;
        }

        public string LectureTitle
        {
            get => this.lectureTitle;
        }

        public string CompleteType
        {
            get => this.completeType;
        }

        public string Grade
        {
            get => this.grade;
            set => this.grade = value;
        }

        public string Credit
        {
            get => this.credit;
        }
        public string DateAndTime
        {
            get => this.dateAndTime;
        }

        public string LectureRoom
        {
            get => this.lectureRoom;
        }

        public string Professor
        {
            get => this.professor;
        }

        public string Language
        {
            get => this.language;
        }
        public string FirstDay
        {
            get => this.firstDay; 
            set => this.firstDay = value;
        }

        public string LastDay
        {
            get => this.lastDay; 
            set => this.lastDay = value;
        }
        public List<LectureTimeAndDate> LectureTimeAndDates
        {
            get => this.lectureTimeAndDates;
            set => this.lectureTimeAndDates = value;
        }
    }

    public class LectureTimeAndDate
    {
        private int startTime;
        private int endTime;

        public int StartTime
        {
            get => this.startTime;
            set => this.startTime = value;
        }

        public int EndTime
        {
            get => this.endTime; 
            set => this.endTime = value;
        }
    }
}