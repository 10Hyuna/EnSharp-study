package controller;

import controller.nessesaryPathCommand.CD;
import controller.nessesaryPathCommand.COPY;
import controller.nessesaryPathCommand.DIR;
import controller.nessesaryPathCommand.MOVE;
import controller.nonnessesaryPathCommand.CLS;
import controller.nonnessesaryPathCommand.HELP;
import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;
import utility.ExceptionHandler;
import view.PrinterMessage;

import java.io.IOException;
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
    private TakingCMDMention takingCMDMention;
    private ExceptionHandler exceptionHandler;
    public InputCommand()
    {
        exceptionHandler = new ExceptionHandler();
        takingCMDMention = new TakingCMDMention();
        inputDTO = new InputDTO();
        currentStateDTO = new CurrentStateDTO();
        cd = new CD(inputDTO, currentStateDTO);
        copy = new COPY(inputDTO, currentStateDTO);
        dir = new DIR(inputDTO, currentStateDTO);
        move = new MOVE(inputDTO, currentStateDTO);
        cls = new CLS(currentStateDTO);
        help = new HELP(currentStateDTO);
    }
    public void inputCommand() throws IOException {
        boolean isExit = true;
        boolean isValidCommand = true;
        String command;

        currentStateDTO.setPath(System.getProperty("user.home"));
        takingCMDMention.takeInCMDMention();

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
    private String cutEmpty()
    {
        boolean isEmpty = true;
        String command = "";
        String input = inputDTO.getTotalInput();
        for(int i = 0; i < input.length(); i++)
        {
            if(input.charAt(i) == '.' || input.charAt(i) == '/')
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
    private boolean isValidCommand(String command)
    {
        switch (command)
        {
            case "cd": case "dir": case "copy":
            case "move": case "cls": case "help":
                currentStateDTO.setPath(command);
                break;
            default:
                PrinterMessage.getPrinterMessage().printExceptionMessage(Constant.NON_COMMAND, command);
                return false;
        }
        return true;
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
