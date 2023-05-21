package controller;

import model.TotalStorage;
import view.InputState;

import javax.swing.*;

public class Calculate {
    private TotalStorage totalStorage;
    private int currentInput;
    private int recentInput;
    private int result;
    private String operator;
    private String recentInputs;
    private String currentInputs;
    private JLabel current;
    private JLabel recent;
    public Calculate()
    {
        totalStorage = new TotalStorage();
        current = InputState.GetInputState().GetCurrentInput();
        recent = InputState.GetInputState().GetRecentInput();
    }
    public void InputNumber(String input)
    {
        currentInput *= 10;
        currentInput += Integer.parseInt(input);
        current = InputState.GetInputState().GetCurrentInput();
        current.setText(String.valueOf(currentInput));
    }
    public void InputOperator(String input)
    {
        recentInput = currentInput;
        operator = input;
        recentInputs = String.valueOf(currentInput) + operator;
        recent.setText(recentInputs);
        currentInput = 0;
    }
    public void InputEqual()
    {
        if(currentInput == 0)
        {
            currentInput = recentInput;
        }
        CalculateValue();
        current.setText(String.valueOf(result));
        recent.setText(String.format(recent.getText() + "="));
        recentInput = result;
        recent.setText("");
    }
    public void InputNegate()
    {
        currentInputs = current.getText();
        recentInputs += String.format("negate(%s)", currentInputs);
        currentInput *= -1;
        current.setText(String.valueOf(currentInput));
    }
    public void InputCE()
    {
        current.setText("0");
        currentInput = 0;
    }
    public void InputC()
    {
        InputCE();
        recent.setText("");
        recentInput = 0;
    }
    public void InputBackspace()
    {
        if(currentInput > 0)
        {
            currentInput /= 10;
            current.setText(String.valueOf(currentInput));
        }
    }
    public void InputPoint()
    {

    }
    private void CalculateValue()
    {
        switch (operator)
        {
            case "+":
                result = currentInput + recentInput;
                break;
            case "-":
                result = currentInput - recentInput;
                break;
            case "×":
                result = currentInput * recentInput;
                break;
            case "÷":
                result = currentInput / recentInput;
                break;
        }
    }
}
