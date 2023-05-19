package model.VO;

public class CaculateResultVO {
    private int firstInput;
    private int lastInput;
    private String operator;
    private int result;

    public int GetFirstInput()
    {
        return firstInput;
    }
    public int GetLastInput()
    {
        return lastInput;
    }
    public String GetOperator()
    {
        return operator;
    }
    public int GetResult()
    {
        return result;
    }
}
