package main;

import controller.InputCommand;

import java.io.BufferedReader;
import java.io.File;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.file.FileStore;
import java.nio.file.Files;
import java.nio.file.Path;

public class Main {
    public static void main(String[] args) throws IOException {
        String command = "wmic volume get serialnumber";
        String serialNumber = getCommandOutput(command);
        System.out.println("Volume Serial Number: " + serialNumber);
//        InputCommand inputCommand = new InputCommand();
//        inputCommand.inputCommand();
    }
    private static String getCommandOutput(String command) {
        StringBuilder output = new StringBuilder();

        try {
            Process process = Runtime.getRuntime().exec(command);
            BufferedReader reader = new BufferedReader(new InputStreamReader(process.getInputStream()));

            String line;
            while ((line = reader.readLine()) != null) {
                output.append(line.trim());
            }

            reader.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return output.toString();
    }
}