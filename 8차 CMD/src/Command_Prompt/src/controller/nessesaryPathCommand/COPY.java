package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.InputDTO;

public class COPY extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    public COPY(InputDTO inputDTO)
    {
        this.inputDTO = inputDTO;
    }
    @Override
    public void excuteCommand() {

    }
}
