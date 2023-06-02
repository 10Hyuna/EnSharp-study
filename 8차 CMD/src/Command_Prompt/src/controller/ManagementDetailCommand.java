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
                detailCommand = managerCdcommand(totalInput, path);
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
    protected String managerCdcommand(String totalInput, String path)
    {
        totalInput = totalInput.replace("cd", "");
        totalInput = totalInput.replace(" ", "");

        boolean isRecievedPath = false;
        int index;

        switch (totalInput)
        {
            case "":
                detailCommand = Constant.EMPTY;
                break;
            case ".":
                detailCommand = Constant.POINT;
                break;
            case "\\":
                index = findSlash(totalInput);
                detailCommand = totalInput.substring(0, index + 1);
                break;
            case "..":
                detailCommand = totalInput.substring(0, totalInput.lastIndexOf("\\"));
                break;
            case "..\\..":
                totalInput = totalInput.substring(0, totalInput.lastIndexOf("\\"));
                detailCommand = totalInput.substring(0, totalInput.lastIndexOf("\\"));
                break;
            default:
                isRecievedPath = true;
        }

        if(isRecievedPath)
        {
            if(!isValidPath(totalInput, path))
            {
                detailCommand = Constant.FAIL;
            }
        }
        return detailCommand;
    }
    private int findSlash(String path)
    {
        int count = 0;
        for(int i = 0; i < path.length(); i++)
        {
            if(path.charAt(i) == '\\')
                break;
            count++;
        }
        return count;
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
        path = path.replace("\\", "\\\\");
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
