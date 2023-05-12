package Controller;

import Model.AccessorData;
import Model.LogVO;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;

public class LogCheck extends JFrame {
    private AccessorData accessorData;
    public LogCheck(AccessorData accessorData)
    {
        this.accessorData = accessorData;
    }
    JPanel jButtonPanel;
    JPanel[] logPanel;
    JLabel[] logLabel;
    JButton delete;
    JButton exit;
    public void CheckLog()
    {
        setSize(500, 500);
        setTitle("imageSearch");
        setResizable(false);
        setLocationRelativeTo(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        setLayout(new FlowLayout());

        List<LogVO> logs;
        logs = accessorData.SelectLog();
        logLabel = new JLabel[logs.size()];
        logPanel = new JPanel[logs.size()];

        for(int i = 0; i < logs.size(); i++)
        {
            logLabel[i].setText(logs.get(i).toString());
            logPanel[i].add(logLabel[i]);
            add(logPanel[i]);
        }

        jButtonPanel = new JPanel();
        delete = new JButton("Delete Log");
        delete.setActionCommand("delete");
        delete.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if(command.equals("delete"))
                {
                    accessorData.DeleteData();
                }
            }
        });

        exit = new JButton("Exit");
        exit.setActionCommand("exit");
        exit.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                String command = e.getActionCommand();

                if (command.equals("exit"))
                {
                    return;
                }
            }
        });
        jButtonPanel.add(delete);
        jButtonPanel.add(exit);
        add(jButtonPanel);

    }
}
