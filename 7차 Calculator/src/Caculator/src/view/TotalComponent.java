package view;

import javax.swing.*;

public class TotalComponent {
    private JButton[] calculatorButton;
    private JLabel previousLabel;
    private JLabel currentLabel;
    private JButton logButton;
    private static TotalComponent totalComponent;
    private TotalComponent()
    {       // 김영환 spring 객체 지향 강의
        calculatorButton = new JButton[20];
        previousLabel = new JLabel();
        currentLabel = new JLabel();
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
    public JLabel getCurrentJLabel()
    {
        return currentLabel;
    }
    public JButton getLogButton()
    {
        return logButton;
    }
}
