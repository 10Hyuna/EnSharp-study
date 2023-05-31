package utility;

public enum ERROR {
    NON_EXISTENCE_COMMAND(0);
    private final int number;
    ERROR(int number)
    {
        this.number = number;
    }
    public int getNumber() {return number;}
}
