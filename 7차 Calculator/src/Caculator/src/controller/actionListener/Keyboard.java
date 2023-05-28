package controller.actionListener;

import controller.ValueUpdater;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Keyboard implements KeyListener
{
    private ValueUpdater valueUpdater;
    public Keyboard(ValueUpdater valueUpdater)
    {
        this.valueUpdater = valueUpdater;
    }

    @Override
    public void keyTyped(KeyEvent e) {

    }

    @Override
    public void keyPressed(KeyEvent e) {
        int keyCode = e.getKeyCode();
        String command;
        switch (keyCode)
        {
            case KeyEvent.VK_0: case KeyEvent.VK_1: case KeyEvent.VK_2:
            case KeyEvent.VK_3: case KeyEvent.VK_4: case KeyEvent.VK_5:
            case KeyEvent.VK_6: case KeyEvent.VK_7: case KeyEvent.VK_9:
                command = String.valueOf(keyCode - 48);
                valueUpdater.processInputtedNumber(command);
                break;
            case KeyEvent.VK_BACK_SPACE:
                valueUpdater.processInputtedDeleter();
                break;
            case KeyEvent.VK_DIVIDE:
                valueUpdater.processInputtedOperator("÷");
                break;
            case KeyEvent.VK_EQUALS:
                if(e.isShiftDown())
                {
                    valueUpdater.processInputtedOperator("+");
                }
                else
                {
                    valueUpdater.processInputtedEqual();
                }
                break;
            case KeyEvent.VK_MINUS:
                valueUpdater.processInputtedOperator("-");
                break;
            case KeyEvent.VK_8:
                if(e.isShiftDown())
                {
                    valueUpdater.processInputtedOperator("×");
                }
                else
                {
                    command = String.valueOf(keyCode - 48);
                    valueUpdater.processInputtedNumber(command);
                }
                break;
            case KeyEvent.VK_PERIOD:
                valueUpdater.processInputtedPoint();
                break;
            case KeyEvent.VK_F8:
                valueUpdater.processInputtedNegate();
                break;
            case KeyEvent.VK_ENTER:
                valueUpdater.processInputtedEqual();
                break;
            case KeyEvent.VK_DELETE:
                valueUpdater.processInputtedCE();
                break;
            case KeyEvent.VK_ESCAPE:
                valueUpdater.processInputtedC();
                break;
        }
    }

    @Override
    public void keyReleased(KeyEvent e) {

    }
}
