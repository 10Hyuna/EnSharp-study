package view;

import javax.swing.*;
import java.awt.*;

public class MainView extends JFrame
{
    private JLabel standard;
    private JPanel buttons;
    private JPanel record;
    private JPanel inputPanel;
    private CaculatorButton calculatorButton;

    public MainView()
    {
        calculatorButton = new CaculatorButton();
    }

    public void SetFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new FlowLayout());
        setSize(500, 750);
        setMinimumSize(new Dimension(400, 650));

        Dimension dimension = new Dimension(this.getWidth(), this.getHeight());
        standard = new JLabel("표준", JLabel.LEFT);
        standard.setPreferredSize(new Dimension(dimension.width, dimension.height / 15));

        inputPanel = InputState.GetInputState().GetPanel(dimension);
        inputPanel.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 3));

        buttons = calculatorButton.GetCalculatorButton(dimension);
        buttons.setPreferredSize(new Dimension(dimension.width, (dimension.height / 15) * 10));

        add(standard);
        add(inputPanel);
        add(buttons);

        setVisible(true);
    }
}
