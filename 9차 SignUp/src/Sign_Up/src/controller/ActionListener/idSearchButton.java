package controller.ActionListener;

import controller.ValidationId;
import model.VO.UserInformation;
import view.TotalComponent;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class idSearchButton implements ActionListener {
    private ValidationId validationId;
    private JTextField name;
    private JTextField phonenumber;
    private UserInformation userInformation;
    public idSearchButton(){
        validationId = new ValidationId();
        name = TotalComponent.getTotalComponent().getName();
        phonenumber = TotalComponent.getTotalComponent().getNumber();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String nameString = name.getText();
        String phoneString = phonenumber.getText();
        userInformation = new UserInformation(nameString, phoneString);
        validationId.validateId(userInformation);
    }
}
