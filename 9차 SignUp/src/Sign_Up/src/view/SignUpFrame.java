package view;

import main.Main;
import net.sourceforge.jdatepicker.impl.JDatePickerImpl;

import javax.swing.*;
import java.awt.*;

public class SignUpFrame extends JFrame{
    private Image image;
    private Image background = new ImageIcon(Main.class.getResource("../image/sign_up_page.png")).getImage();
    private ImageIcon signUpImage = new ImageIcon(Main.class.getResource("../image/sign_up_success.png"));
    private ImageIcon searcherAddress = new ImageIcon(Main.class.getResource("../image/searcher_address.png"));
    private JButton signUpButton;
    private JButton addressButton;
    private JTextField id;
    private JPasswordField pw;
    private JPasswordField pwCheck;
    private JTextField name;
    private JDatePickerImpl birthDate;
    private JTextField email;
    private JTextField phoneNumber;
    private JTextField address;
    private JTextField zipCode;
//    private signUp sign;
    public SignUpFrame(){
        signUpButton = TotalComponent.getTotalComponent().getSuccessSignUp();
        addressButton = TotalComponent.getTotalComponent().getSearcherAddress();
        id = TotalComponent.getTotalComponent().getId();
        pw = TotalComponent.getTotalComponent().getPw();
        pwCheck = TotalComponent.getTotalComponent().getPwCheck();
        name = TotalComponent.getTotalComponent().getName();
        birthDate = TotalComponent.getTotalComponent().getDatePicker();
        email = TotalComponent.getTotalComponent().getEmail();
        phoneNumber = TotalComponent.getTotalComponent().getNumber();
        address = TotalComponent.getTotalComponent().getAddress();
        zipCode = TotalComponent.getTotalComponent().getZipCode();

//        sign = new signUp();

        setTitle("회원 가입 창");
        setSize(1276, 710);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        setFrame();
    }

    public void setFrame(){
        add(signUpButton);
        signUpButton.setBounds(1050, 580, 200, 80);
        image = signUpImage.getImage();
        image = image.getScaledInstance(200, 80, Image.SCALE_SMOOTH);
        signUpImage = new ImageIcon(image);
        signUpButton.setBorder(null);
        signUpButton.setFocusable(false);
        signUpButton.setContentAreaFilled(false);
        signUpButton.setFocusPainted(false);
        signUpButton.setBorderPainted(false);
        signUpButton.setIcon(signUpImage);
        signUpButton.setSize(signUpImage.getIconWidth(), signUpImage.getIconHeight());
//        signUpButton.addActionListener(sign);

        add(addressButton);
        addressButton.setBounds(570, 520, 100, 40);
        image = searcherAddress.getImage();
        image = image.getScaledInstance(100, 40, Image.SCALE_SMOOTH);
        searcherAddress = new ImageIcon(image);
        address.setBorder(null);
        addressButton.setFocusable(false);
        addressButton.setContentAreaFilled(false);
        addressButton.setFocusPainted(false);
        addressButton.setBorderPainted(false);
        addressButton.setIcon(searcherAddress);
        addressButton.setSize(searcherAddress.getIconWidth(), searcherAddress.getIconHeight());

        add(id);
        id.setBounds(180, 22, 300, 40);
        id.setBorder(null);

        add(pw);
        pw.setBounds(180, 90, 300, 40);
        pw.setBorder(null);

        add(pwCheck);
        pwCheck.setBounds(730, 90, 300, 40);
        pwCheck.setBorder(null);

        add(name);
        name.setBounds(180, 172, 300, 40);
        name.setBorder(null);

        add(birthDate);
        birthDate.setBounds(180, 255, 300, 40);

        add(email);
        email.setBounds(180, 350, 300, 40);
        email.setBorder(null);

        add(phoneNumber);
        phoneNumber.setBounds(180, 440, 300, 40);
        phoneNumber.setBorder(null);

        add(address);
        address.setBounds(180, 520, 300, 40);
        address.setBorder(null);

        add(zipCode);
        zipCode.setBounds(180, 610, 300, 40);
        zipCode.setBorder(null);
    }
//    public void successSignUp(){
//        JFrame jFrame = new JFrame();
//        this.dispose();
//        jFrame.setTitle("회원가입 성공");
//        jFrame.setSize(300, 300);
//        jFrame.setResizable(false);
//        jFrame.setLocationRelativeTo(null);
//        jFrame.setLayout(null);
//        jFrame.setVisible(true);
//        jFrame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
//
//        JLabel label = new JLabel("로그인 성공!");
//        label.setBounds(115, 120, 180, 40);
//        jFrame.add(label);
//    }
    public void paint(Graphics g)
    {
        g.drawImage(background, 0, 0, null);
    }
}
