package controller.ActionListener;

import controller.Validation;
import model.VO.UserInformation;
import view.TotalComponent;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class pwSearchButton implements ActionListener {
    private Validation validation;
    private JTextField name;
    private JTextField phonenumber;
    private JTextField id;
    private UserInformation userInformation;
    public pwSearchButton(){
        name = TotalComponent.getTotalComponent().getNameSearch();
        phonenumber = TotalComponent.getTotalComponent().getPhoneSearch();
        id = TotalComponent.getTotalComponent().getIdSearch();
        validation = new Validation();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String idString = id.getText();
        String nameString = name.getText();
        String phoneString = phonenumber.getText();
        userInformation = new UserInformation(idString, nameString, phoneString);
        validation.validatePw(userInformation);
    }
}
