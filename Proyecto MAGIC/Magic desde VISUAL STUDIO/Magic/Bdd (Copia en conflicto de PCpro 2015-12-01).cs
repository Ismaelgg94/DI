using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;

namespace Magic
{
    public static class Bdd
    {   //                                                                                                 Consigue la ruta relativa de la carpeta donde se encuentra el .mdf
        private readonly static string BASE_DATA = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.GetFullPath(@"..\..\BDD\Magic.mdf") + ";Integrated Security=True;Connect Timeout=30";
        //private readonly static string BASE_DATA = "Data Source =.\\SQLEXPRESS;Initial Catalog = M; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static readonly String COLOR_AZUL = "Azul", COLOR_ROJO = "Rojo", COLOR_VERDE = "Verde", COLOR_NEGRO = "Negro", COLOR_BLANCO = "Blanco", COLOR_GENERAL="";
        
        
        public static String ejecutarSQLScalar(string sql)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = BASE_DATA;
            SqlCommand order = new SqlCommand();
            string datos;

            connection.Open();
                        
            order.CommandText = sql;
            order.CommandType = System.Data.CommandType.Text;
            order.Connection = connection;
            datos = (string)order.ExecuteScalar();

            connection.Close();
            return datos;
        }

        public static ArrayList ejecutarSQLReader(String sql)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = BASE_DATA;
            SqlCommand order = new SqlCommand();
            SqlDataReader resultado;
            ArrayList datos = new ArrayList();

            connection.Open();

            order.CommandText = sql;
            order.CommandType = System.Data.CommandType.Text;
            order.Connection = connection;
            try
            {
                resultado = order.ExecuteReader();
            }
            catch (SqlException)
            {
                //Para cuando se Hace un drag and drop de una carta en su misma listView (Daría un error de claves repetidas)
                return null;
            }
            

            while (resultado.Read())
                for(int i = 0; i<resultado.FieldCount;i++) //Devuelve todas las columnas que devuelva la consulta Sql.
                    datos.Add(resultado.GetString(i));
            
            connection.Close();
            return datos;
        }
        public static bool identificarUsuario(string user, string password)
        {
            if (ejecutarSQLScalar(String.Format("SELECT nick FROM Usuario WHERE nick = '{0}' AND Pass = '{1}'", user, password)) != null)
                return true;
            else
                return false;
        }

        public static ArrayList getCartasUsuario(String user, String color)
        {
            //Si color no es cadena Vacía, se hará la select filtrando por ese color.
            String sql = String.Format("SELECT imagen FROM Carta,Tiene WHERE nombre=nombreCarta AND '{0}'=nick AND color='{1}'", user,color);
            //Si es cadena vacia, se sacarán todas las cartas ordenadas por color.
            if (color=="")
                sql= String.Format("SELECT imagen FROM Carta,Tiene WHERE nombre=nombreCarta AND '{0}'=nick ORDER BY color", user);

            //Devuelve las rutas de las imágenes que son propiedad del usuario.
            return ejecutarSQLReader(sql);
        }
        public static ArrayList getCartasTienda(String user, String color)
        {
            //Si color no es cadena Vacía, se hará la select filtrando por ese color.
            String sql = String.Format("SELECT imagen FROM Carta WHERE nombre NOT IN (SELECT nombreCarta FROM Tiene WHERE nick='{0}') AND color='{1}'", user,color);
            //Si es cadena vacia, se sacarán todas las cartas ordenadas por color.
            if (color=="")
                sql = String.Format("SELECT imagen FROM Carta WHERE nombre NOT IN (SELECT nombreCarta FROM Tiene WHERE nick='{0}') ORDER BY color", user);
            //Devuelve las rutas de las imágenes que no son propiedad del usuario.
            return ejecutarSQLReader(sql);
        }

        public static void venderCarta(String user,String pathImage)
        {
            //Elimina la relacion carta-propietario 
            ejecutarSQLReader(String.Format("DELETE FROM Tiene WHERE nombreCarta = (SELECT nombre FROM Carta WHERE '{0}' = imagen) AND nick='{1}'", pathImage, user));
        }
        public static void comprarCarta(String user, String pathImage)
        {
            //Crea la relación carta-propietario cuando se compra una carta.
            ejecutarSQLReader(String.Format("INSERT INTO Tiene VALUES ('{0}',(SELECT nombre FROM Carta WHERE '{1}'=imagen) )", user, pathImage));
                
        }
        public static ArrayList datosCarta(String pathImage)
        {
            return ejecutarSQLReader(String.Format("Select * FROM Carta WHERE '{0}'=imagen", pathImage));
        }
        public static bool existeUsuario(String nick)
        {
            //Si la select devuelve algo, es que existe el usuario y devuelve True
            if (ejecutarSQLScalar(String.Format("SELECT nick FROM Usuario WHERE '{0}'=nick", nick)) != null)
                return true;

            return false;
        }
        public static void crearUsuario(string nick, string password)
        {
            ejecutarSQLScalar(String.Format("INSERT INTO Usuario VALUES ('{0}','{1}')",nick,password));
        }
    }
}
