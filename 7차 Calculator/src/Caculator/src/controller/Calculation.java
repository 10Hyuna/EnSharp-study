package controller;

import model.TotalStorage;
import utility.ExceptionHandler;
import view.InputState;

import java.text.DecimalFormat;

import javax.swing.*;
import java.math.BigDecimal;

public class Calculation {
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
    private DecimalFormat Eformating = new DecimalFormat("###,###.################E0");
    public Calculation()
    {
        totalStorage = new TotalStorage();
        exceptionHandler = new ExceptionHandler();
    }
    public void InputNumber(String input)
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        BigDecimal ten = new BigDecimal("10");
        BigDecimal inputValue = new BigDecimal(input);
        current = current.multiply(ten);
        current = current.add(inputValue);
        currentLabel = InputState.GetInputState().GetCurrentInput();
        if(String.valueOf(current).length() >= 16)
        {
            return;
        }
        currentLabel.setText(formating.format(current));
    }
    public void InputOperator(String input)
    {
        if(!isUnableCalculate)
        {
            return;
        }
        operator = input;
        if(current.equals(new BigDecimal("0")))
        {
            current = recent;
        }
        else if(!result.equals(new BigDecimal("0")))
        {
            current = result;
        }
        recent = current;
        recentLabel = InputState.GetInputState().GetRecentInput();
        recentLabel.setText(String.format(String.valueOf(recent) + " " + operator));
        current = new BigDecimal("0");
    }
    public void InputEqual()
    {
        if(!isUnableCalculate)
        {
            return;
        }
        recentLabel = InputState.GetInputState().GetRecentInput();
        if (recent.equals(new BigDecimal("0")) && current.equals(new BigDecimal("0")))
        {
            recentLabel.setText("0 =");
        }
        else if(operator == null)
        {
            recentLabel.setText(String.format("%s = ", current));
        }
        else
        {
            if(current.equals(new BigDecimal("0")))
            {
                current = recent;
            }

            isUnableCalculate = CalculateValue();
            if(isUnableCalculate)
            {
                recentLabel.setText(String.format(String.valueOf(recent) + " " + operator + " " + String.valueOf(current) + " ="));
                currentLabel = InputState.GetInputState().GetCurrentInput();
                if(result.toString().length() >= 16)
                {
                    currentLabel.setText(Eformating.format(result));
                }
                else
                {
                    currentLabel.setText(String.valueOf(result));
                }
                recent = new BigDecimal(String.valueOf(result));
            }
        }
    }
    public void InputNegate()
    {
        if(!isUnableCalculate)
        {
            return;
        }
        if(!result.equals(new BigDecimal("0")))
        {
            recentInputs = String.format("negate(%s)", String.valueOf(result));
            recentLabel = InputState.GetInputState().GetRecentInput();
            recentLabel.setText(recentInputs);

            current = result;
            result = new BigDecimal("0");
        }
        else if(!recent.equals(new BigDecimal("0")))
        {
            if(recentInputs == null)
            {
                recentLabel = InputState.GetInputState().GetRecentInput();
                currentLabel = InputState.GetInputState().GetCurrentInput();
                recentInputs = String.valueOf(currentLabel.getText());
                recentInputs = String.format("negate(%s)", String.valueOf(recentInputs));
                recentLabel.setText(String.format(recentLabel.getText() + " " + recentInputs));
            }
            else
            {
                recentLabel = InputState.GetInputState().GetRecentInput();
                recentInputs = String.format("negate(%s)", String.valueOf(recentInputs));
                recentLabel.setText(String.format(recent + " " + operator + " " + recentInputs));
            }
        }
        else if(current.equals(new BigDecimal("0")))
        {
            return;
        }
        currentLabel = InputState.GetInputState().GetCurrentInput();
        current = new BigDecimal(currentLabel.getText());
        current = current.multiply(new BigDecimal("-1"));
        currentLabel.setText(String.valueOf(current));
    }
    public void InputCE()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        currentLabel.setText("0");
        current = new BigDecimal("0");
        currentInputs = null;
    }
    public void InputC()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        InputCE();
        recentLabel.setText("");
        recent = new BigDecimal("0");
        result = new BigDecimal("0");
        recentInputs = null;
    }
    public void InputBackspace()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        if(current.equals(new BigDecimal("0")))
        {
            return;
        }
        else if(current.compareTo(new BigDecimal("0")) == -1)
        {
            current = new BigDecimal("0");
            currentLabel = InputState.GetInputState().GetCurrentInput();
            currentLabel.setText(String.valueOf(current));
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
    public void InputPoint() {
        if(!isUnableCalculate)
        {
            return;
        }
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
