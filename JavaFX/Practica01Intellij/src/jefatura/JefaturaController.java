/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jefatura;

import java.io.IOException;
import java.net.URL;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;

import Utilidades.BddConnection;
import javafx.beans.value.ObservableValue;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.geometry.Pos;
import javafx.scene.Group;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;
import javafx.beans.value.ChangeListener;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.*;
import javafx.scene.layout.*;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

/**
 *
 * @author Usuario
 */
public class JefaturaController implements Initializable {

    @FXML
    private ComboBox cbProfesor;
    @FXML
    private RadioButton rbSemanal;
    @FXML
    private RadioButton rbDiario;
    @FXML
    private ListView lvHorario;
    @FXML
    private GridPane gridHorario;
    @FXML
    private Pane paneSemanal, paneMoverVentana;
    @FXML
    private ImageView colorAzul, colorAmarillo, colorVerde, colorMorado, btnAtras;
    @FXML
    private Label btnCerrar, btnMinimizar;

    private double posX, posY;


    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initCbProfesor();
    }

    private void initCbProfesor() {
        cbProfesor.getItems().addAll(getProfesoresFromBdd());
        cbProfesor.setPromptText("Profesor");
        //Cuando se cambia el valor del ComboBox se cargará el horario del profesor marcado.
        cbProfesor.valueProperty().addListener(new ChangeListener<String>() {
            @Override
            public void changed(ObservableValue ov, String t, String t1) {
                cargarHorario();
            }
        });

        //Vuelve al login
        btnAtras.setOnMouseClicked(event -> showLogin());
        //Cierra la aplicación
        btnCerrar.setOnMouseClicked(event -> ((Stage) btnCerrar.getScene().getWindow()).close());
        //Minimiza la aplicación
        btnMinimizar.setOnMouseClicked(event -> ((Stage) btnCerrar.getScene().getWindow()).setIconified(true));


        configMovimientoVentana();
    }

    private void configMovimientoVentana() {
        paneMoverVentana.setOnMousePressed(event -> {
            posX = event.getX();
            posY =  event.getY();
        });
        paneMoverVentana.setOnMouseDragged(event -> {
            Stage stage = ((Stage) paneMoverVentana.getScene().getWindow());

            stage.setX(event.getScreenX() - posX);
            stage.setY(event.getScreenY() - posY);
        });
    }

    //Carga la lista o la tabla dependiendo de que RadioButton esté marcado
    private void cargarHorario(){
        if (rbDiario.isSelected())
            cargarLista();
        else
            cargarTabla();
    }
    private void cargarLista() {
        //Se oculta el horario y se muestra la lista.
        paneSemanal.setVisible(false);
        lvHorario.setVisible(true);
        //Si ha seleccionado algún profesor del comboBox.
        if (cbProfesor.getValue() != null) {
            lvHorario.getItems().clear();
            try {
                SimpleDateFormat format = new SimpleDateFormat("E");
                Connection connection = BddConnection.getConnection();
                final String SQL = "SELECT h.codTramo,r.codOe ,r.codCurso, h.codAsignatura FROM Horario h, reparto r WHERE h.codAsignatura = r.codAsignatura AND h.codCurso=r.codCurso AND r.codOe=h.codOe AND codProf = ? AND h.codTramo LIKE ? ORDER BY h.codTramo";
                PreparedStatement statement = connection.prepareStatement(SQL);
                //ID actual en el comboBox
                statement.setString(1, cbProfesor.getValue().toString().substring(0, 3));
                //Primera letra del dia de hoy.
                statement.setString(2, format.format(new Date()).toUpperCase().charAt(0) + "%");
                ResultSet rs = statement.executeQuery();

                while (rs.next()) {
                    lvHorario.getItems().add(String.format("Tramo Horario: %-10s Curso: %s %-10s Asignatura: %s", rs.getString(1), rs.getString(2), rs.getString(3), rs.getString(4)));
                }
                connection.close();
            } catch (SQLException | ClassNotFoundException ex) {
                Logger.getLogger(JefaturaController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }
    //Muestra en pantalla un gridPane con las asígnaturas que tiene el profesor personal la semana
    private void cargarTabla() {
        //Se oculta la lista y se muestra el horario semanal
        lvHorario.setVisible(false);
        paneSemanal.setVisible(true);
        //Si ha seleccionado algún profesor del comboBox.
        gridHorario.getChildren().clear();
        if (cbProfesor.getValue() != null) {
            try {
                SimpleDateFormat format = new SimpleDateFormat("E");
                Connection connection = BddConnection.getConnection();
                final String SQL = "SELECT h.codTramo,r.codOe ,r.codCurso, h.codAsignatura FROM Horario h, reparto r WHERE h.codAsignatura = r.codAsignatura AND h.codCurso=r.codCurso AND r.codOe=h.codOe AND codProf = ? ORDER BY h.codTramo";
                PreparedStatement statement = connection.prepareStatement(SQL);
                //ID actual en el comboBox
                statement.setString(1, cbProfesor.getValue().toString().substring(0, 3));
                ResultSet rs = statement.executeQuery();
                
                while (rs.next()) {
                    //Se consigue el número del codTramo ej: L3
                    int hora = Character.getNumericValue(rs.getString(1).charAt(1));
                    int dia = 0;
                    //Se salta el cuadro del recreo.
                    if(hora>3)
                        hora++;
                    //Asigna a cada día un número de row del grid.
                    switch (rs.getString(1).toUpperCase().charAt(0)) {
                        case 'L':
                            dia = 1;
                            break;
                        case 'M':
                            dia = 2;
                            break;
                        case 'X':
                            dia = 3;
                            break;
                        case 'J':
                            dia = 4;
                            break;
                        case 'V':
                            dia = 5;
                            break;
                    }
                    //Se crea un panel con la imagen y el codCurso que gestionara la alineación y el dragDrop de ambos elementos.
                    StackPane p = new StackPane();
                    StackPane.setAlignment(p, Pos.CENTER);
                    //Se inserta en el panel un color diferenciador de cursos.
                    p.getChildren().add( newColorImage(rs.getString("r.codCurso"), rs.getString("r.codOe")) );
                    //Inserta el código de asignatura que toca en esa hora.
                    p.getChildren().add(new Label(rs.getString("h.codAsignatura")));
                    gridHorario.add(p, dia, hora);



                }

             connection.close();
            } catch (SQLException | ClassNotFoundException ex) {
                Logger.getLogger(JefaturaController.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }



    private ImageView newColorImage(String codOe, String codCurso){
        Image image = null;


        switch (codOe+codCurso){
            case "1ADAM":
                image = colorAzul.getImage();
                break;
            case "2ADAM":
                image = colorAmarillo.getImage();
                break;
            case "1ASMR":
                image = colorVerde.getImage();
                break;
            case "2ASMR":
                image = colorMorado.getImage();
                break;
        }
        ImageView img = new ImageView(image);

        img.rotateProperty().setValue(-88.8);
        img.setFitWidth(25);
        img.setFitHeight(50);

        return img;
    }


    @FXML
    private void onCbPressed(ActionEvent event) {
        cargarHorario();
    }

    private ArrayList<String> getProfesoresFromBdd() {
        ArrayList<String> listaProfesores = new ArrayList<>();
        try {
            Connection connection = BddConnection.getConnection();
            Statement statement = connection.createStatement();
            ResultSet rs = statement.executeQuery("SELECT codProf, nombre FROM Profesor");

            while (rs.next()) {
                listaProfesores.add(rs.getString(1) + " - " + rs.getString(2));
            }

            connection.close();
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(JefaturaController.class.getName()).log(Level.SEVERE, null, ex);
        }

        return listaProfesores;
    }

    private ResultSet getHorarioFromBdd() {
        ResultSet rs = null;
        try {
            Connection connection = BddConnection.getConnection();
            final String SQL = "SELECT h.codTramo,r.codOe ,r.codCurso, h.codAsignatura FROM Horario h, reparto r WHERE h.codAsignatura = r.codAsignatura AND h.codCurso=r.codCurso AND r.codOe=h.codOe AND codProf = ? ORDER BY h.codTramo";
            PreparedStatement statement = connection.prepareStatement(SQL);
            statement.setString(1, cbProfesor.getValue().toString().substring(0, 3));
            rs = statement.executeQuery();

            connection.close();
        } catch (SQLException | ClassNotFoundException ex) {
            Logger.getLogger(JefaturaController.class.getName()).log(Level.SEVERE, null, ex);
        }
        return rs;
    }
    public void onKeyPressed(KeyEvent event) {
        //Vuelve al formulario anterior cuando se presiona la tecla Escape
        if(event.getCode() == KeyCode.ESCAPE)
            showLogin();

    }

    public void showLogin(){
        try {
            Stage stage = new Stage();
            AnchorPane root = FXMLLoader.load(getClass().getResource("/login/FXMLLogin.fxml"));
            Scene scene = new Scene(root);
            scene.setFill(null);
            stage.initStyle(StageStyle.TRANSPARENT);

            //Permite que la ventana se mueva
            root.setOnMousePressed(event -> {
                posX = event.getX();
                posY =  event.getY();
            });

            root.setOnMouseDragged(event -> {
                stage.setX(event.getScreenX() - posX);
                stage.setY(event.getScreenY() - posY);
            });

            scene.getStylesheets().addAll(getClass().getResource("/login/styleLogin.css").toExternalForm());
            stage.setResizable(false);
            stage.setScene(scene);
            stage.show();
            //Cierra este formulario
            ((Stage) btnAtras.getScene().getWindow()).close();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
