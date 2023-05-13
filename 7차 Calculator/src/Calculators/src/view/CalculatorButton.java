package view;

import javax.swing.*;
import java.awt.*;

public class CalculatorButton extends JPanel
{
    String[] button = {"CE", "C", "⌫", "⁒", "7", "8", "9", "X",
            "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".", "="};
    public void SetCalculatorButton()
    {
        JPanel buttonPanel = new JPanel(new GridLayout(5, 4));
        JButton[] calculateButton = new JButton[20];
        for (int buttonIndex = 0; buttonIndex < button.length; buttonIndex++)
        {
            buttonPanel.add(calculateButton[buttonIndex] = new JButton(button[buttonIndex]));

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
    }
}