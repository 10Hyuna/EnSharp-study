package controller;

import view.MainView;

public class ModificationCalculator {
    private MainView mainView;
    public ModificationCalculator()
    {
        mainView = new MainView();
    }
    public void ModifyCalculator()
    {
        mainView.SetFrame();
    }
}
