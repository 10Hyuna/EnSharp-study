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
        private TotalStorage totalStorage;
        private bool isOverlap;
        public DuplicationLectureTime(TotalStorage totalStorage) 
        {
            this.totalStorage = totalStorage;
        }


        public bool IsCheckDuplicateTime(int lectureIndex, int standardIndex, bool isEntryMethod)
        {   // 강의 시간대의 겹침을 조사하는 함수
            bool isDuplicated = false;

            if (isEntryMethod == ConstantNumber.IS_INTERESTED)
            {       // 진입점이 관심과목 메뉴
                if (totalStorage.interestedLectures[standardIndex].LectureTimeAndDates == null)
                {
                    totalStorage.interestedLectures[standardIndex].LectureTimeAndDates = new List<LectureTimeAndDate>();
                }
                if (totalStorage.interestedLectures[standardIndex].LectureTimeAndDates.Count == 1
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                {
                    isDuplicated = IsCompareTimeOnce(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.interestedLectures[standardIndex].LectureTimeAndDates.Count == 1
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                {
                    isDuplicated = IsComparedTimeTwice(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.interestedLectures[standardIndex].LectureTimeAndDates.Count == 2
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                {
                    isDuplicated = IsComparedTimeThird(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.interestedLectures[standardIndex].LectureTimeAndDates.Count == 2
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                {
                    isDuplicated = IsComparedTimeFourth(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
            }
            else if(isEntryMethod == ConstantNumber.IS_ENROLLED)
            {       // 진입점이 수강 신청 메뉴
                if (totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates == null)
                {
                    totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates = new List<LectureTimeAndDate>();
                }
                if (totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates.Count == 1
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                {
                    isDuplicated = IsCompareEnrollTimeOnce(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates.Count == 1
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                {
                    isDuplicated = IsComparedEnrollTimeTwice(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates.Count == 2
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 1)
                {
                    isDuplicated = IsComparedEnrollTimeThird(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
                    }
                }
                else if (totalStorage.enrolledLectures[standardIndex].LectureTimeAndDates.Count == 2
                    && totalStorage.lecture[lectureIndex].LectureTimeAndDates.Count == 2)
                {
                    isDuplicated = IsComparedEnrollTimeFourth(lectureIndex, standardIndex);
                    if (isDuplicated)
                    {
                        return isDuplicated;
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
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if(standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if(comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if(standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
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
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
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
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeTwice(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareEnrollTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[0].EndTime;

            if (standardStartTime == comparisonStartTime)
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
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
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeThird(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsCompareEnrollTimeOnce(standardIndex, comparisonIndex);

            if (isOverlap)
            {
                return isOverlap;
            }
            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[0].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
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
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
                    isOverlap = true;
                }
            }
            return isOverlap;
        }

        private bool IsComparedEnrollTimeFourth(int standardIndex, int comparisonIndex)
        {
            isOverlap = false;

            isOverlap = IsComparedEnrollTimeTwice(standardIndex, comparisonIndex);
            if (isOverlap)
            {
                return isOverlap;
            }

            isOverlap = IsComparedEnrollTimeThird(standardIndex, comparisonIndex);
            if (isOverlap)
            {
                return isOverlap;
            }

            int standardStartTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].StartTime;
            int standardEndTime = totalStorage.lecture[standardIndex].LectureTimeAndDates[1].EndTime;
            int comparisonStartTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].StartTime;
            int comparisonEndTime = totalStorage.enrolledLectures[comparisonIndex].LectureTimeAndDates[1].EndTime;

            if (standardStartTime == comparisonStartTime)
            {   // 시작하는 시간대가 같다면 무조건 중복
                isOverlap = true;
            }
            else if (standardStartTime > comparisonStartTime)
            {   // 먼저 시작하는 수업의 시작시간이
                if (comparisonEndTime - standardStartTime > 0)
                {   // 늦게 시작하는 수업의 종료 시간보다 작다면 중복
                    isOverlap = true;
                }
            }
            else if (standardStartTime < comparisonStartTime)
            {   // 늦게 시작하는 수업의 종료 시간이
                if (standardEndTime - comparisonStartTime > 0)
                {   // 일찍 시작하는 수업의 시작 시간보다 크다면 중복
                    isOverlap = true;
                }
            }
            return isOverlap;
        }
    }
}
