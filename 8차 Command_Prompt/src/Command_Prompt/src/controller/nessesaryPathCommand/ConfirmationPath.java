package controller.nessesaryPathCommand;

import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Currency;
import java.util.Scanner;

public class ConfirmationPath {
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private GoingOverPath goingOverPath;
    public boolean isAll;
    public ConfirmationPath(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
                            ExceptionHandler exceptionHandler, GoingOverPath goingOverPath)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.goingOverPath = goingOverPath;
    }
    public boolean setPath()
    {
        boolean isSuccess;
        isAll = false;
        boolean isValid;
        boolean isDuplicatedFile;

        int excutedCount = 0;

        String targetPath;
        String sourcePath = currentStateDTO.getPath();
        currentStateDTO.setExcutedPath(sourcePath);

        String inputtedPath = inputDTO.getcutCommand();

        goingOverPath.discriminatePath(inputtedPath);
        inputtedPath = parseInputtedParse(inputtedPath);
        targetPath = setTargetPath(inputtedPath);

        sourcePath = currentStateDTO.getExcutedPath();
        isValid = exceptionHandler.isValidPath(sourcePath);
        isDuplicatedFile = isDuplication(sourcePath, targetPath);

        if(!isValid)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_TARGET_FILE, "");
            isSuccess = false;
        }
        else if(isDuplicatedFile)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.DUPLICATION_FILE, "");
            isSuccess = false;
        }
        else
        {
            isSuccess = true;
        }
        return isSuccess;
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
        File validateFile;
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
            validateFile = new File(targetPath);

            if(!validateFile.isAbsolute())
            {
                if(!validateFile.exists())
                {
                    targetPath = String.format("%s\\%s", currentStateDTO.getPath(), inputDTO.getcutCommand().substring(targetIndex));
                }
            }
        }
        currentStateDTO.setDestinationPath(targetPath);
        return targetPath;
    }
    public boolean createFile(String targetPath)
    {
        boolean isFile;
        String answer;
        if(Files.exists(Paths.get(targetPath)))
        {
            PrinterMessage.getPrinterMessage().printMessage(targetPath);
            PrinterMessage.getPrinterMessage().printMessage("\n");
            isFile = exceptionHandler.isValidPath(targetPath);

            if(!isFile)
            {
                targetPath = String.format("%s\\%s", currentStateDTO.getPath(), targetPath);
            }
            if(!isAll)
            {
                answer = askOverwriting(targetPath);
                if(answer.equals("n") || answer.equals("no"))
                {
                    return false;
                }
                else if(answer.equals("a") || answer.equals("all"))
                {
                    isAll = true;
                }
            }
        }
        else
        {
            try {
                Files.createFile(Paths.get(targetPath));
            }
            catch (Exception e)
            {
                e.printStackTrace();
            }
        }
        return true;
    }
    public String askOverwriting(String targetFile)
    {
        Scanner scanner = new Scanner(System.in);
        String answer;
        String message = String.format("%s을(를) 덮어쓰시겠습니까? (Yes/No/All): ", targetFile);
        PrinterMessage.getPrinterMessage().printMessage(message);

        answer = scanner.nextLine();
        answer.toLowerCase();

        return answer;
    }
    public boolean isDuplication(String targetFile, String targetPath)
    {
        boolean isDuplicated = false;

        if(targetFile.equals(targetPath))
        {
            isDuplicated = true;
        }

        return isDuplicated;
    }
}