package utility;

public class DatabaseConstant {
    public static final String userId = "localhost";
    public static final String port = "3306";
    public static final String tableName = "hyunaSignUp";
    public static final String user = "root";
    public static final String password = "00000000";
    public static final String SELECT_ID_SEARCH = "SELECT * FROM userInformation WHERE name = '%s' AND phonenumber = '%s'";
    public static final String SELECT_PW_SEARCH = "SELECT * FROM userInformation WHERE id = '%s' AND name = '%s' AND phonenumber = '%s'";
    public static final String SELECT_OVERLAP_ID = "SELECT * FROM userInformation WHERE id = '%s'";
    public static final String SELECT_LOGIN_INFORMATION = "SELECT * FROM userInformation WHERE id = '%s' AND password = '%s'";
    public static final String INSERT_INFORMATION = "INSERT INTO userInformation VALUE('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')";
}
