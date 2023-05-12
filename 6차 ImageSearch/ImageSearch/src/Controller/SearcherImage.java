package Controller;

import Model.DataParse;

import java.awt.*;
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.IOException;
import javax.swing.JButton;
import javax.swing.JFrame;

public class SearcherImage extends JFrame{
    private DataParse dataParse;
    public SearcherImage()
    {
        dataParse = new DataParse();
    }
    JButton[] image;
    JButton exitButton;
    JPanel jPanel;
    JPanel exitPanel;

    public void SearchImage(String searchingKeyword, String size) throws IOException {

        setSize(500, 500);
        setTitle("imageSearch");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        int sizeNumber = Integer.parseInt(size);
        BufferedImage[] searchedImage = new BufferedImage[sizeNumber];
        searchedImage = dataParse.ParseURL(searchingKeyword, sizeNumber);

        jPanel = new JPanel();
        exitPanel = new JPanel();

        image = new JButton[sizeNumber];

        for(int i = 0; i < sizeNumber; i++)
        {
            image[i] = new JButton(new ImageIcon(searchedImage[i]));
            image[i].setBorderPainted(false);
            image[i].setContentAreaFilled(false);
            image[i].setFocusPainted(false);
            jPanel.add(image[i]);
        }
        setVisible(true);
        exitButton = new JButton("EXIT");
        exitButton.setActionCommand("exit");
        exitButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if(command.equals("exit")){
                    setVisible(false);
                    return;
                }
                else {
                    exitButton.setText("exit");
                }
            }
        });

        exitPanel.add(exitButton);
        add(exitPanel);
        add(jPanel);
    }
}
