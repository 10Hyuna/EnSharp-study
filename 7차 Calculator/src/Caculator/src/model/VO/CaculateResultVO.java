package model.VO;

public class CaculateResultVO {
    public CaculateResultVO()
    {

    }
    public CaculateResultVO(int firstInput, int lastInput, String operator, int result)
    {
        this.firstInput = firstInput;
        this.lastInput = lastInput;
        this.operator = operator;
        this.result = result;
    }
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
