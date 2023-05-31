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
import view.PrinterMessage;

import java.io.IOException;
import java.util.Scanner;
import java.util.regex.Pattern;

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
    public InputCommand()
    {
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

            isExit = isValidCommand(command);
            if(!isExit)
            {
                continue;
            }
            enterCommandService();
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
        Pattern cd = Pattern.compile(Constant.MATCH_CD);
        Pattern dir = Pattern.compile(Constant.MATCH_DIR);
        Pattern copy = Pattern.compile(Constant.MATCH_COPY);
        Pattern move = Pattern.compile(Constant.MATCH_MOVE);
        Pattern cls = Pattern.compile(Constant.MATCH_CLS);
        Pattern help = Pattern.compile(Constant.MATCH_HELP);
        Pattern exit = Pattern.compile(Constant.MATCH_EXIT);

        if(Pattern.matches(cd.pattern(), command))
        {
            inputDTO.setCommand("cd");
        }
        else if(Pattern.matches(dir.pattern(), command))
        {
            inputDTO.setCommand("dir");
        }
        else if(Pattern.matches(copy.pattern(), command))
        {
            inputDTO.setCommand("copy");
        }
        else if(Pattern.matches(move.pattern(), command))
        {
            inputDTO.setCommand("move");
        }
        else if(Pattern.matches(help.pattern(), command))
        {
            inputDTO.setCommand("help");
        }
        else if(Pattern.matches(cls.pattern(), command))
        {
            inputDTO.setCommand("cls");
        }
        else if(Pattern.matches(exit.pattern(), command))
        {
            return false;
        }
        else
        {

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
