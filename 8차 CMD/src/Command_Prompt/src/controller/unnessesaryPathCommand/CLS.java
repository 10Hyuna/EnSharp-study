package controller.unnessesaryPathCommand;

import controller.ExcutionCommand;
import view.PrinterMessage;

public class CLS implements ExcutionCommand
{
    @Override
    public void excuteCommand() {
        for(int i = 0; i < 40; i++)
        {
            PrinterMessage.getPrinterMessage().printMessage(" ");
        }
    }
}
