/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jefatura;

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
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ComboBox;
import javafx.scene.control.ListView;
import javafx.beans.value.ChangeListener;
import javafx.scene.control.Label;
import javafx.scene.control.RadioButton;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Pane;

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
    private Pane paneSemanal;
    @FXML
    private ImageView colorAzul, colorAmarillo, colorVerde, colorMorado;


    @Override
    public void initialize(URL url, ResourceBundle rb) {
        initCbProfesor();
    }

    private void initCbProfesor() {
        cbProfesor.getItems().addAll(getProfesoresFromBdd());
        cbProfesor.setPromptText("Profesor");
        cbProfesor.valueProperty().addListener(new ChangeListener<String>() {
            @Override
            public void changed(ObservableValue ov, String t, String t1) {

                cargarHorario();
            }
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
                    //Se inserta en la celda un color diferenciador de cursos.
                    gridHorario.add(newColorImage(rs.getString("r.codCurso"),rs.getString("r.codOe")), dia, hora);
                    //Inserta el código de asignatura que toca en esa hora.
                    gridHorario.add(new Label(rs.getString("h.codAsignatura")), dia, hora);
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

}
