package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel {
    private JLabel previousInput = new JLabel();
    private JLabel currentInput = new JLabel();
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
}