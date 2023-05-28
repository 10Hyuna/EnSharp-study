package controller;

import model.TotalStorage;
import model.VO.CaculateResultVO;
import utility.ExceptionHandler;
import view.MediationValue;
import view.TotalComponent;

import javax.swing.*;
import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;

public class ValueUpdater
{
    private MediationValue mediationValue;
    private TotalStorage totalStorage;
    private ValueValidator valueValidator;
    private ExceptionHandler exceptionHandler;
    private boolean isComeinOpearator;
    private boolean isCalculated = false;
    public ValueUpdater()
    {
        mediationValue = new MediationValue();
        totalStorage = new TotalStorage();
        valueValidator = new ValueValidator();
        exceptionHandler = new ExceptionHandler();
    }
    public void processInputtedNumber(String command)
    {   // 숫자 버튼이 눌렸을 경우
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
        String pointValue = valueValidator.isEndedPoint(totalStorage.comeInValue.getCurrentNumber().toString());
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
        if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {   // 입력 중이던 값이 없을 때,
            totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getPreviousNumber());
        }
        else if(totalStorage.comeInValue.getOperator() != null)
        {   // 어떤 값을 입력 중에 있다가 연산자를 눌렀을 경우
            calculateValue();   // 값을 계산
        }
        else if(isCalculated)
        {   // 계산을 한 적이 있었다면
            isCalculated = false;
            totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getResultNumber());
        }
        if(totalStorage.comeInValue.getResultNumber().equals(new BigDecimal("0")))
        {   // 최근에 값끼리 연산을 한 적이 없다면
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getCurrentNumber());
        }   // 이전 값은 가장 최근에 입력하던 값으로 초기화
        else
        {   // 최근에 값끼리 연산을 한 적이 있다면
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getResultNumber());
        }   // 이전 값은 결괏값으로 초기화

        totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());
        totalStorage.comeInValue.setPreviousString(totalStorage.comeInValue.getPreviousNumber().toString());
        totalStorage.comeInValue.setOperator(command);
        totalStorage.comeInValue.setPreviousString(
                String.format("%s %s", totalStorage.comeInValue.getPreviousString(), totalStorage.comeInValue.getOperator()));

        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
        isComeinOpearator = true;
    }
    public void processInputtedEqual()
    {
        if(totalStorage.comeInValue.getOperator() == null)
        {   // 연산자를 입력한 적이 없다면
            totalStorage.comeInValue.setPreviousString(String.format("%s = ", totalStorage.comeInValue.getCurrentString()));

            mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
        }
        else
        {
            if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0"))
            && isComeinOpearator)
            {
                totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getPreviousNumber());
            }
            calculateValue();   // 연산

            totalStorage.comeInValue.setPreviousString(
                    String.format("%s %s =", totalStorage.comeInValue.getPreviousString(), totalStorage.comeInValue.getCurrentNumber()));

            mediationValue.changeCurrent(totalStorage.comeInValue.getResultNumber().toString());
            mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());

            totalStorage.comeInValue.setPreviousString(
                    String.format("%s %s", totalStorage.comeInValue.getResultNumber(), totalStorage.comeInValue.getOperator()));
            isCalculated = true;
            // 한 번 사용한 연산자는 null로 초기화
        }
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
    public void processInputtedNegate() {   // negate 버튼이 눌렸을 경우,
        if (!totalStorage.comeInValue.getResultNumber().equals(new BigDecimal("0")))
        {
            totalStorage.comeInValue.setPreviousString(
                    String.format("negate(%s)", totalStorage.comeInValue.getResultNumber().toString()));
            totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getResultNumber());
            totalStorage.comeInValue.setResultNumber(new BigDecimal("0"));
        }
        else if(!totalStorage.comeInValue.getPreviousNumber().equals(new BigDecimal("0")))
        {
            if(totalStorage.comeInValue.getPreviousString().equals(""))
            {
                totalStorage.comeInValue.setPreviousString(String.format("negate(%s)", totalStorage.comeInValue.getCurrentString()));
                totalStorage.comeInValue.setPreviousString(
                        String.format("%s %s %s", totalStorage.comeInValue.getPreviousNumber(), totalStorage.comeInValue.getOperator(), totalStorage.comeInValue.getPreviousString()));
            }
        }
        else if(totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0")))
        {
            return;
        }
        totalStorage.comeInValue.setCurrentNumber
                (new BigDecimal(totalStorage.comeInValue.getCurrentString()).multiply(new BigDecimal(-1)));
        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
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
        totalStorage.comeInValue.setResultNumber(new BigDecimal("0"));
        isCalculated = false;

        mediationValue.changeCurrent(totalStorage.comeInValue.getCurrentString());
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
    }
    private void calculateValue() {
        switch (totalStorage.comeInValue.getOperator()) {
            case "+":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                add(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL128));
                break;
            case "-":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                subtract(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL128));
                break;
            case "×":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                multiply(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL128));
                break;
            case "÷":
                totalStorage.comeInValue.setResultNumber
                        (totalStorage.comeInValue.getPreviousNumber().
                                divide(totalStorage.comeInValue.getCurrentNumber(), MathContext.DECIMAL128));
                break;
        }
        
        totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getResultNumber());
        totalStorage.result.add(new CaculateResultVO(totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getOperator(), totalStorage.comeInValue.getResultNumber().intValue()));
    }
}