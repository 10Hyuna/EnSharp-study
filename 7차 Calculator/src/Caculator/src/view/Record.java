package view;

import javax.swing.*;
import java.awt.*;

public class Record{
    private JButton recordButton;
    private JButton[] recordButtons;
    private JPanel recordButtonPanel;
    private JPanel recordPanel;
    public JPanel getRecordButtonPanel()
    {
        recordButton = new JButton("⟲");
        recordButtonPanel.setLayout(new BorderLayout());
        recordButtonPanel.add(recordButton, BorderLayout.EAST);
        return recordButtonPanel;
    }

    public JPanel getRecordPanel()
    {

        return recordPanel;
    }
}
