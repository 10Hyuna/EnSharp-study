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
}
