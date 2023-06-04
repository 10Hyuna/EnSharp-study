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

public class COPY implements ExcutionCommand, ConfirmationFile
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ConfirmationPath confirmationPath;
    public COPY(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
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

        int copiedCount = 0;

        if(isSuccessSetting)
        {
            copiedCount = checkOneFlie(currentStateDTO.getExcutedPath(), currentStateDTO.getDestinationPath());
            String successMessage = String.format("       %d개 파일이 복사되었습니다.\n", copiedCount);
            PrinterMessage.getPrinterMessage().printMessage(successMessage);
        }
    }
    @Override
    public int checkOneFlie(String targetFile, String targetPath)
    {
        boolean isCreated;
        int copiedCount = 0;
        String target = targetPath;
        String destinationFile;

        File file = new File(targetFile);

        if(file.isDirectory())
        {
            File[] files = file.listFiles();

            for(File fn: files)
            {
                if(fn.isDirectory() || fn.isHidden())
                {
                    continue;
                }
                targetPath = String.format("%s\\%s", target, fn.getName());
                PrinterMessage.getPrinterMessage().printMessage(targetPath);
                PrinterMessage.getPrinterMessage().printMessage("\n");
                isCreated = confirmationPath.createFile(targetPath);
                if(isCreated)
                {
                    destinationFile = targetPath;
                    copiedCount += copyFile(fn.getAbsolutePath(), destinationFile);
                }
            }
        }
        else
        {
            isCreated = confirmationPath.createFile(targetPath);
            if(isCreated)
            {
                destinationFile = targetPath;
                copiedCount += copyFile(targetFile, destinationFile);
            }
        }

        return copiedCount;
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
}
