using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HojaRol
{
    public class Equipo 
    {
        private string img;
        private int atq, poderMag, defFis, defMag;

        public Equipo()
        {

        }
        public Equipo(string img, int atq, int poderMag, int defFis, int defMag)
        {
            this.img = img;
            this.atq = atq;
            this.poderMag = poderMag;
            this.defFis = defFis;
            this.defMag = defMag;
        }

        public int hashCode()
        {
            int hash = 0;
            if (img != null)
                hash += img.GetHashCode();
            else
                hash += 2;
            hash += atq * 22222;
            hash += poderMag * 3;
            hash += defFis + 11;
            hash += defMag * 412;

            return hash;
        }
        public void setImg(string img)
        {
            this.img = img;
        }
        public string getImg()
        {
            return img;
        }
        public void setAtq(int atq)
        {
            this.atq = atq;
        }
        public void setPoderMag(int poderMag)
        {
            this.poderMag = poderMag;
        }
        public int getAtq()
        {
            return atq;
        }
        public int getPoderMag()
        {
            return poderMag;
        }
        public void setdefFis(int defFis)
        {
            this.defFis = defFis;
        }
        public void setDefMag(int defMag)
        {
            this.defMag = defMag;
        }
        public int getDefFis()
        {
            return defFis;
        }
        public int getDefMag()
        {
            return defMag;
        }
    }
}
