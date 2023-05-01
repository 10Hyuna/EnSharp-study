using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class PrintBookInformation
    {
        private PrintBookInformation printBookInformation;

        private PrintBookInformation() { }

        public PrintBookInformation GetPrintBookInformation()
        {
            if(printBookInformation == null)
            {
                printBookInformation = new PrintBookInformation();
            }
            return printBookInformation;
        }
    }
}
