package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.GoingOverPath;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DIR implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private GoingOverPath goingOverPath;
    private long restByte;
    private long usedByte = 0;
    private int fileCount;
    private int directoryCount;
    public DIR(InputDTO inputDTO, CurrentStateDTO currentStateDTO, GoingOverPath goingOverPath)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.goingOverPath = goingOverPath;
    }
    @Override
    public void excuteCommand()
    {
        fileCount = 0;
        directoryCount = 0;
        restByte = 0;
        String path = inputDTO.getcutCommand();
        currentStateDTO.setExcutedPath(currentStateDTO.getPath());

        goingOverPath.discriminatePath(path);
        // 커맨드와 입력 받은 경로 처리하는 함수 호출

        path = currentStateDTO.getExcutedPath();

        TakeInSerialNumber();
        PrinterMessage.getPrinterMessage().printMessage(String.format("\n %s 디렉터리\n\n", path));

        File file = new File(path);
        // 그 경로 내부의 파일, 디렉토리 읽어 오기
        checkFileValid(file);
        // 그 경로의 유효성 검사
    }
    private void checkFileValid(File file)
    {
        File[] files;

        if(file.exists() && file.isDirectory())
        {   // 그 경로가 존재하고, 그 경로가 디렉토리의 경로일 경우
            restByte = file.getFreeSpace();
            // 경로 내부 남은 바이트 반환

            files = file.listFiles();
            parseFileInformation(files, file);
            // 파일의 정보를 관리하는 함수 호출
        }
        else
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_FILE, "");
            // 예외 처리 (올바르지 않은 경로)
        }
    }
    private void parseFileInformation(File[] files, File file)
    {
        String[] fileInformation = new String[5];
        String date;
        File currentFile;
        File previousFile;

        if(!(file.getPath().equals("C:\\") || file.getPath().equals("c:\\")))
        {
            // 현재 위치가 최상위 폴더가 아닐 때
            File parentFile = new File(file.getPath());
            if(file.getParent().equals("C:\\") || file.getParent().equals("c:\\"))
            {
                // 현재 위치의 부모 경로가 최상위 폴더일 때
                currentFile = new File(file.getPath());
                sortFileInformation(currentFile);
            }
            else
            {
                currentFile = new File(file.getPath());
                previousFile = new File(file.getParent());
                sortFileInformation(currentFile);
                sortFileInformation(previousFile);
            }
        }

        for(File fn : files)
        {
            sortFileInformation(fn);
        }
        PrinterMessage.getPrinterMessage().printFolder(fileCount, directoryCount, usedByte, restByte);
    }
    private void sortFileInformation(File file)
    {
        String date;
        String[] fileInformation = new String[5];

        if(file.isFile() && file.isHidden())
        {
            return;
        }
        else if(file.isDirectory() && file.delete())
        {
            return;
        }
        date = formatDate(file);
        // 최근 수정 날짜를 cmd 형식으로 포맷팅 해 주는 함수 호출

        fileInformation[0] = date.substring(0, 10);
        // 일자
        fileInformation[1] = date.substring(11);
        // 시간

        if(file.isFile())
        {
            fileCount++;
            usedByte += file.length();
            fileInformation[2] = " ";
            fileInformation[3] = String.valueOf(file.length());
        }
        else
        {
            directoryCount++;
            fileInformation[2] = "<DIR>";
            fileInformation[3] = " ";
        }
        if(file.getPath().equals(currentStateDTO.getExcutedPath()))
        {   // 파일이 현재 위치와 같다면
            fileInformation[4] = ".";
        }
        else if(file.getPath().equals(currentStateDTO.getExcutedPath().substring(0, currentStateDTO.getExcutedPath().lastIndexOf("\\"))))
        {   // 파일이 현재 위치의 부모 경로와 같다면
            fileInformation[4] = "..";
        }
        else
        {
            fileInformation[4] = file.getName();
        }
        PrinterMessage.getPrinterMessage().printFileInformation(fileInformation);
    }
    private String formatDate(File file)
    {
        long lastModified;
        String format = "yyyy-MM-dd aa hh:mm";
        String date;
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat(format);

        lastModified = file.lastModified();

        Date lastModifiedDate = new Date(lastModified);
        date = simpleDateFormat.format(lastModifiedDate);
        date = date.replace("AM", "오전");
        date = date.replace("PM", "오후");

        return date;
    }
    private void TakeInSerialNumber()
    {
        try {
            ProcessBuilder processBuilder = new ProcessBuilder("cmd.exe", "/c", "dir");
            processBuilder.redirectErrorStream(true);

            Process process = processBuilder.start();

            InputStream inputStream = process.getInputStream();
            BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream, Charset.forName("EUC-KR")));

            String line;
            for(int i = 0; i < 2; i++)
            {
                line = bufferedReader.readLine();
                PrinterMessage.getPrinterMessage().printMessage(line);
                PrinterMessage.getPrinterMessage().printMessage("\n");
            }
            process.waitFor();
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
