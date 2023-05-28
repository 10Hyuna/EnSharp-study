package controller.actionListener;

import controller.Calculation;
import controller.ValueUpdater;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Button implements ActionListener
{
    private ValueUpdater valueUpdater;
    private Calculation calculation;
    public Button()
    {
        valueUpdater = new ValueUpdater();
        calculation = new Calculation();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        switch (command)
        {
            case "⟲":
                break;
            case "CE":
                calculation.InputCE();
                //valueUpdater.processInputtedClear();
                break;
            case "C":
                calculation.InputC();
                //valueUpdater.processInputtedClear();
                break;
            case "=":
                calculation.InputEqual();
                //valueUpdater.processInputtedEqual();
                break;
            case "+": case "-": case "×": case "÷":
                calculation.InputOperator(command);
                //valueUpdater.processInputtedOperator(command);
                break;
            case "+/-":
                calculation.InputNegate();
                //valueUpdater.processInputtedNegate();
                break;
            case "⌫":
                calculation.InputBackspace();
                //valueUpdater.processInputtedDeleter();
                break;
            case ".":
                calculation.InputPoint();
                //valueUpdater.processInputtedPoint();
                break;
            default:
                calculation.InputNumber(command);
                //valueUpdater.processInputtedNumber(command);
                break;
        }
    }
}