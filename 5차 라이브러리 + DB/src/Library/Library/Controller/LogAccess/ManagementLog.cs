using Library.Model.DAO;
using Library.Model.VO;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Org.BouncyCastle.Crypto;
using System.Net.WebSockets;

namespace Library.Controller.LogAccess
{
    public class ManagementLog
    {
        PrintLogInformation printLogInformation;
        public ManagementLog()
        {
            printLogInformation = new PrintLogInformation();
        }

        public void ModifyLog()
        {
            List<LogVO> logs = new List<LogVO>();

            string logId;
            int logNumber;

            bool isESC = true;

            Console.Clear();
            printLogInformation.ModifyUI();

            int column = 45;
            int row = 2;

            Console.SetWindowSize(76, 40);

            while(isESC)
            {
                isESC = false;
                logs = AccessorData.GetAccessorData().SelectLog();
                Console.SetCursorPosition(0, 6);
                printLogInformation.PrintLog(logs);

                logId = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD);

                if(logId == Constant.ESC_STRING)
                {
                    continue;
                }
                else if (!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(logId) || logId == "")
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                Console.SetCursorPosition(0, 0);
                logNumber = int.Parse(logId);

                for(int i = 0; i < logs.Count; i++)
                {
                    if (logs[i].Id == logNumber)
                    {
                        AccessorData.GetAccessorData().DeleteOneLog(logNumber);
                        isESC = true;
                        break;
                    }
                }
                if(!isESC)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, 0, row + 3);
                    continue;
                }

                Console.SetCursorPosition(column, row);
                printLogInformation.ModifySuccess();
                InputFromUser.GetInputFromUser().InputEnterESC();
                isESC = true;
            }
        }

        public void AskSaveLog()
        {
            bool isESC = true;
            string inputValue;

            Console.SetWindowSize(76, 20);
            Console.Clear();
            printLogInformation.SaveCheckUI();

            while(isESC)
            {
                isESC = false;
                inputValue = InputFromUser.GetInputFromUser().InputEnterESC();

                if(inputValue == Constant.ESC_STRING)
                {
                    isESC = true;
                    continue;
                }
                else
                {
                    SaveLogFile();
                    printLogInformation.SaveSuccessUI();
                }
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private void SaveLogFile()
        {
            List<LogVO> logs = new List<LogVO>();
            logs = AccessorData.GetAccessorData().SelectLog();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\로그 저장.txt";

            FileInfo file = new FileInfo(path);

            if(!file.Exists)
            {
                FileStream fileStream = file.Create();
                fileStream.Close();
            }
            StreamWriter streamWriter = new StreamWriter(path, true);
            for (int i = 0; i < logs.Count; i++)
            {
                string fileInsert = string.Format(Constant.LOG_SAVE_FORMAT, logs[i].Id, logs[i].Time, logs[i].User, logs[i].Information, logs[i].Action);
                streamWriter.WriteLine(fileInsert);
            }
            streamWriter.Close();
        }

        public void AskDeleteLog()
        {
            bool isESC = true;
            bool isSuccessDelete = false;
            string inputValue;

            Console.SetWindowSize(76, 20);
            Console.Clear();
            printLogInformation.DeleteCheckUI();

            while (isESC)
            {
                isESC = false;
                inputValue = InputFromUser.GetInputFromUser().InputEnterESC();

                if (inputValue == Constant.ESC_STRING)
                {
                    continue;
                }
                else
                {
                    isSuccessDelete = DeleteLogFile();
                }
                if (!isSuccessDelete)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NULL_FILE, 19, 15);
                    isESC = true;
                    continue;
                }
                printLogInformation.DeleteSuccessUI();
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private bool DeleteLogFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\로그 저장.txt";

            FileInfo file = new FileInfo(path);
            if (!file.Exists)
            {
                return false;
            }
            file.Delete();
            return true;
        }

        public void CheckResetLog()
        {
            bool isESC = true;
            bool isSuccessDelete = false;
            string inputValue;

            Console.SetWindowSize(76, 20);
            Console.Clear();
            printLogInformation.CheckResetUI();

            while (isESC)
            {
                isESC = false;
                inputValue = InputFromUser.GetInputFromUser().InputEnterESC();

                if (inputValue == Constant.ESC_STRING)
                {
                    continue;
                }
                else
                {
                    ResetLog();
                    printLogInformation.ResetSuccessUI();
                }
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private void ResetLog()
        {
            AccessorData.GetAccessorData().DeleteLog();
            LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOG_RESET, "로그");
        }
    }
}
