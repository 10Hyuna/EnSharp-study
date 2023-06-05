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
        // 입력받은 경로 값 처리

        isValidPath = exceptionHandler.isValidPath(currentStateDTO.getExcutedPath());
        // 경로 값을 처리하고 나서의 실행되어야 하는 경로가 유효한 경로인지 판단

        if(isValidPath)
        {   // 유효한 경로일 경우
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
    }
}
