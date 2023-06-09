package model.VO;

public class UserInformation {
    private String id;
    private String pw;
    private String name;
    private String birstDate;
    private String email;
    private String phoneNumber;
    private String address;
    private String zipCode;
    public UserInformation(String id, String name, String phoneNumber){
        this.id = id;
        this.name = name;
        this.phoneNumber = phoneNumber;
    }
    public UserInformation(String name, String phoneNumber){
        this.name = name;
        this.phoneNumber = phoneNumber;
    }
    public UserInformation(String id, String pw, String name, String birthDate,
                           String email, String phoneNumebr, String address, String zipCode)
    {
        this.id = id;
        this.pw = pw;
        this.name = name;
        this.birstDate = birthDate;
        this.email = email;
        this.phoneNumber = phoneNumebr;
        this.address = address;
        this.zipCode = zipCode;
    }

    public String getId(){
        return id;
    }
    public String getPw() {
        return pw;
    }
    public String getName(){
        return name;
    }
    public String getBirstDate(){
        return birstDate;
    }
    public String getEmail(){
        return email;
    }
    public String getPhoneNumber(){
        return phoneNumber;
    }
    public String getAddress(){
        return address;
    }
    public String getZipCode(){
        return zipCode;
    }
}
