using Library.Model.DTO;
using Library.Model.DAO;
using Library.Utility;
using Library.View;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.APIAccess
{
    public class RequestmentBook
    {
        public void RequestBook(List<BookDTO> books)
        {
            List<BookDTO> requestedBook = new List<BookDTO>();
            requestedBook = AccessorData.GetAccessorData().SelectRequestBook();
            int column = 20;
            int row = 1;

            bool isESC = true;

            int requestBookCount = 0;
            string bookInformation;

            PrintBookInformation.GetPrintBookInformation().PrintRequestBook();
            while (isESC)
            {
                isESC = false;
                bookInformation = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);

                for (int i = 0; i < requestedBook.Count; i++)
                {
                    if (requestedBook[i].Title.Contains(bookInformation))
                    {
                        GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.ALREADY_REQUEST, column, row);
                        isESC = true;
                        break;
                    }
                }

                if (isESC)
                {
                    continue;
                }

                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i].Title.Contains(bookInformation))
                    {
                        requestBookCount++;
                        AccessorData.GetAccessorData().InsertRequestBook(books[i]);
                    }
                }

                if (requestBookCount == 0)
                {
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row);
                    isESC = true;
                    continue;
                }
                PrintBookInformation.GetPrintBookInformation().PrintSuccessRequestBook();
                isESC = true;
            }
        }
    }
}
