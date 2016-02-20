package Stages;/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Modality;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

public class MainStage extends Application {
    double posX= 0, posY = 0;

    @Override
    public void start(Stage stage) throws Exception {
        AnchorPane root = FXMLLoader.load(getClass().getResource("/login/FXMLLogin.fxml"));

        Scene scene = new Scene(root);
        scene.setFill(null);
        stage.initStyle(StageStyle.TRANSPARENT);


        scene.getStylesheets().addAll(getClass().getResource("/login/styleLogin.css").toExternalForm());
        stage.setResizable(false);
        stage.setScene(scene);
        stage.show();
    }


    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }


}
