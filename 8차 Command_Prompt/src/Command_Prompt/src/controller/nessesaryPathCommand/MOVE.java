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

public class MOVE implements ExcutionCommand
{
    private CurrentStateDTO currentStateDTO;
    private ConfirmationPath confirmationPath;
    public MOVE(CurrentStateDTO currentStateDTO, ConfirmationPath confirmationPath)
    {
        this.currentStateDTO = currentStateDTO;
        this.confirmationPath = confirmationPath;
    }
    @Override
    public void excuteCommand()
    {
        String sourcePath;
        String targetPath;
        File sourceFile;
        boolean isSuccessSetting;
        boolean isDirectory;
        isSuccessSetting = confirmationPath.setPath();
        // 입력받은 sourcePath와 targetPath를 정규화해 주는 함수 호출

        int movedCount = 0;

        if(isSuccessSetting)
        // sourcePath와 targetPath가 올바른 경로일 경우
        {
            sourcePath = currentStateDTO.getExcutedPath();
            targetPath = currentStateDTO.getDestinationPath();

            sourceFile = new File(sourcePath);
            isDirectory = sourceFile.isDirectory();
            movedCount += moveFile(sourcePath, targetPath);
            // 이동시킨 객체들이 몇 개인지 확인

            if(isDirectory)
            {
                // 이동시키려는 파일 객체가 폴더일 경우
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
    private int moveFile(String sourcePath, String destinationPath)
    {
        int movedCount = 0;

        File sourceFile = new File(sourcePath);
        File destinationFile = new File(destinationPath);
        File destinatedPath = new File(destinationPath);

        if(destinationFile.isDirectory())
        {
            // 이동의 목적지가 폴더일 경우
            destinatedPath = new File(destinationPath, sourceFile.getName());
            // 폴더 내부의 한 파일에 접근하는 객체 선언
        }

        try
        {
            Path sourceFilePath = sourceFile.toPath();
            Path destinationFilePath = destinatedPath.toPath();
            Files.move(sourceFilePath, destinationFilePath, StandardCopyOption.REPLACE_EXISTING);
            // 파일 이동
            movedCount++;
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }

        return movedCount;
    }
}
