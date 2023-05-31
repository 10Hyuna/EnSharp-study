package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;

import java.io.File;

public class DIR extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    public DIR(InputDTO inputDTO, CurrentStateDTO currentStateDTO)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
    }
    @Override
    public void excuteCommand() {
        String detailCommand;
        String path = currentStateDTO.getPath();
        int fileCount = 0;
        int directoryCount = 0;
        int restByte = 0;
        int usedByte = 0;

        detailCommand = managerDirCommand();
        if(detailCommand != Constant.EMPTY)
        {
            path = detailCommand;
        }

        File file = new File(path);

        if(file.exists() && file.isDirectory())
        {

        }
    }
}
