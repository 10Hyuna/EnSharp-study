package view;

import model.VO.CaculateResultVO;

import javax.swing.*;
import java.awt.*;
import java.util.List;

public class Record extends JPanel{
    private JButton recordButton;
    private JLabel standard;
    private JButton[] recordButtons;
    public JPanel getRecordButtonPanel()
    {
        removeAll();

        standard = getStandard();

        recordButton = TotalComponent.getTotalComponent().getLogButton();
        recordButton.setText("⟲");

        setLayout(new BorderLayout());
        add(standard, BorderLayout.WEST);
        add(recordButton, BorderLayout.EAST);

        return this;
    }

    public JPanel getRecordPanel()
    {

        return this;
    }
    public JPanel getRecords(List<CaculateResultVO> resultVO)
    {
        JLabel calculator;
        JLabel result;
        JPanel recordsPanel = new JPanel();
        recordsPanel.setLayout(new BoxLayout(recordsPanel, BoxLayout.Y_AXIS));
        JScrollPane scrollPane = new JScrollPane(recordsPanel);
        scrollPane.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);

        recordButtons = new JButton[resultVO.size()];

        for (int i = 0; i < resultVO.size(); i++)
        {
            calculator = new JLabel(String.format("%s %s %s", resultVO.get(i).getFirstInput(), resultVO.get(i).getOperator(), resultVO.get(i).getLastInput()));
            calculator.setFont(new Font("맑은 고딕", Font.PLAIN, 15));
            result = new JLabel(String.format("%s", resultVO.get(i).getResult()));
            result.setFont(new Font("맑은 고딕", Font.BOLD, 30));
            recordButtons[i] = new JButton();
            recordButtons[i].setText(String.format("%s\n%s", calculator.getText(), result.getText()));
        }
        return recordsPanel;
    }
    public JLabel getStandard()
    {
        standard = new JLabel("표준", JLabel.LEFT);

        return standard;
    }
}
