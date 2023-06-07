package model.DAO;

import utility.ConnectionMySql;

import java.util.List;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Hashtable;

public class AccessorData
{
    private ConnectionMySql connectionMySql;
    private static AccessorData accessorData;
    private AccessorData()
    {
        connectionMySql = new ConnectionMySql();
    }

    public static AccessorData GetAccessorData()
    {
        if(accessorData == null)
        {
            accessorData = new AccessorData();
        }
        return accessorData;
    }

}
