package view;

import utility.Constant;
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

    public void printExceptionMessage(int errorCode, String input)
    {
        switch (errorCode)
        {
            case Constant.NON_COMMAND:
                System.out.printf("'%s'은(는) 내부 또는 외부 명령, 실행할 수 있는 프로그램, 또는\n" +
                        "배치 파일이 아닙니다.\n\n", input);
                break;
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
