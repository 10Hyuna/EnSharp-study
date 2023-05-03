using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

            for(int i = 0; i < reader.FieldCount; i++)
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
