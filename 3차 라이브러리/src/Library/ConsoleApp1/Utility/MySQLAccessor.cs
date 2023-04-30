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
        private static MySQLAccessor mySQLAccessor;

        private string server = "localhost";
        int port = 3306;
        string database = "en#library";
        string id = "root";
        string password = "0000";
        string connectionAddress;
        string inputQuery;
        private MySQLAccessor() { }

        public static MySQLAccessor SetmySQLAccessor()
        {
            if(mySQLAccessor == null)
            {
                mySQLAccessor = new MySQLAccessor();
            }
            return mySQLAccessor;
        }

        public void AccessVoidData(string inputQuery, int inputDirection)
        {
            connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", server, port, database, id, password);
            switch (inputDirection)
            {
                case (int)INPUTDATA.USER:
                    AccessData(inputQuery);
                    break;
                case (int)INPUTDATA.BOOK:
                    AccessData(inputQuery);
                    break;
            }
        }

        public MySqlDataReader AccessReturnData(string inputQuery, int inputDirection)
        {
            MySqlDataReader returnData = null;
            connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", server, port, database, id, password);

            switch (inputDirection)
            {
                case (int)INPUTDATA.USER:
                    returnData = AccessReturnData(inputQuery);
                    break;
                case (int)INPUTDATA.BOOK:
                    returnData = AccessReturnData(inputQuery);
                    break;
            }
            return returnData;
        }

        private void AccessData(string stringQuery)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionAddress))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(stringQuery, connection);
            }
        }

        private MySqlDataReader AccessReturnData(string stringQuery)
        {
            MySqlDataReader returnValue;

            using (MySqlConnection connection = new MySqlConnection(connectionAddress))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(stringQuery, connection);
                returnValue = command.ExecuteReader();
            }
            return returnValue;
        }

        public void CloseConnection()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionAddress))
            {
                connection.Close();
            }
        }
    }
}
