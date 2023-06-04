package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.File;

public class MOVE implements ExcutionCommand, ConfirmationFile
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ConfirmationPath confirmationPath;
    public MOVE(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
                ExceptionHandler exceptionHandler, ConfirmationPath confirmationPath)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.confirmationPath = confirmationPath;
    }
    @Override
    public void excuteCommand()
    {
        boolean isSuccessSetting;
        isSuccessSetting = confirmationPath.setPath();

        int movedCount = 0;

        if(isSuccessSetting)
        {
            movedCount = checkOneFlie(currentStateDTO.getExcutedPath(), currentStateDTO.getDestinationPath());
            String successMessage = String.format("        %d개 파일을 이동했습니다.\n", movedCount);
            PrinterMessage.getPrinterMessage().printMessage(successMessage);
        }
    }

    @Override
    public int checkOneFlie(String sourcePath, String targetPath) {

        int movedCount = 0;
        boolean isCreated;

        File file = new File(sourcePath);

        if(file.isDirectory())
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.ACCESS_DENIED, "");
        }

        return movedCount;
    }
}
