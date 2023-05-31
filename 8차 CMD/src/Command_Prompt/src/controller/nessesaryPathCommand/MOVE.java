package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;

import java.io.File;
import java.math.BigDecimal;
import java.text.DecimalFormat;

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
        String path = currentStateDTO.getPath();
        File file = new File(path);
        int fileCount = 0;
        int directoryCount = 0;
        BigDecimal restByte = new BigDecimal(0);
        BigDecimal usedByte = new BigDecimal(0);
        DecimalFormat decimalFormat = new DecimalFormat("###,###");

        detailCommand = managerMoveCommand();
    }
}
