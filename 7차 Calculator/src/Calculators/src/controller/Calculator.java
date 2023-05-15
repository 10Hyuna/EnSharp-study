package controller;

import utility.InputValueParse;
import view.InputState;
import view.MainView;

import javax.swing.*;

public class Calculator {
    private MainView mainView;
    private InputValueParse inputValueParse;
    private JLabel currentInputs;
    private JLabel recentInputs;
    private String inputtedValue;
    private String firstInput;
    private String secondInput;
    private String operator;
    private int result;
    private boolean isCalculated = false;
    private boolean isOperated = false;
    public Calculator()
    {
        mainView = new MainView();
        inputValueParse = new InputValueParse();
        currentInputs = InputState.getInputState().getCurrentInput();
        recentInputs = InputState.getInputState().getRecentInput();
    }
    public void startcalculator()
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
        else if(isOperated)
        {
            isOperated = false;
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
        operator = input;
        isOperated = true;

        if(recentInputs.getText() == "")
        {
            firstInput = currentInputs.getText();
            inputtedValue = firstInput;
            inputtedValue += input;
            recentInputs.setText(inputtedValue);
        }
        else
        {
            inputtedValue = String.format("%s %s", firstInput, operator);
            recentInputs.setText(inputtedValue);
        }
//        if(currentInputs.getText() == "0")
//        {
//            inputtedValue = currentInputs.getText();
//            inputtedValue += input;
//            recentInputs.setText(inputtedValue);
//        }
//        else if(isCalculated)
//        {
//            isCalculated = false;
//            inputtedValue = String.valueOf(result);
//            inputtedValue += input;
//            recentInputs.setText(inputtedValue);
//        }
//        else
//        {
//            if(recentInputs.getText() == "")
//            {
//                inputtedValue = currentInputs.getText();
//                inputtedValue += input;
//                recentInputs.setText(inputtedValue);
//            }
//            else
//            {
//                inputtedValue = recentInputs.getText();
//                inputtedValue = inputtedValue.substring(0, inputtedValue.length() -1);
//                inputtedValue += input;
//                recentInputs.setText(inputtedValue);
//            }
//        }
    }
    public void inputEqual()
    {
        if(operator == null)
        {
            inputtedValue = String.format("%s =", firstInput);
            recentInputs.setText(inputtedValue);
        }
        else
        {
            secondInput = currentInputs.getText();;
            inputtedValue = String.format("%s %s %s = ", firstInput, operator, secondInput);
            result = inputValueParse.calculateValue(secondInput, firstInput, operator);
            firstInput = String.valueOf(result);
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
        operator = null;
        currentInputs.setText("0");
        recentInputs.setText("");
    }
}
