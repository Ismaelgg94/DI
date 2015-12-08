using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class UnionPersonaBoton
    {
        
        private Persona persona;
        private Button b= new Button();

        public UnionPersonaBoton(Point tamanoForm)
        {
            persona = nacer(tamanoForm);
            b.Location = persona.getPosicion();
            b.Size = persona.getTamano();
            b.FlatStyle = FlatStyle.Flat;
            b.BackgroundImage = persona.getImg();
            b.BackgroundImageLayout = ImageLayout.Zoom;
 
        }

        
        private Persona nacer(Point tamanoForm)
        {
            Persona p;
            Random rnd = new Random();
            int x, y, muroFobia = 10 ;
            Size tamano = new Size(30, 30);
            //Se crea una posición aleatoria para la persona.
            x = rnd.Next(0+muroFobia,tamanoForm.X-muroFobia-tamano.Width);
            y = rnd.Next(0+muroFobia, tamanoForm.Y-muroFobia-tamano.Height);
            p = new Persona(1, 70, tamano, muroFobia, new Point(x,y));

            return p;

        }

        //Getters
        public Persona getPersona()
        {
            return persona;
        }
        public Button getB()
        {
            return b;
        }

    }
}
