using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DTO
{
    public class UserDTO
    {
        public UserDTO() { }

        private string id;
        private string password;
        private string name;
        private int age;
        private string phoneNumber;
        private string address;

        public string Id
        {
            get => this.id; 
            set => this.id = value;
        }

        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public string PhoneNumber
        {
            get => this.phoneNumber;
            set => this.phoneNumber = value;
        }

        public string Address
        {
            get => this.address;
            set => this.address = value;
        }
    }
}
