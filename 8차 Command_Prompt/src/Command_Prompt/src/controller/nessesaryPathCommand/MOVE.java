package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.StandardCopyOption;

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
        String sourcePath;
        String targetPath;
        File sourceFile;
        boolean isSuccessSetting;
        isSuccessSetting = confirmationPath.setPath();

        int movedCount = 0;

        if(isSuccessSetting)
        {
            sourcePath = currentStateDTO.getExcutedPath();
            targetPath = currentStateDTO.getDestinationPath();

            sourceFile = new File(sourcePath);
            movedCount = checkOneFlie(currentStateDTO.getExcutedPath(), currentStateDTO.getDestinationPath());
            if(sourceFile.isDirectory())
            {
                String successMessage = String.format("        %d개의 디렉터리를 이동했습니다.\n", movedCount);
                PrinterMessage.getPrinterMessage().printMessage(successMessage);
            }
            else
            {
                String successMessage = String.format("        %d개 파일을 이동했습니다.\n", movedCount);
                PrinterMessage.getPrinterMessage().printMessage(successMessage);
            }
        }
    }

    @Override
    public int checkOneFlie(String sourcePath, String targetPath) {

        int movedCount = 0;

        movedCount += moveFile(sourcePath, targetPath);

        return movedCount;
    }
    private int moveFile(String sourcePath, String destinationPath)
    {
        int movedCount = 0;

        File sourceFile = new File(sourcePath);
        File destinationFile = new File(destinationPath);
        File destinatedPath = new File(destinationPath);

        if(destinationFile.isDirectory())
        {
            destinatedPath = new File(destinationPath, sourceFile.getName());
        }

        try
        {
            Path sourceFilePath = sourceFile.toPath();
            Path destinationFilePath = destinatedPath.toPath();
            Files.move(sourceFilePath, destinationFilePath, StandardCopyOption.REPLACE_EXISTING);
            movedCount++;
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        return movedCount;
    }
}
