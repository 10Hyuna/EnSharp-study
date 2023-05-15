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
        }
        else if(command.equals("."))
        {
            calculator.inputPoint();
        }
        else if(command.equals("÷") || command.equals("×") ||
                command.equals("-") || command.equals("+"))
        {
            calculator.inputOperator(command);
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
