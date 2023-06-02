package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.ExceptionHandler;

public class COPY extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ManagementDetailCommand managementDetailCommand;
    public COPY(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
                ExceptionHandler exceptionHandler, ManagementDetailCommand managementDetailCommand)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.managementDetailCommand = managementDetailCommand;
    }
    @Override
    public void excuteCommand() {
        String detailCommand;
        detailCommand = managementDetailCommand.distinguishDetailCommand("copy", inputDTO.getTotalInput(), "");
    }
}
