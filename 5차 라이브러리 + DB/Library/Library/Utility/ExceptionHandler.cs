using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class ExceptionHandler
    {
        private static ExceptionHandler exceptionHandler;
        private InputFromUser inputFromUser;

        private ExceptionHandler() 
        {
            inputFromUser = InputFromUser.GetInputFromUser();
        }

        public static ExceptionHandler GetExceptionHandler()
        {
            if(exceptionHandler == null)
            {
                exceptionHandler = new ExceptionHandler();
            }
            return exceptionHandler;
        }
    }
}
