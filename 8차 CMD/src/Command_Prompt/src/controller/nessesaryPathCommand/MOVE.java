package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;

public class MOVE extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    public MOVE(InputDTO inputDTO, CurrentStateDTO currentStateDTO)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
    }
    @Override
    public void excuteCommand() {
        String detailCommand;

        detailCommand = managerMoveCommand();
    }
}
