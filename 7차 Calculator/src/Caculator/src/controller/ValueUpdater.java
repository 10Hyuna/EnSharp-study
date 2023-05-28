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
    public ValueUpdater()
    {
        mediationValue = new MediationValue();
        totalStorage = new TotalStorage();
        valueValidator = new ValueValidator();
        exceptionHandler = new ExceptionHandler();
    }
    public void processInputtedNumber(String command)
    {   // 숫자 버튼이 눌렸을 경우,
        if(totalStorage.comeInValue.getOperator() != null)
        {
            totalStorage.comeInValue.setCurrentNumber(new BigDecimal("0"));
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
        mediationValue.changePrevious(totalStorage.comeInValue.getPreviousString());
        // 입력 값의 길이를 확인하고 폰트 크기 줄이는 함수 호출
    }
    private void calculatePoint(String commnad)
    {
        String PointValue = valueValidator.isEndedPoint(totalStorage.comeInValue.getCurrentString());

        totalStorage.comeInValue.setCurrentNumber(new BigDecimal(PointValue).add(new BigDecimal(commnad)));
        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());
    }
    private void calculatePlane(String command)
    {
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().multiply(new BigDecimal("10")));
        totalStorage.comeInValue.setCurrentNumber(totalStorage.comeInValue.getCurrentNumber().add(new BigDecimal(command)));

        totalStorage.comeInValue.setCurrentString(totalStorage.comeInValue.getCurrentNumber().toString());
    }
    public void processInputtedOperator(String command)
    {   // 연산자 버튼이 눌렸을 경우,
        if(!totalStorage.comeInValue.getCurrentNumber().equals(new BigDecimal("0"))
        && !totalStorage.comeInValue.getPreviousNumber().equals(new BigDecimal("0")))
        {
            calculateValue();
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getResultNumber());
        }
        else
        {
            totalStorage.comeInValue.setPreviousNumber(totalStorage.comeInValue.getCurrentNumber());
        }
        totalStorage.comeInValue.setPreviousString(totalStorage.comeInValue.getPreviousNumber().toString());
        totalStorage.comeInValue.setOperator(command);
        totalStorage.comeInValue.setPreviousString(
                String.format("%s %s", totalStorage.comeInValue.getPreviousString(), totalStorage.comeInValue.getOperator()));
    }
    public void processInputtedEqual()
    {
        //계산할 수 있는 값이 입력되어 있는지 확인하는 유효성 검사 함수 호출
    }
    public void processInputtedPoint()
    {
        //소수점이 이미 입력되어 있을 경우를 확인하는 유효성 검사 함수 호출
    }
    public void processInputtedNegate()
    {   // negate 버튼이 눌렸을 경우,

    }
    public void processInputtedDeleter()
    {   // 백스페이스 버튼이 눌렸을 경우,

    }
    public void processInputtedClear()
    {   // CE나 C 버튼이 눌렸을 경우,

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
        totalStorage.result.add(new CaculateResultVO(totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getCurrentNumber().intValue(),
                totalStorage.comeInValue.getOperator(), totalStorage.comeInValue.getResultNumber().intValue()));
    }
}