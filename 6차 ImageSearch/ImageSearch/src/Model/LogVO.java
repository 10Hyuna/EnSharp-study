package Model;

public class LogVO {
    private String searchWord;
    private String searchTime;

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
