package controller.actionListener;

import controller.Calculation;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MyButtonActionListener implements ActionListener
{
    private Calculation calculate;
    private static MyButtonActionListener myButtonActionListener;

    public MyButtonActionListener()
    {
        calculate = new Calculation();
    }
    public static MyButtonActionListener GetMyActionListener()
    {
        if(myButtonActionListener == null)
        {
            myButtonActionListener = new MyButtonActionListener();
        }
        return myButtonActionListener;
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