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

        String targetPath;
        String sourcePath = currentStateDTO.getPath();
        currentStateDTO.setExcutedPath(sourcePath);

        String inputtedPath = inputDTO.getcutCommand();

        goingOverPath.discriminatePath(inputtedPath);
        // 커맨드 이후에 입력된 값을 경로로 보고 경로를 처리하는 함수 호출

        inputtedPath = parseInputtedParse(inputtedPath);
        targetPath = setTargetPath(inputtedPath);
        // 대상 경로를 정규화해서 설정하는 함수 호출

        sourcePath = currentStateDTO.getExcutedPath();
        isValid = exceptionHandler.isValidPath(sourcePath);
        // 원본 경로가 유효한 경로인지 확인
        isDuplicatedFile = isDuplication(sourcePath, targetPath);
        // 원본 경로와 대상 경로가 일치하는 경로인지 확인

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

        if(!exceptionHandler.isValidPath(parsedPath))
        // parsing된 파일 경로가 절대경로가 아니라면
        {
            currentStateDTO.setExcutedPath(String.format("%s\\%s", currentStateDTO.getPath(), parsedPath));
            // 현재 위치에 parsing된 파일 경로를 이어 붙여 절대 경로로 만듦
        }
        else
        {
            currentStateDTO.setExcutedPath(parsedPath);
        }
        return parsedPath;
    }
    private String setTargetPath(String inputtedPath)
    {
        File validateFile;
        String targetPath;
        String originPath = currentStateDTO.getExcutedPath();
        int targetIndex;

        if(inputtedPath.equals(inputDTO.getcutCommand()))
        {   // 커맨드 뒤에 나온 것이 하나의 경로라면
            targetPath = currentStateDTO.getPath();
            // 목표 경로는 현재 위치
        }
        else
        {
            targetIndex = inputtedPath.length() + 1;
            targetPath = inputDTO.getcutCommand().substring(targetIndex);
            // sourcePath를 제외한 입력 경로를 substring으로 만듦

            validateFile = new File(targetPath);

            if(!validateFile.isAbsolute())
            {   // targetPath 경로로 생성한 객체가 절대경로가 아닐 때,
                if(!validateFile.exists())
                {
                    targetPath = String.format("%s\\%s", currentStateDTO.getPath(), inputDTO.getcutCommand().substring(targetIndex));
                    // 절대경로로 만듦
                }
                else
                {
                    currentStateDTO.setExcutedPath(currentStateDTO.getPath());
                    goingOverPath.discriminatePath(targetPath);
                    targetPath = currentStateDTO.getExcutedPath();
                }
            }
        }
        currentStateDTO.setExcutedPath(originPath);
        currentStateDTO.setDestinationPath(targetPath);
        return targetPath;
    }
    public boolean createFile(String targetPath)
    {
        boolean isFile;
        String answer;
        if(Files.exists(Paths.get(targetPath)))
        // targetPath 경로가 존재한다면
        {
            PrinterMessage.getPrinterMessage().printMessage(targetPath);
            PrinterMessage.getPrinterMessage().printMessage("\n");
            isFile = exceptionHandler.isValidPath(targetPath);
            // 경로의 유효성 검사

            if(!isFile)
            {
                targetPath = String.format("%s\\%s", currentStateDTO.getPath(), targetPath);
                // 절대경로화
            }
            if(!isAll)
            {
                // all을 선택한 적이 없다면
                answer = askOverwriting(targetPath);
                // yes no all 중에 선택
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
            // 파일이 존재하지 않을 때
            try {
                Files.createFile(Paths.get(targetPath));
                // 파일을 만듦
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