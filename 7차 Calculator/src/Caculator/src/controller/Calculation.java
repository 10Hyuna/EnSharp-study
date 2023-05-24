package controller;

import model.TotalStorage;
import model.VO.CaculateResultVO;
import utility.ExceptionHandler;
import view.InputState;

import java.awt.*;
import java.math.MathContext;
import java.text.DecimalFormat;

import javax.swing.*;
import java.math.BigDecimal;

public class Calculation {
    private TotalStorage totalStorage;
    private ExceptionHandler exceptionHandler;
    private boolean isUnableCalculate = true;
    private boolean isCalculated;
    private BigDecimal current = new BigDecimal("0");
    private BigDecimal recent = new BigDecimal("0");
    private BigDecimal result = new BigDecimal("0");
    private String operator;
    private String recentInputs;
    private String currentInputs;
    private JLabel currentLabel;
    private JLabel recentLabel;
    private DecimalFormat formating = new DecimalFormat("###,###.################");
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
        if(String.valueOf(current).length() >= 16)
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 40));
            return;
        }
        BigDecimal ten = new BigDecimal("10");
        BigDecimal inputValue = new BigDecimal(input);
        totalStorage.comeInValue.SetCurrentNumber(totalStorage.comeInValue.GetCurrentNumber().multiply(ten));
        totalStorage.comeInValue.SetCurrentNumber(totalStorage.comeInValue.GetCurrentNumber().add(inputValue));
        currentLabel = InputState.GetInputState().GetCurrentInput();
        if(String.valueOf(totalStorage.comeInValue.GetCurrentNumber()).length() == 15)
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 43));
        }
        else if(String.valueOf(totalStorage.comeInValue.GetCurrentNumber()).length() == 14)
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 46));
        }
        else
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
        }
        currentLabel.setText(formating.format(totalStorage.comeInValue.GetCurrentNumber()));
    }
    public void InputOperator(String input)
    {
        if(!isUnableCalculate)
        {
            return;
        }
        if(totalStorage.comeInValue.GetCurrentNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.SetCurrentNumber(recent);
        }
        else if(isCalculated)
        {
            totalStorage.comeInValue.SetCurrentNumber(result);
        }
        else if(totalStorage.comeInValue.GetOperator() != null)
        {
            isUnableCalculate = CalculateValue();
            if(isUnableCalculate)
            {
                totalStorage.comeInValue.SetOperator(input);
                recentLabel.setText(String.format(String.valueOf(result) + " " + operator));
                currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                currentLabel.setText(formating.format(result));
                if(result.toString().length() > 16)
                {
                    String formatedString = result.toString().replace("E", "e");
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 35));
                    currentLabel.setText(formatedString);
                }
                else
                {
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                    currentLabel.setText(formating.format(result));
                }
                totalStorage.comeInValue.GetPreviousString(new BigDecimal(String.valueOf(result));
                totalStorage.comeInValue.SetCurrentNumber(new BigDecimal("0"));
            }
            return;
        }
        totalStorage.comeInValue.SetOperator(input);
        totalStorage.comeInValue.SetPreviousNumber(totalStorage.comeInValue.GetCurrentNumber());
        recentLabel = InputState.GetInputState().GetRecentInput();
        recentLabel.setText(String.format(String.valueOf(totalStorage.comeInValue.GetPreviousNumber()) + " " + totalStorage.comeInValue.GetOperator()));
        totalStorage.comeInValue.SetCurrentNumber(new BigDecimal("0"));
    }
    public void InputEqual()
    {
        currentLabel = InputState.GetInputState().GetCurrentInput();
        if(!isUnableCalculate)
        {
            return;
        }
        recentLabel = InputState.GetInputState().GetRecentInput();
        if (totalStorage.comeInValue.GetPreviousNumber().equals(new BigDecimal("0"))
                && totalStorage.comeInValue.GetCurrentNumber().equals(new BigDecimal("0")))
        {
            recentLabel.setText("0 =");
        }
        else if(totalStorage.comeInValue.GetOperator() == null)
        {
            recentLabel.setText(String.format("%s = ", current));
        }
        else
        {
            if(totalStorage.comeInValue.GetCurrentNumber().equals(new BigDecimal("0"))
                    && !currentLabel.getText().equals("0"))
            {
                totalStorage.comeInValue.SetCurrentNumber(totalStorage.comeInValue.GetPreviousNumber());
            }
            isUnableCalculate = CalculateValue();
            if(isUnableCalculate)
            {
                recentLabel.setText(String.format(String.valueOf(totalStorage.comeInValue.GetPreviousNumber())
                        + " " + totalStorage.comeInValue.GetOperator() + " " +
                        String.valueOf(totalStorage.comeInValue.GetCurrentNumber()) + " ="));
                if(totalStorage.comeInValue.GetResultNumber().toString().length() > 16)
                {
                    String formatedString = totalStorage.comeInValue.GetResultNumber().toString().replace("E", "e");
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 35));
                    currentLabel.setText(formatedString);
                }
                else
                {
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                    currentLabel.setText(formating.format(totalStorage.comeInValue.GetResultNumber()));
                }
                totalStorage.comeInValue.SetPreviousNumber(new BigDecimal(String.valueOf(totalStorage.comeInValue.GetResultNumber())));
            }
        }
    }
    public void InputNegate()
    {
        if(!isUnableCalculate)
        {
            return;
        }
        if(!totalStorage.comeInValue.GetResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.SetPreviousString
                    (String.format("negate(%s)", String.valueOf(totalStorage.comeInValue.GetResultNumber())));
            recentLabel = InputState.GetInputState().GetRecentInput();
            recentLabel.setText(totalStorage.comeInValue.GetPreviousString());

            totalStorage.comeInValue.SetCurrentNumber(totalStorage.comeInValue.GetResultNumber());
            totalStorage.comeInValue.SetResultNumber(new BigDecimal("0"));
        }
        else if(!totalStorage.comeInValue.GetPreviousString().equals(new BigDecimal("0")))
        {
            if(totalStorage.comeInValue.GetPreviousString() == null)
            {
                recentLabel = InputState.GetInputState().GetRecentInput();
                currentLabel = InputState.GetInputState().GetCurrentInput();
                totalStorage.comeInValue.SetPreviousString(String.format("negate(%s)", currentLabel.getText()));
                recentLabel.setText(String.format(recentLabel.getText() + " " + recentInputs));
            }
            else
            {
                recentLabel = InputState.GetInputState().GetRecentInput();
                totalStorage.comeInValue.SetPreviousString(String.format("negate(%s)", totalStorage.comeInValue.GetPreviousString()));
                recentLabel.setText(String.format(recent + " " + operator + " " + recentInputs));
            }
        }
        else if(totalStorage.comeInValue.GetCurrentNumber().equals(new BigDecimal("0")))
        {
            return;
        }
        currentLabel = InputState.GetInputState().GetCurrentInput();
        totalStorage.comeInValue.SetCurrentNumber
                ((new BigDecimal(currentLabel.getText())).multiply(new BigDecimal("-1")));
        currentLabel.setText(formating.format(totalStorage.comeInValue.GetCurrentNumber()));
    }
    public void InputCE()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        totalStorage.comeInValue.SetOperator(null);
        currentLabel.setText("0");
        totalStorage.comeInValue.SetCurrentNumber(new BigDecimal("0"));
        totalStorage.comeInValue.SetCurrentString(null);
    }
    public void InputC()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        InputCE();
        recentLabel = InputState.GetInputState().GetRecentInput();
        recentLabel.setText("");
        totalStorage.comeInValue.SetPreviousNumber(new BigDecimal("0"));
        totalStorage.comeInValue.SetResultNumber(new BigDecimal("0"));
        isCalculated = false;
        totalStorage.comeInValue.SetPreviousString(null);
    }
    public void InputBackspace()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        if(totalStorage.comeInValue.GetCurrentNumber().equals(new BigDecimal("0")))
        {
            return;
        }
        else if(totalStorage.comeInValue.GetCurrentNumber().compareTo(new BigDecimal("0")) == -1)
        {
            totalStorage.comeInValue.SetCurrentNumber(new BigDecimal("0"));
            currentLabel = InputState.GetInputState().GetCurrentInput();
            currentLabel.setText(formating.format(totalStorage.comeInValue.GetCurrentNumber()));
            return;
        }
        else if(totalStorage.comeInValue.GetResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.SetCurrentString(String.valueOf(totalStorage.comeInValue.SetCurrentNumber()));
            if(totalStorage.comeInValue.GetCurrentString().length() == 1)
            {
                totalStorage.comeInValue.SetCurrentString("0");
            }
            else
            {
                totalStorage.comeInValue.SetCurrentString
                        (totalStorage.comeInValue.GetCurrentString().substring(0, totalStorage.comeInValue.GetCurrentString().length() - 1));
            }
            totalStorage.comeInValue.SetCurrentNumber(new BigDecimal(totalStorage.comeInValue.GetCurrentString()));
            currentLabel = InputState.GetInputState().GetCurrentInput();
            currentLabel.setText(formating.format(current));
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
        isCalculated = false;
        if (recent.equals(new BigDecimal("0")) && current.equals(new BigDecimal("0")) && operator.equals("÷")) {
            exceptionHandler.UndifinedNumber();
            return false;
        }
        else if(current.equals(new BigDecimal("0")) && operator.equals("÷"))
        {
            exceptionHandler.UndividedNumber();
            return false;
        }
        switch (operator) {
            case "+":
                result = recent.add(current, MathContext.DECIMAL64);
                break;
            case "-":
                result = recent.subtract(current, MathContext.DECIMAL64);
                break;
            case "×":
                result = recent.multiply(current, MathContext.DECIMAL64);
                break;
            case "÷":
                result = recent.divide(current, MathContext.DECIMAL64);
                break;
        }
        totalStorage.result.add(new CaculateResultVO(recent.intValue(), current.intValue(), operator, result.intValue()));
        isCalculated = true;
        return true;
    }
}
