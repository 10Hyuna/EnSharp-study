using Library.Model.DAO;
using Library.Model.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class LogAddition
    {
        private static LogAddition logAddition;

        private LogAddition() { }

        public static LogAddition SetLogAddition()
        {
            if(logAddition == null)
            {
                logAddition = new LogAddition();
            }
            return logAddition;
        }

        public void SetLogValue(string user, string logAction, string logInformation)
        {
            LogVO log = new LogVO(DateTime.Now.ToString(), user, logInformation, logAction);

            AccessorData.GetAccessorData().InsertLog(log);
        }
    }
}
