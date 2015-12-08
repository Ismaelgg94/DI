using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HojaRol
{
    public class Atributos
    {
        private int fuerza, agilidad, vitalidad, mente, espiritu, suerte;

        public Atributos(int fuerza, int agilidad, int vitalidad, int mente, int espiritu, int suerte)
        {
            this.fuerza = fuerza;
            this.agilidad = agilidad;
            this.vitalidad = vitalidad;
            this.mente = mente;
            this.espiritu = espiritu;
            this.suerte = suerte;
        }
        public int hashCode()
        {
            int hash = 0;
            hash += fuerza * 400;
            hash += agilidad * 24;
            hash += vitalidad * 222;
            hash += mente * 2212;
            hash += espiritu * 2;
            hash += suerte * 11;
            return hash;
        }

        public int getFuerza()
        {
            return fuerza;
        }
        public int getAgilidad()
        {
            return agilidad;
        }
        public int getVitalidad()
        {
            return vitalidad;
        }
        public int getMente()
        {
            return mente;
        }
        public int getEspiritu()
        {
            return espiritu;
        }
        public int getSuerte()
        {
            return suerte;
        }
        public void setFuerza(int fuerza)
        {
            this.fuerza = fuerza;
        }
        public void setAgilidad(int agilidad)
        {
            this.agilidad = agilidad;
        }
        public void setVitalidad(int vitalidad)
        {
            this.vitalidad = vitalidad;
        }
        public void setMente(int mente)
        {
            this.mente = mente;
        }
        public void setEspiritu(int espiritu)
        {
            this.espiritu = espiritu;
        }
        public void setSuerte(int suerte)
        {
            this.suerte = suerte;
        }
    }
}
