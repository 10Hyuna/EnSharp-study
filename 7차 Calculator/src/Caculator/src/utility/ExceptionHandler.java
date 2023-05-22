package utility;

import view.InputState;

import javax.swing.*;

public class ExceptionHandler {
    private JLabel currentLabel;
    private JLabel recentLabel;
    public void UndifinedNumber()
    {
        currentLabel = InputState.GetInputState().GetCurrentInput();
        currentLabel.setText("정의되지 않은 결과입니다.");
    }
    public void UndividedNumber()
    {
        currentLabel = InputState.GetInputState().GetCurrentInput();
        currentLabel.setText("0으로 나눌 수 없습니다");
    }
}
