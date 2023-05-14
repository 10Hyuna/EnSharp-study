package view;

import utility.InputValueParse;

import javax.swing.*;
import java.awt.*;

public class MainView extends JFrame{
    private CalculatorButton calculatorButton;
    private RecordButton recordButton;
    private InputValueParse inputValueParse;
    public MainView()
    {
        calculatorButton = new CalculatorButton();
        recordButton = new RecordButton();
        inputValueParse = new InputValueParse();
    }
    public void setcalculator()
    {
        JPanel recordPanel = recordButton.setRecordPanel();
        recordPanel.setPreferredSize(new Dimension(10,10));
        JPanel inputPanel = InputState.getInputState().setCurrentInput();
        JPanel calculatorPanel = calculatorButton.setCalculatorButton();

        setSize(500, 700);
        setTitle("Calculator");
        setResizable(true);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new BorderLayout());

        this.add(recordPanel, BorderLayout.NORTH);
        this.add(inputPanel, BorderLayout.CENTER);
        this.add(calculatorPanel, BorderLayout.SOUTH);

        setVisible(true);
    }
}
