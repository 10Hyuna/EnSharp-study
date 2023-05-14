package view;

import javax.swing.*;

public class ManagementInput {
    private JLabel input;
    private JLabel endInput;
    private JLabel operator;
    private JLabel recentInput;
    private static ManagementInput managementInput;
    private ManagementInput()
    {
        input = new JLabel();
        endInput = new JLabel();
        operator = new JLabel();
        recentInput = new JLabel();
    }
    public static ManagementInput GetManagementInput()
    {
        if(managementInput == null)
        {
            managementInput = new ManagementInput();
        }
        return managementInput;
    }
    public JLabel GetInput()
    {
        return input;
    }
    public JLabel GetEndInput()
    {
        return endInput;
    }
    public JLabel GetOperator()
    {
        return operator;
    }
    public JLabel GetRecentInput()
    {
        return recentInput;
    }
}
