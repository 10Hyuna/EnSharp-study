package view;

import javax.swing.*;
import java.awt.*;

public class MainView extends JFrame
{
    private JLabel standard;
    private JPanel calculatorButton;
    private JPanel record;
    private JPanel inputPanel;

    public void SetFrame()
    {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());
        setSize(500, 750);

        Dimension frameSize = this.getSize();
        Dimension standardSize = new Dimension(450, 650);
        if(frameSize.getHeight() <= standardSize.getHeight()
        || frameSize.getWidth() <= standardSize.getHeight())
        {
            setSize(standardSize);
        }

        Dimension dimension = new Dimension(this.getWidth(), this.getHeight());
        standard = new JLabel("표준", JLabel.LEFT);
        standard.setSize(dimension.width, dimension.height / 15);

        inputPanel = InputState.GetInputState().GetPanel();
        inputPanel.setSize(dimension.width, (dimension.height / 15) * 4);


    }
}
