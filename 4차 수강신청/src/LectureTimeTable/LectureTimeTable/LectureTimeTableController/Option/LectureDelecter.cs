using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.Option
{
    public class LectureDelecter
    {
        LectureDisplay lectureDisplay;
        TotalStorage totalStorage;
        ExceptionHandler exceptionHandler;
        GuidancePhrase guidancePhrase;
        public LectureDelecter(LectureDisplay lectureDisplay, TotalStorage totalStorage, ExceptionHandler exceptionHandler, GuidancePhrase guidancePhrase)
        {
            this.lectureDisplay = lectureDisplay;
            this.totalStorage = totalStorage;
            this.exceptionHandler = exceptionHandler;
            this.guidancePhrase = guidancePhrase;
        }

        public void DelectLectureList(bool isEnrolled)
        {
            bool isESC = false;

            lectureDisplay.PrintSearchLectureUI();
            lectureDisplay.PrintLine();

            string lectureNumber;
            int numberNo;

            while (!isESC)
            {
                if (!isEnrolled)
                {

                }
                Console.SetCursorPosition(0, Console.CursorTop + 1);
                lectureDisplay.PrintDelectInterestedCredit(totalStorage.user);
                guidancePhrase.PrintException((int)EXCEPTION.NULL_STORAGE, Console.CursorLeft, Console.CursorTop);

                if(totalStorage.interestedLectures.Count == 0) 
                {

                }

                lectureNumber = exceptionHandler.IsValid(ConstantNumber.NUMBER, Console.CursorLeft, Console.CursorTop, 3, ConstantNumber.IS_NOT_PASSWORD, ConstantNumber.IS_NOT_ID);

                if(lectureNumber == ConstantNumber.ESC)
                {
                    isESC = true;
                }
                else
                {
                    numberNo = int.Parse(lectureNumber);
                    if (!FindDelectLectureIndex(numberNo))
                    {

                        continue;
                    }
                    else
                    {
                        totalStorage.interestedLectures.RemoveAt(numberNo - 1);

                    }
                }

            }
        }

        private bool FindDelectLectureIndex(int number)
        {
            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                if (totalStorage.interestedLectures[i].Id == number)
                    return true;
            }
            return false;
        }

        private bool DelectInterestedLecture()
        {

        }
    }
}
