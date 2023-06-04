package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.File;

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
        boolean isValid;
        boolean isDuplicatedFile;

        int copiedCount = 0;

        String targetPath;
        String currentPath = currentStateDTO.getPath();
        currentStateDTO.setExcutedPath(currentPath);
        String inputtedPath = inputDTO.getcutCommand();

        inputtedPath = parseInputtedParse(inputtedPath);

        goingOverPath.discriminatePath(inputtedPath);
        targetPath = setTargetPath(inputtedPath);

        isValid = isValidPath(currentStateDTO.getExcutedPath(), targetPath);
        isDuplicatedFile = isDuplication(currentStateDTO.getExcutedPath(), targetPath);

        if(!isValid)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_TARGET_FILE, "");
        }
        else if(isDuplicatedFile)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.DUPLICATION_FILE, "");
        }
        copiedCount = discrimanateFile(currentPath, targetPath);
        PrinterMessage.getPrinterMessage().printCopidFileCount(copiedCount);
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
            targetPath = String.format("%s\\%s", currentStateDTO.getPath(), inputDTO.getcutCommand().substring(targetIndex));
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
    private int discrimanateFile(String file, String path)
    {
        File targetFile = new File(file);
        File targetPath = new File(path);

        int copiedCount;

        if(targetFile.isFile())
        {
            copiedCount = copyFile(targetFile, targetPath);
        }
        else
        {
            File[] targetFiles = targetFile.listFiles();
            copiedCount = copyFiles(targetFiles, targetPath);
        }

        return copiedCount;
    }
    private int copyFile(File targetFile, File targetPath)
    {
        int copiedCount = 0;



        return copiedCount;
    }
    private int copyFiles(File[] targetFile, File targetPath)
    {
        int copiedCount = 0;


        return copiedCount;
    }
    private boolean isDuplication(String targetFile, String targetPath)
    {
        boolean isDuplicated = false;

        if(targetFile.equals(targetPath))
        {
            isDuplicated = true;
        }

        return isDuplicated;
    }
}
