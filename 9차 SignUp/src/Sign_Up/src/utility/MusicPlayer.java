package utility;

import javazoom.jl.player.Player;
import main.Main;

import java.io.BufferedInputStream;
import java.io.File;
import java.io.FileInputStream;
import javazoom.jl.player.Player;

public class MusicPlayer extends Thread{
    private Player jlPlayer;
    private File fileName;
    private FileInputStream fileInputStream;
    private BufferedInputStream bufferedInputStream;
    public MusicPlayer()
    {
        try{
            fileName = new File(Main.class.getResource("../music/download.mp3").toURI());
            fileInputStream = new FileInputStream(fileName);
            bufferedInputStream = new BufferedInputStream(fileInputStream);
            jlPlayer = new Player(bufferedInputStream);
        }
        catch (Exception e)
        {
            e.getMessage();
        }
    }
    @Override
    public void run()
    {
        try {
            while(true){
                jlPlayer.play();
                fileInputStream = new FileInputStream(fileName);
                bufferedInputStream = new BufferedInputStream(fileInputStream);
                jlPlayer = new Player(bufferedInputStream);
            }
        } catch (Exception e)
        {
            e.getMessage();
        }
    }
}
