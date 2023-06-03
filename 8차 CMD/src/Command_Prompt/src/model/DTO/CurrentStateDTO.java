package model.DTO;

public class CurrentStateDTO
{
    private static String path = System.getProperty("user.home");
    public String getPath()
    {
        return path;
    }
    public void setPath(String value)
    {
        this.path = value;
    }
}
