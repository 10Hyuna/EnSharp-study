package view;

import javax.swing.*;
import java.awt.*;

public class Record extends JPanel{
    private JButton recordButton;
    private JLabel standard;
    private JButton[] recordButtons;
    public JPanel getRecordButtonPanel()
    {
        removeAll();

        standard = new JLabel("표준", JLabel.LEFT);
        recordButton = TotalComponent.getTotalComponent().getLogButton();
        recordButton.setText("⟲");

        setLayout(new BorderLayout());
        setMinimumSize(new Dimension(400, 40));
        setMaximumSize(new Dimension(600, 60));
        add(standard, BorderLayout.WEST);
        add(recordButton, BorderLayout.EAST);

        return this;
    }

    public JPanel getRecordPanel()
    {

        return this;
    }
}
