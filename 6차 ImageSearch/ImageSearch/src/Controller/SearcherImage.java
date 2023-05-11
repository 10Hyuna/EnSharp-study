package Controller;

import Model.DataParse;

import java.awt.*;
import javax.swing.*;
import java.awt.image.BufferedImage;
import java.io.IOException;
import javax.swing.JButton;
import javax.swing.JFrame;

public class SearcherImage {
    private DataParse dataParse;
    public SearcherImage()
    {
        dataParse = new DataParse();
    }
    JButton[] image;
    JPanel jPanel;

    public void SearchImage(String searchingKeyword, String size) throws IOException {

        int sizeNumber = Integer.parseInt(size);
        BufferedImage[] searchedImage = new BufferedImage[sizeNumber];
        searchedImage = dataParse.ParseURL(searchingKeyword, sizeNumber);

        jPanel = new JPanel();
        image = new JButton[sizeNumber];

        for(int i = 0; i < sizeNumber; i++)
        {
            image[i] = new JButton(new ImageIcon(searchedImage[i]));
            image[i].setBorderPainted(false);
            image[i].setContentAreaFilled(false);
            image[i].setFocusPainted(false);
            jPanel.add(image[i]);
        }
        jPanel.setVisible(true);
    }
}
