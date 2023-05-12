package Controller;

import Model.AccessorData;

import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.IOException;

import javax.swing.*;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JTextField;

public class EntryImageSearch extends JFrame {
    JLabel keyword;
    JLabel size;
    JTextField searchingKeyword;
    JTextField searchedResultSize;
    JButton searchingButton;
    JButton logButton;
    JPanel jPanel;
    JPanel logPanel;
    AccessorData accessorData;
    LogCheck logCheck;
    SearcherImage searcherImage;
    public EntryImageSearch()
    {
        accessorData = new AccessorData();
        searcherImage =  new SearcherImage(accessorData);
        logCheck = new LogCheck(accessorData);
    }
    public void EnterMenu() {
        setSize(500, 500);
        setTitle("imageSearch");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setLayout(new FlowLayout());

        keyword = new JLabel("찾을 이미지 키워드");
        size = new JLabel("찾을 이미지 개수");

        searchingKeyword = new JTextField(10);
        searchedResultSize = new JTextField(3);

        searchingButton = new JButton("Search");
        searchingButton.setActionCommand("search");
        searchingButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if(command.equals("search")){
                    try {
                        searcherImage.SearchImage(searchingKeyword.getText(), searchedResultSize.getText());
                    } catch (IOException ex) {
                        throw new RuntimeException(ex);
                    }
                }
            }
        });

        logButton = new JButton("Log");
        logButton.setActionCommand("Log");
        logButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if(command.equals("Log")){
                    logCheck.CheckLog();
                }
            }
        });
        jPanel = new JPanel();
        logPanel = new JPanel();

        jPanel.add(keyword);
        jPanel.add(searchingKeyword);
        jPanel.add(size);
        jPanel.add(searchedResultSize);
        jPanel.add(searchingButton);

        logPanel.add(logButton);
        add(jPanel);
        add(logPanel);

        setVisible(true);
    }
}
