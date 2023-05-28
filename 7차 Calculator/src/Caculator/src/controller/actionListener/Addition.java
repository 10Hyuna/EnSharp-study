package controller.actionListener;

import view.MainView;
import view.TotalComponent;

import javax.swing.*;

public class Addition {
    private JButton[] calculatorButton;
    private JButton logButton;
    private Button button;
    private MainView mainView;
    private Component component;
    private Keyboard keyboard;
    public Addition(MainView mainview)
    {
        calculatorButton = TotalComponent.getTotalComponent().getCalculatorButton();
        logButton = TotalComponent.getTotalComponent().getLogButton();

        this.mainView = mainview;

        button = new Button();
        component = new Component();
        keyboard = new Keyboard();
    }
    public void addActionListener()
    {
        for (int i = 0; i < calculatorButton.length; i++)
        {
            calculatorButton[i].addActionListener(button);
        }
        mainView.addKeyListener(keyboard);
        mainView.addComponentListener(component);
        logButton.addActionListener(button);
    }
    public void sendComponent()
    {

    }
}
