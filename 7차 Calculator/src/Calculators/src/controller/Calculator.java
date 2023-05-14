package controller;

import com.sun.tools.javac.Main;
import view.InputState;
import view.MainView;

import javax.swing.*;

public class Calculator {
    private MainView mainView;
    private JLabel currentInputs;
    private JLabel recentInputs;
    private String inputtedValue;
    private int firstInput;
    private int secondInput;
    private String operator;
    private int result;
    private boolean isCalculated = false;
    public Calculator()
    {
        mainView = new MainView();
        currentInputs = InputState.getInputState().getCurrentInput();
        recentInputs = InputState.getInputState().getRecentInput();
    }
    public void calculate()
    {
        mainView.setcalculator();
    }
    public void inputNumber(String input)
    {
        if(currentInputs.getText() == "0")
        {
            currentInputs.setText(input);
        }
        else if(isCalculated)
        {
            isCalculated = false;
            recentInputs.setText("");
            currentInputs.setText(input);
        }
        else
        {
            inputtedValue = currentInputs.getText();
            inputtedValue += input;
            currentInputs.setText(inputtedValue);
        }
    }
    public void inputPoint()
    {

    }
    public void inputOperator(String input)
    {
        if(currentInputs.getText() == "0")
        {
            inputtedValue = currentInputs.getText();
            inputtedValue += input;
            recentInputs.setText(inputtedValue);
        }
        else if(isCalculated)
        {
            isCalculated = false;
            inputtedValue = String.valueOf(result);
            inputtedValue += input;
            recentInputs.setText(inputtedValue);
        }
        else
        {
            if(recentInputs.getText() == "")
            {
                inputtedValue = currentInputs.getText();
                inputtedValue += input;
                recentInputs.setText(inputtedValue);
            }
            else
            {
                inputtedValue = recentInputs.getText();
                inputtedValue = inputtedValue.substring(0, inputtedValue.length() -1);
                inputtedValue += input;
                recentInputs.setText(inputtedValue);
            }
        }
    }
    public void inputEqual()
    {
        if(currentInputs.getText() == "0")
        {
            if(recentInputs.getText() != "")
            {

            }
        }
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
}
