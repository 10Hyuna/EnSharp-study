package view;

import utility.Constant;
import utility.Padding;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class PrinterMessage
{
    private static PrinterMessage printerMessage;
    private Padding padding;
    private PrinterMessage()
    {
        padding = new Padding();
    }
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
            case Constant.NON_FILE:
                System.out.println("지정된 파일을 찾을 수 없습니다.\n");
                break;
            case Constant.FILE_EXISTENCE:
                System.out.println("파일을 찾을 수 없습니다.");
                break;
            case Constant.NON_PATH:
                System.out.println("지정된 경로를 찾을 수 없습니다.");
                break;
        }
    }
    public void printCurrentPath(String path)
    {
        System.out.printf("%s>", path);
    }
    public void printMessage(String message)
    {
        System.out.println(message);
    }
    public void printFileInformation(String[] message)
    {
        System.out.print(padding.padRigth(message[0], 12));
        System.out.print(padding.padRigth(message[1], 12));
        System.out.print(padding.padRigth(message[2], 5));
        System.out.print(padding.padLeft(message[3], 9));
        System.out.print(" ");
        System.out.println(padding.padRigth(message[4], 30));
    }
    public void printFolder(int fileCount, int directoryCount, long usedByte, long restByte)
    {
        DecimalFormat decimalFormat = new DecimalFormat("###,###");

        String file = String.format("%d개 파일", fileCount);
        String useByte = String.format("%s 바이트", decimalFormat.format(new BigDecimal(usedByte)));
        String directory = String.format("%d개 디렉터리", directoryCount);
        String wasteByte = String.format("%s 바이트", decimalFormat.format(new BigDecimal(restByte)));

        System.out.print(padding.padLeft(file, 19));
        System.out.println(padding.padLeft(useByte, 25));
        System.out.print(padding.padLeft(directory, 21));
        System.out.println(padding.padLeft(wasteByte, 22));
    }
}
