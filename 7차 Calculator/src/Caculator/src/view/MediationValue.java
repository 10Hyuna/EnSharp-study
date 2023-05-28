package view;

import javax.swing.*;
import java.awt.*;
import java.math.BigDecimal;
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
    public void changeCurrent(String current)
    {
        int wasteSize = currentLabel.getText().length() - 12;
        int fontSize = 50;

        if(wasteSize > 0)
        {
            fontSize -= wasteSize * 3;
        }

        currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, fontSize));
        currentLabel.setText(formating.format(new BigDecimal(current)));
    }
    public void changePrevious(String previous)
    {
        previousLabel.setText(previous);
    }
}
