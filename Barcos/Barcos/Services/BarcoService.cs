using Barcos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Services
{
    public class BarcoService
    {
        /// Evalua si un barco vale la pena saquear según su cargamento y tripulación,
        /// y muestra el resultado por consola.
        public void RespuestaSaquear(List<Barco> barcos)
        {
            if (ValeLaPenaSaquear(barcos))
            {
                Console.WriteLine("¡Vale la pena saquear el barco!");
            }
            else
            {
                Console.WriteLine("No vale la pena saquear este barco.");
            }
        }

        // Evalua si vale la pena saquear un barco.
        // Selecciona un barco de la lista, calcula el cargamento real (restando la tripulacion),
        // y determina si el valor excede a 20.
        // Devuelve true si vale la pena saquear, false en caso contrario.
        public bool ValeLaPenaSaquear(List<Barco> barcos)
        {
            Console.WriteLine("¿Que barco desea espiar?");

            Barco barcoSeleccionado = MostrarBarcos(barcos);

            int pesoReal = barcoSeleccionado.Cargamento - barcoSeleccionado.Tripulacion;

            return pesoReal > 20;
        }

        // Simula una batalla entre el barco de una persona atacante y un barco defensor.
        // Muestra los datos del atacante, permite seleccionar el barco defensor de una lista,
        // y luego calcula el resultado de la batalla usando el metodo CalcularBatallaBarco.
        public void BatallaContraBarco(Persona personal, List<Barco> barcos)
        {
            Console.WriteLine($"\nBarco del atacante ({personal.Nombre}):");
            Console.WriteLine(personal.Tanque);

            Barco defensor = MostrarBarcos(barcos);

            CalcularBatallaBarco(personal.Barco, defensor);
        }

        // Compara dos barcos (atacante y defensor) y determina el ganador de la batalla.
        // Se asignan puntos en base al cargamento y la tripulación de cada barco.
        // El barco con mas puntos gana la batalla. Si empatan en puntos, el resultado es un empate.
        public void CalcularBatallaBarco(Barco atacante, Barco defensor)
        {
            Console.WriteLine($"|||||||||||BARCO  ATACANTE||||||||||||\n{atacante}");

            Console.WriteLine($"|||||||||||BARCO  DEFENSOR||||||||||||\n{defensor}");

            int puntosAtacante = 0;
            int puntosDefensor = 0;

            if (atacante.Cargamento > defensor.Cargamento)
            {
                puntosAtacante++;
            }
            else if (defensor.Cargamento > atacante.Cargamento)
            {
                puntosDefensor++;
            };

            if (atacante.Tripulacion > defensor.Tripulacion)
            {
                puntosAtacante++;
            }
            else if (defensor.Tripulacion > atacante.Tripulacion)
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

        // Muestra una lista numerada de barcos por consola y permite al usuario seleccionar uno.
        // Devuelve el barco seleccionado por el usuario.
        public Barco MostrarBarcos(List<Barco> barcos)
        {
            for (int i = 0; i < barcos.Count; i++)
            {
                Console.WriteLine($"||||||||||||||||||||||||||||||||||||||\n{i + 1} - {barcos[i]}");
            }

            Console.Write("Seleccionar un barco: ");
            int opcionBloque = GuardClause.GuardClause.ValidarOpcion(1, barcos.Count);

            return barcos[opcionBloque - 1];
        }

        // Solicita al usuario los datos necesarios para crear un nuevo barco (nombre, cargamento y tripulación).
        // Valida que los numeros ingresados no sean negativos.
        // Crea una instancia de Barco con los datos proporcionados y la agrega a la lista de barcos.
        public void CrearBarco(List<Barco> barcos)
        {
            Console.Write("Ingrese el nombre del barco: ");
            string nombre = Console.ReadLine();

            int cargamento = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese la cantidad de cargamento: ");

            int tripulacion = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese la cantidad de tripulacion: ");

            Barco nuevoBarco = new Barco(nombre, cargamento, tripulacion);
            barcos.Add(nuevoBarco);

            Console.WriteLine($"\nDatos cargados exitosamente:");
        }
    }
}
