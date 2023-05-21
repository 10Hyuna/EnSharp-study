package controller;

import model.TotalStorage;
import utility.ExceptionHandler;
import view.InputState;

import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.Locale;

import javax.swing.*;
import java.math.BigDecimal;
import java.text.DecimalFormat;

public class Calculate {
    private TotalStorage totalStorage;
    private ExceptionHandler exceptionHandler;
    private boolean isUnableCalculate;
    private BigDecimal current = new BigDecimal("0");
    private BigDecimal recent = new BigDecimal("0");
    private BigDecimal result = new BigDecimal("0");
    private String operator;
    private String recentInputs;
    private String currentInputs;
    private JLabel currentLabel;
    private JLabel recentLabel;
    private DecimalFormat formating = new DecimalFormat("###,###.################");
    public Calculate()
    {
        totalStorage = new TotalStorage();
        exceptionHandler = new ExceptionHandler();
    }
    public void InputNumber(String input)
    {
        BigDecimal ten = new BigDecimal("10");
        BigDecimal inputValue = new BigDecimal(input);
        current = current.multiply(ten);
        current = current.add(inputValue);
        currentLabel = InputState.GetInputState().GetCurrentInput();
        currentLabel.setText(formating.format(current));
    }
    public void InputOperator(String input)
    {
        operator = input;
        if(current.equals(new BigDecimal("0")))
        {
            current = recent;
        }
        recent = current;
        recentLabel = InputState.GetInputState().GetRecentInput();
        recentLabel.setText(String.format(String.valueOf(recent) + " " + operator));
        current = new BigDecimal("0");
    }
    public void InputEqual()
    {

    }
    public void InputNegate()
    {

    }
    public void InputCE()
    {
        currentLabel.setText("0");
        current = new BigDecimal("0");
    }
    public void InputC()
    {
        InputCE();
        recentLabel.setText("");
        recent = new BigDecimal("0");
    }
    public void InputBackspace()
    {
        if(current.equals(new BigDecimal("0")))
        {
            return;
        }
        else if(result.equals(new BigDecimal("0")))
        {
            currentInputs = String.valueOf(current);
            if(currentInputs.length() == 1)
            {
                currentInputs = "0";
            }
            else
            {
                currentInputs = currentInputs.substring(0, currentInputs.length() - 1);
            }
            current = new BigDecimal(currentInputs);
            currentLabel = InputState.GetInputState().GetCurrentInput();
            currentLabel.setText(String.valueOf(current));
        }
        else
        {
            recent = new BigDecimal("0");
            recentLabel = InputState.GetInputState().GetRecentInput();
            recentLabel.setText("");
        }
    }
    public void InputPoint()
    {

    }
    private boolean CalculateValue() {
        if (recent.equals(0) && current.equals(0)) {
            exceptionHandler.IsUndivisableNumber();
            return false;
        }
        switch (operator) {
            case "+":
                result = recent.add(current);
                break;
            case "-":
                result = recent.subtract(current);
                break;
            case "×":
                result = recent.multiply(current);
                break;
            case "÷":
                result = recent.divide(current);
                break;
        }
        return true;
    }
}
