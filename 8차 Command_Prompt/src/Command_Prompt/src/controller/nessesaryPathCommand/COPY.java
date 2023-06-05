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
    private CurrentStateDTO currentStateDTO;
    private ConfirmationPath confirmationPath;
    public COPY(CurrentStateDTO currentStateDTO, ConfirmationPath confirmationPath)
    {
        this.currentStateDTO = currentStateDTO;
        this.confirmationPath = confirmationPath;
    }
    @Override
    public void excuteCommand()
    {
        String sourcePath;
        String targetPath;
        boolean isSuccessSetting;
        isSuccessSetting = confirmationPath.setPath();
        // 입력받은 sourcePath와 targetPath를 정규화해 주는 함수 호출

        int copiedCount = 0;

        if(isSuccessSetting)
        {
            sourcePath = currentStateDTO.getExcutedPath();
            targetPath = currentStateDTO.getDestinationPath();

            copiedCount = checkOneFlie(sourcePath, targetPath);
            // 이동시킨 객체들이 몇 개인지 확인

            String successMessage = String.format("       %d개 파일이 복사되었습니다.\n", copiedCount);
            PrinterMessage.getPrinterMessage().printMessage(successMessage);
        }
    }
    public int checkOneFlie(String sourcePath, String targetPath)
    {
        boolean isCreated;
        int copiedCount = 0;
        String target = targetPath;
        String destinationFile;

        File sourceFile = new File(sourcePath);

        if(sourceFile.isDirectory())
        {
            // 이동시키고자 하는 객체가 폴더일 경우
            File[] files = sourceFile.listFiles();
            // 그 폴더 내부의 파일을 하나하나 복사하기 위해 이동시키고자 하는 파일 객체를 list로 반환

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
                // 복사하고자 하는 파일이 이미 존재하는 파일인지 확인하고 덮어쓸 것인지 물어보기 위한 함수 호출
                if(isCreated)
                {
                    // 복사하고자 하는 파일이 없어서 파일 객체를 만들었을 경우
                    destinationFile = targetPath;
                    copiedCount += copyFile(fn.getAbsolutePath(), destinationFile);
                    // 파일 복사
                }
            }
        }
        else
        {
            isCreated = confirmationPath.createFile(targetPath);
            if(isCreated)
            {
                destinationFile = targetPath;
                copiedCount += copyFile(sourcePath, destinationFile);
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
