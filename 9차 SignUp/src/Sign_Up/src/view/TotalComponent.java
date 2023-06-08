package view;

import com.toedter.calendar.JCalendar;
import net.sourceforge.jdatepicker.impl.JDatePanelImpl;
import net.sourceforge.jdatepicker.impl.JDatePickerImpl;
import net.sourceforge.jdatepicker.impl.UtilDateModel;

import javax.swing.*;
import javax.swing.JFrame;
import javax.swing.JSpinner;
import javax.swing.SpinnerDateModel;

import java.awt.BorderLayout;
import java.util.Calendar;
public class TotalComponent {
    private JButton loginButton;
    private JButton signUpButton;
    private JButton searcherIdButton;
    private JButton searcherPwButton;
    private JTextField IdInput;
    private JPasswordField PwInput;
    private JButton successSignUp;
    private JButton searcherAddress;
    private JTextField id;
    private JPasswordField pw;
    private JPasswordField pwCheck;
    private JTextField name;
    private UtilDateModel model = new UtilDateModel();
    private JDatePanelImpl datePanel = new JDatePanelImpl(model);
    private JDatePickerImpl datePicker;
    private JCalendar calendar;
    private JTextField email;
    private JTextField number;
    private JTextField address;
    private JTextField zipCode;
    private static TotalComponent totalComponent;
    private TotalComponent(){
        loginButton = new JButton();
        signUpButton = new JButton();
        searcherIdButton = new JButton();
        searcherPwButton = new JButton();
        IdInput = new JTextField();
        PwInput = new JPasswordField();

        successSignUp = new JButton();
        searcherAddress = new JButton();
        id = new JTextField();
        pw = new JPasswordField();
        pwCheck = new JPasswordField();
        name = new JTextField();
        datePicker = new JDatePickerImpl(datePanel);
        calendar = new JCalendar();
        email = new JTextField();
        number = new JTextField();
        address = new JTextField();
        zipCode = new JTextField();
    }

    public static TotalComponent getTotalComponent(){
        if(totalComponent == null){
            totalComponent = new TotalComponent();
        }
        return totalComponent;
    }

    public JButton getLoginButton() {
        return loginButton;
    }

    public JButton getSearcherIdButton() {
        return searcherIdButton;
    }

    public JButton getSignUpButton(){
        return signUpButton;
    }

    public JButton getSearcherPwButton(){
        return searcherPwButton;
    }

    public JTextField getIdInput(){
        return IdInput;
    }

    public JPasswordField getPwInput() {
        return PwInput;
    }

    public JButton getSearcherAddress() {
        return searcherAddress;
    }

    public JButton getSuccessSignUp() {
        return successSignUp;
    }

    public JTextField getAddress() {
        return address;
    }

    public JTextField getEmail() {
        return email;
    }

    public JTextField getId() {
        return id;
    }

    public JTextField getName() {
        return name;
    }

    public JPasswordField getPw() {
        return pw;
    }

    public JTextField getNumber() {
        return number;
    }

    public JDatePickerImpl getDatePicker(){
        return datePicker;
    }

    public JPasswordField getPwCheck() {
        return pwCheck;
    }

    public JTextField getZipCode() {
        return zipCode;
    }
}
