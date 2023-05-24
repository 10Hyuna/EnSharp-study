package view;

import controller.actionListener.MyKeyActionListener;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentEvent;
import java.awt.Dimension;
import java.awt.event.ComponentAdapter;

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

    public void SetFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new FlowLayout());
        setSize(500, 750);
        setMinimumSize(new Dimension(400, 650));

        addKeyListener(myKeyActionListener);
        Dimension dimension = new Dimension(this.getWidth(), this.getHeight());
        standard = new JLabel("표준", JLabel.LEFT);
        standard.setPreferredSize(new Dimension(dimension.width, dimension.height / 15));
        standard.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                standard.setPreferredSize(new Dimension(dimension.width, dimension.height / 15));
                standard.revalidate();
            }
        });

        inputPanel = InputState.GetInputState().GetPanel(dimension);
        inputPanel.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 3));
        inputPanel.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                inputPanel.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 3));
                inputPanel.revalidate();
            }
        });

        buttons = calculatorButton.GetCalculatorButton(dimension);
        buttons.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 10));
        buttons.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                buttons.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 10));
                buttons.revalidate();
            }
        });

        add(standard);
        add(inputPanel);
        add(buttons);

        setVisible(true);
    }
}
