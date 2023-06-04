package model.DTO;

public class InputDTO
{
    private String totalInput;
    private String cutCommand;
    private String path;
    private String file;
    private String command;
    public String getTotalInput()
    {
        return totalInput;
    }
    public void setTotalInput(String value)
    {
        this.totalInput = value;
    }
    public String getcutCommand()
    {
        return cutCommand;
    }
    public void setcutCommand(String value)
    {
        value = value.replace("\\\\", "\\");
        value = value.replace("/", "\\");
        this.cutCommand = value;
    }
    public String getPath()
    {
        return path;
    }
    public void setPath(String value)
    {
        this.path = value;
    }
    public String getFile()
    {
        return file;
    }
    public void setFile(String value)
    {
        this.file = value;
    }
    public String getCommand()
    {
        return command;
    }
    public void setCommand(String value)
    {
        this.command = value;
    }
}
