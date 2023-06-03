package model.DTO;

public class CurrentStateDTO
{
    private static String path = System.getProperty("user.home");
    private String excutedPath = "";
    public String getPath()
    {
        return path;
    }
    public void setPath(String value)
    {
        value = value.replace("\\\\", "\\");
        value = value.replace("/","\\");
        this.path = value;
    }
    public String getExcutedPath() { return excutedPath; }
    public void setExcutedPath(String value)
    {
        value = value.replace("\\\\", "\\");
        value = value.replace("/","\\");
        this.excutedPath = value;
    }
}
