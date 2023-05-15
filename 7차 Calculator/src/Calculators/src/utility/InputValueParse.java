package utility;

import model.VO.LogVO;

import model.DAO.AccessorData;

public class InputValueParse {

    public void parseInput(String currentInputs, String recentInputs, String operator)
    {
        int result = calculateValue(currentInputs, recentInputs, operator);
        LogVO log = new LogVO(Integer.parseInt(recentInputs), Integer.parseInt(currentInputs), operator, result);
        AccessorData.GetAccessorData().InsertLog(log);
    }
    public int calculateValue(String currentInputs, String recentInputs, String operator)
    {
        int result = 0;

        switch(operator)
        {
            case "+":
                result = Integer.parseInt(recentInputs) + Integer.parseInt(currentInputs);
                break;
            case "-":
                result = Integer.parseInt(recentInputs) - Integer.parseInt(currentInputs);
                break;
            case "×":
                result = Integer.parseInt(recentInputs) * Integer.parseInt(currentInputs);
                break;
            case "÷":
                result = Integer.parseInt(recentInputs) / Integer.parseInt(currentInputs);
                break;
        }
        return result;
    }
}
