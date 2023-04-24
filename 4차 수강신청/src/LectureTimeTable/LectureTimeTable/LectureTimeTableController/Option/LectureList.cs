using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.Option
{
    public class LectureList
    {
        TotalStorage totalStorage;
        LectureDisplay lectureDisplay;
        GuidancePhrase guidancePhrase;
        public LectureList(TotalStorage totalStorage, LectureDisplay lectureDisplay, GuidancePhrase guidancePhrase)
        {
            this.totalStorage = totalStorage;
            this.lectureDisplay = lectureDisplay;
            this.guidancePhrase = guidancePhrase;
        }

        ConsoleKeyInfo keyInfo;

        bool isESC;
        public void InformLectureList(bool isEnrolled)
        {
            bool isNullStorage = false;

            lectureDisplay.PrintSearchLectureUI();
            if (!isEnrolled)
            {
                if(totalStorage.interestedLectures.Count == 0)
                {
                    isNullStorage = true;
                }
            }
            else
            {
                if (totalStorage.enrolledLectures.Count == 0)
                {
                    isNullStorage = true;
                }
            }
            if (isNullStorage)
            {
                guidancePhrase.PrintESC();
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, 0, Console.CursorTop + 1);
            }
            else
            {
                if (!isEnrolled)
                {
                    InformInterestedList();
                }
                else
                {
                    InformEnrolledList();
                }
            }
        }

        private void InformInterestedList()
        {
            isESC = false;

            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.interestedLectures[i]);
            }
            lectureDisplay.PrintLine();
            guidancePhrase.PrintESC();

            EnteredESC();
        }

        private void InformEnrolledList()
        {
            for(int i = 0; i < totalStorage.enrolledLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.enrolledLectures[i]);
            }
            lectureDisplay.PrintLine();
            guidancePhrase.PrintESC();

            EnteredESC();
        }

        private void EnteredESC()
        {
            while (!isESC)
            {
                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    isESC = true;
                }
            }
        }
    }
}
