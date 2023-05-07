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
            string stringQuery = string.Format(Constant.INSERT_USER, userData.Id, userData.Password, userData.Name, userData.Age, userData.PhoneNumber, userData.Address);
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteUserData(string userId)
        {
            string stringQuery = string.Format(Constant.DELETE_USER, userId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateStringUserData(string userId, string updateDataLocation, string updateInformation)
        {
            string stringQuery = string.Format(Constant.UPDATE_USER_STRING, updateDataLocation, updateInformation, userId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateIntUserData(string userId, string updateDataLocation, int updateInformation)
        {
            string stringQuery = string.Format(Constant.UPDATE_USER_INT, updateDataLocation, updateInformation, userId);
            connectionDataBase.CUD(stringQuery);
        }

        public static UserDTO SelectUserData(string userId)
        {
            string stringQuery = string.Format(Constant.SELECT_USER, userId);
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
                user.PhoneNumber = ((ArrayList)hashtable["phonenumber"])[i].ToString();
            }
            return user;
        }

        public static List<UserDTO> SelectAllUserData()
        {
            string stringQuery = string.Format(Constant.SELECT_ALL_USER);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<UserDTO> users = new List<UserDTO>();
            if(hashtable.Count == 0)
            {
                return users;
            }
            for (int i = 0; i < ((ArrayList)hashtable["id"]).Count; i++)
            {
                UserDTO user = new UserDTO();
                user.Id = ((ArrayList)hashtable["id"])[i].ToString();
                user.Password = ((ArrayList)hashtable["password"])[i].ToString();
                user.Name = ((ArrayList)hashtable["name"])[i].ToString();
                user.Address = ((ArrayList)hashtable["address"])[i].ToString();
                user.Age = int.Parse(((ArrayList)hashtable["age"])[i].ToString());
                user.PhoneNumber = ((ArrayList)hashtable["address"])[i].ToString();
                users.Add(user);
            }
            return users;
        }

        public static ManagerVO SelectManagerData(string managerId)
        {
            string stringQuery = string.Format(Constant.SELECT_MANAGER, managerId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            ManagerVO manager = new ManagerVO(((ArrayList)hashtable["id"])[0].ToString(), ((ArrayList)hashtable["password"])[0].ToString());
            return manager;
        }

        public void InsertBookData(BookDTO book)
        {
            string stringQuery = string.Format(Constant.INSERT_BOOK, book.Title, book.Author, book.Publisher, book.Amount, book.Price, book.PublishDate, book.ISBN, book.Information); ;
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

        public void InsertRequestBook(BookDTO book)
        {
            string stringQuery = string.Format(Constant.INSERT_REQUEST_BOOK, book.Title, book.Author, book.Publisher, book.Price, book.PublishDate, book.ISBN, book.Information);
            connectionDataBase.CUD(stringQuery);
        }
        public static void DeleteBookData(int bookId)
        {
            string stringQuery = string.Format(Constant.DELETE_BOOK, bookId);
            connectionDataBase.CUD(stringQuery);

        }

        public static void DeleteRentBookData(int bookId)
        {
            string stringQuery = string.Format(Constant.DELETE_RENT_BOOK_WITH, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteReturnBookData(int bookId)
        {
            string stringQuery = string.Format(Constant.DELETE_RETURN_BOOK, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void DeleteRentBookData(string userId, int bookId)
        {
            string stringQuery = string.Format(Constant.DELETE_RENT_BOOK, userId, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public void DeleteRequestBook(string title)
        {
            string stringQuery = string.Format(Constant.DELETE_REQUEST_BOOK, title);
            connectionDataBase.CUD(stringQuery);
        }
        public static void UpdateBookIntData(int bookId, string updateDataLocation, int bookInformation)
        {
            string stringQuery = string.Format(Constant.UPDATE_BOOK_STRING, updateDataLocation, bookInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static void UpdateBookStringData(int bookId, string updateDataLocation, string bookInformation)
        {
            string stringQuery = string.Format(Constant.UPDATE_BOOK_INT, updateDataLocation, bookInformation, bookId);
            connectionDataBase.CUD(stringQuery);
        }

        public static List<BookDTO> SelectBookData(string title, string author, string publisher)
        {
            string stringQuery = string.Format(Constant.SELECT_BOOK, title, author, publisher);
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

        public List<BookDTO> SelectRequestBook()
        {
            string stringQuery = string.Format(Constant.SELECT_REQUEST_BOOK);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<BookDTO> books = new List<BookDTO>();
            if (hashtable.Count == 0)
            {
                return books;
            }

            for (int i = 0; i < ((ArrayList)hashtable["title"]).Count; i++)
            {
                BookDTO book = new BookDTO();
                book.Title = ((ArrayList)hashtable["title"])[i].ToString();
                book.Author = ((ArrayList)hashtable["author"])[i].ToString();
                book.Publisher = ((ArrayList)hashtable["publisher"])[i].ToString();
                book.Price = int.Parse(((ArrayList)hashtable["price"])[i].ToString());
                book.PublishDate = ((ArrayList)hashtable["publishdate"])[i].ToString();
                book.ISBN = ((ArrayList)hashtable["isbn"])[i].ToString();
                book.Information = ((ArrayList)hashtable["information"])[i].ToString();
                books.Add(book);
            }
            return books;
        }

        public List<LogVO> SelectLog()
        {
            string stringQuery = string.Format(Constant.SELECT_LOG);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<LogVO> logs = new List<LogVO>();
            if(hashtable.Count == 0) 
            {
                return logs;
            }
            for(int i = 0; i < ((ArrayList)hashtable["id"]).Count; i++)
            {
                LogVO log = new LogVO(int.Parse(((ArrayList)hashtable["id"])[i].ToString()), ((ArrayList)hashtable["time"])[i].ToString(), ((ArrayList)hashtable["user"])[i].ToString(), ((ArrayList)hashtable["information"])[i].ToString(), ((ArrayList)hashtable["action"])[i].ToString());
                logs.Add(log);
            }
            return logs;
        }

        public void DeleteOneLog(int id)
        {
            string stringQuery = string.Format(Constant.DELETE_ONE_LOG, id);
            connectionDataBase.CUD(stringQuery);
        }

        public void DeleteLog()
        {
            string stringQuery = string.Format(Constant.DELETE_LOG);
            connectionDataBase.CUD(stringQuery);
        }

        public void InsertLog(LogVO log)
        {
            string stringQuery = string.Format(Constant.INSERT_LOG, log.Time, log.User, log.Information, log.Action);
            connectionDataBase.CUD(stringQuery);
        }

        public BookDTO SelectRequestedBook(string title)
        {
            string stringQuery = string.Format(Constant.SELECT_REQUESTED_BOOK, title);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            BookDTO book = new BookDTO();
            if (hashtable.Count == 0)
            {
                return book;
            }

            for (int i = 0; i < ((ArrayList)hashtable["title"]).Count; i++)
            {
                book.Title = ((ArrayList)hashtable["title"])[i].ToString();
                book.Author = ((ArrayList)hashtable["author"])[i].ToString();
                book.Publisher = ((ArrayList)hashtable["publisher"])[i].ToString();
                book.Price = int.Parse(((ArrayList)hashtable["price"])[i].ToString());
                book.PublishDate = ((ArrayList)hashtable["publishdate"])[i].ToString();
                book.ISBN = ((ArrayList)hashtable["isbn"])[i].ToString();
                book.Information = ((ArrayList)hashtable["information"])[i].ToString();
                book.Amount = 1;
            }
            return book;
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

        public static BookDTO SelectPartlyBook(int id)
        {
            string stringQuery = string.Format(Constant.SELECT_PARTLY_BOOK, id);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            BookDTO book = new BookDTO();
            if(hashtable.Count == 0)
            {
                return book;
            }
            book.Id = int.Parse(((ArrayList)hashtable["id"])[0].ToString());
            book.Title = ((ArrayList)hashtable["title"])[0].ToString();
            book.Author = ((ArrayList)hashtable["author"])[0].ToString();
            book.Publisher = ((ArrayList)hashtable["publisher"])[0].ToString();
            book.Amount = int.Parse(((ArrayList)hashtable["amount"])[0].ToString());
            book.Price = int.Parse(((ArrayList)hashtable["price"])[0].ToString());
            book.PublishDate = ((ArrayList)hashtable["publishdate"])[0].ToString();
            book.ISBN = ((ArrayList)hashtable["ISBN"])[0].ToString();
            book.Information = ((ArrayList)hashtable["information"])[0].ToString();

            return book;
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

        public static UsersBookDTO SelectRentBook(string userId, int bookId)
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

        public static UsersBookDTO SelectReturnedBook(string userId, int bookId)
        {
            string stringQuery = string.Format(Constant.SELECT_RETURNED_BOOK, userId, bookId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            UsersBookDTO book = new UsersBookDTO();
            if (hashtable.Count == 0)
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
        public static List<UsersBookDTO> SelectAllReturnBook(string userId)
        {
            string stringQuery = string.Format(Constant.SELECT_ALL_RETURN_BOOK, userId);
            Hashtable hashtable = connectionDataBase.SelectData(stringQuery);
            List<UsersBookDTO> books = new List<UsersBookDTO>();
            if (hashtable.Count == 0)
            {
                return books;
            }
            for (int i = 0; i < ((ArrayList)hashtable["book_id"]).Count; i++)
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
                book.ReturnTime = ((ArrayList)hashtable["return_time"])[i].ToString();
                books.Add(book);
            }
            return books;
        }
    }
}
