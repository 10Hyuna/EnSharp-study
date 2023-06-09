package view;

import main.Main;
import utility.MusicPlayer;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.*;

public class LoginFrame extends JFrame {
    private Image image;
    private Image background = new ImageIcon(Main.class.getResource("../image/mainFrame.png")).getImage();
    // 배경 이미지
    private ImageIcon loginButton = new ImageIcon(Main.class.getResource("../image/Login2.png"));
    private ImageIcon searcherIdImage = new ImageIcon(Main.class.getResource("../image/SearcherId.png"));
    private ImageIcon searcherPwButton = new ImageIcon(Main.class.getResource("../image/SearcherPw.png"));
    private ImageIcon signUpButton = new ImageIcon(Main.class.getResource("../image/SignUp.png"));
    private MusicPlayer musicPlayer;
    private JTextField idInput = TotalComponent.getTotalComponent().getIdInput();
    private JPasswordField pwInput = TotalComponent.getTotalComponent().getPwInput();
    private JButton login = TotalComponent.getTotalComponent().getLoginButton();
    private JButton searcherId = TotalComponent.getTotalComponent().getSearcherIdButton();
    private JButton searcherPw = TotalComponent.getTotalComponent().getSearcherPwButton();
    private JButton signUp = TotalComponent.getTotalComponent().getSignUpButton();
    public LoginFrame(){
        setTitle("로그인 창");
        setSize(960, 480);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setFrame();
    }
    public void setFrame()
    {
        musicPlayer = new MusicPlayer();
        musicPlayer.start();

        add(idInput);
        idInput.setBorder(null);
        idInput.setBounds(640, 287, 150, 23);

        add(pwInput);
        pwInput.setBorder(null);
        pwInput.setBounds(640, 323, 150, 23);

        add(login);
        login.setText("");
        login.setBounds(800, 285, 50, 25);
        image = loginButton.getImage();
        image = image.getScaledInstance(50, 25, Image.SCALE_SMOOTH);
        loginButton = new ImageIcon(image);
        login.setFocusable(false);
        login.setContentAreaFilled(false);
        login.setFocusPainted(false);
        login.setBorderPainted(false);
        login.setIcon(loginButton);
        login.setSize(loginButton.getIconWidth(), loginButton.getIconHeight());

        add(searcherId);
        searcherId.setBounds(640, 350, 50, 25);
        image = searcherIdImage.getImage();
        image = image.getScaledInstance(50, 25, Image.SCALE_AREA_AVERAGING);
        searcherIdImage = new ImageIcon(image);
        searcherId.setIcon(searcherIdImage);
        searcherId.setContentAreaFilled(false);
        searcherId.setFocusPainted(false);
        searcherId.setBorderPainted(false);
        searcherId.setFocusable(false);
        searcherId.setSize(searcherIdImage.getIconWidth(), searcherIdImage.getIconHeight());
        searcherId.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                new IdSearchFrame();
            }
        });

        add(searcherPw);
        searcherPw.setBounds(720, 350, 50, 25);
        image = searcherPwButton.getImage();
        image = image.getScaledInstance(50, 25, Image.SCALE_SMOOTH);
        searcherPwButton = new ImageIcon(image);
        searcherPw.setIcon(searcherPwButton);
        searcherPw.setContentAreaFilled(false);
        searcherPw.setFocusPainted(false);
        searcherPw.setBorderPainted(false);
        searcherPw.setFocusable(false);
        searcherPw.setSize(searcherPwButton.getIconWidth(), searcherPwButton.getIconHeight());
        searcherPw.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                new PwSearchFrame();
            }
        });

        add(signUp);
        signUp.setBounds(800, 350, 50, 20);
        image = signUpButton.getImage();
        image = image.getScaledInstance(50, 25, Image.SCALE_SMOOTH);
        signUpButton = new ImageIcon(image);
        signUp.setIcon(signUpButton);
        signUp.setContentAreaFilled(false);
        signUp.setFocusPainted(false);
        signUp.setBorderPainted(false);
        signUp.setFocusable(false);
        signUp.setSize(signUpButton.getIconWidth(), signUpButton.getIconHeight());
        signUp.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                new SignUpFrame();
            }
        });
    }

    public void paint(Graphics g)
    {
        g.drawImage(background, 0, 0, null);
    }
}
