
using System.Drawing;
namespace HojaRol
{
    public static class Constantes
    {
        //FORMULARIO
        public static readonly string MODO_CREACION = "modoCreacion", MODO_MODIFICACION = "modoModificacion";
        public static readonly int FACTOR_ALEATORIO_ATRIBUTOS = 10;
        public static readonly int PUNTOS_POR_HAB = 5;
        public static readonly int PUNTOS_RESTANTES_HAB = 5;
        public static readonly Color COLOR_DEFAULT = Color.White;
        public static readonly int PUNTOS_RESTANTES = 10, PUNTOS_A_REPARTIR = 1;

        //PROFESION

        public static readonly int FUERZA_G_DEFAULT = 50, FUERZA_M_DEFAULT = 10, FUERZA_P_DEFAULT = 20, FUERZA_C_DEFAULT = 30;
        public static readonly int AGILIDAD_G_DEFAULT = 20, AGILIDAD_M_DEFAULT = 30, AGILIDAD_P_DEFAULT = 60, AGILIDAD_C_DEFAULT = 40;
        public static readonly int VITALIDAD_G_DEFAULT = 50, VITALIDAD_M_DEFAULT = 20, VITALIDAD_P_DEFAULT = 30, VITALIDAD_C_DEFAULT = 35;
        public static readonly int MENTE_G_DEFAULT = 10, MENTE_M_DEFAULT = 50, MENTE_P_DEFAULT = 10, MENTE_C_DEFAULT = 20;
        public static readonly int ESPIRITU_G_DEFAULT = 5, ESPIRITU_M_DEFAULT = 50, ESPIRITU_P_DEFAULT = 10, ESPIRITU_C = 20;
        public static readonly int SUERTE_G_DEFAULT = 10, SUERTE_M_DEFAULT = 10, SUERTE_P_DEFAULT = 35, SUERTE_C_DEFAULT = 10;
        public static readonly string GUERRERO="Guerrero", MAGO="Mago", PICARO="Picaro", CAZADOR="Cazador";
        //IMAGEN 
        public static readonly string PATH_RESOURCES = "..\\..\\Resources\\";
        //RUTA donde se guardaran y cargaran los personajes automaticamente, para no perder el trabajo hecho.
        public static readonly string DEFAULT_ALBUM_PATH = "..\\..\\albumPersonajes.txt";

    }
}
