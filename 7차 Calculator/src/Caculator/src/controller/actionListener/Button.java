package controller.actionListener;

import controller.Calculation;
import controller.ValueUpdater;
import main.Main;
import model.TotalStorage;
import view.MainView;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Button implements ActionListener
{
    private ValueUpdater valueUpdater;
    private TotalStorage totalStorage;
    private MainView mainView;
    public Button(ValueUpdater valueUpdater, TotalStorage totalStorage, MainView mainView)
    {
        this.valueUpdater = valueUpdater;
        this.totalStorage = totalStorage;
        this.mainView = mainView;
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        mainView.requestFocus();
        switch (command)
        {
            case "⟲":
                mainView.addLogPanel(totalStorage.result);
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