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
    private Calculator calculator;
    private MyActionListener()
    {
        calculator = new Calculator();
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
        //inputtedValue = null;
        String command = e.getActionCommand();
        if(command.equals("0") || command.equals("1") || command.equals("2")
        || command.equals("3") || command.equals("4") || command.equals("5")
        || command.equals("6") || command.equals("7") || command.equals("8")
                || command.equals("9") || command.equals("."))
        {
            calculator.inputNumber();
//            inputtedValue = currentInputs.getText();
//            if(isCalculated)
//            {
//                isCalculated = false;
//                inputtedValue = command;
//            }
//            else if(inputtedValue == "0" || operator != null)
//            {
//                operator = null;
//                inputtedValue = command;
//            }
//            else
//            {
//                inputtedValue += command;
//            }
//            currentInputs.setText(inputtedValue);
        }
        else if(command.equals("÷") || command.equals("×") ||
                command.equals("-") || command.equals("+"))
        {
            calculator.inputOperator();
//            operator = command;
//            if(isCalculated)
//            {
//                inputtedValue = currentInputs.getText();
//            }
//            else if(recentInputs.getText() != "")
//            {
//                result = inputValueParse.calculateValue(currentInputs.getText(), recentInputs.getText());
//                inputtedValue = String.valueOf(result);
//            }
//            else
//            {
//                inputtedValue = currentInputs.getText();
//            }
//            inputtedValue += command;
//            recentInputs.setText(inputtedValue);
        }
        else if(command.equals("CE"))
        {
            calculator.inputCE();
//            currentInputs.setText("0");
        }
        else if(command.equals("C"))
        {
            calculator.inputC();
//            currentInputs.setText("0");
//            recentInputs.setText("");
        }
        else if(command.equals("="))
        {
            calculator.inputEqual();
//            if(!isCalculated)
//            {
//                isCalculated = true;
//                result = inputValueParse.calculateValue(currentInputs.getText(), recentInputs.getText());
//                inputValueParse.parseInput(currentInputs.getText(), recentInputs.getText());
//                inputtedValue = String.format("%s%s =", recentInputs.getText(), currentInputs.getText());
//                recentInputs.setText(inputtedValue);
//                currentInputs.setText(String.valueOf(result));
//            }
        }
        else if(command.equals("⌫"))
        {
            calculator.inputBackspqce();
//            inputtedValue = currentInputs.getText();
//            currentInputs.setText(inputtedValue.substring(0, inputtedValue.length() - 1));
//            if(currentInputs.getText() == "")
//            {
//                currentInputs.setText("0");
//            }
        }
        else if(command.equals("+/-"))
        {
            calculator.inputNegate();
//            if(recentInputs.getText() != "")
//            {
//                inputtedValue = String.format("negate(%s)", recentInputs.getText());
//                recentInputs.setText(inputtedValue);
//            }
//            if(currentInputs.getText() != "0")
//            {
//                inputtedValue = String.valueOf(Integer.parseInt(currentInputs.getText()) * -1);
//                currentInputs.setText(inputtedValue);
//            }
        }
    }
}
