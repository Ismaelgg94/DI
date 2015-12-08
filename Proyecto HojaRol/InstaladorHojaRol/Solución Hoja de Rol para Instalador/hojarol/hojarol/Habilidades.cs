using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HojaRol
{
    public class Habilidades
    {
        private int correr, saltar, nadar, sigilo, cocinar, negociar, hurtar, rastrear;

        public Habilidades(int correr,int saltar,int nadar,int sigilo, int cocinar, int negociar,int hurtar,int rastrear)
        {
            this.correr = correr;
            this.saltar = saltar;
            this.nadar = nadar;
            this.sigilo = sigilo;
            this.cocinar = cocinar;
            this.negociar = negociar;
            this.hurtar = hurtar;
            this.rastrear = rastrear;
        }

        public int getCorrer()
        {
            return correr;
        }
        public int getSaltar()
        {
            return saltar;
        }
        public int getNadar()
        {
            return nadar;
        }
        public int getSigilo()
        {
            return sigilo;
        }
        public int getCocinar()
        {
            return cocinar;
        }
        public int getNegociar()
        {
            return negociar;
        }
        public int getHurtar()
        {
            return hurtar;
        }
        public int getRastrear()
        {
            return rastrear;
        }

        public void setCorrer(int correr)
        {
            this.correr = correr;
        }
        public void setSaltar(int saltar)
        {
            this.saltar = saltar;
        }
        public void setNadar(int nadar)
        {
            this.nadar = nadar;
        }
        public void setSigilo(int sigilo)
        {
            this.sigilo = sigilo;
        }
        public void setCocinar(int cocinar)
        {
            this.cocinar = cocinar;
        }
        public void setNegociar(int negociar)
        {
            this.negociar = negociar;
        }
        public void setHurtar(int hurtar)
        {
            this.hurtar = rastrear;
        }
        public void setRastrear(int rastrear)
        {
            this.rastrear = rastrear;
        }
    }
}
