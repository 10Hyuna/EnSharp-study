package controller;

import controller.actionListener.AdditionActionListener;
import view.MainView;

import javax.swing.*;

public class CalculatorStart {
    private MainView mainView;
    private AdditionActionListener additionActionListener;
    private JFrame mainFrame;
    public CalculatorStart()
    {
        mainView = new MainView();
        additionActionListener = new AdditionActionListener();
    }
    public void SetCalculator()
    {
        mainFrame = mainView.SetFrame();
        additionActionListener.AddActionListener(mainFrame);
    }
}
