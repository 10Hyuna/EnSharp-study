package controller;

import model.TotalStorage;
import utility.ExceptionHandler;
import view.InputState;

import javax.swing.*;
import java.math.BigDecimal;

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
    public Calculate()
    {
        totalStorage = new TotalStorage();
        exceptionHandler = new ExceptionHandler();
    }
    public void InputNumber(String input)
    {

    }
    public void InputOperator(String input)
    {

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
        current = 0;
    }
    public void InputC()
    {
        InputCE();
        recentLabel.setText("");
        recent = 0;
    }
    public void InputBackspace()
    {

    }
    public void InputPoint()
    {

    }
    private boolean CalculateValue()
    {
        if(recent.equals(0) && current.equals(0))
        {
            exceptionHandler.IsUndivisableNumber();
            return false;
        }
        switch (operator)
        {
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
