package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

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
        String command = e.getActionCommand();
        if(command.equals("0") || command.equals("1") || command.equals("2")
        || command.equals("3") || command.equals("4") || command.equals("5")
        || command.equals("6") || command.equals("7") || command.equals("8")
                || command.equals("9"))
        {
            calculator.inputNumber(command);
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
        else if(command.equals("."))
        {
            calculator.inputPoint();
        }
        else if(command.equals("÷") || command.equals("×") ||
                command.equals("-") || command.equals("+"))
        {
            calculator.inputOperator(command);
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
        }
        else if(command.equals("C"))
        {
            calculator.inputC();
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
        }
        else if(command.equals("+/-"))
        {
            calculator.inputNegate();
        }
    }
}
