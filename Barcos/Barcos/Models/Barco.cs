using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Models
{
    public class Barco
    {
        public string Nombre { get; set; }
        public int Cargamento { get; set; }
        public int Tripulacion { get; set; }

        public Barco()
        {
            this.Nombre = "";
            this.Cargamento = 0;
            this.Tripulacion = 0;
        }

        public Barco(string nombre, int cargamento, int tripulacion)
        {
            this.Nombre = nombre;
            this.Cargamento = cargamento;
            this.Tripulacion = tripulacion;
        }

        public override string ToString()
        {
            return String.Concat("Nombre: ", Nombre,
                               "\nCargamento: ", Cargamento.ToString(),
                               "\nTripulacion: ", Tripulacion.ToString());
        }
    }
}
