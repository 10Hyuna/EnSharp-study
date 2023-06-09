package view;

import main.Main;

import javax.swing.*;
import java.awt.*;

public class IdSearchFrame extends JFrame{
    private Image image;
    private Image background = new ImageIcon(Main.class.getResource("../image/search_id_page.png")).getImage();
    private ImageIcon searchButtonImage = new ImageIcon(Main.class.getResource("../image/search_button.png"));
    private JButton searchButton;
    private JTextField name;
    private JTextField phone;

    public IdSearchFrame(){
        searchButton = TotalComponent.getTotalComponent().getSearch();
        name = TotalComponent.getTotalComponent().getNameSearch();
        phone = TotalComponent.getTotalComponent().getPhoneSearch();

        setTitle("아이디 찾기");
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
        searchButton.setBounds(1050, 100, 150, 40);
        image = searchButtonImage.getImage();
        image = image.getScaledInstance(150, 40, Image.SCALE_SMOOTH);
        searchButtonImage = new ImageIcon(image);
        searchButton.setBorder(null);
        searchButton.setFocusPainted(false);
        searchButton.setContentAreaFilled(false);
        searchButton.setFocusable(false);
        searchButton.setBorderPainted(false);
        searchButton.setIcon(searchButtonImage);
        searchButton.setSize(searchButtonImage.getIconWidth(), searchButtonImage.getIconHeight());

        add(name);
        name.setBorder(null);
        name.setBounds(500, 40, 300, 40);

        add(phone);
        phone.setBorder(null);
        phone.setBounds(500, 170, 300, 40);
    }
    public void paint(Graphics g)
    {
        g.drawImage(background, 0, 0, null);
    }
}
