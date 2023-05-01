using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DataBase
{
    public class ConnectionDataBase
    {
        private static MySqlConnection connection;

        public ConnectionDataBase() { }

        private static MySqlConnection ConnectServer()
        {
            if (connection == null)
            {
                connection = new MySqlConnection("Server=localhost;Port=3306;Database=en#library;Uid=root;Pwd=0000");
                connection.Open();
            }
            return connection;
        }

        private static void DisConnectServer()
        {
            if(connection != null)
            {
                connection.Close();
                connection.Open();
            }
        }

        public MySqlDataReader SelectData(string stringQuery)
        {
            DisConnectServer();
            MySqlCommand command = new MySqlCommand(stringQuery, ConnectServer());
            MySqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public void CUD(string stringQuery)
        {
            DisConnectServer();
            MySqlCommand command = new MySqlCommand(stringQuery, ConnectServer());
            command.ExecuteNonQuery();
        }
    }
}
