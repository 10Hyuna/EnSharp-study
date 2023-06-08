package controller.ActionListener;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Button implements ActionListener {
    @Override
    public void actionPerformed(ActionEvent e) {
        String command = e.getActionCommand();
    }
}
