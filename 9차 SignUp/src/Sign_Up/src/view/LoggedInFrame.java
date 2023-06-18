package view;

import main.Main;

import javax.swing.*;
import java.awt.*;

public class LoggedInFrame extends JFrame{
    private JLabel label;
    public LoggedInFrame(){
        setTitle("로그인 성공");
        setSize(300, 300);
        setResizable(false);
        setLocationRelativeTo(null);
        setLayout(null);
        setVisible(true);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        label = new JLabel("로그인 성공!");
        label.setBounds(115, 120, 180, 40);
        add(label);
    }
}
