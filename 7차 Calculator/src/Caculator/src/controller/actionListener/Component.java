package controller.actionListener;
import view.MainView;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;

public class Component extends ComponentAdapter {
    private MainView mainview;
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
            mainview.setContainLog();
        }
        else if(main.getWidth() < dimension.getWidth()
            || main.getHeight() < dimension.getHeight())
        {
            mainview.setFrame();
        }
    }
}
