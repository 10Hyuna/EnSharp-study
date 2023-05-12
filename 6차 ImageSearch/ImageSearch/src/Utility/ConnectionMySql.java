package Utility;

import com.mysql.cj.MysqlConnection;

import java.sql.*;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Hashtable;

public class ConnectionMySql {

    private static Connection connection;
    private static String serverAddress;
    private ResultSet resultSet;

    private static Connection ConnectServer()
    {
        String url = "jdbc:mysql://localhost:3306/hyuna";
        String user = "root";
        String password = "00000000";

        if(connection == null)
        {
            try
            {
                connection = DriverManager.getConnection(url, user, password);
            }
            catch (SQLException e)
            {
                System.out.println(e.getMessage());
            }
        }
        return connection;
    }

    public ArrayList ConnectReader(String query) throws SQLException {
        ArrayList<Hashtable<String, Object>> list = new ArrayList<>();
        int column;
        String[] ColumnNames;
        Connection connection = null;

        try
        {
            connection = ConnectServer();
            Statement statement = connection.createStatement();
            ResultSet resultSet = statement.executeQuery(query);

            ResultSetMetaData metaData = resultSet.getMetaData();
            column = metaData.getColumnCount();
            ColumnNames = new String[column];
            for(int i = 1; i <= column; i++)
            {
                ColumnNames[i - 1]= metaData.getColumnName(i);
            }

            while(resultSet.next())
            {
                Hashtable<String, Object> hashtable = new Hashtable<>();
                for(String columnName : ColumnNames)
                {
                    Object value = resultSet.getObject(columnName);
                    hashtable.put(columnName, value);
                }
                list.add(hashtable);
            }
            statement.close();
            connection.close();
        }
        catch (SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return list;
    }

    public void CUD(String query)
    {
        Connection connection = null;

        try
        {
            connection = ConnectServer();
            Statement statement = connection.createStatement();
            statement.execute(query);
            statement.close();
            connection.close();
        }
        catch (SQLException e)
        {
            System.out.println(e.getMessage());
        }
    }
}
