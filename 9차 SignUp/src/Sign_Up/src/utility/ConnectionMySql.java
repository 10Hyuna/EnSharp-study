package utility;

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
    private static Connection connection = null;
    private static Connection ConnectServer()
    {
        String url = String.format("jdbc:mysql://%s:%s/%s", DatabaseConstant.userId, DatabaseConstant.port, DatabaseConstant.tableName);
        String user = DatabaseConstant.user;
        String password = DatabaseConstant.password;

        if(connection == null)
        {
            try{
                connection = DriverManager.getConnection(url, user, password);
            }
            catch (SQLException e){
                System.out.println(e.getMessage());
            }
        }
        return connection;
    }

    public ArrayList ConnectReader(String query) throws SQLException {

        ArrayList<Hashtable<String, String>> list = new ArrayList<>();
        int column;
        String[] ColumnNames;

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
                Hashtable<String, String> hashtable = new Hashtable<>();
                for(String columnName : ColumnNames)
                {
                    Object value = resultSet.getObject(columnName);
                    hashtable.put(columnName, String.valueOf(value));
                }
                list.add(hashtable);
            }
            statement.close();
            connection.close();
            connection = null;
        }
        catch (SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return list;
    }

    public void CUD(String query)
    {
        try
        {
            connection = ConnectServer();
            Statement statement = connection.createStatement();
            statement.execute(query);
            statement.close();
            connection.close();
            connection = null;
        }
        catch (SQLException e)
        {
            System.out.println(e.getMessage());
        }
    }

}