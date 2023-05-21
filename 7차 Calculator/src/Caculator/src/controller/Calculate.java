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
    private BigDecimal current;
    private BigDecimal recent;
    private BigDecimal result;
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
        if(current == null)
        {
            current = new BigDecimal("0");
        }
        BigDecimal ten = new BigDecimal("10");
        BigDecimal inputValue = new BigDecimal(input);
        current = current.multiply(ten);
        current = current.add(inputValue);
        currentLabel = InputState.GetInputState().GetCurrentInput();
        currentLabel.setText(formating.format(current));
    }
    public void InputOperator(String input)
    {
        if(recent == null)
        {
            recent = new BigDecimal("0");
        }
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
        current.equals("0");
    }
    public void InputC()
    {
        InputCE();
        recentLabel.setText("");
        recent.equals("0");
    }
    public void InputBackspace()
    {

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
