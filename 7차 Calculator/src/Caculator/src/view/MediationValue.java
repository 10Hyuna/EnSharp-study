package view;

import javax.swing.*;
import java.awt.*;
import java.math.BigDecimal;
import java.text.DecimalFormat;

public class MediationValue {
    private JLabel currentLabel;
    private JLabel previousLabel;
    private DecimalFormat formatPoint = new DecimalFormat("###,###.0###############");
    private DecimalFormat formatPlain = new DecimalFormat("###,###.################");
    public MediationValue()
    {
        currentLabel = TotalComponent.getTotalComponent().getCurrentJLabel();

        previousLabel = TotalComponent.getTotalComponent().getPreviousLabel();
    }
    public void changeCurrent(String current)
    {
        current = current.replace(",", "");
        current = current.replace("E", "e");

        int wasteSize = checkInteger(current) - 10;
        int fontSize = 50;

        if(wasteSize > 0)
        {
            fontSize -= wasteSize * 3;
        }

        currentLabel.setFont(new Font("맑은 고딕", Font.BOLD, fontSize));
        if(current.contains("e"))
        {
            currentLabel.setText(current);
        }
        else if(current.contains("."))
        {
            currentLabel.setText(formatPoint.format(new BigDecimal(current)));
        }
        else
        {
            currentLabel.setText(formatPlain.format(new BigDecimal(current)));
        }
    }
    public void changePrevious(String previous)
    {
        previous = previous.replace("E", "e");
        previousLabel.setText(previous);
    }
    private int checkInteger(String value)
    {
        String[] number = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        String cuttedValue;
        int numberCount = 0;
        boolean checkInt;
        int length = value.length();

        for(int i = 0; i < length; i++)
        {
            checkInt = false;
            cuttedValue = value.substring(value.length() - 1, value.length());
            value = value.substring(0, value.length() - 1);
            for(int j = 0; j < number.length; j++)
            {
                if(cuttedValue.equals(number[j]))
                {
                    checkInt = true;
                    break;
                }
            }
            if(checkInt)
            {
                numberCount++;
            }
        }
        return numberCount;
    }
}
