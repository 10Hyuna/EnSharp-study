package controller;

import utility.Constant;

import java.io.File;

public class ManagementDetailCommand
{
    String detailCommand;
    public String distinguishDetailCommand(String input, String totalInput, String path)
    {
        detailCommand = "";
        switch (input)
        {
            case "cd":
                detailCommand = managerCdcommand(totalInput);
                break;
            case "dir":
                detailCommand = managerDirCommand(totalInput, path);
                break;
            case "copy":
                detailCommand = managerCopyCommand(totalInput);
                break;
            case "move":
                detailCommand = managerMoveCommand(totalInput);
                break;
        }
        return detailCommand;
    }
    protected String managerCdcommand(String totalInput)
    {
        detailCommand = "";
        return detailCommand;
    }
    protected String managerDirCommand(String totalInput, String path)
    {
        totalInput = totalInput.replace("dir", "");
        totalInput = totalInput.replace(" ", "");

        if(!isValidPath(totalInput, path))
        {
            detailCommand = Constant.FAIL;
        }
        return detailCommand;
    }
    protected String managerCopyCommand(String totalInput)
    {
        return detailCommand;
    }
    protected String managerMoveCommand(String totalInput)
    {
        return detailCommand;
    }
    private boolean isValidPath(String path, String currentPath)
    {
        File absolutePath = new File(path);
        boolean isValidFilePath = false;
        if(absolutePath.exists() && absolutePath.isAbsolute())
        {
            detailCommand = path;
            isValidFilePath = true;
        }
        else if(!absolutePath.isAbsolute())
        {
            if(isValidPath(String.format("%s\\%s", currentPath, path), ""));
            {
                detailCommand = String.format("%s\\%s", currentPath, path);
                isValidFilePath = true;
            }
        }
        return isValidFilePath;
    }
}
