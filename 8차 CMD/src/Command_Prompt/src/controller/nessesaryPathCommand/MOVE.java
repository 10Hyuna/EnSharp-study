package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.ExceptionHandler;

public class MOVE extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;

    public MOVE(InputDTO inputDTO, CurrentStateDTO currentStateDTO, ExceptionHandler exceptionHandler)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
    }
    @Override
    public void excuteCommand() {
        String detailCommand;

        detailCommand = managerMoveCommand();
    }
}
