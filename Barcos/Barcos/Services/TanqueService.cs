using Barcos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Services
{
    public class TanqueService
    {
        /// Inicia una batalla entre el tanque del atacante (persona) y un tanque defensor.
        /// Se calcula el resultado de la batalla en función de las características de los tanques.
        public void BatallaContraTanque(Persona personal, List<Tanque> tanques)
        {
            Console.WriteLine($"\nTanque del atacante ({personal.Nombre}):");
            Console.WriteLine(personal.Tanque);

            Tanque enemigo = MostrarTanques(tanques);

            CalcularBatallaTanque(personal.Tanque, enemigo);
        }

        /// Calcula el resultado de la batalla entre dos tanques en función de su año de fabricación y peso.
        /// El tanque con el año más reciente y el peso más alto obtiene más puntos.
        public void CalcularBatallaTanque(Tanque atacante, Tanque defensor)
        {
            Console.WriteLine($"|||||||||||TANQUE ATACANTE||||||||||||\n{atacante}");

            Console.WriteLine($"|||||||||||TANQUE DEFENSOR||||||||||||\n{defensor}");

            int puntosAtacante = 0;
            int puntosDefensor = 0;

            if (atacante.Año > defensor.Año)
            {
                puntosAtacante++;
            }
            else if (defensor.Año > atacante.Año)
            {
                puntosDefensor++;
            };

            if (atacante.Peso > defensor.Peso)
            {
                puntosAtacante++;
            }
            else if (defensor.Peso > atacante.Peso)
            {
                puntosDefensor++;
            }

            Console.WriteLine("|||||||RESULTADO DE LA BATALLA||||||||\n");
            if (puntosAtacante > puntosDefensor)
            {
                Console.WriteLine($"{atacante.Nombre} gana la batalla.");
            }
            else if (puntosDefensor > puntosAtacante)
            {
                Console.WriteLine($"{defensor.Nombre} gana la batalla. Haz perdido");
            }
            else
                Console.WriteLine("La batalla termina en empate.");
        }

        /// Muestra una lista de tanques disponibles y permite al usuario seleccionar uno.
        public Tanque MostrarTanques(List<Tanque> tanques)
        {
            for (int i = 0; i < tanques.Count; i++)
            {
                Console.WriteLine($"||||||||||||||||||||||||||||||||||||||\n{i + 1} - {tanques[i]}");
            }

            Console.Write("Seleccionar un tanque: ");
            int opcionTanque = GuardClause.GuardClause.ValidarOpcion(1, tanques.Count);

            return tanques[opcionTanque - 1];
        }

        /// Crea un nuevo tanque solicitando datos al usuario, como nombre, país, año de fabricación, peso y aliados.
        public void CrearTanque(List<Tanque> tanques)
        {
            Console.Write("Ingrese el nombre del tanque: ");
            string nombre = Console.ReadLine();
            
            Console.Write("Ingrese el pais del tanque: ");
            string pais = Console.ReadLine();

            int año = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese el año: ");

            int peso = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese el peso: ");

            Console.Write("Ingrese los/el aliado/s (separados por coma): ");
            List<string> aliados = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList(); ;

            Tanque nuevoTanque = new Tanque(nombre, pais, año, peso, aliados);
            tanques.Add(nuevoTanque);

            Console.WriteLine($"\nDatos cargados exitosamente:");
        }
    }
}
