package Model;

import Utility.ConnectionMySql;
import Utility.Constant;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.List;

public class AccessorData {
    private ConnectionMySql connectionMySql;

    public AccessorData()
    {
        connectionMySql = new ConnectionMySql();
    }

    public void InsertData(LogVO log)
    {
        String query = String.format(Constant.INSERT_LOG, log.GetSearchWord(), log.GetSearchTime());
        connectionMySql.CUD(query);
    }

    public void DeleteData()
    {
        String query = String.format(Constant.DELETE_LOG);
        connectionMySql.CUD(query);
    }

    public List<LogVO> SelectLog()
    {
        String query = String.format(Constant.SELECT_LOG);
        List<Hashtable<String, String>> hashtableList;
        List<LogVO> logs = new ArrayList<>();
        try
        {
            hashtableList = connectionMySql.ConnectReader(query);
        }
        catch (SQLException e)
        {
            throw new RuntimeException(e);
        }
        for (Hashtable<String, String> hashtable : hashtableList)
        {
            LogVO log = new LogVO();
            log.SetSearchWord(hashtable.get("searchWord"));
            log.SetSearchTime(hashtable.get("searchTime"));
            logs.add(log);
        }
        return logs;
    }
}
