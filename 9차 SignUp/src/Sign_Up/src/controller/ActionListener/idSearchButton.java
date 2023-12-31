package controller.ActionListener;

import controller.Validation;
import model.VO.UserInformation;
import view.TotalComponent;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class idSearchButton implements ActionListener {
    private Validation validation;
    private JTextField name;
    private JTextField phonenumber;
    private UserInformation userInformation;
    public idSearchButton(){
        validation = new Validation();
        name = TotalComponent.getTotalComponent().getNameSearch();
        phonenumber = TotalComponent.getTotalComponent().getPhoneSearch();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String nameString = name.getText();
        String phoneString = phonenumber.getText();
        userInformation = new UserInformation(nameString, phoneString);
        validation.validateId(userInformation);
    }
}
