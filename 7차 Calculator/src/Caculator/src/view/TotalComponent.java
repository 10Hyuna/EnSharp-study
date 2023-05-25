package view;

import javax.swing.*;

public class TotalComponent {
    private JButton[] calculatorButton;
    private JLabel previousLabel;
    private JTextField currentText;
    private JButton logButton;
    private static TotalComponent totalComponent;
    private TotalComponent()
    {
        calculatorButton = new JButton[20];
        previousLabel = new JLabel();
        currentText = new JTextField();
        logButton = new JButton();
    }
    public static TotalComponent getTotalComponent()
    {
        if(totalComponent == null)
        {
            totalComponent = new TotalComponent();
        }
        return totalComponent;
    }
    public JButton[] getCalculatorButton()
    {
        return calculatorButton;
    }
    public JLabel getPreviousLabel()
    {
        return previousLabel;
    }
    public JTextField getCurrentText()
    {
        return currentText;
    }
    public JButton getLogButton()
    {
        return logButton;
    }
}
