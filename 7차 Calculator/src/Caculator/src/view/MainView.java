package view;

import model.VO.CaculateResultVO;

import javax.swing.*;
import java.awt.*;
import java.awt.Dimension;
import java.util.List;

public class MainView extends JFrame
{
    private JPanel buttons;
    private JLabel standard;
    private JPanel recordPanel;
    private JPanel records;
    private JPanel inputPanel;
    private CaculatorButton calculatorButton;
    private InputState inputState;
    private Record record;
    private JPanel subPanel = new JPanel();
    public JPanel mainPanel = new JPanel();
    public MainView()
    {
        calculatorButton = new CaculatorButton();
        inputState = new InputState();
        record = new Record();

        getContentPane().removeAll();
    }

    public void setFrame()
    {
        getContentPane().removeAll();

        mainPanel.setLayout(new BorderLayout());

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setMinimumSize(new Dimension(400, 600));
        setMaximumSize(new Dimension(800, 1200));

        recordPanel = record.getRecordButtonPanel();
        inputPanel = inputState.getPanel();
        buttons = calculatorButton.getCalculatorButton();
        buttons.setPreferredSize(new Dimension(this.getWidth(), this.getWidth()));

        mainPanel.add(recordPanel, BorderLayout.NORTH);
        mainPanel.add(inputPanel, BorderLayout.EAST);
        mainPanel.add(buttons, BorderLayout.SOUTH);

        add(mainPanel);

        setVisible(true);
        setFocusable(true);
        requestFocus();
    }
    public void setContainLog()
    {
        getContentPane().removeAll();

        subPanel = new JPanel();
        subPanel.setLayout(new BorderLayout());

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
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
        sortPanel.add(buttons, BorderLayout.SOUTH);

        subPanel.add(sortPanel, BorderLayout.WEST);
        subPanel.add(recordPanel, BorderLayout.EAST);

        add(subPanel);

        setVisible(true);
        setFocusable(true);
        requestFocus();
    }
    public void addLogPanel(List<CaculateResultVO> resultVO)
    {
        mainPanel.remove(buttons);

        records = record.getRecords(resultVO);
        records.setPreferredSize(new Dimension(this.getWidth(), this.getWidth()));

        mainPanel.add(records, BorderLayout.SOUTH);
        mainPanel.revalidate();
        mainPanel.repaint();

        add(mainPanel);
    }
}
