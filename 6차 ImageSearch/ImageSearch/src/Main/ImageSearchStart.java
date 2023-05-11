package Main;

import Controller.EntryImageSearch;
import Model.DataParse;
import Utility.ConnectionAPI;

import javax.imageio.ImageIO;
import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.io.IOException;
import java.net.URL;

import org.json.JSONArray;
import org.json.JSONObject;

public class ImageSearchStart
{
    public static void main(String[] args) throws IOException
    {
        EntryImageSearch entryImageSearch = new EntryImageSearch();
        entryImageSearch.EnterMenu();
    }
}