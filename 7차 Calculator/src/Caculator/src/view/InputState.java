package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel {
    private JLabel previousInput = new JLabel();
    private JLabel currentInput = new JLabel();

    private static InputState inputState;

    private InputState() {
    }

    public static InputState getInputState() {
        if (inputState == null) {
            inputState = new InputState();
        }
        return inputState;
    }

    public JPanel getPanel()
    {
        setLayout(new BorderLayout());

        JLabel previousLabel = TotalComponent.getTotalComponent().getPreviousLabel();
        JLabel currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();

        previousLabel.setText("");
        previousLabel.setBackground(Color.GRAY);
        previousLabel.setFont(new Font("맑은 고딕", Font.PLAIN, 15));

        currentLabel.setText("0");
        currentLabel.setForeground(Color.BLACK);
        currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));

        add(previousLabel, BorderLayout.EAST);
        add(currentLabel, BorderLayout.SOUTH);

        return this;
    }
    private JPanel returnRecentInput()
    {
        JPanel recentPanel = new JPanel();
        previousInput = new JLabel("", JLabel.RIGHT);
        previousInput.setForeground(Color.GRAY);
        previousInput.setFont(new Font("맑은 고딕", Font.PLAIN, 15));

        recentPanel.add(previousInput);

        return recentPanel;
    }
    private JPanel returnCurrentInput()
    {
        JPanel currentPanel = new JPanel();

        currentInput = new JLabel("0", JLabel.RIGHT);
        currentInput.setForeground(Color.BLACK);
        currentInput.setFont(new Font("맑은 고딕", Font.BOLD, 50));

        currentPanel.add(currentInput);

        return currentPanel;
    }
    public JLabel getPreviousInput() {
        return previousInput;
    }
    public JLabel getCurrentInput() {
        return currentInput;
    }
}