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
        for(int i = 0; i < button.length; i++)
        {
            if(i >= 0 && i <= 3 )
            calculateButton[i].setText(button[i]);
        }

    }
}
