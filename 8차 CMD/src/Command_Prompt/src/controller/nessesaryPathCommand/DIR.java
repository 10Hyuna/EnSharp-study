package controller.nessesaryPathCommand;

import controller.ExcutionCommand;
import controller.ManagementDetailCommand;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.File;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DIR extends ManagementDetailCommand implements ExcutionCommand
{
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ManagementDetailCommand managementDetailCommand;
    private long restByte;
    public DIR(InputDTO inputDTO, CurrentStateDTO currentStateDTO,
               ExceptionHandler exceptionHandler, ManagementDetailCommand managementDetailCommand)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
        this.managementDetailCommand = managementDetailCommand;
    }
    @Override
    public void excuteCommand()
    {
        restByte = 0;
        String detailCommand;
        File files[] = {};
        String path = currentStateDTO.getPath();

        detailCommand = managementDetailCommand.distinguishDetailCommand("dir", inputDTO.getTotalInput(), path);
        // 명령어의 상세 사항을 구분하는 함수 호출
        if(detailCommand == Constant.FAIL)
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.FILE_EXISTENCE, "");
            return;
        }
        else if(detailCommand != Constant.EMPTY)
        {   // 어느 경로가 반환되었다면
            path = detailCommand;
            // 경로 갱신
        }

        path = path.replace("\\\\", "\\");
        PrinterMessage.getPrinterMessage().printMessage(String.format("\n %s 디렉터리\n", path));

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
            parseFileInformation(files);
            // 파일의 정보를 관리하는 함수 호출
        }
        else
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_FILE, "");
            // 예외 처리 (올바르지 않은 경로)
        }
    }
    private void parseFileInformation(File[] files)
    {
        int fileCount = 0;
        int directoryCount = 0;
        long usedByte = 0;
        String[] fileInformation = new String[5];
        String date;

        for(File file : files)
        {
            if(file.isFile() && file.isHidden())
            {   // 숨긴 파일은 출력 안 함
                continue;
            }
            else if(file.isDirectory() && file.delete())
            {   // junction 폴더는 출력 안 함
                continue;
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
            fileInformation[4] = file.getName();
            PrinterMessage.getPrinterMessage().printFileInformation(fileInformation);
        }
        PrinterMessage.getPrinterMessage().printFolder(fileCount, directoryCount, usedByte, restByte);
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
}
