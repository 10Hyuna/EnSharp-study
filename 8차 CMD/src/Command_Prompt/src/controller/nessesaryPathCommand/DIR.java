package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.InputDTO;

public class DIR extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    public DIR(InputDTO inputDTO)
    {
        this.inputDTO = inputDTO;
    }
    @Override
    public void excuteCommand() {

    }
}
