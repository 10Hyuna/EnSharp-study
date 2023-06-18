package view;

import main.Main;

import javax.swing.*;
import java.awt.*;

public class SearcherResult extends JFrame{
    private Image background = new ImageIcon(Main.class.getResource("../image/search_result_panel.png")).getImage();
    private JLabel announceMention;
    public SearcherResult(){
        announceMention = new JLabel();

        setTitle("정보 찾기");
        setSize(436, 380);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
    }

    public void setIdFrame(String announce){
        add(announceMention);
        announceMention.setText(announce);
        announceMention.setBounds(160, 175, 180, 40);
        announceMention.setOpaque(true);
        announceMention.setBackground(new Color(189, 155, 210));
    }

    public void setPwFrame(String announce){
        add(announceMention);
        announceMention.setText(announce);
        announceMention.setBounds(160, 175, 180, 40);
        announceMention.setOpaque(true);
        announceMention.setBackground(new Color(189, 155, 210));
    }
    public void paint(Graphics g){
        g.drawImage(background, 0, 0, null);
    }
}