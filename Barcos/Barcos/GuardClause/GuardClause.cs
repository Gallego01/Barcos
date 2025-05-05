using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.GuardClause
{
    public class GuardClause
    {
        /// Valida si una opción ingresada por el usuario está dentro del rango especificado.
        public static int ValidarOpcion(int minimo, int maximo)
        {
            bool pudo = false;
            int opcion = 0;
            while (!pudo)
            {
                pudo = int.TryParse(Console.ReadLine(), out opcion);
                if (!pudo || opcion < minimo || opcion > maximo)
                {
                    pudo = false;
                    Console.WriteLine(string.Concat("Solo numeros entre ", minimo, " y ", maximo, ".\nIntente nuevamente: "));
                }
            }
            return opcion;
        }

        /// Valida que el género ingresado por el usuario esté dentro de un conjunto predefinido de opciones.
        public static string ValidarGenero()
        {
            string[] opciones = { "Masculino", "Femenino", "Otros" };

            Console.WriteLine("Seleccione el genero: ");
            for (int i = 0; i < opciones.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i]}");
            }

            int opcion = ValidarOpcion(1, opciones.Length);
            return opciones[opcion - 1];
        }

        /// Valida que la edad ingresada por el usuario esté dentro del rango de 1 a 120 años.
        public static int ValidarEdad()
        {
            int edad;

            while (true)
            {
                Console.Write("Ingrese la edad (1 a 120): ");

                bool esValida = int.TryParse(Console.ReadLine(), out edad);

                if (esValida && edad >= 1 && edad <= 120)
                {
                    return edad;
                }

                Console.WriteLine("Edad no valida. Intente nuevamente.");
            }
        }

        /// Valida que un número ingresado por el usuario sea positivo.
        public static int ValidarNumeroPositivo(string mensaje)
        {
            int numero;
            do
            {
                Console.WriteLine(mensaje);
                bool esValido = int.TryParse(Console.ReadLine(), out numero);

                if (!esValido || numero <= 0)
                {
                    Console.WriteLine("Se debe de ingresar numeros positivos.");
                }
            } while (numero <= 0);

            return numero;
        }
    }
}
