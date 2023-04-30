using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.DTO;
using Library.Model.VO;

namespace Library.Model
{
    class TotalStorage        // 데이터 관리
    {
        public TotalStorage()
        {
            Book bookInformation = new Book();
            Manager managerInformation = new Manager();
            SearchResult searchResult = new SearchResult();
        }
        public List<Book> books = new List<Book>();
        public List<User> users = new List<User>();
        public List<Manager> manager = new List<Manager>();
        public SearchResult searchResult = new SearchResult();
        public string loggedInUserId;
    }
}