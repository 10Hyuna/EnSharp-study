package controller;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class MyActionListener implements ActionListener
{
    private Calculate calculate;

    public MyActionListener()
    {
        calculate = new Calculate();
    }
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
        if()
    }
}