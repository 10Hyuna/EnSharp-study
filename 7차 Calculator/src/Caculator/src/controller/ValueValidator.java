package controller;

public class ValueValidator
{
    public boolean isContainPoint(String currentValue)
    {
        if(currentValue.contains("."))
        {
            return true;
        }
        return false;
    }
    public String isEndedPoint(String currentValue)
    {
        String lastString = currentValue.substring(currentValue.length() - 2, currentValue.length());
        if(lastString.equals(".0"))
        {
            currentValue = currentValue.substring(0, currentValue.length() - 1);
        }
        return currentValue;
    }
}
