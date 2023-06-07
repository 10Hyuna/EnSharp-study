package view;

import javax.swing.*;

public class TotalComponent {
    JButton loginButton;
    JButton signUpButton;
    JButton searcherIdButton;
    JButton searcherPwButton;
    JTextField IdInput;
    JPasswordField PwInput;
    private static TotalComponent totalComponent;
    private TotalComponent(){
        loginButton = new JButton();
        signUpButton = new JButton();
        searcherIdButton = new JButton();
        searcherPwButton = new JButton();
        IdInput = new JTextField();
        PwInput = new JPasswordField();
    }
    public static TotalComponent getTotalComponent(){
        if(totalComponent == null){
            totalComponent = new TotalComponent();
        }
        return totalComponent;
    }

}
