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

public class Calculation
{
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
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().multiply(ten));
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().add(inputValue));
        currentLabel = InputState.getInputState().getCurrentInput();
        if(String.valueOf(totalStorage.comeInValue.getCurrentNumber()).length() == 15)
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 43));
        }
        else if(String.valueOf(totalStorage.comeInValue.getCurrentNumber()).length() == 14)
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 46));
        }
        else
        {
            currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
        }
        currentLabel.setText(formating.format(totalStorage.comeInValue.getCurrentNumber()));
    }
    public void InputOperator(String input)
    {
        if(!isUnableCalculate)
        {
            return;
        }
        if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.setCurrentNumber(recent);
        }
        else if(isCalculated)
        {
            totalStorage.comeInValue.setCurrentNumber(result);
        }
        else if(totalStorage.comeInValue.getOperator() != null)
        {
            isUnableCalculate = CalculateValue();
            if(isUnableCalculate)
            {
                totalStorage.comeInValue.setOperator(input);
                recentLabel.setText(String.format(String.valueOf(totalStorage.comeInValue.getResultNumber())
                        + " " + totalStorage.comeInValue.getOperator()));
                currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                currentLabel.setText(formating.format(totalStorage.comeInValue.getResultNumber()));
                if(result.toString().length() > 16)
                {
                    String formatedString = result.toString().replace("E", "e");
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 35));
                    currentLabel.setText(formatedString);
                }
                else
                {
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                    currentLabel.setText(formating.format(totalStorage.comeInValue.getResultNumber()));
                }
                totalStorage.comeInValue.setPreviousNumber(new BigDecimal
                        (String.valueOf(totalStorage.comeInValue.getResultNumber())));
                totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
            }
            return;
        }
        totalStorage.comeInValue.setOperator(input);
        totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getCurrentNumber());
        recentLabel = InputState.getInputState().getPreviousInput();
        recentLabel.setText(String.format(String.valueOf
                (totalStorage.comeInValue.getPreviousNumber()) + " " + totalStorage.comeInValue.getOperator()));
        totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
    }
    public void InputEqual()
    {
        currentLabel = InputState.getInputState().getCurrentInput();
        if(!isUnableCalculate)
        {
            return;
        }
        recentLabel = InputState.getInputState().getPreviousInput();
        if (totalStorage.comeInValue.getPreviousNumber().equals(new BigDecimal("0"))
                && totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {
            recentLabel.setText("0 =");
        }
        else if(totalStorage.comeInValue.getOperator() == null)
        {
            recentLabel.setText(String.format("%s = ", current));
        }
        else
        {
            if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0"))
                    && !currentLabel.getText().equals("0"))
            {
                totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getPreviousNumber());
            }
            isUnableCalculate = CalculateValue();
            if(isUnableCalculate)
            {
                recentLabel.setText(String.format(String.valueOf(totalStorage.comeInValue.getPreviousNumber())
                        + " " + totalStorage.comeInValue.getOperator() + " " +
                        String.valueOf(totalStorage.comeInValue.getCurrentNumber()) + " ="));
                if(totalStorage.comeInValue.getResultNumber().toString().length() > 16)
                {
                    String formatedString = totalStorage.comeInValue.getResultNumber().toString().
                            replace("E", "e");
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 35));
                    currentLabel.setText(formatedString);
                }
                else
                {
                    currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, 50));
                    currentLabel.setText(formating.format(totalStorage.comeInValue.getResultNumber()));
                }
                totalStorage.comeInValue.setPreviousNumber(new BigDecimal(String.valueOf
                        (totalStorage.comeInValue.getResultNumber())));
            }
        }
    }
    public void InputNegate()
    {
        if(!isUnableCalculate)
        {
            return;
        }
        if(!totalStorage.comeInValue.getResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.setPreviousString
                    (String.format("negate(%s)", String.valueOf(totalStorage.comeInValue.getResultNumber())));
            recentLabel = InputState.getInputState().getPreviousInput();
            recentLabel.setText(totalStorage.comeInValue.getPreviousString());

            totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getResultNumber());
            totalStorage.comeInValue.setResultNumber(new BigDecimal("0"));
        }
        else if(!totalStorage.comeInValue.getPreviousString().equals(new BigDecimal("0")))
        {
            if(totalStorage.comeInValue.getPreviousString() == null)
            {
                recentLabel = InputState.getInputState().getPreviousInput();
                currentLabel = InputState.getInputState().getCurrentInput();
                totalStorage.comeInValue.setPreviousString(String.format("negate(%s)", currentLabel.getText()));
                recentLabel.setText(String.format(recentLabel.getText() + " " + recentInputs));
            }
            else
            {
                recentLabel = InputState.getInputState().getPreviousInput();
                totalStorage.comeInValue.setPreviousString(String.format("negate(%s)", totalStorage.comeInValue.getPreviousString()));
                recentLabel.setText(String.format(recent + " " + operator + " " + recentInputs));
            }
        }
        else if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {
            return;
        }
        currentLabel = InputState.getInputState().getCurrentInput();
        totalStorage.comeInValue.setCurrentNumber
                ((new BigDecimal(currentLabel.getText())).multiply(new BigDecimal("-1")));
        currentLabel.setText(formating.format(totalStorage.comeInValue.getCurrentNumber()));
    }
    public void InputCE()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        totalStorage.comeInValue.setOperator(null);
        currentLabel.setText("0");
        totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
        totalStorage.comeInValue.setCurrentString(null);
    }
    public void InputC()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        InputCE();
        recentLabel = InputState.getInputState().getPreviousInput();
        recentLabel.setText("");
        totalStorage.comeInValue.setPreviousNumber(new BigDecimal("0"));
        totalStorage.comeInValue.setResultNumber(new BigDecimal("0"));
        isCalculated = false;
        totalStorage.comeInValue.setPreviousString(null);
    }
    public void InputBackspace()
    {
        if(!isUnableCalculate)
        {
            isUnableCalculate = true;
        }
        if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {
            return;
        }
        else if(totalStorage.comeInValue.getCurrentNumber().compareTo(new BigDecimal("0")) == -1)
        {
            totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
            currentLabel = InputState.getInputState().getCurrentInput();
            currentLabel.setText(formating.format(totalStorage.comeInValue.getCurrentNumber()));
            return;
        }
        else if(totalStorage.comeInValue.getResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.setCurrentString(String.valueOf(totalStorage.comeInValue.getCurrentNumber()));
            if(totalStorage.comeInValue.getCurrentString().length() == 1)
            {
                totalStorage.comeInValue.setCurrentString("0");
            }
            else
            {
                totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentString().
                                substring(0, totalStorage.comeInValue.getCurrentString().length() - 1));
            }
            totalStorage.comeInValue.setCurrentNumber(new BigDecimal(totalStorage.comeInValue.getCurrentString()));
            currentLabel = InputState.getInputState().getCurrentInput();
            currentLabel.setText(formating.format(current));
        }
        else
        {
            recent = new BigDecimal("0");
            recentLabel = InputState.getInputState().getPreviousInput();
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
            exceptionHandler.undifinedNumber();
            return false;
        }
        else if(current.equals(new BigDecimal("0")) && operator.equals("÷"))
        {
            exceptionHandler.undividedNumber();
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
