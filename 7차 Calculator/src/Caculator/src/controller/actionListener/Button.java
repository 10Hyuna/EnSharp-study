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
                valueUpdater.processInputtedCE();
                break;
            case "C":
                valueUpdater.processInputtedC();
                break;
            case "=":
                valueUpdater.processInputtedEqual();
                break;
            case "+": case "-": case "×": case "÷":
                valueUpdater.processInputtedOperator(command);
                break;
            case "+/-":
                calculation.InputNegate();
                //valueUpdater.processInputtedNegate();
                break;
            case "⌫":
                //calculation.InputBackspace();
                valueUpdater.processInputtedDeleter();
                break;
            case ".":
                valueUpdater.processInputtedPoint();
                break;
            default:
                valueUpdater.processInputtedNumber(command);
                break;
        }
    }
}