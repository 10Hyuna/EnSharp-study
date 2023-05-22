package controller;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class MyKeyActionListener implements KeyListener{
    private boolean isKeyPressed;
    @Override
    public void keyTyped(KeyEvent e) {

    }

    public void keyPressed(KeyEvent e)
    {
        int command = e.getKeyCode();
        if(!isKeyPressed)
        {
            isKeyPressed = true;
            Timer timer = new Timer(100, new ActionListener() {
                @Override
                public void actionPerformed(ActionEvent e) {

                }
            });
        }
        isKeyPressed = true;

    }
    public void keyReleased(KeyEvent e)
    {
        isKeyPressed = false;

    }
    public void ActivateKeyAction(String command)
    {

    }
}
