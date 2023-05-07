using Library.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Library.Utility;
using System.Globalization;

namespace Library.Model.DAO
{
    public class DataParse
    {
        private static DataParse dataParse;
        private AccessorData accessorData;
        private ConnectionNaverApi connectionNaverApi;
        private DataParse()
        {
            connectionNaverApi = new ConnectionNaverApi();
            accessorData = AccessorData.GetAccessorData();
        }

        public static DataParse GetDataParse()
        {
            if(dataParse == null)
            {
                dataParse = new DataParse();
            }
            return dataParse;
        }

        
        public List<BookDTO> ReturnSearchResult(string searchValue, int displayConut)
        {
            List<BookDTO> books = new List<BookDTO>();
            string totalStorage;
            string publishDate;
            string information;

            totalStorage = connectionNaverApi.ConnectNaver(searchValue, displayConut);

            JObject json = JObject.Parse(totalStorage);

            int count = int.Parse(json["total"].ToString());
            
            if(count < displayConut)
            {
                displayConut = count;
            }

            for(int i = 0; i < displayConut; i++)
            {
                BookDTO book = new BookDTO();
                book.Title = (string)json["items"][i]["title"];
                book.Author = (string)json["items"][i]["author"];
                book.Price = int.Parse((string)json["items"][i]["discount"]);
                book.Publisher = (string)json["items"][i]["publisher"];
                publishDate = (string)json["items"][i]["pubdate"];
                book.PublishDate = string.Format("{0}-{1}-{2}", publishDate.Substring(0, 4), publishDate.Substring(4, 2), publishDate.Substring(6, 2));
                book.ISBN = (string)json["items"][i]["isbn"];
                book.Information = (string)json["items"][i]["description"];
                books.Add(book);
            }
            return books;
        }
    }
}
