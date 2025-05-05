using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Models
{
    public class Tanque
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int Año { get; set; }
        public int Peso { get; set; }
        public List<string> Aliados { get; set; }

        public Tanque()
        {
            this.Nombre = "";
            this.Pais = "";
            this.Año = 0;
            this.Peso = 0;
            this.Aliados = Aliados;
        }

        public Tanque(string nombre, string pais, int año, int peso,List<string> aliados)
        {
            this.Nombre = nombre;
            this.Pais = pais;
            this.Año = año;
            this.Peso = peso;
            this.Aliados = aliados;
        }

        public override string ToString()
        {
            return string.Concat("Nombre: ", Nombre,
                               "\nPais: ", Pais,
                               "\nAño: ", Año.ToString(),
                               "\nPeso: ", Peso.ToString(),
                               "\nAliados: ", string.Join(", ", Aliados));
        }
    }
}
