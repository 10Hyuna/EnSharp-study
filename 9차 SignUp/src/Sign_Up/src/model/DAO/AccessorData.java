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

        idSearch = new UserInformation(hashtableList.get(0).get("name"), hashtableList.get(0).get("phonenumber"));

        return idSearch;
    }
    public UserInformation SelectPwInformation(UserInformation userInformation){
        String query = String.format(DatabaseConstant.SELECT_PW_SEARCH, userInformation.getId(), userInformation.getName(), userInformation.getEmail());

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

        pwSearch = new UserInformation(hashtableList.get(0).get("id"), hashtableList.get(0).get("name"), hashtableList.get(0).get("phonenumber"));

        return pwSearch;
    }
}
