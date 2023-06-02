package utility;

public class Padding {
    public String padRigth(String messege, int n)
    {
        return String.format("%-" + n + "s", messege);
    }
    public String padLeft(String messege, int n)
    {
        return String.format("%" + n + "s", messege);
    }
    public int CalculateRadRightSize(String message, int count)
    {   // 문자가 한글에 해당하는지 확인하고, 한글이 몇 개 나오는지 확인 후,
        // 맞추려는 PadRight 개수 빼기 한글의 개수만큼 공백으로 채우는 계산
        int koreanCount = 0;
        String korean;

        for (int i = 0; i < message.length(); i++)
        {
            korean = String.valueOf(message.charAt(i));
            if(IsCheckException(korean, Constant.KOREAN))
            {
                koreanCount++;
            }
        }
        return (count - koreanCount);
    }
    public boolean IsCheckException(String message, String regex)
    // 정규식으로 문자열이 주어진 조건에 해당하는지 확인
    {
        if (message.matches(regex))
        {
            return true;
        }
        return false;
    }
}
