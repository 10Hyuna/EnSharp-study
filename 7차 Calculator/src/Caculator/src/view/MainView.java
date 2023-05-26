package view;

import javax.swing.*;
import java.awt.*;
import java.awt.Dimension;

public class MainView extends JFrame
{
    private JPanel buttons;
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

    public JFrame setFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        setMinimumSize(new Dimension(400, 600));
        setMaximumSize(new Dimension(600, 900));

        recordPanel = record.getRecordButtonPanel();
        inputPanel = inputState.getPanel();
        buttons = calculatorButton.getCalculatorButton();
        buttons.setPreferredSize(new Dimension(this.getWidth(), (this.getWidth() / 5) * 4));

        add(recordPanel, BorderLayout.NORTH);
        add(inputPanel, BorderLayout.EAST);
        add(buttons, BorderLayout.SOUTH);

        setVisible(true);

        return this;
    }
}
