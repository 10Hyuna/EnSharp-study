package view;

import javax.swing.*;
import java.awt.*;
import java.awt.Dimension;
import java.util.List;

public class MainView extends JFrame
{
    private JPanel buttons;
    private JLabel standard;
    private JPanel recordPanel;
    private JPanel inputPanel;
    private CaculatorButton calculatorButton;
    private InputState inputState;
    private Record record;
    public MainView()
    {
        calculatorButton = new CaculatorButton();
        inputState = new InputState();
        record = new Record();
    }

    public void setFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        setMinimumSize(new Dimension(400, 600));
        setMaximumSize(new Dimension(800, 1200));

        recordPanel = record.getRecordButtonPanel();
        inputPanel = inputState.getPanel();
        buttons = calculatorButton.getCalculatorButton();
        buttons.setPreferredSize(new Dimension(this.getWidth(), this.getWidth()));

        add(recordPanel, BorderLayout.NORTH);
        add(inputPanel, BorderLayout.EAST);
        add(buttons, BorderLayout.SOUTH);

        setVisible(true);
        setFocusable(true);
        requestFocus();
    }
    public void setContainLog()
    {
        remove(this);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        setMinimumSize(new Dimension(400, 600));
        setMaximumSize(new Dimension(800, 1200));

        standard = record.getStandard();
        recordPanel = record.getRecordPanel();
        inputPanel = inputState.getPanel();
        buttons = calculatorButton.getCalculatorButton();
        buttons.setPreferredSize(new Dimension(this.getWidth(), this.getWidth()));

        JPanel sortPanel = new JPanel();
        sortPanel.setLayout(new BorderLayout());

        sortPanel.add(standard, BorderLayout.NORTH);
        sortPanel.add(inputPanel, BorderLayout.EAST);
        sortPanel.add(buttons);

        add(sortPanel, BorderLayout.WEST);
        add(recordPanel, BorderLayout.EAST);

        setVisible(true);
        setFocusable(true);
        requestFocus();
    }
}
