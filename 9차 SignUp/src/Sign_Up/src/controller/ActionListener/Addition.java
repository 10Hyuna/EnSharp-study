package controller.ActionListener;

import view.TotalComponent;

import javax.swing.*;

public class Addition {
    private JButton loginButton;
    private JButton searcherIdButton;
    private JButton searcherPwButton;
    private JButton signUpButton;
    private Button button;
    public Addition(){
        button = new Button();
        loginButton = TotalComponent.getTotalComponent().getLoginButton();
        searcherIdButton = TotalComponent.getTotalComponent().getSearcherIdButton();
        searcherPwButton = TotalComponent.getTotalComponent().getSearcherPwButton();
        signUpButton = TotalComponent.getTotalComponent().getSignUpButton();
    }
    public void addActionListener(){
        loginButton.addActionListener(button);
        searcherIdButton.addActionListener(button);
        searcherPwButton.addActionListener(button);
        signUpButton.addActionListener(button);
    }
}
