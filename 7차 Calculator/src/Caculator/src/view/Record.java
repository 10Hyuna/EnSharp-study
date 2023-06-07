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
        int cnt = 0;

        JLabel calculator;
        JLabel result;
        JPanel recordsPanel = new JPanel();
        recordsPanel.setLayout(new GridLayout(0, 1));

        recordButtons = new JButton[resultVO.size()];

        for (int i = resultVO.size() - 1; i >= 0; i--)
        {
            if(cnt == 17)
            {
                break;
            }
            cnt++;

            calculator = new JLabel(String.format("%s %s %s", resultVO.get(i).getFirstInput(), resultVO.get(i).getOperator(), resultVO.get(i).getLastInput()));
            result = new JLabel(String.format("%s", resultVO.get(i).getResult()));
            recordButtons[i] = new JButton();
            recordButtons[i].setText(String.format("%s = %s", calculator.getText(), result.getText()));
            recordButtons[i].setMaximumSize(new Dimension(recordsPanel.getWidth(), recordsPanel.getHeight() / 17));
            recordButtons[i].setMinimumSize(new Dimension(recordsPanel.getWidth(), recordsPanel.getHeight() / 17));
            recordsPanel.add(recordButtons[i]);
        }

        JScrollPane scrollPane = new JScrollPane();
        scrollPane.setViewportView(recordsPanel);
        scrollPane.setHorizontalScrollBarPolicy(ScrollPaneConstants.HORIZONTAL_SCROLLBAR_ALWAYS);

        return recordsPanel;
    }
    public JLabel getStandard()
    {
        standard = new JLabel("표준", JLabel.LEFT);

        return standard;
    }
}
