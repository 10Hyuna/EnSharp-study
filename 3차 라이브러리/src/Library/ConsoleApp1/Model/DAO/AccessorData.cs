using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model.DataBase;
using Library.Model.DTO;
using MySql.Data.MySqlClient;

namespace Library.Model.DAO
{
    public class AccessorData
    {
        private static AccessorData accessorData;
        Book book;
        User user;
        Manager manager;
        ConnectionDataBase connectionDataBase;

        private AccessorData()
        {
            book = new Book();
            user = new User();
            manager = new Manager();
            connectionDataBase = new ConnectionDataBase();
        }

        public static AccessorData GetAccessorData() 
        {
            if(accessorData == null)
            {
                accessorData = new AccessorData();
            }
            return accessorData;
        }

        public void InsertUserData(User userData)
        {
            string stringQuery = string.Format("INSERT INTO user_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", userData.GetId(), userData.GetPassword(), userData.GetName(), userData.GetAge(), userData.GetPhoneNumber(), userData.GetAddress());
            connectionDataBase.CUD(stringQuery);
        }

        public void DeleteUserData(string userId)
        {
            string stringQuery = string.Format("DELETE FROM user_list WHERE id ='{0}'", userId);
            connectionDataBase.CUD(stringQuery);
        }

        public void UpdateUserData(string userId, string updateDataLocation, string updateInformation)
        {
            string stringQuery = string.Format("UPDATE user_list SET '{0}' = '{1}' WHERE id = '{2}'", updateDataLocation, updateInformation, userId);
        }

        public User SelectUserData(string userId)
        {
            string stringQuery = string.Format("SELECT * FROM user_list WHERE id = '{0}'", userId);
            MySqlDataReader reader = connectionDataBase.SelectData(stringQuery);
            User user = new User();
            while (reader.Read())
            {
                user.SetId(reader["id"].ToString());
                user.SetPassword(reader["password"].ToString());
                user.SetName(reader["name"].ToString());
                user.SetAge(reader["age"].ToString());
                user.SetPhoneNumber(reader["phonenumber"].ToString());
                user.SetAddress(reader["address"].ToString());
            }
            return user;
        }

        public Manager SelectManagerData(string managerId)
        {
            string stringQuery = string.Format("SELECT * FROM manager_list WHERE id LIKE '{0}'", managerId);
            MySqlDataReader reader = connectionDataBase.SelectData(stringQuery);
            Manager manager = new Manager();
            while (reader.Read())
            {
                manager.Id = reader["id"].ToString();
                manager.Password = reader["password"].ToString();
            }
            return manager;
        }

        public void InsertBookData(List<string> bookData)
        {
            string stringQuery = string.Format("INSERT INTO book_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", bookData[0], bookData[1], bookData[2], bookData[3], bookData[4], bookData[5]);
            connectionDataBase.CUD(stringQuery);
        }

        public void DeleteBookData(string bookId)
        {
            string stringQuery = string.Format("DELETE FROM book_list WHERE id = '{0}'", bookId);
            connectionDataBase.CUD(stringQuery);

        }

        public void UpdataBookData(string bookId, string updateDataLocation, string updateInformation)
        {
            string stringQuery = string.Format("UPDATE book_list SET '{0}' = '{1}' WHERE id = '{2}'", updateDataLocation, updateInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public List<Book> SelectBookData(string title, string author, string publisher)
        {
            string stringQuery = string.Format("SELECT * FROM book_list WHERE ((title LIKE '{0}') and (author LIKE '{0}') and (publisher LIKE '{0}'))");
            MySqlDataReader reader = connectionDataBase.SelectData(stringQuery);
            List<Book> books = new List<Book>();
            while(reader.Read())
            {
                books.Add(new Book(int.Parse(reader["id"].ToString()), reader["title"].ToString(), reader["author"].ToString(), reader["publisher"].ToString(), reader["amount"].ToString(), reader["price"].ToString(), reader["publishdate"].ToString(), reader["ISBN"].ToString(), reader["information"].ToString()));
            }
            return books;
        }

        //public ReturnBookList SelectReturnBookList(string userId)
        //{
            //string stringQuery = string.Format("SELECT * FROM user_return_book WHERE id = '{0}'", );
            //MySqlDataReader reader = connectionDataBase.SelectData(stringQuery);
            //ReturnBookList returnBookList;
            //while(reader.Read())
            //{
                //return
            //}
        //}
    }
}
