package utility;

import model.VO.LogVO;

import model.DAO.AccessorData;

public class InputValueParse {

    public void parseInput(String currentInputs, String recentInputs)
    {
        String operator = recentInputs.substring(recentInputs.length() - 1, recentInputs.length());
        String recentInput = recentInputs.substring(0, recentInputs.length() - 1);
        int result = calculateValue(currentInputs, recentInput, operator);
        LogVO log = new LogVO(Integer.parseInt(recentInput), Integer.parseInt(currentInputs), operator, result);
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
