package view;

import javax.swing.*;
import java.awt.*;
import java.text.DecimalFormat;

public class MediationValue {
    private JLabel currentLabel;
    private JLabel previousLabel;
    private DecimalFormat formating = new DecimalFormat("###,###.################");
    public MediationValue()
    {
        currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();
        previousLabel = TotalComponent.getTotalComponent().getPreviousLabel();
    }
    public void changeCurrent(String currentString)
    {
        int wasteSize = currentLabel.getText().length() - 9;
        int fontSize = 50;

        if(wasteSize > 0)
        {
            fontSize -= wasteSize * 3;
        }

        currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, fontSize));
        currentLabel.setText(currentString);
    }
    public void changePrevious(String previousString)
    {
        previousLabel.setText(previousString);
    }
}
