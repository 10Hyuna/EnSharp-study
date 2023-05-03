using Library.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library.Model.DTO;
using Library.Model.VO;
using System.Collections;
using Google.Protobuf.WellKnownTypes;

namespace Library.Model.DAO
{
    public class AccessorData
    {
        private static AccessorData accessorData;

        ConnectionDataBase connectionDataBase;

        private AccessorData()
        {
            connectionDataBase = new ConnectionDataBase();
        }

        public static AccessorData GetAccessorData()
        {
            if (accessorData == null)
            {
                accessorData = new AccessorData();
            }
            return accessorData;
        }

        public void InsertUserData(UserDTO userData)
        {
            string stringQuery = string.Format("INSERT INTO user_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", userData.Id, userData.Password, userData.Name, userData.Age, userData.PhoneNumber, userData.Address);
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

        public UserDTO SelectUserData(string userId)
        {
            string stringQuery = string.Format("SELECT * FROM user_list WHERE id = '{0}'", userId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            UserDTO user = new UserDTO();
            for(int i = 0; i < ((ArrayList)hashtable["id"]).Count; i++)
            {
                user.Id = ((ArrayList)hashtable["id"])[i].ToString();
                user.Password = ((ArrayList)hashtable["password"])[i].ToString();
                user.Name = ((ArrayList)hashtable["name"])[i].ToString();
                user.Address = ((ArrayList)hashtable["address"])[i].ToString();
                user.Age = int.Parse(((ArrayList)hashtable["age"])[i].ToString());
                user.PhoneNumber = ((ArrayList)hashtable["address"])[i].ToString();
            }
            return user;
        }

        public ManagerVO SelectManagerData(string managerId)
        {
            string stringQuery = string.Format("SELECT * FROM manager_list WHERE id LIKE '{0}'", managerId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            ManagerVO manager = new ManagerVO(hashtable["id"].ToString(), hashtable["password"].ToString());
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

        public List<BookDTO> SelectBookData(string title, string author, string publisher)
        {
            string stringQuery = string.Format("SELECT * FROM book_list WHERE ((title LIKE '{0}') and (author LIKE '{0}') and (publisher LIKE '{0}'))");
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<BookDTO> books = new List<BookDTO>();
            for(int i = 0; i < hashtable.Count; i++)
            {
                books[i].Id = int.Parse(hashtable["id"].ToString());
                books[i].Title = hashtable["title"].ToString();
                books[i].Author = hashtable["author"].ToString();
                books[i].Publisher = hashtable["publisher"].ToString();
                books[i].Amount = int.Parse(hashtable["amount"].ToString());
                books[i].Price = int.Parse(hashtable["price"].ToString());
                books[i].PublishDate = hashtable["publishDate"].ToString();
                books[i].ISBN = hashtable["isbn"].ToString();
                books[i].Information = hashtable["information"].ToString();
            }
            return books;
        }

        //public ReturnBookDTO SelectReturnBookList(string userId)
        //{
        //
        //}
    }
}
