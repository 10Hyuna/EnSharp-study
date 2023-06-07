package view;

import main.Main;

import java.awt.Graphics;
import java.awt.Image;
import javax.swing.ImageIcon;
import javax.swing.JFrame;

public class LoginFrame extends JFrame {
    private Image background = new ImageIcon(Main.class.getResource("../image/mainFrame.png")).getImage();
    // 배경 이미지
    public LoginFrame(){
        setFrame();
    }
    public void setFrame()
    {
        setTitle("로그인 창");
        setSize(960, 480);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
    }
    public void paint(Graphics g)
    {
        g.drawImage(background, 0, 0, null);
    }
}
