using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class MySQLAccessor
    {
        private MySQLAccessor mySQLAccessor;

        private string server = "localhost";
        int port = 3306;
        string database = "en#library";
        string id = "root";
        string password = "0000";
        string connectionAddress;
        string inputQuery;'
        private MySQLAccessor() { }

        public MySQLAccessor SetmySQLAccessor()
        {
            if(mySQLAccessor == null)
            {
                mySQLAccessor = new MySQLAccessor();
                connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", server, port, database, id, password);
            }
            return mySQLAccessor;
        }

        public void InsertData(List<string> inputData, int inputDirection)
        {
            switch(inputDirection)
            {
                case (int)INPUTDATA.USER:
                    inputQuery = string.Format("INSERT INTO user_list VAULES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", inputData[(int)USERINFORMATION.ID], inputData[(int)USERINFORMATION.PASSWORD], inputData[(int)USERINFORMATION.NAME], inputData[(int)USERINFORMATION.AGE], inputData[(int)USERINFORMATION.PHONENUMBER], inputData[(int)USERINFORMATION.ADDRESS]);
                    AccessData(inputQuery);
                    break;
                case (int)INPUTDATA.BOOK:
                    inputQuery = string.Format("INSERT INTO book_list (title, author, publisher, amount, price, publishdate, ISBN, information) VAULES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'", inputData[(int)BOOKINFORMATION.TITLE], inputData[(int)BOOKINFORMATION.AUTHOR], inputData[(int)BOOKINFORMATION.PUBLISHER], inputData[(int)BOOKINFORMATION.AMOUNT], inputData[(int)BOOKINFORMATION.PRICE], inputData[(int)BOOKINFORMATION.PUBLISHDAY], inputData[(int)BOOKINFORMATION.ISBN], inputData[(int)BOOKINFORMATION.INFORMATION]);
                    AccessData(inputQuery);
                    break;
            }
        }


        public void UpdateData(List<string> inputData, int inputDirection)
        {
            switch (inputDirection)
            {
                case (int)INPUTDATA.USER:
                    inputQuery = string.Format("UPDATE user_list VAULES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}'", inputData[(int)USERINFORMATION.ID], inputData[(int)USERINFORMATION.PASSWORD], inputData[(int)USERINFORMATION.NAME], inputData[(int)USERINFORMATION.AGE], inputData[(int)USERINFORMATION.PHONENUMBER], inputData[(int)USERINFORMATION.ADDRESS]);
                    AccessData(inputQuery);
                    break;
                case (int)INPUTDATA.BOOK:
                    inputQuery = string.Format("UPDATE book_list (title, author, publisher, amount, price, publishdate, ISBN, information) VAULES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'", inputData[(int)BOOKINFORMATION.TITLE], inputData[(int)BOOKINFORMATION.AUTHOR], inputData[(int)BOOKINFORMATION.PUBLISHER], inputData[(int)BOOKINFORMATION.AMOUNT], inputData[(int)BOOKINFORMATION.PRICE], inputData[(int)BOOKINFORMATION.PUBLISHDAY], inputData[(int)BOOKINFORMATION.ISBN], inputData[(int)BOOKINFORMATION.INFORMATION]);
                    Access
                    break;
            }
        }
        private void AccessData(string stringQuery)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionAddress))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(stringQuery, connection);
            }
        }
    }
}
