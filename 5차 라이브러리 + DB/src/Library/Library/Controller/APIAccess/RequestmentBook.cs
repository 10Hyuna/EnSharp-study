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
        public void RequestBook(List<BookDTO> books, string userId)
        {
            List<BookDTO> requestedBook = new List<BookDTO>();
            requestedBook = AccessorData.GetAccessorData().SelectRequestBook();
            int column = 20;
            int row = 1;

            bool isESC = true;

            int requestBookCount = 0;
            string bookInformation;

            while (isESC)
            {
                isESC = false;
                Console.Clear();
                PrintBookInformation.GetPrintBookInformation().PrintRequestBook();
                bookInformation = ExceptionHandler.GetExceptionHandler().IsValidInput(Constant.TITLE, column, row, 20, Constant.IS_NOT_PASSWORD);
                // 요청하고자 하는 책의 정보를 입력받는 메소드 호출

                for (int i = 0; i < requestedBook.Count; i++)
                {
                    if (requestedBook[i].Title.Contains(bookInformation))
                    {   // 이미 신청되어 있는 책 중에서 내가 추가하려는 책의 제목과 일치하는 값이 있을 경우 예외 처리
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
                    {   // 추가하고자 하는 책의 정보를 포함하고 있는 검색 결과 찾기
                        requestBookCount++;
                        AccessorData.GetAccessorData().InsertRequestBook(books[i]);
                        LogAddition.SetLogAddition().SetLogValue(Constant.USER_NAME, books[i].Title, Constant.REQUEST_BOOK);
                    }
                }

                if (requestBookCount == 0)
                {   // 추가할 수 있는 책이 없다면
                    GuidancePhrase.SetGuidancePhrase().PrintException((int)EXCEPTION.NOT_MATCH_SEARCH, column, row);
                    isESC = true;
                    continue;
                }
                PrintBookInformation.GetPrintBookInformation().PrintSuccessRequestBook();
                InputFromUser.GetInputFromUser().InputEnterESC();
                isESC = true;
            }
        }
    }
}
