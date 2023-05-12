package Model;

public class LogVO {
    private String searchWord;
    private String searchTime;

    public LogVO(String searchWord, String searchTime)
    {
        this.searchWord = searchWord;
        this.searchTime = searchTime;
    }
    public LogVO()
    {

    }

   public String GetSearchWord()
   {
       return searchWord;
   }
   public String GetSearchTime()
   {
       return searchTime;
   }
   public void SetSearchWord(String value)
   {
       this.searchWord = value;
   }
   public void SetSearchTime(String value)
   {
       this.searchTime = value;
   }
}
