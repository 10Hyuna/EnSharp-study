package view;

import main.Main;

import javax.swing.*;
import java.awt.*;

public class PwSearchFrame extends JFrame{
    private Image image;
    private Image background = new ImageIcon(Main.class.getResource("../image/search_pw_page.png")).getImage();
    private JButton searchButton;
    private JTextField name;
    private JTextField phone;
    private JTextField id;
    public PwSearchFrame(){
        searchButton = new JButton(new ImageIcon(Main.class.getResource("../image/search_button.png")));

        name = new JTextField();
        phone = new JTextField();
        id = new JTextField();

        setTitle("비밀번호 찾기");
        setSize(1276, 710);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        setFrame();
    }
    public void setFrame(){
        add(searchButton);
        searchButton.setBounds(1050, 70, 180, 40);
        searchButton.setFocusPainted(false);
        searchButton.setContentAreaFilled(false);
        searchButton.setFocusable(false);
        searchButton.setBorderPainted(false);
        searchButton.setOpaque(false);

        add(name);
        name.setBorder(null);
        name.setBounds(500, 40, 300, 40);

        add(phone);
        phone.setBorder(null);
        phone.setBounds(500, 170, 300, 40);

        add(id);
        id.setBorder(null);
        id.setBounds(500, 350, 300, 40);
    }
    public void paint(Graphics g) {
        g.drawImage(background, 0, 0, null);
    }
}
