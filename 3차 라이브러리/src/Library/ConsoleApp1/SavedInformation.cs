using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class SavedInformation
    {

        public SavedInformation(DataController dataController)
        {
            dataController.members.Add(new MemberData());
            dataController.members.Add(new MemberData());
            dataController.members[0].id = "managerid12";
            dataController.members[0].password = "managerpw12";
            dataController.members[1].id = "userid12";
            dataController.members[1].password = "userpw12";
            dataController.members[1].name = "김유저";
            dataController.members[1].phoneNumber = "010-1234-5678";
            dataController.members[1].age = "23";
            dataController.members[1].address = "서울특별시 광진구 아차산로";
        }
    }
}
