package model.DAO;

import model.VO.UserInformation;
import utility.ConnectionMySql;
import utility.DatabaseConstant;

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
    public void InsertInformation(UserInformation userInformation){
        String query = String.format(DatabaseConstant.INSERT_INFORMATION, userInformation.getId(), userInformation.getPw(),
                userInformation.getName(), userInformation.getBirstDate(), userInformation.getEmail(), userInformation.getPhoneNumber(),
                userInformation.getAddress(), userInformation.getZipCode());
        connectionMySql.CUD(query);
    }
    public UserInformation SelectIdInformation(UserInformation userInformation){
        String query = String.format(DatabaseConstant.SELECT_ID_SEARCH, userInformation.getName(), userInformation.getPhoneNumber());
        List<Hashtable<String, String>> hashtableList;
        UserInformation idSearch;

        try
        {
            hashtableList = connectionMySql.connectReader(query);
        }
        catch (SQLException e)
        {
            throw new RuntimeException(e);
        }

        idSearch = new UserInformation(hashtableList.get(0).get("id"));

        return idSearch;
    }
    public UserInformation SelectPwInformation(UserInformation userInformation){
        String query = String.format(DatabaseConstant.SELECT_PW_SEARCH, userInformation.getId(), userInformation.getName(), userInformation.getPhoneNumber());

        List<Hashtable<String, String>> hashtableList;
        UserInformation pwSearch;

        try
        {
            hashtableList = connectionMySql.connectReader(query);
        }
        catch (SQLException e)
        {
            throw new RuntimeException(e);
        }

        pwSearch = new UserInformation(hashtableList.get(0).get("id"), hashtableList.get(0).get("password"));

        return pwSearch;
    }
    public UserInformation SelectOverlapId(UserInformation userInformation){
        String query = String.format(DatabaseConstant.SELECT_OVERLAP_ID, userInformation.getId());

        List<Hashtable<String, String>> hashtable;
        UserInformation overlapId;

        try{
            hashtable = connectionMySql.connectReader(query);
        }
        catch (SQLException e){
            throw new RuntimeException(e);
        }

        if(hashtable.get(0).get("id") != null){
            overlapId = new UserInformation(hashtable.get(0).get("id"));
        }
        else{
            overlapId = new UserInformation(null);
        }

        return overlapId;
    }
    public UserInformation SelectLoginInformation(UserInformation userInformation){
        String query = String.format(DatabaseConstant.SELECT_LOGIN_INFORMATION, userInformation.getId(), userInformation.getPw());
        List<Hashtable<String, String>> hashtable;
        UserInformation loginInformation;

        try{
            hashtable = connectionMySql.connectReader(query);
        }
        catch (SQLException e){
            throw new RuntimeException(e);
        }

        if(hashtable.get(0).get("id") != null){
            loginInformation = new UserInformation(hashtable.get(0).get("id"), hashtable.get(0).get("password"));
        }
        else{
            loginInformation = new UserInformation(null);
        }

        return loginInformation;
    }
}
