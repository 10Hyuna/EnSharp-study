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
    class TotalInformationStorage        // 데이터 관리
    {
        public TotalInformationStorage()
        {
            BookInformation bookInformation = new BookInformation();
            ManagerInformation managerInformation = new ManagerInformation();
        }
        public List<BookInformation> books = new List<BookInformation>();
        public List<UserInformation> users = new List<UserInformation>();
        public List<ManagerInformation> manager = new List<ManagerInformation>();
    }
}