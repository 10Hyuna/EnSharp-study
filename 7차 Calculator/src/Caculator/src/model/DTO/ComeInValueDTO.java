package model.DTO;

public class ComeInValueDTO {
    private String currentString;
    private String previousString;
    private String operator;
    private int currentNumber;
    private int previousNumber;
    private int resultNumber;
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
    public String GetOperator()
    {
        return operator;
    }
    public void SetOperator(String value)
    {
        operator = value;
    }
    public int GetCurrentNumber()
    {
        return currentNumber;
    }
    public void SetCurrentNumber(int value)
    {
        currentNumber = value;
    }
    public int GetPreviousNumber()
    {
        return previousNumber;
    }
    public void SetPreviousNumber(int value)
    {
        previousNumber = value;
    }
    public int GetResultNumber()
    {
        return resultNumber;
    }
    public void SetResultNumber(int value)
    {
        resultNumber = value;
    }
}
