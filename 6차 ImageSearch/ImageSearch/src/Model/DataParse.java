package Model;

import Utility.ConnectionAPI;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.xml.crypto.Data;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.MalformedURLException;
import java.net.URL;
import org.json.JSONArray;
import org.json.JSONObject;

public class DataParse {

    private ConnectionAPI connectionAPI;
    public DataParse()
    {
        connectionAPI = new ConnectionAPI();
    }

    public BufferedImage[] ParseURL(String query, int size) throws IOException
    {
        String[] imageUrl = new String[size];
        String Url;
        Url = connectionAPI.ConnectAPI(query, size);
        BufferedImage[] bufferedImages = new BufferedImage[size];

        int startIndex = Url.indexOf("\"thumbnail_url\"");
        int endIndex;

        // response parsing
        for(int i = 0; i < size; i++)
        {
            endIndex = Url.indexOf("\",\"image_url\"", startIndex);
            imageUrl[i] = Url.substring(startIndex + 16, endIndex);
            startIndex = endIndex + 16;
        }

        // 이미지 다운로드
        for(int i = 0; i < size; i++)
        {
            URL image = new URL(imageUrl[i]);
            bufferedImages[i] = ImageIO.read(image);
        }

        return bufferedImages;
    }
}
