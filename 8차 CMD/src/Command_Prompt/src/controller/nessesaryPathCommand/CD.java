package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.InputDTO;

public class CD extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    public CD(InputDTO inputDTO)
    {
        this.inputDTO = inputDTO;
    }
    @Override
    public void excuteCommand() {

    }
}
