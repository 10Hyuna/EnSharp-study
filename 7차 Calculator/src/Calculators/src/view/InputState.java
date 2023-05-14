package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel
{
    private static InputState inputState;
    private JLabel currentInput;
    private JLabel recentInput;

    private InputState(){
    }

    public static InputState getInputState()
    {
        if(inputState == null)
        {
            inputState = new InputState();
        }
        return inputState;
    }

    public JPanel setCurrentInput()
    {
        setLayout(new BorderLayout());
        recentInput = new JLabel();
        recentInput.setFont(new Font("Serif", Font.PLAIN, 15));
        recentInput.setForeground(Color.gray);
        add(recentInput, BorderLayout.NORTH);

        currentInput = new JLabel("0");
        currentInput.setFont(new Font("Serif", Font.BOLD, 40));
        currentInput.setForeground(Color.BLACK);
        add(currentInput, BorderLayout.SOUTH);

        return this;
    }

    public JLabel getCurrentInput()
    {
        return currentInput;
    }

    public JLabel getRecentInput()
    {
        return recentInput;
    }
}
