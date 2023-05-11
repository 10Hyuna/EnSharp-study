package Utility;

import java.awt.Image;
import java.awt.image.BufferedImage;
import java.io.BufferedReader;
import java.io.ByteArrayInputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

import javax.imageio.ImageIO;
import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;

import java.util.regex.*;

public class ConnectionAPI {
    public String ConnectAPI(String query, int size)
    {
        String apiUrl;
        String apiKey;
        String encodedQuery;

        StringBuffer response = null;

        try {
            apiUrl = "https://dapi.kakao.com/v2/search/image"; // 카카오 이미지 검색 API URL
            apiKey = "d94dd2125796846c80b2b0bc9a97f94f"; // 카카오 API 키
            encodedQuery = URLEncoder.encode(query, "UTF-8"); // 검색어를 UTF-8 인코딩

            // HTTP 요청 보내기
            URL url = new URL(apiUrl + "?query=" + encodedQuery + "&size=" + size);
            HttpURLConnection conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("GET");
            conn.setRequestProperty("Authorization", "KakaoAK " + apiKey);

            // 응답 받기
            BufferedReader br = new BufferedReader(new InputStreamReader(conn.getInputStream(), "UTF-8"));
            String line;
            response = new StringBuffer();

            while ((line = br.readLine()) != null)
            {
                response.append(line);
            }
            br.close();
        }

        catch (Exception e)
        {
            System.out.println("API 요청 오류: " + e.getMessage());
        }
        return response.toString();
    }
}
