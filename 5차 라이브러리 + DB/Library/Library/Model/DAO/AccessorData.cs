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
using System.Configuration;

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

        public static void InsertRentBookData(string userId, BookDTO book)
        {
            string stringQuery = string.Format(Constant.INSERT_RENT_BOOK, userId, book.Id, book.Title, book.Author, book.Publisher, book.Amount, book.Price, book.PublishDate, book.ISBN, book.Information, DateTime.Now.ToString(), DateTime.Now.AddDays(7).ToString());
            connectionDataBase.CUD(stringQuery);
        }

        public static void InsertReturnBookData(UsersBookDTO book)
        {
            string stringQuery = string.Format(Constant.INSERT_RETURN_BOOK, book.UserId, book.Id, book.Title, book.Author, book.Publisher, book.Amount, book.Price, book.PublishDate, book.ISBN, book.Information, book.RentTime, DateTime.Now.ToString());
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteBookData(string bookId)
        {
            string stringQuery = string.Format("DELETE FROM book_list WHERE id = '{0}'", bookId);
            connectionDataBase.CUD(stringQuery);

        }

        public static void DeleteRentBookData(string userId, int bookId)
        {
            string stringQuery = string.Format(Constant.DELETE_RENT_BOOK, userId, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateBookIntData(int bookId, string updateDataLocation, int bookInformation)
        {
            string stringQuery = string.Format("UPDATE book_list SET {0} = {1} WHERE id = {2}", updateDataLocation, bookInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateBookStringData(int bookId, string updateDataLocation, string bookInformation)
        {
            string stringQuery = string.Format("UPDATE book_list SET {0} = '{1}' WHERE id = {2}", updateDataLocation, bookInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static List<BookDTO> SelectBookData(string title, string author, string publisher)
        {
            string stringQuery = string.Format("SELECT * FROM book_list WHERE (title LIKE CONCAT('%', '{0}', '%') OR '{0}' = '') AND (author LIKE CONCAT('%', '{1}', '%') OR '{1}' = '') AND (publisher LIKE CONCAT('%', '{2}', '%') OR '{2}' = '');", title, author, publisher);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<BookDTO> books = new List<BookDTO>();
            if (hashtable.Count == 0)
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
            if (hashtable.Count == 0)
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

        public static List<UsersBookDTO> SelectAllRentBookList(string userId)
        {
            string stringQuery = string.Format(Constant.SELECT_RENT_BOOK, userId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<UsersBookDTO> books = new List<UsersBookDTO>();
            if (hashtable.Count == 0)
            {
                return books;
            }
            for (int i = 0; i < ((ArrayList)hashtable["book_id"]).Count ; i++)
            {
                UsersBookDTO book = new UsersBookDTO();
                book.UserId = ((ArrayList)hashtable["user_id"])[i].ToString();
                book.Id = int.Parse(((ArrayList)hashtable["book_id"])[i].ToString());
                book.Title = ((ArrayList)hashtable["title"])[i].ToString();
                book.Author = ((ArrayList)hashtable["author"])[i].ToString();
                book.Publisher = ((ArrayList)hashtable["publisher"])[i].ToString();
                book.Amount = int.Parse(((ArrayList)hashtable["amount"])[i].ToString());
                book.Price = int.Parse(((ArrayList)hashtable["price"])[i].ToString());
                book.PublishDate = ((ArrayList)hashtable["publish_date"])[i].ToString();
                book.ISBN = ((ArrayList)hashtable["ISBN"])[i].ToString();
                book.Information = ((ArrayList)hashtable["information"])[i].ToString();
                book.RentTime = ((ArrayList)hashtable["rental_time"])[i].ToString();
                book.ReturnTime= ((ArrayList)hashtable["return_time"])[i].ToString();
                books.Add(book);
            }
            return books;
        }

        public static UsersBookDTO SelectReturnBook(string userId, int bookId)
        {
            string stringQuery = string.Format(Constant.SELECT_USER_RENT_BOOK, userId, bookId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            UsersBookDTO book = new UsersBookDTO();
            if(hashtable.Count == 0)
            {
                return book;
            }
            book.UserId = ((ArrayList)hashtable["user_id"])[0].ToString();
            book.Id = int.Parse(((ArrayList)hashtable["book_id"])[0].ToString());
            book.Title = ((ArrayList)hashtable["title"])[0].ToString();
            book.Author = ((ArrayList)hashtable["author"])[0].ToString();
            book.Publisher = ((ArrayList)hashtable["publisher"])[0].ToString();
            book.Amount = int.Parse(((ArrayList)hashtable["amount"])[0].ToString());
            book.Price = int.Parse(((ArrayList)hashtable["price"])[0].ToString());
            book.PublishDate = ((ArrayList)hashtable["publish_date"])[0].ToString();
            book.ISBN = ((ArrayList)hashtable["ISBN"])[0].ToString();
            book.Information = ((ArrayList)hashtable["information"])[0].ToString();
            book.RentTime = ((ArrayList)hashtable["rental_time"])[0].ToString();
            book.ReturnTime = ((ArrayList)hashtable["return_time"])[0].ToString();
            return book;
        }
    }
}
