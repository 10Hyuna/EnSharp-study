package Model;

import Utility.ConnectionAPI;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;
import java.util.regex.*;

public class DataParse {

    private ConnectionAPI connectionAPI;
    public DataParse()
    {
        connectionAPI = new ConnectionAPI();
    }

    public BufferedImage[] ParseURL(String query, int size) throws IOException
    {
        String Url;
        Url = connectionAPI.ConnectAPI(query, size);
        BufferedImage[] bufferedImages = new BufferedImage[size];

        String[] imageUrl = new String[size]; // 이미지 URL을 담을 배열 선언
        Pattern pattern = Pattern.compile("\"thumbnail_url\":\"(.*?)\"");
        Matcher matcher = pattern.matcher(Url);
        int i = 0;
        while (matcher.find()) {
            imageUrl[i++] = matcher.group(1);
        }

        // 이미지 다운로드
        for(i = 0; i < size; i++)
        {
            URL image = new URL(imageUrl[i]);
            bufferedImages[i] = ImageIO.read(image);
        }

        return bufferedImages;
    }
}
