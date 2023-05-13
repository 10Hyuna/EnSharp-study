package Controller;

import Model.AccessorData;
import Model.LogVO;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
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

        LocalDateTime time = LocalDateTime.now();
        String timeNow = time.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));

        LogVO log = new LogVO("로그", timeNow);

        accessorData.InsertData(log);
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
                    LocalDateTime time = LocalDateTime.now();
                    String timeNow = time.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));

                    LogVO log = new LogVO("로그 삭제", timeNow);
                    accessorData.InsertData(log);
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
                    dispose();
                }
            }
        });
        jButtonPanel.add(delete);
        jButtonPanel.add(exit);
        add(jButtonPanel);

        List<LogVO> logs;
        logs = accessorData.SelectLog();
        logLabel = new JLabel[logs.size()];
        logPanel = new JPanel[logs.size()];

        for(int i = 0; i < logs.size(); i++)
        {
            logLabel[i] = new JLabel();
            logPanel[i] = new JPanel();
            logLabel[i].setText(String.format("%s %s", logs.get(i).GetSearchWord(), logs.get(i).GetSearchTime()));
            logPanel[i].add(logLabel[i]);
            add(logPanel[i]);
        }

        setVisible(true);
    }
}
