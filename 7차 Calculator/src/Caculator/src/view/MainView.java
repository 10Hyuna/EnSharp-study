package view;

import controller.actionListener.MyKeyActionListener;

import javax.swing.*;
import java.awt.*;
import java.awt.Dimension;

public class MainView extends JFrame
{
    private JLabel standard;
    private JPanel buttons;
    private JPanel record;
    private JPanel inputPanel;
    private CaculatorButton calculatorButton;
    private MyKeyActionListener myKeyActionListener;

    public MainView()
    {
        calculatorButton = new CaculatorButton();
        myKeyActionListener = new MyKeyActionListener();
    }

    public JFrame setFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new FlowLayout());
        setSize(500, 750);
        setMinimumSize(new Dimension(400, 650));

        addKeyListener(myKeyActionListener);
        Dimension dimension = new Dimension(this.getWidth(), this.getHeight());
        standard = new JLabel("표준", JLabel.LEFT);
        standard.setPreferredSize(new Dimension(dimension.width, dimension.height / 15));

        inputPanel = InputState.getInputState().getPanel();
        inputPanel.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 3));
        buttons = calculatorButton.getCalculatorButton();
        buttons.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 10));

        add(standard);
        add(inputPanel);
        add(buttons);

        setVisible(true);

        return this;
    }
}
