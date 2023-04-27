using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController
{
    public class DuplicationLectureTime
    {
        TotalStorage totalStorage;
        public DuplicationLectureTime(TotalStorage totalStorage) 
        {
            this.totalStorage = totalStorage;
        }

        bool isOverlap;

        public bool IsCheckDuplicateTime(int lectureIndex, bool isEntryMethod)
        {
            bool isDuplicated = false;

            if (isEntryMethod == ConstantNumber.IS_INTERESTED)
            {
                for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
                {
                    if (totalStorage.interestedLectures[i].LectureTimeAndDates == null)
                    {
                        totalStorage.interestedLectures[i].LectureTimeAndDates = new List<LectureTimeAndDate>();
                    }
                    if (totalStorage.interestedLectures[i].LectureTimeAndDates.Count == 1
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                    {
                        isDuplicated = IsCompareTimeOnce(lectureIndex, i);
                    }
                    else if (totalStorage.interestedLectures[i].LectureTimeAndDates.Count == 1
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                    {
                        isDuplicated = IsComparedTimeTwice(lectureIndex, i);
                    }
                    else if(totalStorage.interestedLectures[i].LectureTimeAndDates.Count == 2
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                    {
                        isDuplicated = IsComparedTimeThird(lectureIndex, i);
                    }
                    else if(totalStorage.interestedLectures[i].LectureTimeAndDates.Count == 2
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                    {
                        isDuplicated = IsComparedTimeFourth(lectureIndex, i);
                    }
                }
            }
            else if(isEntryMethod == ConstantNumber.IS_ENROLLED)
            {
                for (int i = 0; i < totalStorage.interestedLectures.Count; i++)
                {
                    if (totalStorage.enrolledLectures[i].LectureTimeAndDates == null)
                    {
                        totalStorage.enrolledLectures[i].LectureTimeAndDates = new List<LectureTimeAndDate>();
                    }
                    if (totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 1
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                    {
                        isDuplicated = IsCompareEnrollTimeOnce(lectureIndex, i);
                    }
                    else if (totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 1
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                    {
                        isDuplicated = IsComparedEnrollTimeTwice(lectureIndex, i);
                    }
                    else if (totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 2
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                    {
                        isDuplicated = IsComparedEnrollTimeThird(lectureIndex, i);
                    }
                    else if (totalStorage.enrolledLectures[i].LectureTimeAndDates.Count == 2
                        && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                    {
                        isDuplicated = IsComparedEnrollTimeFourth(lectureIndex, i);
                    }
                }
            }
            return isDuplicated;
        }

        private bool IsCompareTimeOnce(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].EndTime;
            int comparisonStartTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[0].StartTime;
            int comparisonEndTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[0].EndTime;

            if(standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if(standardStartTime > comparisonStartTime)
            {
                if(comparisonEndTime - standardStartTime > 0)
                {
                    isOverlap = true;
                }
            }
            else if(standardStartTime < comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime > 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsCompareEnrollTimeOnce(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedTimeTwice(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[0].StartTime;
            int comparisonEndTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[0].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeTwice(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedTimeThird(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }
            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].EndTime;
            int comparisonStartTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeThird(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }
            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedTimeFourth(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsComparedTimeTwice(standardIndex, comparisonIndex);
            if(isOverlap)
            {
                return isOverlap;
            }

            isOverlap = IsComparedTimeThird(standardIndex, comparisonIndex);
            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.interestedLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeFourth(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsComparedTimeTwice(standardIndex, comparisonIndex);
            if (isOverlap)
            {
                return isOverlap;
            }

            isOverlap = IsComparedTimeThird(standardIndex, comparisonIndex);
            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {
                if (standardEndTime - comparisonStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {
                if (comparisonEndTime - standardStartTime < 0)
                {
                    isOverlap = true;
                }
            }
            return isOverlap;
        }
    }
}
