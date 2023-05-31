package controller.nonnessesaryPathCommand;

import controller.ExcutionCommand;
import model.DTO.CurrentStateDTO;
import view.PrinterMessage;

public class CLS implements ExcutionCommand
{
    private CurrentStateDTO currentStateDTO;
    public CLS(CurrentStateDTO currentStateDTO)
    {
        this.currentStateDTO = currentStateDTO;
    }
    @Override
    public void excuteCommand() {
        for(int i = 0; i < 40; i++)
        {
            PrinterMessage.getPrinterMessage().printMessage(" ");
        }
    }
}
