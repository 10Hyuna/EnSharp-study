package controller;

import model.VO.LogVO;
import view.CalculatorButton;
import view.InputState;
import view.RecordButton;

import javax.swing.*;
import java.awt.*;

public class Calculator extends JFrame {
    private CalculatorButton calculatorButton;
    private InputState inputState;
    private RecordButton recordButton;

    public Calculator()
    {
        calculatorButton = new CalculatorButton();
        inputState = new InputState();
        recordButton = new RecordButton();
    }
    public void calculate()
    {
        Setcalculator();
        LogVO log = new LogVO();

    }

    private void Setcalculator()
    {
        JPanel recordPanel = recordButton.SetRecordPanel();
        recordPanel.setPreferredSize(new Dimension(10,10));
        JPanel inputPanel = inputState.SetCurrentInput();
        JPanel calculatorPanel = calculatorButton.SetCalculatorButton();

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
