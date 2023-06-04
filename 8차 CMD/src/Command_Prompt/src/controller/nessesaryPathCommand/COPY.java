package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Scanner;

public class COPY implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private GoingOverPath goingOverPath;
    private boolean isAll;
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
        isAll = false;
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

        currentPath = currentStateDTO.getExcutedPath();
        isValid = isValidPath(currentPath, targetPath);
        isDuplicatedFile = isDuplication(currentPath, targetPath);

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
        PrinterMessage.getPrinterMessage().printMessage("\n");
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
            if(!validateFile.exists())
            {
                targetPath = String.format("%s\\%s", currentStateDTO.getPath(), inputDTO.getcutCommand().substring(targetIndex));
            }
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

        copiedCount = checkOneFlie(file, path);

        return copiedCount;
    }
    private int checkOneFlie(String targetFile, String targetPath)
    {
        boolean isCreated = false;
        int copiedCount = 0;
        String target = targetPath;
        String answer;
        String destinationFile;
        String targetFileName = targetPath.substring(targetPath.lastIndexOf("\\") + 1);

        File file = new File(targetFile);
        File destination = new File(targetPath);

        if(destination.isDirectory())
        {
            File[] files = file.listFiles();

            for(File fn: files)
            {
                if(fn.isDirectory() || fn.isHidden() || fn.delete())
                {
                    continue;
                }
                targetPath = String.format("%s\\%s", target, fn.getName());
                PrinterMessage.getPrinterMessage().printMessage(targetPath);
                isCreated = createFile(targetPath);
                if(isCreated)
                {
                    destinationFile = targetPath;
                    copiedCount += copyFile(fn.getAbsolutePath(), destinationFile);
                }
            }
        }
        else
        {
            PrinterMessage.getPrinterMessage().printMessage(targetFileName);
            answer = askOverwriting(targetFileName);
            if(answer.equals("y") || answer.equals("yes"))
            {
                destinationFile = targetPath;
                copiedCount += copyFile(targetFile, destinationFile);
            }
        }

        return copiedCount;
    }
    private boolean createFile(String targetPath)
    {
        String answer;
        if(Files.exists(Paths.get(targetPath)))
        {
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
    private int copyFile(String sourceFile, String destination)
    {
        int copiedCount = 0;

        try (InputStream inputStream = new FileInputStream(sourceFile);
             OutputStream outputStream = new FileOutputStream(destination);)
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while((bytesRead = inputStream.read(buffer)) != -1)
            {
                outputStream.write(buffer, 0, bytesRead);
            }
            copiedCount++;
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        return copiedCount;
    }
    private String askOverwriting(String targetFile)
    {
        Scanner scanner = new Scanner(System.in);
        String answer;
        String message = String.format("%s을(를) 덮어쓰시겠습니까? (Yes/No/All): ", targetFile);
        PrinterMessage.getPrinterMessage().printMessage(message);

        answer = scanner.nextLine();
        answer.toLowerCase();

        return answer;
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
