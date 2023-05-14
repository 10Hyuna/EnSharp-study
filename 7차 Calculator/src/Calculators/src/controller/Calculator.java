package controller;

import view.CalculatorButton;
import view.InputState;
import view.RecordButton;

import javax.swing.*;
import java.awt.*;

public class Calculator extends JFrame {
    private CalculatorButton calculatorButton;
    private RecordButton recordButton;

    public Calculator()
    {
        calculatorButton = new CalculatorButton();
        recordButton = new RecordButton();
    }
    public void calculate()
    {
        setcalculator();

    }

    private void setcalculator()
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
