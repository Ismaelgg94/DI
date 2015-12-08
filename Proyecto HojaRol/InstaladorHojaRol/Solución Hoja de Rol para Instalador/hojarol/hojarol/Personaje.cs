using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HojaRol
{
    public class Personaje
    {
        private string nombre;
        private string raza;
        private char genero;
        private string profesion;
        

        private Atributos atributos;
        private Habilidades habilidades;
        
        private Equipo armaIzquierda;
        private Equipo armaDerecha;
        private Equipo proteccion;
        private Equipo accesorio1;
        private Equipo accesorio2;

        public Personaje()
        {

        }

        public int hashCode()
        {
            int hashCode = 0;
            hashCode += nombre.GetHashCode() * 23;
            hashCode += raza.GetHashCode() * 99;
            hashCode += genero.GetHashCode() * 2;
            hashCode += profesion.GetHashCode() * 1000;
            hashCode += atributos.hashCode();
            hashCode += armaIzquierda.hashCode();
            hashCode += armaDerecha.hashCode();
            hashCode += proteccion.hashCode();
            hashCode += accesorio1.hashCode();
            hashCode += accesorio2.hashCode();


            return hashCode;
        }

        //----------------------- GETTERS & SETTERS ------------------------------
        public string getNombre()
        {
            return nombre;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setGenero(char genero)
        {
            this.genero = genero;
        }
        public char getGenero()
        {
            return genero;
        }
        public void setProfesion(String profesion)
        {
            this.profesion = profesion;
        }
        public string getProfesion()
        {
            return profesion;
        }
        public string getRaza()
        {
            return raza;
        }
        public void setRaza(string raza)
        {
            this.raza = raza;
        }
        public void setAtributos(Atributos atributos)
        {
            this.atributos = atributos;
        }
        public Atributos getAtributos()
        {
            return atributos;
        }
        public void setHabilidades(Habilidades habilidades)
        {
            this.habilidades = habilidades;
        }
        public Habilidades getHabilidades()
        {
            return habilidades;
        }
        public void setArmaIzquierda(Equipo armaIzquierda)
        {
            this.armaIzquierda=armaIzquierda;
        }
        public void setArmaDerecha(Equipo armaDerecha)
        {
            this.armaDerecha=armaDerecha;
        }
        public void setProteccion(Equipo proteccion)
        {
            this.proteccion=proteccion;
        }
        public void setAccesorio1(Equipo accesorio1)
        {
            this.accesorio1=accesorio1;
        }
        public void setAccesorio2(Equipo accesorio2)
        {
            this.accesorio2 = accesorio2;
        }
        public Equipo getArmaIzquierda()
        {
            return armaIzquierda;
        }
        public Equipo getArmaDerecha()
        {
            return armaDerecha;
        }
        public Equipo getProteccion()
        {
            return proteccion;
        }
        public Equipo getAccesorio1()
        {
            return accesorio1;
        }
        public Equipo getAccesorio2()
        {
            return accesorio2;
        }
    }
}
