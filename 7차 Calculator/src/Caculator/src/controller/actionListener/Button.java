package controller.actionListener;

import controller.Calculation;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Button implements ActionListener
{
    private Calculation calculation;
    public Button()
    {
        calculation = new Calculation();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        switch (command)
        {
            case "CE":
                calculation.InputCE();
                break;
            case "C":
                calculation.InputC();
                break;
            case "=":
                calculation.InputEqual();
                break;
            case "+": case "-": case "×": case "÷":
                calculation.InputOperator(command);
                break;
            case "+/-":
                calculation.InputNegate();
                break;
            case "⌫":
                calculation.InputBackspace();
                break;
            case ".":
                calculation.InputPoint();
                break;
            default:
                calculation.InputNumber(command);
                break;
        }
    }
}