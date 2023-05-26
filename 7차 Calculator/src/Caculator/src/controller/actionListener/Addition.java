package controller.actionListener;

import view.TotalComponent;

import javax.swing.*;

public class Addition {
    private JButton[] calculatorButton;
    private JButton logButton;
    private Button button;
    private Component component;
    private Keyboard keyboard;
    public Addition()
    {
        calculatorButton = TotalComponent.getTotalComponent().getCalculatorButton();
        logButton = TotalComponent.getTotalComponent().getLogButton();

        button = new Button();
        component = new Component();
        keyboard = new Keyboard();
    }
    public void addActionListener(JFrame mainFrame)
    {
        for (int i = 0; i < calculatorButton.length; i++)
        {
            calculatorButton[i].addActionListener(button);
        }
        mainFrame.addKeyListener(keyboard);
        mainFrame.addComponentListener(component);
        logButton.addActionListener(button);
    }
    public void sendComponent()
    {

    }
}
