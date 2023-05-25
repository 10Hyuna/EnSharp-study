package controller;

import controller.actionListener.Addition;
import view.MainView;

import javax.swing.*;

public class CalculatorStart
{
    private MainView mainView;
    private Addition addition;
    private JFrame mainFrame;
    public CalculatorStart()
    {
        mainView = new MainView();
        addition = new Addition();
    }
    public void setCalculator()
    {
        mainFrame = mainView.setFrame();
        addition.addActionListener(mainFrame);
    }
}
