package utility;

import view.PrinterMessage;

public class ExceptionHandler
{
    public boolean isValidCommand(String command)
    {
        switch (command)
        {
            case "cd": case "dir": case "copy":
            case "move": case "cls": case "help": case "exit":
                return true;
            default:
                PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_COMMAND, command);
                return false;
        }
    }
    public boolean isOnlyHelp(String command)
    {
        command = command.replace(" ", "");
        command = command.toLowerCase();

        if(command.equals("help"))
        {
            return true;
        }
        return false;
    }
}
