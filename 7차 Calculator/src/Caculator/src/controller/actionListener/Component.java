package controller.actionListener;
import view.MainView;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

public class Component extends ComponentAdapter {
    private MainView mainview;
    private int status = 0;
    public Component(MainView mainView)
    {
        this.mainview = mainView;
    }
    @Override
    public void componentResized(ComponentEvent e) {
        JFrame main = (JFrame)e.getSource();

        Dimension dimension = new Dimension(600, 900);

        if(main.getWidth() > dimension.getWidth()
            || main.getHeight() > dimension.getHeight())
        {
            if(status == 1)
            {
                return;
            }
            status = 1;
            main.getContentPane().removeAll();
            mainview.setContainLog();
            main.getContentPane().revalidate();
            main.getContentPane().repaint();
        }
        else if(main.getWidth() < dimension.getWidth()
            || main.getHeight() < dimension.getHeight())
        {
            if(status == 0)
            {
                return;
            }
            status = 0;
            main.getContentPane().removeAll();
            mainview.setFrame();
            main.getContentPane().revalidate();
            main.getContentPane().repaint();
        }
    }
}
