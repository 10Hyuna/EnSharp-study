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
        add(currentInput);
    }

    public JLabel GetCurrentInput()
    {
        return currentInput;
    }

    public void SetRecentInput()
    {
        recentInput = new JLabel();
        recentInput.setFont(new Font("Serif", Font.PLAIN, 8));
        recentInput.setForeground(Color.gray);
        add(recentInput);
    }

    public JLabel GetRecentInput()
    {
        return recentInput;
    }
}
