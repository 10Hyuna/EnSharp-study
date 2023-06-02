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
    private long restByte;
    public DIR(InputDTO inputDTO, CurrentStateDTO currentStateDTO, ExceptionHandler exceptionHandler)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
        this.exceptionHandler = exceptionHandler;
    }
    @Override
    public void excuteCommand()
    {
        restByte = 0;
        String detailCommand;
        File files[] = {};
        String path = currentStateDTO.getPath();

        detailCommand = managerDirCommand();
        if(detailCommand != Constant.EMPTY)
        {
            path = detailCommand;
        }

        File file = new File(path);
        restByte = file.getUsableSpace();
        if(file.exists() && file.isDirectory())
        {
            files = file.listFiles();
            parseFileInformation(files);
        }
        else
        {
            PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_FILE, "");
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
            {
                continue;
            }
            else if(file.isDirectory() && file.delete())
            {
                continue;
            }
            date = formatDate(file);
            fileInformation[0] = date.substring(0, 10);
            fileInformation[1] = date.substring(11);
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
