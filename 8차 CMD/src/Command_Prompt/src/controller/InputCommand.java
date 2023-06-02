package controller;

import controller.nessesaryPathCommand.CD;
import controller.nessesaryPathCommand.COPY;
import controller.nessesaryPathCommand.DIR;
import controller.nessesaryPathCommand.MOVE;
import controller.nonnessesaryPathCommand.CLS;
import controller.nonnessesaryPathCommand.HELP;
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
    public InputCommand()
    {
        exceptionHandler = new ExceptionHandler();
        inputDTO = new InputDTO();
        currentStateDTO = new CurrentStateDTO();
        cd = new CD(inputDTO, currentStateDTO, exceptionHandler);
        copy = new COPY(inputDTO, currentStateDTO, exceptionHandler);
        dir = new DIR(inputDTO, currentStateDTO, exceptionHandler);
        move = new MOVE(inputDTO, currentStateDTO, exceptionHandler);
        cls = new CLS();
        help = new HELP();
    }
    public void inputCommand() throws IOException {
        boolean isExit = true;
        boolean isValidCommand = true;
        String command;

        currentStateDTO.setPath(System.getProperty("user.home"));
        takeInCMDMention();

        while(isExit)
        {
            isExit = false;
            Scanner sc = new Scanner(System.in);
            String input;

            PrinterMessage.getPrinterMessage().printCurrentPath(currentStateDTO.getPath());

            input = sc.nextLine();
            inputDTO.setTotalInput(input);

            command = cutEmpty();
            if(command != "exit")
            {
                isExit = true;
            }

            isValidCommand = exceptionHandler.isValidCommand(command);
            if(isValidCommand)
            {
                inputDTO.setCommand(command);
                enterCommandService();
            }
        }
    }
    private void takeInCMDMention() throws IOException
    {
        Process process = Runtime.getRuntime().exec("cmd");
        InputStream stdout = process.getInputStream();
        InputStreamReader inputStreamReader = new InputStreamReader(stdout);
        BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
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
            {
                break;
            }
            else if(input.charAt(i) != ' ')
            {
                isEmpty = false;
                command += String.valueOf(input.charAt(i));
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
        }
    }
}
