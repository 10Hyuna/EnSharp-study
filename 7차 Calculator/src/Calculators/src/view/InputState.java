package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel
{
    private JLabel currentInput;
    private JLabel recentInput;

    public JPanel SetCurrentInput()
    {
        currentInput = new JLabel("0");
        currentInput.setFont(new Font("Serif", Font.BOLD, 15));
        currentInput.setForeground(Color.BLACK);
        add(currentInput);

        recentInput = new JLabel();
        recentInput.setFont(new Font("Serif", Font.PLAIN, 8));
        recentInput.setForeground(Color.gray);
        add(recentInput);

        return this;
    }

    public JLabel GetCurrentInput()
    {
        return currentInput;
    }

    public JLabel GetRecentInput()
    {
        return recentInput;
    }
}
