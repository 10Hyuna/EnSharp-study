package view;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

public class InputState extends JPanel {
    private JLabel recentInput = new JLabel();
    private JLabel currentInput = new JLabel();

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
        setLayout(new BorderLayout());
        add(ReturnRecentInput(), BorderLayout.EAST);
        add(ReturnCurrentInput(), BorderLayout.SOUTH);

        return this;
    }
    private JPanel ReturnRecentInput()
    {
        JPanel recentPanel = new JPanel();
        recentInput = new JLabel("", JLabel.RIGHT);
        recentInput.setForeground(Color.GRAY);
        recentInput.setFont(new Font("맑은 고딕", Font.PLAIN, 15));

        recentPanel.add(recentInput);

        return recentPanel;
    }
    private JPanel ReturnCurrentInput()
    {
        JPanel currentPanel = new JPanel();

        currentInput = new JLabel("0", JLabel.RIGHT);
        currentInput.setForeground(Color.BLACK);
        currentInput.setFont(new Font("맑은 고딕", Font.BOLD, 50));

        currentPanel.add(currentInput);

        return currentPanel;
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