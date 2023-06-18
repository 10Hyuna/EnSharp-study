package controller;

import model.DAO.AccessorData;
import model.VO.UserInformation;
import view.LoggedInFrame;
import view.SearcherResult;
import view.SignUpFrame;

public class Validation {
    private SearcherResult searcherResult;
    private LoggedInFrame loggedInFrame;
    private SignUpFrame sign;
    public Validation(){
        searcherResult = new SearcherResult();
        sign = new SignUpFrame();
    }
    public void validateId(UserInformation userInformation){

        userInformation = AccessorData.GetAccessorData().SelectIdInformation(userInformation);

        if(userInformation.getId() != null){
            searcherResult.setIdFrame(userInformation.getId());
        }
        else{
            searcherResult.setIdFrame("정보가 없습니다");
        }
    }

    public void validatePw(UserInformation userInformation){
        userInformation = AccessorData.GetAccessorData().SelectPwInformation(userInformation);

        if(userInformation.getPw() != null){
            searcherResult.setPwFrame(userInformation.getPw());
        }
        else{
            searcherResult.setPwFrame("정보가 없습니다");
        }
    }

    public void validateLogin(UserInformation userInformation){
        userInformation = AccessorData.GetAccessorData().SelectLoginInformation(userInformation);

        if(userInformation.getPw() != null){
            loggedInFrame = new LoggedInFrame();
        }
        else{
            return;
        }
    }

//    public void insertInformation(UserInformation userInformation){
//        AccessorData.GetAccessorData().InsertInformation(userInformation);
//
//        //sign.successSignUp();
//    }
}
