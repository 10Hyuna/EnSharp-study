package view;

import javax.swing.*;
import java.awt.*;

public class CaculatorButton extends JPanel {

    private String[] button = {"CE", "C", "⌫", "÷", "7", "8", "9", "×",
            "4", "5", "6", "-", "1", "2", "3", "+", "+/-", "0", ".", "="};
    private JButton[] buttons;
    public JPanel getCalculatorButton()
    {
        setLayout(new GridLayout(5, 4));
        buttons = new JButton[20];

        for (int i = 0; i < button.length; i++)
        {
            buttons[i] = new JButton();
            buttons[i].setText(button[i]);

            if(i == 0 || i == 1 || i == 2 || i == 3 ||
            i == 7 || i == 11 || i == 15)
            {
                buttons[i].setBackground(Color.GRAY);
            }
            else if(i == 19)
            {
                buttons[i].setBackground(Color.BLUE);
            }
            else
            {
                buttons[i].setBackground(Color.LIGHT_GRAY);
            }
            add(buttons[i]);
        }
        return this;
    }
}
