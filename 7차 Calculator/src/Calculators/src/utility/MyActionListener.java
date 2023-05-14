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
    private ManagementInput managementInput;
    private JLabel inputLabel;
    private JLabel inputOperator;
    private JLabel inputEnd;
    private JLabel recentInput;
    private String inputtedValue;

    private MyActionListener()
    {
        inputLabel = ManagementInput.GetManagementInput().GetInput();
        inputOperator = ManagementInput.GetManagementInput().GetOperator();
        inputEnd = ManagementInput.GetManagementInput().GetEndInput();
        recentInput = ManagementInput.GetManagementInput().GetRecentInput();
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
        //{ "+/-"};
        String command = e.getActionCommand();
        if(command.equals("0") || command.equals("1") || command.equals("2")
        || command.equals("3") || command.equals("4") || command.equals("5")
        || command.equals("6") || command.equals("7") || command.equals("8")
                || command.equals("9") || command.equals("."))
        {
            inputtedValue = inputLabel.getText();
            inputtedValue += command;
            inputLabel.setText(inputtedValue);
        }
        else if(command.equals("⁒") || command.equals("X") ||
                command.equals("-") || command.equals("+"))
        {
            inputOperator.setText(command);
        }
        else if(command.equals("CE") || command.equals("C") || command.equals("="))
        {
            inputEnd.setText(command);
        }
        else if(command.equals("⌫") && inputLabel.getText().length() != 0)
        {
            inputtedValue = inputLabel.getText();
            inputtedValue.substring(inputtedValue.length() - 1);
            inputLabel.setText(inputtedValue);
        }
        else if(command.equals("+/-"))
        {
            inputtedValue = String.format("negate(%s)", recentInput);
            recentInput.setText(inputtedValue);
            inputtedValue = String.valueOf(Integer.parseInt(inputLabel.getText()) * -1);
            inputLabel.setText(inputtedValue);
        }
    }
}
