package controller;

import model.TotalStorage;
import model.VO.CaculateResultVO;
import utility.ExceptionHandler;
import view.MediationValue;
import view.TotalComponent;

import javax.swing.*;
import java.math.BigDecimal;
import java.math.MathContext;

public class ValueUpdater
{
    private MediationValue mediationValue;
    private TotalStorage totalStorage;
    private ValueValidator valueValidator;
    private ExceptionHandler exceptionHandler;
    private boolean isComeinOpearator;
    public ValueUpdater()
    {
        mediationValue = new MediationValue();
        totalStorage = new TotalStorage();
        valueValidator = new ValueValidator();
        exceptionHandler = new ExceptionHandler();
    }
    public void processInputtedNumber(String command)
    {   // 숫자 버튼이 눌렸을 경우,
        if(totalStorage.comeInValue.getCurrentString().length() < 16)
        {
            if(isComeinOpearator)
            {
                isComeinOpearator = false;
                totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
                totalStorage.comeInValue.setCurrentString("0");
            }
            if(valueValidator.isContainPoint(totalStorage.comeInValue.getCurrentString()))
            {
                calculatePoint(command);
            }
            else
            {
                calculatePlane(command);
            }
            mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        }
    }
    private void calculatePoint(String command)
    {
        String pointValue = valueValidator.isEndedPoint(totalStorage.comeInValue.getCurrentString());
        pointValue += command;
        totalStorage.comeInValue.setCurrentNumber(new BigDecimal(pointValue));
        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
    }
    private void calculatePlane(String command)
    {
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().multiply(new BigDecimal("10")));
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().add(new BigDecimal(command)));

        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());
    }
    public void processInputtedOperator(String command)
    {   // 연산자 버튼이 눌렸을 경우,
        isComeinOpearator = true;
        if(!totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0"))
        && !totalStorage.comeInValue.getPreviousNumber().equals(new BigDecimal("0"))
        && totalStorage.comeInValue.getOperator() != null)
        {
            calculateValue();
        }
        else if(totalStorage.comeInValue.getResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getCurrentNumber());
        }
        else
        {
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getResultNumber());
        }
        totalStorage.comeInValue.setPreviousString(totalStorage.comeInValue.getPreviousNumber().toString());
        totalStorage.comeInValue.setOperator(command);
        totalStorage.comeInValue.setPreviousString(
                String.format("%s %s", totalStorage.comeInValue.getPreviousString(), totalStorage.comeInValue.getOperator()));

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
    }
    public void processInputtedEqual()
    {
        calculateValue();

        totalStorage.comeInValue.setPreviousString(
                String.format("%s %s =", totalStorage.comeInValue.getPreviousString(), totalStorage.comeInValue.getCurrentNumber()));

        mediationValue.changeCurrent(totalStorage.comeInValue.getResultNumber().toString());
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());

        totalStorage.comeInValue.setPreviousString(String.format("%s %s", totalStorage.comeInValue.getResultNumber(), totalStorage.comeInValue.getOperator()));
        totalStorage.comeInValue.setOperator(null);
        //계산할 수 있는 값이 입력되어 있는지 확인하는 유효성 검사 함수 호출
    }
    public void processInputtedPoint()
    {
        if(valueValidator.isContainPoint(totalStorage.comeInValue.getCurrentString()))
        {
            return;
        }
        totalStorage.comeInValue.setCurrentNumber(new BigDecimal(totalStorage.comeInValue.getCurrentString() + ".0"));
        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        //소수점이 이미 입력되어 있을 경우를 확인하는 유효성 검사 함수 호출
    }
    public void processInputtedNegate()
    {   // negate 버튼이 눌렸을 경우,

    }
    public void processInputtedDeleter()
    {   // 백스페이스 버튼이 눌렸을 경우,
        if(totalStorage.comeInValue.getResultNumber().equals(null))
        {
            totalStorage.comeInValue.setPreviousNumber(new BigDecimal("0"));
            totalStorage.comeInValue.setPreviousString("");
        }
        else
        {
            String cuttedValue = totalStorage.comeInValue.getCurrentString();
            cuttedValue = cuttedValue.substring(0, cuttedValue.length() - 1);
            if (cuttedValue == "") {
                cuttedValue = "0";
            }
            totalStorage.comeInValue.setCurrentNumber(new BigDecimal(cuttedValue));
            totalStorage.comeInValue.setCurrentString(cuttedValue);
        }

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
    }
    public void processInputtedCE()
    {   // CE나 C 버튼이 눌렸을 경우,
        totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
        totalStorage.comeInValue.setCurrentString("0");

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
    }
    public void processInputtedC()
    {
        processInputtedCE();

        totalStorage.comeInValue.setPreviousNumber(new BigDecimal("0"));
        totalStorage.comeInValue.setPreviousString("");
        totalStorage.comeInValue.setOperator(null);

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
    }
    private void calculateValue() {
        switch (totalStorage.comeInValue.getOperator()) {
            case "+":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                add(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL64));
                break;
            case "-":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                subtract(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL64));
                break;
            case "×":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                multiply(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL64));
                break;
            case "÷":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                divide(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL64));
                break;
        }
        totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getResultNumber());
        totalStorage.result.add(new CaculateResultVO(totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getOperator(), totalStorage.comeInValue.getResultNumber().intValue()));
    }
}