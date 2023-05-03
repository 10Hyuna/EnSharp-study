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
using Library.Utility;

namespace Library.Model.DAO
{
    public class AccessorData
    {
        private static AccessorData accessorData;

        private static ConnectionDataBase connectionDataBase;

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

        public static void InsertUserData(UserDTO userData)
        {
            string stringQuery = string.Format("INSERT INTO user_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", userData.Id, userData.Password, userData.Name, userData.Age, userData.PhoneNumber, userData.Address);
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteUserData(string userId)
        {
            string stringQuery = string.Format("DELETE FROM user_list WHERE id ='{0}'", userId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateUserData(string userId, string updateDataLocation, string updateInformation)
        {
            string stringQuery = string.Format("UPDATE user_list SET '{0}' = '{1}' WHERE id = '{2}'", updateDataLocation, updateInformation, userId);
        }

        public static UserDTO SelectUserData(string userId)
        {
            string stringQuery = string.Format("SELECT * FROM user_list WHERE id = '{0}'", userId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            UserDTO user = new UserDTO();
            if (hashtable.Count == 0)
            {
                return user;
            }
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

        public static ManagerVO SelectManagerData(string managerId)
        {
            string stringQuery = string.Format("SELECT * FROM manager_list WHERE id LIKE '{0}'", managerId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            ManagerVO manager = new ManagerVO(hashtable["id"].ToString(), hashtable["password"].ToString());
            return manager;
        }

        public static void InsertBookData(List<string> bookData)
        {
            string stringQuery = string.Format("INSERT INTO book_list VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", bookData[0], bookData[1], bookData[2], bookData[3], bookData[4], bookData[5]);
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteBookData(string bookId)
        {
            string stringQuery = string.Format("DELETE FROM book_list WHERE id = '{0}'", bookId);
            connectionDataBase.CUD(stringQuery);

        }

        public static void UpdataBookData(string bookId, string updateDataLocation, string updateInformation)
        {
            string stringQuery = string.Format("UPDATE book_list SET '{0}' = '{1}' WHERE id = '{2}'", updateDataLocation, updateInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static List<BookDTO> SelectBookData(string title, string author, string publisher)
        {
            string stringQuery = string.Format("SELECT * FROM book_list WHERE (title LIKE CONCAT('%', '{0}', '%') OR '{0}' = '') AND (author LIKE CONCAT('%', '{1}', '%') OR '{1}' = '') AND (publisher LIKE CONCAT('%', '{2}', '%') OR '{2}' = '');", title, author, publisher);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<BookDTO> books = new List<BookDTO>();
            if(hashtable.Count == 0)
            {
                return books;
            }

            for(int i = 0; i < ((ArrayList)hashtable["id"]).Count; i++)
            {
                BookDTO book = new BookDTO();
                book.Id = int.Parse(((ArrayList)hashtable["id"])[i].ToString());
                book.Title = ((ArrayList)hashtable["title"])[i].ToString();
                book.Author = ((ArrayList)hashtable["author"])[i].ToString();
                book.Publisher = ((ArrayList)hashtable["publisher"])[i].ToString();
                book.Amount = int.Parse(((ArrayList)hashtable["amount"])[i].ToString());
                book.Price = int.Parse(((ArrayList)hashtable["price"])[i].ToString());
                book.PublishDate = ((ArrayList)hashtable["publishdate"])[i].ToString();
                book.ISBN = ((ArrayList)hashtable["ISBN"])[i].ToString();
                book.Information = ((ArrayList)hashtable["information"])[i].ToString();
                books.Add(book);
            }
            return books;
        }

        public static List<BookDTO> AllBookData()
        {
            string stringQuery = string.Format(Constant.SELECT_ALL_BOOK);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<BookDTO> books = new List<BookDTO>();
            if (((ArrayList)hashtable["id"]).Count == 0)
            {
                return books;
            }
            for (int i = 0; i < ((ArrayList)hashtable["id"]).Count; i++)
            {
                BookDTO book = new BookDTO();
                book.Id = int.Parse(((ArrayList)hashtable["id"])[i].ToString());
                book.Title = ((ArrayList)hashtable["title"])[i].ToString();
                book.Author = ((ArrayList)hashtable["author"])[i].ToString();
                book.Publisher = ((ArrayList)hashtable["publisher"])[i].ToString();
                book.Amount = int.Parse(((ArrayList)hashtable["amount"])[i].ToString());
                book.Price = int.Parse(((ArrayList)hashtable["price"])[i].ToString());
                book.PublishDate = ((ArrayList)hashtable["publishdate"])[i].ToString();
                book.ISBN = ((ArrayList)hashtable["ISBN"])[i].ToString();
                book.Information = ((ArrayList)hashtable["information"])[i].ToString();
                books.Add(book);
            }
            return books;
        }

        //public ReturnBookDTO SelectReturnBookList(string userId)
        //{
        //
        //}
    }
}
