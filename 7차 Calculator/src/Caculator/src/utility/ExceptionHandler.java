package utility;

import view.InputState;
import view.TotalComponent;

import javax.swing.*;

public class ExceptionHandler {
    private JLabel currentLabel;
    private JLabel recentLabel;
    public void undifinedNumber()
    {
        currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();
        currentLabel.setText("정의되지 않은 결과입니다.");
    }
    public void undividedNumber()
    {
        currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();
        currentLabel.setText("0으로 나눌 수 없습니다");
    }
    public boolean isContainPoint(String currentValue)
    {
        if(currentValue.contains("."))
        {
            return true;
        }
        return false;
    }
}
