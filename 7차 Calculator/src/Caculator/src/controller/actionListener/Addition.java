package controller.actionListener;

import controller.ValueUpdater;
import model.TotalStorage;
import view.MainView;
import view.TotalComponent;

import javax.swing.*;

public class Addition {
    private JButton[] calculatorButton;
    private JButton logButton;
    private Button button;
    private MainView mainView;
    private Component component;
    private Keyboard keyboard;
    private TotalStorage totalStorage;
    private ValueUpdater valueUpdater;
    public Addition(MainView mainview)
    {
        calculatorButton = TotalComponent.getTotalComponent().getCalculatorButton();
        logButton = TotalComponent.getTotalComponent().getLogButton();

        this.mainView = mainview;

        totalStorage = new TotalStorage();
        valueUpdater = new ValueUpdater(totalStorage);
        button = new Button(valueUpdater, totalStorage, mainView);
        keyboard = new Keyboard(valueUpdater);
        component = new Component(mainview);
    }
    public void addActionListener()
    {
        for (int i = 0; i < calculatorButton.length; i++)
        {
            calculatorButton[i].addActionListener(button);
        }
        mainView.addKeyListener(keyboard);
        mainView.addComponentListener(component);
        logButton.addActionListener(button);
    }
    public void sendComponent()
    {

    }
}
