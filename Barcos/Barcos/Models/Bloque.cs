using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Models
{
    public class Bloque
    {
        public int Largo { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }

        public Bloque() 
        {
            this.Largo = 0;
            this.Ancho = 0;
            this.Alto = 0;
        }

        public Bloque(int largo, int ancho, int alto)
        {
            this.Largo = largo;
            this.Ancho = ancho;
            this.Alto = alto;
        }

        public override string ToString()
        {
            return string.Concat("Largo: ", Largo.ToString(),
                               "\nAncho: ", Ancho.ToString(),
                               "\nAlto: ", Alto.ToString());
        }
    }
}
