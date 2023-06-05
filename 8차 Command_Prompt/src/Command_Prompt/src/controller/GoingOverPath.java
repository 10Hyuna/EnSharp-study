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
        if(path.equals("\\"))
        // 최상위 폴더로 이동하고자 하는 명령어일 때
        {
            path = "C:\\";
        }

        file = new File(path);
        discriminateAbsolutePath(path);
        // path가 절대경로인지 판단하는 함수 호출
    }
    private void discriminateAbsolutePath(String path)
    {
        if(!path.equals(file.getAbsolutePath()))
        {   // 경로가 생성된 파일 객체의 절대 경로와 같지 않을 때
            handlePath(path);
        }
        else
        {   // 경로가 생성된 파일 객체의 절대 경로와 같을 때
            CurrentStep(path);
        }
    }
    private void handlePath(String path)
    {
        path = path.replace("\\\\", "\\");
        path = path.replace("/", "\\");

        String cuttedPath = "";

        for(int i = 0; i < path.length(); i++)
        {
            cuttedPath += path.charAt(i);
            if(path.charAt(i) == '\\')  // "\"를 기준으로 커맨드 하나씩 시행하기 위해 자름
            {
                manipulateRoute(cuttedPath);
                // "\"이 나오기 전까지 입력되어 있던 path를 시행
                cuttedPath = "";
            }
        }
        if(!cuttedPath.equals(""))
        {   // for문이 끝났을 때, 입력되어 있던 커맨드가 있을 경우
            manipulateRoute(cuttedPath);
        }
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
                // 이전 경로로 가고자 하는 커맨드일 경우
                goBackOneStep();
                break;
            case ".":
                // 현재 경로를 뜻하는 커맨드일 경우
                CurrentStep(currentStateDTO.getPath());
                break;
            default:
                // 상대경로가 입력되었을 경우
                CurrentStep(String.format("%s\\%s", currentStateDTO.getExcutedPath(), path));
                break;
        }
    }
    private void goBackOneStep()
    {
        String path = currentStateDTO.getExcutedPath();
        File file = new File(path);

        path = file.getParent();

        currentStateDTO.setExcutedPath(path);
    }
    private void CurrentStep(String currentStep) {
        File sourceFile = new File(currentStep);

        try {
            currentStateDTO.setExcutedPath(sourceFile.getCanonicalPath());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}