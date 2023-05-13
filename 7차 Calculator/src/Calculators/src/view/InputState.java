package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel
{
    private JLabel currentInput;
    private JLabel recentInput;

    public void SetCurrentInput()
    {
        currentInput = new JLabel("0");
        currentInput.setFont(new Font("Serif", Font.BOLD, 15));
        currentInput.setForeground(Color.BLACK);
    }

    public void SetRecentInput()
    {
        recentInput = new JLabel();
        recentInput.setFont(new Font("Serif", Font.PLAIN, 8));
        currentInput.setForeground(Color.gray);
    }
}
