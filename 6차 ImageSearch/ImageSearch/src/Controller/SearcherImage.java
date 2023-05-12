package Controller;

import Model.AccessorData;
import Model.DataParse;
import Model.LogVO;

import java.awt.*;
import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import javax.swing.JButton;
import javax.swing.JFrame;

public class SearcherImage extends JFrame{
    private DataParse dataParse;
    private AccessorData accessorData;

    public SearcherImage(AccessorData accessorData)
    {
        dataParse = new DataParse();
        this.accessorData = accessorData;
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

        LocalDateTime time = LocalDateTime.now();
        String timeNow = time.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));

        int sizeNumber = Integer.parseInt(size);
        BufferedImage[] searchedImage = new BufferedImage[sizeNumber];
        searchedImage = dataParse.ParseURL(searchingKeyword, sizeNumber);

        LogVO log = new LogVO(searchingKeyword, timeNow);
        accessorData.InsertData(log);

        setLayout(new FlowLayout());

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
        exitButton = new JButton("EXIT");
        exitButton.setActionCommand("exit");
        exitButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if(command.equals("exit")){
                    dispose();
                }
            }
        });

        exitPanel.add(exitButton);
        add(exitPanel);
        add(jPanel);
        setVisible(true);
    }
}
