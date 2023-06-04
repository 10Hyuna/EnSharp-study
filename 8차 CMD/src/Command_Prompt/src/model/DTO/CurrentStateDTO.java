package model.DTO;

public class CurrentStateDTO
{
    private static String path = System.getProperty("user.home");
    private String excutedPath;
    private String excutedFile;
    public String getPath()
    {
        return path;
    }
    public void setPath(String value)
    {
        value = parsePath(value);
        this.path = value;
    }
    public String getExcutedPath() { return excutedPath; }
    public void setExcutedPath(String value)
    {
        value = parsePath(value);
        this.excutedPath = value;
    }
    public String getExcutedFile()
    {
        return excutedFile;
    }
    public void setExcutedFile(String value)
    {
        this.excutedFile = value;
    }
    private String parsePath(String value)
    {
        value = value.replace("\\\\", "\\");
        value = value.replace("/","\\");

        return value;
    }
}
