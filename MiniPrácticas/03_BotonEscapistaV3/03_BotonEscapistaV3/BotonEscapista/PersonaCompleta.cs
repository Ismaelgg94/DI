using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotonEscapista
{
    class PersonaCompleta
    {
        public Persona Pers;
        public Button Bot;

        public PersonaCompleta(Persona p, Button b)
        {
            Pers = p;
            Bot = b;
        }        
    }
}
