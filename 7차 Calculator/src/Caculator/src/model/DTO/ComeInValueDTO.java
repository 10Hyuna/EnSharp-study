package model.DTO;

import java.math.BigDecimal;

public class ComeInValueDTO {
    private String currentString = "0";
    private String previousString;
    private String operator;
    private BigDecimal currentNumber = new BigDecimal("0");
    private BigDecimal previousNumber;
    private BigDecimal resultNumber;
    public String getCurrentString()
    {
        return currentString;
    }
    public void setCurrentString(String value)
    {
        currentString = value;
    }
    public String getPreviousString()
    {
        return previousString;
    }
    public void setPreviousString(String value)
    {
        previousString = value;
    }
    public String getOperator() { return operator; }
    public void setOperator(String value) { operator = value; }
    public BigDecimal getCurrentNumber()
    {
        return currentNumber;
    }
    public void setCurrentNumber(BigDecimal value)
    {
        currentNumber = value;
    }
    public BigDecimal getPreviousNumber()
    {
        return previousNumber;
    }
    public void setPreviousNumber(BigDecimal value)
    {
        previousNumber = value;
    }
    public BigDecimal getResultNumber()
    {
        return resultNumber;
    }
    public void setResultNumber(BigDecimal value)
    {
        resultNumber = value;
    }
}
