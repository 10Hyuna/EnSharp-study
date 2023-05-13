package view;

import utility.Constant;

import java.awt.Color;

import javax.swing.*;
import java.awt.*;

import static java.awt.Color.DARK_GRAY;
import static java.awt.Color.getColor;

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
            buttonPanel.add(calculateButton[i] = new JButton(button[i]));
            switch(i)
            {
                case Constant.BUTTON_NUMBER[0]:
                    calculateButton[i].setForeground(DARK_GRAY);
                    break;
                case Constant.BUTTON_NUMBER[1]:
                    calculateButton[i].setForeground(DARK_GRAY);
                    break;
                case Constant.BUTTON_NUMBER[2]:
                    calculateButton[i].setForeground(DARK_GRAY);
                    break;
            }
        }
    }
}
