package model.DTO;

import java.math.BigDecimal;

public class ComeInValueDTO {
    private String currentString;
    private String previousString;
    private String operator;
    private BigDecimal currentNumber;
    private BigDecimal previousNumber;
    private BigDecimal resultNumber;
    public String GetCurrentString()
    {
        return currentString;
    }
    public void SetCurrentString(String value)
    {
        currentString = value;
    }
    public String GetPreviousString()
    {
        return previousString;
    }
    public void SetPreviousString(String value)
    {
        previousString = value;
    }
    public String GetOperator() { return operator; }
    public void SetOperator(String value) { operator = value; }
    public BigDecimal GetCurrentNumber()
    {
        return currentNumber;
    }
    public void SetCurrentNumber(BigDecimal value)
    {
        currentNumber = value;
    }
    public BigDecimal GetPreviousNumber()
    {
        return previousNumber;
    }
    public void SetPreviousNumber(BigDecimal value)
    {
        previousNumber = value;
    }
    public BigDecimal GetResultNumber()
    {
        return resultNumber;
    }
    public void SetResultNumber(BigDecimal value)
    {
        resultNumber = value;
    }
}
