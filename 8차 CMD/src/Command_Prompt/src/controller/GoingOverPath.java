package controller;

import model.DTO.CurrentStateDTO;
import model.DTO.InputDTO;

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
        boolean isPath;

        file = new File(path).getAbsoluteFile();

        isPath = file.exists();

        path = discriminateAbsoultePath(path);

        if (isPath)
        {
            movePath(path);
        }
        else
        {
            handlePath(path);
        }
    }
    private String discriminateAbsoultePath(String path)
    {
        if(path.equals(file.getAbsolutePath()))
        {
            return path;
        }
        else
        {
            return file.getAbsolutePath();
        }
    }
    private void movePath(String path)
    {
        currentStateDTO.setExcutedPath(path);
    }
    private void handlePath(String path)
    {
        String cuttedPath = "";

        for(int i = 0; i < path.length(); i++)
        {
            if(path.equals("\\"))
            {
                cuttedPath += path.charAt(i);
                manipulateRoute(cuttedPath);
                cuttedPath = "";
            }
            else
            {
                cuttedPath += path.charAt(i);
            }
        }
        manipulateRoute(cuttedPath);
    }
    private void manipulateRoute(String path)
    {

    }
}
