package model.VO;

public class FileInformationVO
{
    private String name;
    private String path;
    public FileInformationVO(String name, String path)
    {
        this.name = name;
        this.path = path;
    }
    public String getName()
    {
        return name;
    }
    public String getPath()
    {
        return path;
    }
}
