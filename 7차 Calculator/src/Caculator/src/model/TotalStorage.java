package model;

import model.DTO.ComeInValueDTO;
import model.VO.CaculateResultVO;

import java.util.ArrayList;
import java.util.List;

public class TotalStorage {
    public List<CaculateResultVO> result;
    public ComeInValueDTO comeInValue;
    public TotalStorage()
    {
        result = new ArrayList<>();
        comeInValue = new ComeInValueDTO();
    }
}
