package controller;

import model.TotalStorage;
import view.TotalComponent;

import javax.swing.*;

public class ValueUpdater
{
    public JLabel currentLabel;
    public JLabel previousLabel;
    private TotalStorage totalStorage;
    private ValueValidator valueValidator;
    public ValueUpdater()
    {
        currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();
        previousLabel = TotalComponent.getTotalComponent().getPreviousLabel();
        totalStorage = new TotalStorage();
        valueValidator = new ValueValidator();
    }
    public void processInputtedNumber()
    {   // 숫자 버튼이 눌렸을 경우,

    }
    public void processInputtedOperator()
    {   // 연산자 버튼이 눌렸을 경우,

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
    private void UpdateScreen(String currentString, String previousString)
    {
        currentLabel.setText(currentString);
        previousLabel.setText(previousString);
    }
}