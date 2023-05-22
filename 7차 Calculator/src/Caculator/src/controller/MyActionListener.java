package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MyActionListener implements ActionListener
{
    private Calculation calculate;
    private static MyActionListener myActionListener;

    public MyActionListener()
    {
        calculate = new Calculation();
    }
    public static MyActionListener GetMyActionListener()
    {
        if(myActionListener == null)
        {
            myActionListener = new MyActionListener();
        }
        return myActionListener;
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        switch (command)
        {
            case "CE":
                calculate.InputCE();
                break;
            case "C":
                calculate.InputC();
                break;
            case "=":
                calculate.InputEqual();
                break;
            case "+": case "-": case "×": case "÷":
                calculate.InputOperator(command);
                break;
            case "+/-":
                calculate.InputNegate();
                break;
            case "⌫":
                calculate.InputBackspace();
                break;
            case ".":
                calculate.InputPoint();
                break;
            default:
                calculate.InputNumber(command);
                break;
        }
    }
}