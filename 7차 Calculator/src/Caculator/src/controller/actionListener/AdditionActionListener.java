package controller.actionListener;

import view.TotalComponent;

import javax.swing.*;

public class AdditionActionListener {
    private JButton[] calculatorButton;
    private JTextField currentText;
    private JButton logButton;
    private MyButtonActionListener myButtonActionListener;
    private MyComponentActionListener myComponentActionListener;
    private MyKeyActionListener myKeyActionListener;
    public AdditionActionListener()
    {
        calculatorButton = TotalComponent.GetTotalComponent().GetCalculatorButton();
        currentText = TotalComponent.GetTotalComponent().GetCurrentText();
        logButton = TotalComponent.GetTotalComponent().GetLogButton();

        myButtonActionListener = new MyButtonActionListener();
        myComponentActionListener = new MyComponentActionListener();
        myKeyActionListener = new MyKeyActionListener();
    }
    public void AddActionListener(JFrame mainFrame)
    {
        for (int i = 0; i < calculatorButton.length; i++)
        {
            calculatorButton[i].addActionListener(myButtonActionListener);
        }
        currentText.addKeyListener(myKeyActionListener);
        logButton.addActionListener(myButtonActionListener);
        mainFrame.addComponentListener(myComponentActionListener);
    }
}
