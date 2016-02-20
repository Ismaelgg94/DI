package profesor;

import Utilidades.BddConnection;
import Utilidades.Constantes;
import javafx.event.Event;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.Tab;
import javafx.scene.control.TabPane;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.input.KeyCode;
import javafx.scene.input.KeyEvent;
import javafx.scene.input.MouseEvent;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Pane;
import javafx.scene.shape.Rectangle;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

import java.io.IOException;
import java.net.URL;
import java.sql.*;
import java.text.SimpleDateFormat;
import java.util.*;


public class ProfesorController implements Initializable {
    private String COD_PROF="";
    @FXML
    private TabPane tabPane;
    @FXML
    private ImageView imgFoto, imgSello;
    @FXML
    private Tab tabLunes, tabMartes, tabMiercoles, tabJueves, tabViernes;
    @FXML
    private GridPane gridLunes, gridMartes, gridMiercoles, gridJueves, gridViernes;
    @FXML
    private Pane paneMoverVentana;
    @FXML
    private Label lblNombre, lblCodProf, lblNacimiento, lblAlta, btnCerrar, btnMinimizar;
    @FXML
    private ImageView imgL, imgM, imgX, imgJ, imgV, imgTapa, btnAtras;
    @FXML
    private Group groupTapa;
    @FXML
    private Rectangle shapeLunes, shapeMiercoles;
    private double posX,posY;

    public ProfesorController(String codProf){
        COD_PROF = codProf;
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {

        cargarInformacionProf();
        //Ejecuta la animación de la carpeta al iniciar el formulario.
        FlipTransition transition = new FlipTransition(184, 434);
        transition.play(groupTapa);

        //Vuelve al login
        btnAtras.setOnMouseClicked(event -> showLogin());
        //Cierra la aplicación
        btnCerrar.setOnMouseClicked(event -> ((Stage) btnCerrar.getScene().getWindow()).close());
        //Minimiza la aplicación
        btnMinimizar.setOnMouseClicked(event -> ((Stage) btnCerrar.getScene().getWindow()).setIconified(true));

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

    private void cargarHorario(char letraDia){
        try {
            Connection connection = BddConnection.getConnection();
            final String SQL = "SELECT h.codTramo,r.codOe ,r.codCurso, h.codAsignatura FROM Horario h, reparto r WHERE h.codAsignatura = r.codAsignatura AND h.codCurso=r.codCurso AND r.codOe=h.codOe AND codProf = ? AND h.codTramo LIKE ? ORDER BY h.codTramo";
            PreparedStatement statement = connection.prepareStatement(SQL);
            ResultSet rs;
            //Se indica el profesor del cual buscar los datos.
            statement.setString(1, COD_PROF);
            //Se indica el día del que se cogera las asignaturas impartidas.
            statement.setString(2, letraDia + "%");
            rs = statement.executeQuery();

            while (rs.next()){
                //Se consigue el número del codTramo ej: L3
                int hora = Character.getNumericValue(rs.getString(1).charAt(1));
                GridPane grid = null;
                //Rellena el grid, según el día que le corresponda.
                switch (letraDia) {
                    case 'L':
                        grid = gridLunes;
                        break;
                    case 'M':
                        grid = gridMartes;
                        break;
                    case 'X':
                        grid = gridMiercoles;
                        break;
                    case 'J':
                        grid = gridJueves;
                        break;
                    case 'V':
                        grid = gridViernes;
                        break;
                }
                //Se ocupa de rellenar el hueco del grid elegido en el switch, con los datos obtenidos de la BDD.
                rellenarHuecoHorario(grid, rs.getString("h.codAsignatura"), rs.getString("r.codCurso"), rs.getString("r.codOe"), hora - 1);
            }
            connection.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }

    private void rellenarHuecoHorario(GridPane grid, String codAsignatura, String codCurso, String codOe, int hora){

        //Se insertan la asignatura y el curso en los dias correspondientes
        grid.add(new Label(codAsignatura), 0, hora);
        grid.add(new Label(codCurso + " " + codOe), 1, hora);

    }

    private void cargarInformacionProf() {
        try {
            SimpleDateFormat format = new SimpleDateFormat("dd/MM/yy");
            Connection connection = BddConnection.getConnection();
            PreparedStatement statement = connection.prepareStatement("SELECT codProf, nombre, alta, fechadenacimiento, foto, jefe FROM Profesor WHERE codProf = ?");
            ResultSet rs;
            statement.setString(1, COD_PROF);
            rs = statement.executeQuery();

            if(rs.next()){
                lblCodProf.setText(rs.getString("codProf"));
                lblNombre.setText(rs.getString("nombre"));
                //Formatea el TimeStamp.
                lblAlta.setText(format.format(rs.getTimestamp("alta")));
                //Formatea el Date.
                lblNacimiento.setText(format.format(rs.getDate("fechadenacimiento")));
                imgFoto.setImage(new Image(rs.getString("foto")));
                //Si es jefe de estudios se mostrará una imagen de un sello
                if(rs.getInt("jefe") == 1)
                    imgSello.setVisible(true);
            }

            connection.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    //Cuando se cambia entre pestañas, se carga el horario del dia pulsado y se efectua la animación de
    //los marcapáginas.
    public void onTabChanged(Event event) {
        String id =((Tab) event.getTarget()).getId();
        char letraDia = ' ';
        GridPane grid = null;
        //Se vuelven todos los marcapáginas a su posición inicial.
        resetearMarcaPaginas();

        if(id.equals(tabLunes.getId())){
            grid = gridLunes;
            letraDia = Constantes.LETRA_LUNES;
            shapeLunes.setVisible(true);
            imgL.translateXProperty().setValue(-30);
            imgL.translateYProperty().setValue(-1);
        }
        else if(id.equals(tabMartes.getId())){
            grid = gridMartes;
            letraDia = Constantes.LETRA_MARTES;
            imgM.translateXProperty().setValue(-28);
            imgM.translateYProperty().setValue(-0.5);
        }else if(id.equals(tabMiercoles.getId())){
            grid = gridMiercoles;
            letraDia = Constantes.LETRA_MIERCOLES;
            shapeMiercoles.setVisible(true);
            imgX.translateXProperty().setValue(-25);
        }else if( id.equals(tabJueves.getId())){
            grid = gridJueves;
            letraDia = Constantes.LETRA_JUEVES;
            imgJ.translateXProperty().setValue(-28);
            imgJ.translateYProperty().setValue(-1);
        }else if( id.equals(tabViernes.getId())){
            grid = gridViernes;
            letraDia = Constantes.LETRA_VIERNES;
            imgV.translateXProperty().setValue(-30);
            imgV.translateYProperty().setValue(-1.5);
        }
        //Se limpia el grid antes de insertar los datos.
        grid.getChildren().clear();
        //Se carga los datos del dia seleccionado.
        cargarHorario(letraDia);
    }

    private void resetearMarcaPaginas() {
        imgL.translateXProperty().setValue(0);
        shapeLunes.setVisible(false);
        imgM.translateYProperty().setValue(0);
        imgM.translateXProperty().setValue(0);
        imgX.translateXProperty().setValue(0);
        shapeMiercoles.setVisible(false);
        imgJ.translateXProperty().setValue(0);
        imgJ.translateYProperty().setValue(0);
        imgV.translateXProperty().setValue(0);
        imgV.translateYProperty().setValue(0);
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


