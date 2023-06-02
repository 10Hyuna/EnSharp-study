package controller;

import controller.nessesaryPathCommand.CD;
import controller.nessesaryPathCommand.COPY;
import controller.nessesaryPathCommand.DIR;
import controller.nessesaryPathCommand.MOVE;
import controller.unnessesaryPathCommand.CLS;
import controller.unnessesaryPathCommand.HELP;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.Scanner;

public class InputCommand
{
    private CD cd;
    private COPY copy;
    private DIR dir;
    private MOVE move;
    private CLS cls;
    private HELP help;
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    private ExceptionHandler exceptionHandler;
    private ManagementDetailCommand managementDetailCommand;
    public InputCommand()
    {
        exceptionHandler = new ExceptionHandler();
        inputDTO = new InputDTO();
        currentStateDTO = new CurrentStateDTO();
        managementDetailCommand = new ManagementDetailCommand();
        cd = new CD(inputDTO, currentStateDTO, exceptionHandler, managementDetailCommand);
        copy = new COPY(inputDTO, currentStateDTO, exceptionHandler, managementDetailCommand);
        dir = new DIR(inputDTO, currentStateDTO, exceptionHandler, managementDetailCommand);
        move = new MOVE(inputDTO, currentStateDTO, exceptionHandler, managementDetailCommand);
        cls = new CLS();
        help = new HELP();
    }
    public void inputCommand() throws IOException {
        boolean isExit = true;
        boolean isValidCommand = true;
        String command;

        currentStateDTO.setPath(System.getProperty("user.home"));
        // 프로그램이 처음 시작할 때 첫 경로를 사용자 폴더로 지정
        takeInCMDMention();
        // cmd 첫 실행 시 뜨는 운영체제 알림창 출력 함수 호출

        while(isExit)
        {
            isExit = false;
            Scanner sc = new Scanner(System.in);
            String input;

            PrinterMessage.getPrinterMessage().printCurrentPath(currentStateDTO.getPath());
            // 현재 위치한 경로 출력

            input = sc.nextLine();
            // 명령어 입력 받기
            inputDTO.setTotalInput(input);
            // 입력 받은 명령어 dto에 저장

            command = cutEmpty();
            // 입력받은 명령어에서 앞에 존재할 수도 있는 공백 등과 같은 예외들을 다 자르고 명령어만 반환
            if(command != "exit")
            // 명령어가 탈출을 의미하는 exit가 아니라면
            {
                isExit = true;
                // 반복문을 계속해서 실행할 수 있게 isExit 변수를 true로 설정
            }

            isValidCommand = exceptionHandler.isValidCommand(command);
            // 입력받은 명령어가 유효한 명령어인지 확인
            if(isValidCommand)
            {   // 유효한 명령어라면
                inputDTO.setCommand(command);
                // DTO에 명령어 저장
                enterCommandService();
                // 입력한 명령어에 해당하는 서비스로 들어갈 수 있도록
            }
        }
    }
    private void takeInCMDMention() throws IOException
    {
        Process process = Runtime.getRuntime().exec("cmd");
        // cmd 프로그램 실행
        InputStream stdout = process.getInputStream();
        InputStreamReader inputStreamReader = new InputStreamReader(stdout);
        BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
        // cmd 프로그램에서 텍스트 읽어오기
        String line;

        try
        {
            for (int i = 0; i < 2; i++)
            {
                line = bufferedReader.readLine();
                PrinterMessage.getPrinterMessage().printMessage(line);
            }
            PrinterMessage.getPrinterMessage().printMessage("");
        }
        catch (IOException e)
        {
            PrinterMessage.getPrinterMessage().printMessage(e.getMessage());
        }
    }
    private String cutEmpty()
    {
        boolean isEmpty = true;
        String command = "";
        String input = inputDTO.getTotalInput();
        for(int i = 0; i < input.length(); i++)
        {
            if(input.charAt(i) == '.' || input.charAt(i) == '/' || input.charAt(i) == '&')
            {   // 커맨드와 함께 사용할 수 있는 특수문자가 나왔을 경우 반복문 종료
                break;
            }
            else if(input.charAt(i) != ' ')
            {   // 공백이 아닌 값이 나왔을 경우,
                isEmpty = false;
                command += String.valueOf(input.charAt(i));
                // 입력값을 저장
            }
            else
            {
                if(!isEmpty)
                {
                    break;
                }
            }
        }
        return command;
    }
    private void enterCommandService()
    {
        String command = inputDTO.getCommand();

        switch (command)
        {
            case "cd":
                cd.excuteCommand();
                break;
            case "dir":
                dir.excuteCommand();
                break;
            case "copy":
                copy.excuteCommand();
                break;
            case "move":
                move.excuteCommand();
                break;
            case "cls":
                cls.excuteCommand();
                break;
            case "help":
                help.excuteCommand();
                break;
            default:
                // 명령어가 exit일 경우
                break;
        }
    }
}
