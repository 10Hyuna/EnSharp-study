package controller;

import utility.Constant;

import java.io.File;

public class ManagementDetailCommand
{
    public String distinguishDetailCommand(String input, String totalInput)
    {
        String detailCommand = "";
        switch (input)
        {
            case "cd":
                detailCommand = managerCdcommand(totalInput);
                break;
            case "dir":
                detailCommand = managerDirCommand(totalInput);
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
        String detailCommand = "";
        return detailCommand;
    }
    protected String managerDirCommand(String totalInput)
    {
        String detailCommand = "";
        totalInput = totalInput.replace("dir", " ");
        detailCommand = totalInput.replace(" ", "");

        if(!isValidPath(detailCommand) && detailCommand != "")
        {
            detailCommand = Constant.FAIL;
        }
        return detailCommand;
    }
    protected String managerCopyCommand(String totalInput)
    {
        String detailCommand = "";
        return detailCommand;
    }
    protected String managerMoveCommand(String totalInput)
    {
        String detailCommand = "";
        return detailCommand;
    }
    private boolean isValidPath(String path)
    {
        File file = new File(path);
        if(file.exists())
        {
            return true;
        }
        return false;
    }
}
