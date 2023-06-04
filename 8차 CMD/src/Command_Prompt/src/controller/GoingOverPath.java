package controller;

import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;
import utility.Constant;

import java.io.File;

public class GoingOverPath {
    private InputDTO inputDTO;
    private CurrentStateDTO currentStateDTO;
    File file;
    public GoingOverPath(InputDTO inputDTO, CurrentStateDTO currentStateDTO)
    {
        this.inputDTO = inputDTO;
        this.currentStateDTO = currentStateDTO;
    }
    public void discriminatePath(String path)
    {
        if(path.equals("\\"))
        {
            path = "C:\\";
        }

        boolean isPath;

        file = new File(path);
        discriminateAbsoultePath(path);

//        file = new File(path).getAbsoluteFile();
//        isPath = file.exists();
//
//        if (isPath)
//        {
//            movePath(path);
//        }
//        else
//        {
//            handlePath(path);
//        }
    }
    private void discriminateAbsoultePath(String path)
    {
        if(file.exists())
        {
            if(!path.equals(file.getAbsolutePath()))
            {
                handlePath(path);
            }
            else
            {
                currentStateDTO.setExcutedPath(path);
            }
        }
        else
        {
            currentStateDTO.setExcutedPath(Constant.FAIL);
        }
//        if(path.equals(file.getAbsolutePath()))
//        {
//            return path;
//        }
//        else
//        {
//            return currentStateDTO.getExcutedPath() + "\\" + path;
//        }
    }
    private void handlePath(String path)
    {
        path = path.replace("\\\\", "\\");
        path = path.replace("/", "\\");

        String cuttedPath = "";

        for(int i = 0; i < path.length(); i++)
        {
            cuttedPath += path.charAt(i);
            if(path.charAt(i) == '\\')
            {
                manipulateRoute(cuttedPath);
                cuttedPath = "";
            }
        }
        manipulateRoute(cuttedPath);
    }
    private void manipulateRoute(String path)
    {
        String removeSlash = path.replace("\\", "");
        if(currentStateDTO.getExcutedPath().equals("C:"))
        {
            currentStateDTO.setExcutedPath("C:\\");
            return;
        }
        else if(currentStateDTO.getExcutedPath().equals("C:\\"))
        {
            return;
        }

        switch (removeSlash)
        {
            case "..":
                goBackOneStep();
                break;
            case ".":
                CurrentStep(file.getAbsolutePath());
                break;
            case "":
                CurrentStep(Constant.EMPTY);
                break;
            default:
                currentStateDTO.setExcutedPath(currentStateDTO.getExcutedPath() + "\\" + path);
                break;
        }
    }
    private void goBackOneStep()
    {
        String path = currentStateDTO.getExcutedPath();
        path = path.substring(0, path.lastIndexOf("\\"));

        currentStateDTO.setExcutedPath(path);
    }
    private void CurrentStep(String currentStep)
    {
        currentStateDTO.setExcutedPath(currentStep);
    }
}
