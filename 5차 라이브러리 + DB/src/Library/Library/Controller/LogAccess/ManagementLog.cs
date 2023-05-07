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
                logs = AccessorData.GetAccessorData().SelectLog();  // 모든 로그 불러옴
                Console.SetCursorPosition(0, 6);
                printLogInformation.PrintLog(logs);

                logId = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.NUMBER, column, row, 3, Constant.IS_NOT_PASSWORD); 
                // 삭제하려는 로그 아이디 검색

                if(logId == Constant.ESC_STRING)
                {
                    continue;
                }
                else if (!ExceptionHandler.GetExceptionHandler().IsStringAllNumber(logId) || logId == "")
                {   // 숫자가 아니거나 엔터일 경우 예외 처리
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_CONDITION, column, row);
                    isESC = true;
                    continue;
                }
                Console.SetCursorPosition(0, 0);
                logNumber = int.Parse(logId);

                for(int i = 0; i < logs.Count; i++)
                {
                    if (logs[i].Id == logNumber)
                    {   // 입력받은 값에 해당하는 로그가 있다면
                        AccessorData.GetAccessorData().DeleteOneLog(logNumber);
                        isESC = true;
                        break;
                    }
                }
                if(!isESC)
                {   // 해당하는 로그가 없는 값을 입력한 경우
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, 0, row + 3);
                    continue;
                }

                Console.SetCursorPosition(column, row);
                printLogInformation.ModifySuccess();    
                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOG_MODIFY, "로그"); // 로그 찍기
                InputFromUser.GetInputFromUser().InputEnterESC();
                isESC = true;
            }
        }

        public void AskSaveLog()
        {
            bool isESC;
            Console.SetWindowSize(76, 20);
            printLogInformation.SaveCheckUI();

            isESC = InputESC();
            if(!isESC)
            {
                return;
            }

            SaveLogFile();  // 파일 저장
            printLogInformation.SaveSuccessUI();    
            LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOG_SAVE, "로그"); // 로그 찍기
            InputFromUser.GetInputFromUser().EnteredESC();
        }

        private void SaveLogFile()
        {
            List<LogVO> logs = new List<LogVO>();
            logs = AccessorData.GetAccessorData().SelectLog();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\로그 저장.txt";

            FileInfo file = new FileInfo(path);

            if(!file.Exists)    // 파일이 존재하지 않는다면
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
            printLogInformation.DeleteCheckUI();

            while (isESC)
            {
                isESC = InputESC();
                if(!isESC)
                {
                    continue;
                }
                isSuccessDelete = DeleteLogFile();  // 로그 파일 삭제
                if (!isSuccessDelete)   // 로그 파일이 없어 삭제하는 데 실패한 경우의 예외 처리
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NULL_FILE, 19, 15);
                    isESC = true;
                    continue;
                }
                printLogInformation.DeleteSuccessUI();
                LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOG_DELETE, "로그"); // 로그 찍기
                InputFromUser.GetInputFromUser().EnteredESC();
            }
        }

        private bool DeleteLogFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += "\\로그 저장.txt";

            FileInfo file = new FileInfo(path);
            if (!file.Exists)   // 파일이 없는 경우
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

            InputESC();
            ResetLog(); // 로그 전체 삭제
            printLogInformation.ResetSuccessUI();
            InputFromUser.GetInputFromUser().EnteredESC();
        }

        private void ResetLog()
        {
            AccessorData.GetAccessorData().DeleteLog();
            LogAddition.SetLogAddition().SetLogValue(Constant.MANAGER_NAME, Constant.LOG_RESET, "로그");
        }

        private bool InputESC()
        {
            bool isESC = true;
            bool isSuccessDelete = false;
            string inputValue;

            Console.SetWindowSize(76, 20);

            while (isESC)
            {
                isESC = false;
                inputValue = InputFromUser.GetInputFromUser().InputEnterESC();

                if (inputValue == Constant.ESC_STRING)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
