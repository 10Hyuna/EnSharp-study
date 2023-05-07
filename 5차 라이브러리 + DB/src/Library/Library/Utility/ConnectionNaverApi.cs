using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class ConnectionNaverApi
    {
        public string ConnectNaver(string searchInformation, int displayCount)
        {
            string url;
            string status;
            string text;

            url = string.Format(Constant.URL, searchInformation, displayCount);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", Constant.CLIENT_ID);
            request.Headers.Add("X-Naver-Client-Secret", Constant.CLIENT_SECRET);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            status = response.StatusCode.ToString();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            text = reader.ReadToEnd();
            
            return text;
        }
    }
}
