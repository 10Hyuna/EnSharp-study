package controller.actionListener;

import controller.Calculation;
import controller.ValueUpdater;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Button implements ActionListener
{
    private ValueUpdater valueUpdater;
    public Button(ValueUpdater valueUpdater)
    {
        this.valueUpdater = valueUpdater;
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
                valueUpdater.processInputtedNegate();
                break;
            case "⌫":
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