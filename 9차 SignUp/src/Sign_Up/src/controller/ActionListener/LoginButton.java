package controller.ActionListener;

import controller.Validation;
import model.VO.UserInformation;
import view.TotalComponent;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class LoginButton implements ActionListener {
    private Validation validation;
    private JTextField id;
    private JTextField pw;
    private UserInformation userInformation;
    public LoginButton(){
        id = TotalComponent.getTotalComponent().getIdInput();
        pw = TotalComponent.getTotalComponent().getPwInput();
        validation = new Validation();
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        String idString = id.getText();
        String pwString = pw.getText();
        userInformation = new UserInformation(idString, pwString);
        validation.validateLogin(userInformation);
    }
}
