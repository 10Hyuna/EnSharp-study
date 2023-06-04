package model.DTO;

public class CurrentStateDTO
{
    private static String path = System.getProperty("user.home");
    private String excutedPath;
    private String destinationPath;
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
    public String getDestinationPath()
    {
        return destinationPath;
    }
    public void setDestinationPath(String value)
    {
        this.destinationPath = value;
    }
    private String parsePath(String value)
    {
        value = value.replace("\\\\", "\\");
        value = value.replace("/","\\");

        return value;
    }
}
