package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel {
    private JLabel recentInput;
    private JLabel currentInput;

    private static InputState inputState;

    private InputState() {
    }

    public static InputState GetInputState() {
        if (inputState == null) {
            inputState = new InputState();
        }
        return inputState;
    }

    public JPanel GetPanel() {
        Dimension dimension = new Dimension(this.getWidth(), this.getHeight());

        recentInput = new JLabel("", JLabel.RIGHT);
        recentInput.setForeground(Color.DARK_GRAY);
        recentInput.setFont(new Font("맑은 고딕", Font.PLAIN, 15));
        recentInput.setSize(dimension.width, dimension.height / 4);

        currentInput = new JLabel("0", JLabel.RIGHT);
        currentInput.setForeground(Color.BLACK);
        currentInput.setFont(new Font("맑은 고딕", Font.BOLD, 50));
        currentInput.setSize(dimension.width, 3 * (dimension.height / 4));

        add(recentInput);
        add(currentInput);

        return this;
    }
    public JLabel GetRecentInput() {
        return recentInput;
    }
    public JLabel GetCurrentInput() {
        return currentInput;
    }
    public JPanel GetInputList(String currentString, String recentString)
    {
        JPanel inputList = new JPanel();
        JLabel current = new JLabel();
        JLabel recent = new JLabel();
        Dimension dimension = new Dimension(inputList.getWidth(), inputList.getHeight());

        current.setText(currentString);
        recent.setText(recentString);

        recent.setForeground(Color.DARK_GRAY);
        recent.setFont(new Font("맑은 고딕", Font.PLAIN, 15));
        recent.setSize(dimension.width, dimension.height / 4);

        current.setForeground(Color.BLACK);
        current.setFont(new Font("맑은 고딕", Font.BOLD, 50));
        current.setSize(dimension.width, 3 * (dimension.height / 4));

        inputList.add(recent);
        inputList.add(current);

        return inputList;
    }
}