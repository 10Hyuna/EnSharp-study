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
                        "배치 파일이 아닙니다.\n", input);
                break;
            case Constant.NON_FILE:
                System.out.println("파일을 찾을 수 없습니다.");
                break;
            case Constant.NON_PATH:
                System.out.println("지정된 경로를 찾을 수 없습니다.");
                break;
            case Constant.HELP_CONTAINS_ANOTHER:
                System.out.printf("이 명령은 도움말 유틸리티가 지원하지 않습니다. \"%s /?\"를 사용해 보십시오.\n", input);
                break;
            case Constant.NON_TARGET_FILE:
                System.out.println("지정된 파일을 찾을 수 없습니다.");
                break;
            case Constant.DUPLICATION_FILE:
                System.out.println("같은 파일로 복사할 수 없습니다.");
                break;
        }
    }
    public void printCurrentPath(String path)
    {
        path = path.replace("\\\\", "\\");
        System.out.printf("\n%s>", path);
    }
    public void printCopidFileCount(int count)
    {
        System.out.printf("        %d개 파일이 복사되었습니다.", count);
    }
    public void printMessage(String message)
    {
        message = message.replace("\\\\", "\\");
        System.out.println(message);
    }
    public void printFileInformation(String[] message)
    {
        if(!message[3].equals(" "))
        {
            message[3] = formatInteger(message[3]);
        }

        System.out.print(padding.padRigth(message[0], 12));
        System.out.print(padding.padRigth(message[1], 12));
        System.out.print(padding.padRigth(message[2], 5));
        System.out.print(padding.padLeft(message[3], 9));
        System.out.print(" ");
        System.out.println(padding.padRigth(message[4], 30));
    }
    public void printFolder(int fileCount, int directoryCount, long usedByte, long restByte)
    {
        String usedCapacity = String.valueOf(formatInteger(String.valueOf(usedByte)));
        String restCapacity = String.valueOf(formatInteger(String.valueOf(restByte)));

        String file = String.format("%d개 파일", fileCount);
        String useByte = String.format("%s 바이트", usedCapacity);
        String directory = String.format("%d개 디렉터리", directoryCount);
        String wasteByte = String.format("%s 바이트 남음", restCapacity);

        System.out.print(padding.padLeft(file, 19));
        System.out.println(padding.padLeft(useByte, 25));
        System.out.print(padding.padLeft(directory, 21));
        System.out.println(padding.padLeft(wasteByte, 25));
    }
    private String formatInteger(String message)
    {
        long numberMessage = Long.valueOf(message);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");

        return decimalFormat.format(new BigDecimal(numberMessage));
    }
}
