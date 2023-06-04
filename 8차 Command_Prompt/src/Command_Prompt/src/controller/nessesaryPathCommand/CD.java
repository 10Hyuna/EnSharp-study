package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

public class CD implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private GoingOverPath goingOverPath;
    public CD(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
              ExceptionHandler exceptionHandler, GoingOverPath goingOverPath)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.goingOverPath = goingOverPath;
    }
    @Override
    public void excuteCommand()
    {
        boolean isValidPath = false;
        currentStateDTO.setExcutedPath(currentStateDTO.getPath());
        String path = inputDTO.getcutCommand();

        goingOverPath.discriminatePath(path);

        isValidPath = exceptionHandler.isValidPath(currentStateDTO.getExcutedPath());

        if(isValidPath)
        {
            currentStateDTO.setPath(currentStateDTO.getExcutedPath());
        }
        else
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_PATH, "");
        }

        if(inputDTO.getcutCommand().equals(""))
        {
            PrinterMessage.getPrinterMessage().printMessage(currentStateDTO.getPath());
            PrinterMessage.getPrinterMessage().printMessage("\n");
        }
//        String detailCommand;
//
//        detailCommand = distinguishDetailCommand("cd", inputDTO.getTotalInput(), path);
//
//        if(detailCommand == Constant.FAIL)
//        {
//            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_PATH, "");
//            PrinterMessage.getPrinterMessage().printMessage("");
//        }
//        else if(detailCommand == Constant.EMPTY)
//        {
//            PrinterMessage.getPrinterMessage().printMessage(path);
//            PrinterMessage.getPrinterMessage().printMessage("");
//        }
//        else if(detailCommand == Constant.POINT)
//        {
//            PrinterMessage.getPrinterMessage().printMessage("");
//        }
//        else
//        {
//            currentStateDTO.setPath(detailCommand);
//        }
    }
}
