using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HojaRol
{
    public class AlbumPersonajes
    {
        ArrayList personajes = new ArrayList();
        Personaje personajeActual;
        int hashInicial;
        public AlbumPersonajes()
        {

        }

        public void introducirPersonaje(Personaje personaje)
        {
            personajeActual=(Personaje)personajes[personajes.Add(personaje)];
        }
        public void modificarPersonaje(Personaje personaje)
        {
            //Cambia el personaje actual por el pasado por parámetro.
            personajes[personajes.IndexOf(personajeActual)] = personaje;
            personajeActual = personaje;

        }
        
        public bool eliminarPersonajeActual()
        {
            bool tag=false;
            Personaje personajeABorrar=personajeActual;

            if (existeAnteriorPersonaje())
            {
                if (anteriorPersonaje() != null)
                    tag = true;
            }
            else if (existeSiguientePersonaje())
                if (siguientePersonaje() != null)
                    tag = true;

            personajes.Remove(personajeABorrar);
            //Cuando no quedan personajes, no existe personaje actual.
            if (personajes.Count == 0)
                personajeActual = null;
            return tag;
        }

        public Personaje siguientePersonaje()
        {
            //Si existe un personaje detrás de este, se pasará a ese
            if (existeSiguientePersonaje())
                return personajeActual = (Personaje)personajes[personajes.IndexOf(personajeActual) + 1];
            else
                return null;
        }

        public Personaje anteriorPersonaje()
        {
            //Si existe un personaje antes de este, se retrocederá a ese
            if (existeAnteriorPersonaje())
                return personajeActual = (Personaje)personajes[personajes.IndexOf(personajeActual) - 1];
            else
                return null;
        }
        public bool existeSiguientePersonaje()
        {
            //Si existe un personaje posterior
            if (personajes.IndexOf(personajeActual) + 1 < personajes.Count )
                return true;
            else
                return false;
        }
        public bool existeAnteriorPersonaje()
        {   //Si existe un personaje anterior.
            if (personajes.IndexOf(personajeActual) - 1 >= 0)
                return true;
            else
                return false;
        }

        public Personaje getPersonajeActual()
        {
            return personajeActual;
        }

        public int numPersonajes()
        {
            return personajes.Count;
        }

        public void exportarAlbum(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            //Separará los personajes con un salto de linea.
            foreach (Personaje p in personajes)
                writer.WriteLine( escribirPersonaje(p));

            writer.Close();
        }
        public void importarAlbum(string path)
        {
            StreamReader reader;
            string row;
            Personaje pImportado;

            if (File.Exists(path))
            {
                reader = new StreamReader(path);
                while ((row = reader.ReadLine()) != null) // Saca cada linea del archivo. Cada linea son los datos de cada personaje.
                    if ((pImportado = leerPersonaje(row)) != null)  //Crea un personaje a partir de los datos leidos, si el hashCode no coincide, no se creará.
                            personajes.Add(pImportado);     // Añade el personaje importado al album.

                reader.Close();
            }
            if (personajes.Count > 0)
                personajeActual = (Personaje)personajes[0];
        }

        private String escribirPersonaje(Personaje p)
        {
            hashInicial = p.hashCode();
            string cadena = "";
            string separador = ",";
            //Diferencia los valores del mismo tipo
            
            Atributos at = p.getAtributos();
            Habilidades hab = p.getHabilidades();
            Equipo[] equipoEntero = { p.getArmaIzquierda(),p.getArmaDerecha(), p.getProteccion(), p.getAccesorio1(), p.getAccesorio2()};
            

            cadena += p.getNombre() + separador;
            cadena += p.getRaza() + separador;
            cadena += p.getGenero() + separador;
            cadena += p.getProfesion() + separador;
            //Atributos
            cadena += at.getFuerza() + separador;
            cadena += at.getAgilidad() + separador;
            cadena += at.getVitalidad() + separador;
            cadena += at.getMente() + separador;
            cadena += at.getEspiritu() + separador;
            cadena += at.getSuerte() + separador;
            //Habilidades
            cadena += hab.getCorrer() + separador;
            cadena += hab.getSaltar() + separador;
            cadena += hab.getNadar() + separador;
            cadena += hab.getSigilo() + separador;
            cadena += hab.getCocinar() + separador;
            cadena += hab.getNegociar() + separador;
            cadena += hab.getHurtar() + separador;
            cadena += hab.getRastrear() + separador;
            //Equipo
            foreach (Equipo equipo in equipoEntero)
            {
                cadena += equipo.getAtq()+separador;
                cadena += equipo.getDefFis() + separador;
                cadena += equipo.getDefMag() + separador;
                cadena += equipo.getPoderMag() + separador;
                cadena += equipo.getImg() + separador;
            }
            //Guarda su hashcode para su posterior comprobación de validez.
            cadena += p.hashCode().ToString();

            return cadena;
        }
        private Personaje leerPersonaje(String cadena)
        {
            Personaje p = new Personaje();
            string[] huecos = cadena.Split(',');
            
            p.setNombre(huecos[0]);
            p.setRaza(huecos[1]);
            p.setGenero(huecos[2].ToCharArray()[0]);
            p.setProfesion(huecos[3]);

            p.setAtributos(new Atributos(int.Parse(huecos[4]), int.Parse(huecos[5]), int.Parse(huecos[6]), int.Parse(huecos[7]), int.Parse(huecos[8]), int.Parse(huecos[9])));
            p.setHabilidades(new Habilidades(int.Parse(huecos[10]), int.Parse(huecos[11]), int.Parse(huecos[12]), int.Parse(huecos[13]), int.Parse(huecos[14]) , int.Parse(huecos[15]) , int.Parse(huecos[16]), int.Parse(huecos[17])));

            p.setArmaIzquierda(crearEquipo(huecos,18));
            p.setArmaDerecha(crearEquipo(huecos, 23));
            p.setProteccion(crearEquipo(huecos, 28));
            p.setAccesorio1(crearEquipo(huecos, 33));
            p.setAccesorio2(crearEquipo(huecos, 38));
            // Si no coinciden el hashCode del personaje nuevo creado con los mismos datos que el importado con el hashCode
            // recogido de la cadena, se habrá modificado el personaje y no se importará.
            int hashP = p.hashCode();
            
            if (p.hashCode() != int.Parse(huecos[43]))
                p = null;

            return p;
        }
        private Equipo crearEquipo(string[] huecos, int indiceString)
        {
            Equipo eq = new Equipo();
            eq.setAtq(int.Parse(huecos[indiceString]));
            eq.setdefFis(int.Parse(huecos[indiceString+1]));
            eq.setDefMag(int.Parse(huecos[indiceString+2]));
            eq.setPoderMag(int.Parse(huecos[indiceString+3]));
            //Si es cadena vacía la imagen se le asignará un null. *por defecto cuando no se escoge ningún desplegable.
            if(huecos[indiceString + 4]=="")
                eq.setImg(null);
            else
                eq.setImg(huecos[indiceString+4]);
            return eq;
        }
    }
}
