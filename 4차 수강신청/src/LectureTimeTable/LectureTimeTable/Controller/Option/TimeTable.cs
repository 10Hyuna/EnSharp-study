﻿using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableView;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.Option
{
    public class TimeTable
    {
        private TotalStorage totalStorage;
        private LectureDisplay lectureDisplay;
        private string lectureDay;
        private int initiativeColumn;
        private int lastColumn;
        private int initiativeRow;
        private int lastRow;
        private int hour;
        private int minute;

        public TimeTable(TotalStorage totalStorage, LectureDisplay lectureDisplay)
        {
            this.totalStorage = totalStorage;
            this.lectureDisplay = lectureDisplay;
        }


        public void CheckSchedule(bool isEnrolled)
        {
            ConsoleKeyInfo keyInfo;
            bool isESC = false;
            while (!isESC)
            {
                Console.Clear();
                lectureDisplay.PrintTimeTable();

                if (isEnrolled)
                {
                    for (int i = 0; i < totalStorage.enrolledLectures.Count; i++)
                    {
                        SetCursor(totalStorage.enrolledLectures[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < totalStorage.interestedLectures.Count; i++)
                    {
                        SetCursor(totalStorage.interestedLectures[i]);
                    }
                }
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isESC = true;
                }
            }
        }
        private void SetCursor(LectureVO lecture)
        {
            string day;
            int initiativeHour;
            int initiativeMinute;
            int lastHour;
            int lastMinute;

            string[] splitString = lecture.DateAndTime.Split(',');

            if(splitString.Length == 2 )
            {
                switch (lecture.FirstDay)
                {
                    case "월":
                        initiativeColumn = 21;
                        break;
                    case "화":
                        initiativeColumn = 21 + (36 * 1);
                        break;
                    case "수":
                        initiativeColumn = 21 + (36 * 2);
                        break;
                    case "목":
                        initiativeColumn = 21 + (36 * 3);
                        break;
                    case "금":
                        initiativeColumn = 21 + (36 * 4);
                        break;
                }

                initiativeHour = lecture.LectureTimeAndDates[0].StartTime / 60;
                initiativeMinute = lecture.LectureTimeAndDates[0].StartTime % 60;

                initiativeRow = 2 + (initiativeHour - 8) * 4;
                if (initiativeMinute != 0)
                {
                    initiativeRow += 2;
                }
                for (int i = lecture.LectureTimeAndDates[0].StartTime; i < lecture.LectureTimeAndDates[0].EndTime; i += 30)
                {
                    Console.SetCursorPosition(initiativeColumn, initiativeRow);
                    lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                    initiativeRow += 2;
                }

                switch (lecture.LastDay)
                {
                    case "월":
                        initiativeColumn = 21;
                        break;
                    case "화":
                        initiativeColumn = 21 + (36 * 1);
                        break;
                    case "수":
                        initiativeColumn = 21 + (36 * 2);
                        break;
                    case "목":
                        initiativeColumn = 21 + (36 * 3);
                        break;
                    case "금":
                        initiativeColumn = 21 + (36 * 4);
                        break;
                }

                initiativeHour = lecture.LectureTimeAndDates[1].StartTime / 60;
                initiativeMinute = lecture.LectureTimeAndDates[1].StartTime % 60;

                initiativeRow = 2 + (initiativeHour - 8) * 4;
                if (initiativeMinute != 0)
                {
                    initiativeRow += 2;
                }
                for (int i = lecture.LectureTimeAndDates[1].StartTime; i < lecture.LectureTimeAndDates[1].EndTime; i += 30)
                {
                    Console.SetCursorPosition(initiativeColumn, initiativeRow);
                    lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                    initiativeRow += 2;
                }
                return;
            }

            if(lecture.DateAndTime == "")
            {
                Console.SetCursorPosition(12, 50);
                lectureDisplay.PrintLecture(lecture.LectureTitle, "");
                return;
            }
            switch (lecture.FirstDay)
            {
                case "월":
                    initiativeColumn = 21;
                    break;
                case "화":
                    initiativeColumn = 21 + (36 * 1);
                    break;
                case "수":
                    initiativeColumn = 21 + (36 * 2);
                    break;
                case "목":
                    initiativeColumn = 21 + (36 * 3);
                    break;
                case "금":
                    initiativeColumn = 21 + (36 * 4);
                    break;
            }

            initiativeHour = lecture.LectureTimeAndDates[0].StartTime / 60;
            initiativeMinute = lecture.LectureTimeAndDates[0].StartTime % 60;

            initiativeRow = 2 + (initiativeHour - 8) * 4;
            if (initiativeMinute != 0)
            {
                initiativeRow += 2;
            }
            for (int i = lecture.LectureTimeAndDates[0].StartTime; i < lecture.LectureTimeAndDates[0].EndTime; i += 30)
            {
                Console.SetCursorPosition(initiativeColumn, initiativeRow);
                lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                initiativeRow += 2;
            }

            if (lecture.LectureTimeAndDates.Count == 2)
            {
                initiativeHour = lecture.LectureTimeAndDates[1].StartTime / 60;
                initiativeMinute = lecture.LectureTimeAndDates[1].StartTime % 60;

                initiativeRow = 2 + (initiativeHour - 8) * 4;
                if (initiativeMinute != 0)
                {
                    initiativeRow += 2;
                }

                for (int i = lecture.LectureTimeAndDates[1].StartTime; i < lecture.LectureTimeAndDates[1].EndTime; i += 30)
                {
                    Console.SetCursorPosition(initiativeColumn, initiativeRow);
                    lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                    initiativeRow += 2;
                }
            }
            if(lecture.LastDay != "")
            {
                switch (lecture.LastDay)
                {
                    case "월":
                        initiativeColumn = 21;
                        break;
                    case "화":
                        initiativeColumn = 21 + (36 * 1);
                        break;
                    case "수":
                        initiativeColumn = 21 + (36 * 2);
                        break;
                    case "목":
                        initiativeColumn = 21 + (36 * 3);
                        break;
                    case "금":
                        initiativeColumn = 21 + (36 * 4);
                        break;
                }

                initiativeHour = lecture.LectureTimeAndDates[0].StartTime / 60;
                initiativeMinute = lecture.LectureTimeAndDates[0].StartTime % 60;

                initiativeRow = 2 + (initiativeHour - 8) * 4;
                if (initiativeMinute != 0)
                {
                    initiativeRow += 2;
                }
                for (int i = lecture.LectureTimeAndDates[0].StartTime; i < lecture.LectureTimeAndDates[0].EndTime; i += 30)
                {
                    Console.SetCursorPosition(initiativeColumn, initiativeRow);
                    lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                    initiativeRow += 2;
                }

                if (lecture.LectureTimeAndDates.Count == 2)
                {
                    initiativeHour = lecture.LectureTimeAndDates[1].StartTime / 60;
                    initiativeMinute = lecture.LectureTimeAndDates[1].StartTime % 60;

                    initiativeRow = 2 + (initiativeHour - 8) * 4;
                    if (initiativeMinute != 0)
                    {
                        initiativeRow += 2;
                    }

                    for (int i = lecture.LectureTimeAndDates[1].StartTime; i < lecture.LectureTimeAndDates[1].EndTime; i += 30)
                    {
                        Console.SetCursorPosition(initiativeColumn, initiativeRow);
                        lectureDisplay.PrintLecture(lecture.LectureTitle, lecture.LectureRoom);
                        initiativeRow += 2;
                    }
                }
            }
        }
    }
}