package utility;

import model.VO.LogVO;

import model.DAO.AccessorData;

public class InputValueParse {

    public void parseInput(String currentInputs, String recentInputs)
    {
        String operator = recentInputs.substring(recentInputs.length() - 1, recentInputs.length());
        String recentInput = recentInputs.substring(0, recentInputs.length() - 1);
        int result;
        if(operator.equals("+"))
        {
            result = Integer.parseInt(recentInput) + Integer.parseInt(currentInputs);
        }
        else if(operator.equals("-"))
        {
            result = Integer.parseInt(recentInput) - Integer.parseInt(currentInputs);
        }
        else if(operator.equals("×"))
        {
            result = Integer.parseInt(recentInput) * Integer.parseInt(currentInputs);
        }
        else
        {
            result = Integer.parseInt(recentInput) / Integer.parseInt(currentInputs);
        }
        LogVO log = new LogVO(Integer.parseInt(recentInput), Integer.parseInt(currentInputs), operator, result);
        AccessorData.GetAccessorData().InsertLog(log);
    }
}
