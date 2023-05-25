package controller.actionListener;

import view.TotalComponent;

import javax.swing.*;

public class Addition {
    private JButton[] calculatorButton;
    private JTextField currentText;
    private JButton logButton;
    private Button button;
    private Component component;
    private Keyboard keyboard;
    public Addition()
    {
        calculatorButton = TotalComponent.getTotalComponent().getCalculatorButton();
        currentText = TotalComponent.getTotalComponent().getCurrentText();
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
        currentText.addKeyListener(keyboard);
        logButton.addActionListener(button);
        mainFrame.addComponentListener(component);
    }
    public void sendComponent()
    {

    }
}
