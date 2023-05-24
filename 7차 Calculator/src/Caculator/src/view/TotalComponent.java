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
    public static TotalComponent GetTotalComponent()
    {
        if(totalComponent == null)
        {
            totalComponent = new TotalComponent();
        }
        return totalComponent;
    }
    public JButton[] GetCalculatorButton()
    {
        return calculatorButton;
    }
    public JLabel GetPreviousLabel()
    {
        return previousLabel;
    }
    public JTextField GetCurrentText()
    {
        return currentText;
    }
    public JButton GetLogButton()
    {
        return logButton;
    }
}
