using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public Barco Barco { get; set; }
        public Tanque Tanque { get; set; }

        public Persona()
        {
            this.Nombre = "";
            this.Genero = "";
            this.Edad = 0;
            this.Barco = new Barco();
            this.Tanque = new Tanque();
        }

        public Persona(string nombre, string genero, int edad, Barco barco, Tanque tanque)
        {
            this.Nombre = nombre;
            this.Genero = genero;
            this.Edad = edad;
            this.Barco = barco;
            this.Tanque = tanque;
        }

        public override string ToString()
        {
            return string.Concat("Nombre: ", Nombre,
                               "\nGenero: ", Genero,
                               "\nEdad: ", Edad.ToString(), 
                               "\nBARCO\n",Barco, 
                               "\nTANQUE\n",Tanque);
        }

    }
}
