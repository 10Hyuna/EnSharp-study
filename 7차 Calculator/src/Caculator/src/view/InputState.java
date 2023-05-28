package view;

import javax.swing.*;
import java.awt.*;

public class InputState extends JPanel {
    private JPanel previousPanel = new JPanel();
    private JPanel currentPanel = new JPanel();
    public JPanel getPanel()
    {
        previousPanel.setLayout(new BorderLayout());
        currentPanel.setLayout(new BorderLayout());

        setLayout(new BorderLayout());

        JLabel previousLabel = TotalComponent.getTotalComponent().getPreviousLabel();
        JLabel currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();

        previousLabel.setText("");
        previousLabel.setBackground(Color.GRAY);
        previousLabel.setFont(new Font("맑은 고딕", Font.PLAIN, 15));

        currentLabel.setText("0");
        currentLabel.setForeground(Color.BLACK);
        currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));

        previousPanel.add(previousLabel, BorderLayout.EAST);
        currentPanel.add(currentLabel, BorderLayout.EAST);

        add(previousPanel, BorderLayout.CENTER);
        add(currentPanel, BorderLayout.SOUTH);

        return this;
    }
}