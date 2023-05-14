package utility;

import controller.Calculator;
import view.InputState;
import view.ManagementInput;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;

public class MyActionListener implements ActionListener {

    private static MyActionListener myActionListener;
    private InputValueParse inputValueParse;
    private JLabel currentInputs;
    private JLabel recentInputs;
    private String inputtedValue;

    private MyActionListener()
    {
        inputValueParse = new InputValueParse();
        currentInputs = InputState.getInputState().getCurrentInput();
        recentInputs = InputState.getInputState().getRecentInput();
    }

    public static MyActionListener GetMyActionListener()
    {
        if(myActionListener == null)
        {
            myActionListener = new MyActionListener();
        }
        return myActionListener;
    }
    public void actionPerformed(ActionEvent e)
    {
        inputtedValue = null;
        String command = e.getActionCommand();
        if(command.equals("0") || command.equals("1") || command.equals("2")
        || command.equals("3") || command.equals("4") || command.equals("5")
        || command.equals("6") || command.equals("7") || command.equals("8")
                || command.equals("9") || command.equals("."))
        {
            inputtedValue = currentInputs.getText();
            if(inputtedValue == "0")
            {
                inputtedValue = command;
            }
            else
            {
                inputtedValue += command;
            }
            currentInputs.setText(inputtedValue);
        }
        else if(command.equals("÷") || command.equals("×") ||
                command.equals("-") || command.equals("+"))
        {
            inputtedValue = currentInputs.getText();
            inputtedValue += command;
            recentInputs.setText(inputtedValue);
            currentInputs.setText("0");
        }
        else if(command.equals("CE"))
        {
            currentInputs.setText("0");
        }
        else if(command.equals("C"))
        {
            currentInputs.setText("0");
            recentInputs.setText("");
        }
        else if(command.equals("="))
        {
            inputValueParse.parseInput(currentInputs.getText(), recentInputs.getText());
            currentInputs.setText("0");
            recentInputs.setText("");
        }
        else if(currentInputs.getText() != "0" && (command.equals("⌫") && currentInputs.getText().length() != 0))
        {
            inputtedValue = currentInputs.getText();
            currentInputs.setText(inputtedValue.substring(0, inputtedValue.length() - 1));
            if(currentInputs.getText() == "")
            {
                currentInputs.setText("0");
            }
        }
        else if(command.equals("+/-"))
        {
            inputtedValue = String.format("negate(%s)", recentInputs);
            recentInputs.setText(inputtedValue);
            inputtedValue = String.valueOf(Integer.parseInt(currentInputs.getText()) * -1);
            currentInputs.setText(inputtedValue);
        }
    }
}
