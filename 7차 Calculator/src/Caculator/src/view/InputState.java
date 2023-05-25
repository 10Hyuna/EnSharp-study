package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel {
    private JLabel recentInput = new JLabel();
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

    public JPanel getPanel() {
        setLayout(new BorderLayout());
        add(returnRecentInput(), BorderLayout.EAST);
        add(returnCurrentInput(), BorderLayout.SOUTH);

        return this;
    }
    private JPanel returnRecentInput()
    {
        JPanel recentPanel = new JPanel();
        recentInput = new JLabel("", JLabel.RIGHT);
        recentInput.setForeground(Color.GRAY);
        recentInput.setFont(new Font("맑은 고딕", Font.PLAIN, 15));

        recentPanel.add(recentInput);

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
    public JLabel getRecentInput() {
        return recentInput;
    }
    public JLabel getCurrentInput() {
        return currentInput;
    }
    public JPanel getInputList(String currentString, String recentString)
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