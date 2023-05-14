package view;

import javax.swing.*;
import java.awt.*;

public class RecordButton extends JPanel{
    private JLabel standard;
    private JButton recordButton;

    public JPanel setRecordPanel()
    {
        recordButton = new JButton("⟲");
        standard = new JLabel("표준");
        setLayout(new BorderLayout());
        add(recordButton, BorderLayout.EAST);
        add(standard, BorderLayout.WEST);

        return this;
    }
}
