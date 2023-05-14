package controller;

import utility.InputValueParse;
import view.CalculatorButton;
import view.InputState;
import view.RecordButton;

import javax.swing.*;
import java.awt.*;

public class Calculator extends JFrame {
    private CalculatorButton calculatorButton;
    private RecordButton recordButton;
    private InputValueParse inputValueParse;
    private JLabel currentInputs;
    private JLabel recentInputs;
    private String inputtedValue;
    public Calculator()
    {
        calculatorButton = new CalculatorButton();
        recordButton = new RecordButton();
        inputValueParse = new InputValueParse();
        currentInputs = InputState.getInputState().getCurrentInput();
        recentInputs = InputState.getInputState().getRecentInput();
    }
    public void calculate()
    {
        setcalculator();
    }
    public void inputNumber()
    {

    }
    public void inputOperator()
    {

    }
    public void inputEqual()
    {

    }
    public void inputBackspqce()
    {
        if(currentInputs.getText() != "0" && currentInputs.getText().length() != 0)
        {
            inputtedValue = currentInputs.getText();
            currentInputs.setText(inputtedValue.substring(0, inputtedValue.length() - 1));
            if(currentInputs.getText() == "")
            {
                currentInputs.setText("0");
            }
        }
    }
    public void inputNegate()
    {
        if(currentInputs.getText() != "0")
        {
            inputtedValue = String.valueOf(Integer.parseInt(currentInputs.getText()) * -1);
            currentInputs.setText(inputtedValue);
        }
        if(recentInputs.getText() != "")
        {
            inputtedValue = String.format("negate(%s)", recentInputs.getText());
            recentInputs.setText(inputtedValue);
        }
    }
    public void inputCE()
    {
        currentInputs.setText("0");
    }
    public void inputC()
    {
        currentInputs.setText("0");
        recentInputs.setText("");
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
