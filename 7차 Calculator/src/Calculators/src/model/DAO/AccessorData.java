package model.DAO;

import model.VO.LogVO;
import utility.ConnectionMySql;
import utility.DatabaseConstant;

import java.util.List;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Hashtable;

public class AccessorData {

    private ConnectionMySql connectionMySql;

    public AccessorData()
    {
        connectionMySql = new ConnectionMySql();
    }

    public LogVO SelectLog()
    {
        String query = String.format(DatabaseConstant.SELECT_PARTLY_LOG);
        List<Hashtable<String, String>> hashtableList;
        LogVO log = new LogVO();

        try
        {
            hashtableList = connectionMySql.connectReader(query);
        }
        catch (SQLException e)
        {
            throw new RuntimeException(e);
        }
        log = new LogVO(Integer.parseInt(hashtableList.get(0).get("first_input")),
                Integer.parseInt(hashtableList.get(0).get("last_input")), hashtableList.get(0).get("operator"),
                Integer.parseInt(hashtableList.get(0).get("result")));

        return log;
    }

    public List<LogVO> SelectAllLog() {

        String query = String.format(DatabaseConstant.SELECT_ALL_LOG);
        List<Hashtable<String, String>> hashtableList;
        List<LogVO> logs = new ArrayList<>();
        try
        {
            hashtableList = connectionMySql.connectReader(query);
        }
        catch (SQLException e)
        {
            throw new RuntimeException(e);
        }
        for (Hashtable<String, String> hashtable : hashtableList)
        {
            LogVO log = new LogVO(Integer.parseInt(hashtable.get("first_input")),
                    Integer.parseInt(hashtable.get("last_input")), hashtable.get("operator"),
                    Integer.parseInt(hashtable.get("result")));
            logs.add(log);
        }
        return logs;
    }

    public void DeleteLog()
    {
        String query = String.format(DatabaseConstant.DELETE_PARTLY_LOG);
        connectionMySql.CUD(query);
    }

    public void InsertLog()
    {
        String query = String.format(DatabaseConstant.INSERT_LOG);
        connectionMySql.CUD(query);
    }
}