using LectureTimeTable.LectureTimeTableModel;
using LectureTimeTable.LectureTimeTableUtility;
using LectureTimeTable.LectureTimeTableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.LectureTimeTableController.MainMenu
{
    public class CourseHistory
    {
        TotalStorage totalStorage;
        SaverExcelFile saverExcelFile;
        MainView mainView;
        GuidancePhrase guidancePhrase;
        InputFromUser inputFromUser;

        public CourseHistory(TotalStorage totalStorage, MainView mainView, GuidancePhrase guidancePhrase, InputFromUser inputFromUser) 
        {
            this.totalStorage = totalStorage;
            this.mainView = mainView;
            this.guidancePhrase = guidancePhrase;
            this.inputFromUser = inputFromUser;
            saverExcelFile = new SaverExcelFile(totalStorage);
        }

        public void InquireCourseHistory()
        {
            int consoleColumn = 35;
            int consoleRow = 28;

            string inputKey;
            bool isBreak = false;

            while (!isBreak)
            {
                Console.Clear();
                mainView.PrintMain();
                mainView.PrintBox(4);

                Console.SetCursorPosition(consoleColumn, consoleRow);

                guidancePhrase.PrintException((int)EXCEPTION.CHECK, consoleColumn, consoleRow);
                inputKey = inputFromUser.InputEnterESC();
                if (inputKey == "ESC")
                {
                    return;
                }

                saverExcelFile.SaveTimeTableFile();

                Console.Clear();
                mainView.PrintMain();
                mainView.PrintBox(4);

                Console.SetCursorPosition(consoleColumn, consoleRow);

                guidancePhrase.PrintException((int)EXCEPTION.COMPLETE, consoleColumn, consoleRow);
                inputKey = inputFromUser.InputEnterESC();
                if (inputKey == "ESC")
                {
                    isBreak = true;
                }
            }
        }
    }
}
