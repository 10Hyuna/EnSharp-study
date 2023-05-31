package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.InputDTO;

public class MOVE extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    public MOVE(InputDTO inputDTO)
    {
        this.inputDTO = inputDTO;
    }
    @Override
    public void excuteCommand() {

    }
}
