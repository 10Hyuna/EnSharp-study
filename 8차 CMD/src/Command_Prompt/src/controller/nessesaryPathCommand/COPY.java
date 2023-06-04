package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

public class COPY implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private GoingOverPath goingOverPath;
    public COPY(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
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
        boolean isValid = false;

        String targetPath;
        String currentPath = currentStateDTO.getPath();
        currentStateDTO.setExcutedPath(currentPath);
        String inputtedPath = inputDTO.getcutCommand();

        inputtedPath = parseInputtedParse(inputtedPath);

        goingOverPath.discriminatePath(inputtedPath);

        targetPath = setTargetPath(inputtedPath);

        isValid = isValidPath(inputtedPath, targetPath);

        if(isValid)
        {
            copyFile(currentPath, targetPath);
        }
        else
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_TARGET_FILE, "");
        }
    }
    private String parseInputtedParse(String inputtedPath)
    {
        String parsedPath = "";
        for(int i = 0; i < inputtedPath.length(); i++)
        {
            if(inputtedPath.charAt(i) == ' ')
            {
                break;
            }
            parsedPath += String.valueOf(inputtedPath.charAt(i));
        }
        return parsedPath;
    }
    private String setTargetPath(String inputtedPath)
    {
        String targetPath;
        int targetIndex;

        if(inputtedPath.equals(inputDTO.getcutCommand()))
        {
            targetPath = currentStateDTO.getPath();
        }
        else
        {
            targetIndex = inputtedPath.length() + 1;
            targetPath = inputDTO.getcutCommand().substring(targetIndex);
        }
        return targetPath;
    }
    private boolean isValidPath(String currentPath, String targerPath)
    {
        boolean isValid = false;

        isValid = exceptionHandler.isValidPath(currentPath);
        isValid = exceptionHandler.isValidPath(targerPath);

        return isValid;
    }
    private void copyFile(String currentPath, String targetPath)
    {

    }
    private void discriminateFile(String path)
    {

    }
}
