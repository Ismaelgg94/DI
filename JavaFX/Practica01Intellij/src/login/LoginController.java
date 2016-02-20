package login;

import Utilidades.BddConnection;
import Utilidades.Constantes;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;
import javafx.stage.StageStyle;
import profesor.ProfesorController;

import java.io.IOException;
import java.net.URL;
import java.security.acl.Group;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ResourceBundle;

public class LoginController implements Initializable {

    @FXML
    private TextField txtUser;
    @FXML
    private PasswordField txtPass;
    @FXML
    private Label lblError;
    @FXML
    private Pane paneBtnProfesor;
    @FXML
    private Pane paneBtnJefeEstudio, paneMoverVentana;
    @FXML
    private Label btnClose;
    @FXML
    private Label btnMinimize;
    private double posX,posY;


    @Override
    public void initialize(URL location, ResourceBundle resources) {
        setMaxLenghtTextField(txtUser, Constantes.MAX_LENGHT_USER_FIELD);
        setMaxLenghtTextField(txtPass, Constantes.MAX_LENGHT_PASS_FIELD);
        btnClose.setOnMouseClicked(event -> {
            //Cierra la aplicación.
            ((Stage) btnClose.getScene().getWindow()).close();
        });
        btnMinimize.setOnMouseClicked(event -> {
            //Minimiza la ventana.
            ((Stage) btnMinimize.getScene().getWindow()).setIconified(true);
        });
        paneBtnProfesor.setOnMouseClicked(event -> {
            if(logueoConExito()){
                showProfesor();
                lblError.setVisible(false);
            }
            else
                //Se le indica al usuario mediante un mensaje que se ha equivocado escribiendo el usuario o la contraseña
                showLoginError();
        });
        paneBtnJefeEstudio.setOnMouseClicked(event -> {
            //Si el usuario introducido y su contraseña existen, se comprobara si es jefe de estudio.
            //Si es jefe, se mostrará la jefatura.
            //Se mostrará sus correspondientes errores en caso de fallo.
            if(logueoConExito()){
                if(isJefe()){
                    showJefatura();
                    lblError.setVisible(false);
                }else
                    showJefeError();
            }else
                showLoginError();
        });
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
    private boolean logueoConExito(){
        boolean existe = false;

        try {
            Connection connection = BddConnection.getConnection();
            PreparedStatement statement = connection.prepareStatement("SELECT codProf FROM Profesor WHERE codProf = ? AND password = ?");
            ResultSet rs;

            statement.setString(1,txtUser.getText());
            statement.setString(2, txtPass.getText());
            rs = statement.executeQuery();
            if(rs.next())
                existe=true;

            connection.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        return existe;
    }

    private boolean isJefe()  {
        boolean isJefe = false;
        try {
            Connection connection = BddConnection.getConnection();
            PreparedStatement statement = connection.prepareStatement("SELECT jefe FROM Profesor WHERE codProf = ?");
            ResultSet rs;

            statement.setString(1,txtUser.getText());
            rs = statement.executeQuery();

            while (rs.next())
                if(rs.getInt(1) == 1)
                    isJefe = true;

            connection.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        return isJefe;
    }


    public void showJefatura() {
        try {
            Stage stage = new Stage();
            stage.initStyle(StageStyle.TRANSPARENT);
            AnchorPane root = FXMLLoader.load(getClass().getResource("/jefatura/FXMLJefatura.fxml"));
            Scene scene = new Scene(root);
            scene.setFill(null);
            scene.getStylesheets().addAll(getClass().getResource("/jefatura/styleJefatura.css").toExternalForm());
            stage.setResizable(false);

            stage.setScene(scene);

            //Muestra el Stage de jefatura.
            stage.show();
            //Se cierra el login.
            ((Stage) paneBtnJefeEstudio.getScene().getWindow()).close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    //Muestra la ventana del profesor.
    private void showProfesor(){
        try {
            Stage stage = new Stage();
            stage.initStyle(StageStyle.TRANSPARENT);
            //Se le pasa al controlador el id del profesor que utilizará posteriormente para encontrar su horario.
            ProfesorController controller = new ProfesorController(txtUser.getText());
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/profesor/FXMLProfesor.fxml"));
            //No se puede especificar en el fxml que el controllador es "FXMLProfesor.fxml" para hacer esto.
            loader.setController(controller);

            AnchorPane root = loader.load();

            Scene scene = new Scene(root);
            scene.setFill(null);
            scene.getStylesheets().addAll(getClass().getResource("/profesor/styleProfesor.css").toExternalForm());
            stage.setResizable(false);


            stage.setScene(scene);
            //Muestra el Stage de jefatura.
            stage.show();
            //Cierra el login
            ((Stage) paneBtnProfesor.getScene().getWindow()).close();

        } catch (IOException e) {
            e.printStackTrace();
        }
    }



    private void setMaxLenghtTextField(TextField textField, int maxLenght){
        textField.lengthProperty().addListener((observable, oldValue, newValue) -> {
            if (newValue.intValue() > oldValue.intValue()) {
                //Comprueba si la última inserción supera el límite de carácteres.
                if (textField.getText().length() >= maxLenght) {

                    textField.setText(textField.getText().substring(0, maxLenght));
                }
            }
        });
    }
    private void showLoginError(){
        lblError.setText(Constantes.ERROR_LOGIN);
        lblError.setVisible(true);
    }
    private void showJefeError(){
        lblError.setText(Constantes.ERROR_JEFE);
        lblError.setVisible(true);
    }




}
