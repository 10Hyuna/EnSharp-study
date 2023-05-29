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

        standard = getStandard();

        recordButton = TotalComponent.getTotalComponent().getLogButton();
        recordButton.setText("⟲");

        setLayout(new BorderLayout());
        add(standard, BorderLayout.WEST);
        add(recordButton, BorderLayout.EAST);

        return this;
    }

    public JPanel getRecordPanel()
    {

        return this;
    }
    public JLabel getStandard()
    {
        standard = new JLabel("표준", JLabel.LEFT);

        return standard;
    }
}
