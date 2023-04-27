using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableModel
{
    public class Lecture
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
        private List<LectureTimeAndDate> lectureTimeAndDate;

        public Lecture() { }
        public Lecture(int id, string major, string courseNumber, string classNumber, string lectureTitle, string completeType, string grade, string credit, string dateAndTime, string lectureRoom, string professor, string language)
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
        }

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

    public class LectureTimeAndDate
    {
        private int startTime;
        private int endTime;
        private string firstDay;
        private string lastDay;

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
    }
}