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
    public class LectureList
    {
        private TotalStorage totalStorage;
        private LectureDisplay lectureDisplay;
        private GuidancePhrase guidancePhrase;
        private InputFromUser inputFromUser;
        private ConsoleKeyInfo keyInfo;
        private bool isESC;

        public LectureList(TotalStorage totalStorage, LectureDisplay lectureDisplay, GuidancePhrase guidancePhrase)
        {
            this.totalStorage = totalStorage;
            this.lectureDisplay = lectureDisplay;
            this.guidancePhrase = guidancePhrase;
            inputFromUser = new InputFromUser();
        }

        public void InformLectureList(bool isEnrolled)
        {
            bool isNullStorage = false;

            lectureDisplay.PrintSearchLectureUI();

            if (!isEnrolled)
            {   // 관심과목 메뉴에서 진입했다면
                if(totalStorage.interestedLectures.Count == 0)
                {   // 관심과목에 아무 강의도 없다면
                    isNullStorage = true;
                }
            }
            else
            {   // 수강신청 메뉴에서 진입했다면
                if (totalStorage.enrolledLectures.Count == 0)
                {   // 수강신청에 아무 강의도 없다면
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
                {   // 관심과목 메뉴에서 진입했을 경우
                    InformInterestedList();
                }
                else
                {   // 수강신청 메뉴에서 진입했을 경우
                    InformEnrolledList();
                }
            }
            Console.Clear();
        }

        private void InformInterestedList()
        {
            isESC = false;

            for(int i = 0; i < totalStorage.interestedLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.interestedLectures[i]);
            }
            lectureDisplay.PrintLine();
            lectureDisplay.PrintCredit(totalStorage.user);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            guidancePhrase.PrintESC();


            isESC = inputFromUser.EnteredESC();
        }

        private void InformEnrolledList()
        {
            for(int i = 0; i < totalStorage.enrolledLectures.Count; i++)
            {
                lectureDisplay.PrintSearchLecture(totalStorage.enrolledLectures[i]);
            }
            lectureDisplay.PrintLine();
            lectureDisplay.PrintCredit(totalStorage.user);
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            guidancePhrase.PrintESC();

            isESC = inputFromUser.EnteredESC();
        }
    }
}
