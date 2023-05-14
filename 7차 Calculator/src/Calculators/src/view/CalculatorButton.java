package view;

import utility.MyActionListener;

import javax.swing.*;
import java.awt.*;

public class CalculatorButton extends JPanel
{
    private String[] button = {"CE", "C", "⌫", "⁒", "7", "8", "9", "X",
            "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".", "="};
    public JPanel SetCalculatorButton()
    {
        setLayout(new GridLayout(5, 4));
        JButton[] calculateButton = new JButton[20];
        for (int buttonIndex = 0; buttonIndex < button.length; buttonIndex++)
        {
            add(calculateButton[buttonIndex] = new JButton(button[buttonIndex]));
            calculateButton[buttonIndex].setActionCommand(button[buttonIndex]);
            calculateButton[buttonIndex].addActionListener(MyActionListener.GetMyActionListener());
            if(buttonIndex == 0 || buttonIndex == 1 || buttonIndex == 2
            || buttonIndex == 3 || buttonIndex == 7 || buttonIndex == 11
            || buttonIndex == 15 || buttonIndex == 19)
            {
                calculateButton[buttonIndex].setForeground(Color.DARK_GRAY);
            }
            else
            {
                calculateButton[buttonIndex].setForeground(Color.gray);
            }
        }
        return this;
    }
}