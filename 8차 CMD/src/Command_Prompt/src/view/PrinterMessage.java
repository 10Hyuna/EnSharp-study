package view;

public class PrinterMessage
{
    private static PrinterMessage printerMessage;
    private PrinterMessage(){}
    public static PrinterMessage getPrinterMessage()
    {
        if(printerMessage == null)
        {
            printerMessage = new PrinterMessage();
        }
        return printerMessage;
    }

    public void printExceptionMessage(int errorCode)
    {
        switch (errorCode)
        {
            //case Integer.parseInt(ERROR.NON_EXISTENCE_COMMAND)

        }
    }
    public void printCMDMessage(String message)
    {
        System.out.println(message);
    }
    public void printCurrentPath(String path)
    {
        System.out.printf("%s>", path);
    }
    public void printMessage(String message)
    {
        System.out.println(message);
    }
}
