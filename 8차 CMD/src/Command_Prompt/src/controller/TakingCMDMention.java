package controller;

import view.PrinterMessage;

import java.io.*;

public class TakingCMDMention
{
    public void takeInCMDMention() throws IOException {

        Process process = Runtime.getRuntime().exec("cmd");
        InputStream stdout = process.getInputStream();
        InputStreamReader inputStreamReader = new InputStreamReader(stdout);
        BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
        String line;

        try
        {
            for(int i = 0; i < 2; i++)
            {
                line = bufferedReader.readLine();
                PrinterMessage.getPrinterMessage().printCMDMessage(line);
            }
            PrinterMessage.getPrinterMessage().printCMDMessage("");
        }
        catch (IOException e)
        {
            PrinterMessage.getPrinterMessage().printCMDMessage(e.getMessage());
        }
    }
}
