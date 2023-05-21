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
        recentLabel.setText("");
        currentLabel.setText("0으로 나눌 수 없습니다");
    }
}
