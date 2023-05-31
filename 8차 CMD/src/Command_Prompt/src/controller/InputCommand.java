package controller;

import controller.nessesaryPathCommand.CD;
import controller.nessesaryPathCommand.COPY;
import controller.nessesaryPathCommand.DIR;
import controller.nessesaryPathCommand.MOVE;
import controller.nonnessesaryPathCommand.CLS;
import controller.nonnessesaryPathCommand.HELP;
import model.DTO.InputDTO;

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
    public InputCommand()
    {
        inputDTO = new InputDTO();
        cd = new CD(inputDTO);
        copy = new COPY(inputDTO);
        dir = new DIR(inputDTO);
        move = new MOVE(inputDTO);
        cls = new CLS();
        help = new HELP();
    }
    public void inputCommand()
    {
        boolean isExit = true;
        while(isExit)
        {
            isExit = false;
            Scanner sc = new Scanner(System.in);
            String input;

            input = sc.nextLine();
            inputDTO.setTotalInput(input);

            inputDTO.setCommand(distinguishCommand());
            if(inputDTO.getCommand() != "exit")
            {
                isExit = true;
            }
        }
    }
    private String distinguishCommand()
    {
        boolean isEmpty = true;
        String command = "";
        String input = inputDTO.getTotalInput();
        for(int i = 0; i < input.length(); i++)
        {
            if(input.charAt(i) != ' ')
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

        if(command.contains("cd"))
        {

        }
        else if(command.contains("dir"))
        {

        }
        else if(command.contains("copy"))
        {

        }
        else if(command.contains("move"))
        {

        }
        else if(command.contains("cls"))
        {

        }
        else if(command.contains("help"))
        {

        }
    }
}
