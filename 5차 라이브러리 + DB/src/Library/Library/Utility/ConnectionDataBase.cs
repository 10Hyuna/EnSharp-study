using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Library.Utility
{
    public class ConnectionDataBase
    {
        private static MySqlConnection connection;
        private static string ServerAddress;

        public ConnectionDataBase() { }

        private static MySqlConnection ConnectServer()
        {
            if (connection == null)
            {
                ServerAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", Constant.SERVER, Constant.PORT, Constant.DATABASE, Constant.UID, Constant.PW);
                connection = new MySqlConnection(ServerAddress);
            }
            return connection;
        }

        public Hashtable SelectData(string stringQuery)
        {
            Hashtable dataList = new Hashtable();
            ArrayList columnNames = new ArrayList();
            MySqlCommand command = new MySqlCommand(stringQuery, ConnectServer());
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                columnNames.Add(reader.GetName(i));
            }

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = columnNames[i].ToString();
                    object value = reader.GetValue(i);

                    if (!dataList.ContainsKey(columnName))
                    {
                        dataList[columnName] = new ArrayList();
                    }
                    ((ArrayList)dataList[columnName]).Add(value);
                }
            }
            reader.Close();
            connection.Close();
            return dataList;
        }

        public void CUD(string stringQuery)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, ConnectServer());
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
