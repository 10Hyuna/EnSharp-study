package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

public class CD extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ManagementDetailCommand managementDetailCommand;
    public CD(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
              ExceptionHandler exceptionHandler, ManagementDetailCommand managementDetailCommand)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.managementDetailCommand = managementDetailCommand;
    }
    @Override
    public void excuteCommand()
    {
        String path = currentStateDTO.getPath();
        String detailCommand;

        detailCommand = managementDetailCommand.distinguishDetailCommand("cd", inputDTO.getTotalInput(), path);

        if(detailCommand == Constant.FAIL)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_PATH, "");
        }
        else if()
    }
}
