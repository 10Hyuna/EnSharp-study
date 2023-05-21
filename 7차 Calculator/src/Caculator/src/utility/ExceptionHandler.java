package utility;

import view.InputState;

import javax.swing.*;

public class ExceptionHandler {
    private JLabel currentLabel;
    private JLabel recentLabel;
    public void IsUndivisableNumber()
    {
        currentLabel = InputState.GetInputState().GetCurrentInput();
        recentLabel = InputState.GetInputState().GetRecentInput();
        currentLabel.setText("정의되지 않은 결과입니다.");
    }
}
