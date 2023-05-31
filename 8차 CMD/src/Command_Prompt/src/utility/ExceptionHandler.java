package utility;

import view.PrinterMessage;

public class ExceptionHandler
{
    public boolean isExistencePath(String path)
    {
        return true;
    }
    public boolean isExistenceFile(String file)
    {
        return true;
    }
    public boolean isExistenceDirectory(String directory)
    {
        return true;
    }
    public boolean isValidCommand(String command)
    {
        switch (command)
        {
            case "cd": case "dir": case "copy":
            case "move": case "cls": case "help":
                return true;
            default:
                PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_COMMAND, command);
                return false;
        }
    }
}
