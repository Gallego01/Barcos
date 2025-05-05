using Barcos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Services
{
    public class PersonaService
    {
        BarcoService barcoService = new BarcoService();
        TanqueService tanqueService = new TanqueService();

        /// Crea una nueva persona, solicitando datos como nombre, genero y edad.
        /// También permite seleccionar un barco y un tanque asociado a la persona.
        public void CrearPersona(List<Persona> personas, List<Barco> barcos, List<Tanque> tanques)
        {
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            string genero = GuardClause.GuardClause.ValidarGenero();

            int edad = GuardClause.GuardClause.ValidarEdad();

            Barco barcoElegido = barcoService.MostrarBarcos(barcos);

            Tanque tanqueElegido = tanqueService.MostrarTanques(tanques);

            Persona nuevaPersona = new Persona(nombre, genero, edad, barcoElegido, tanqueElegido);
            personas.Add(nuevaPersona);

            Console.WriteLine($"\nDatos cargados:");
            Hablar(nuevaPersona);
        }

        /// Muestra un mensaje de presentación con los datos de la persona y los objetos asociados.
        public void Hablar(Persona persona)
        {
            Console.WriteLine($"Hola me llamo {persona.Nombre} me considero {persona.Genero} y tengo {persona.Edad} años, empecemos con esto.");
            Console.WriteLine($"||||||||||||BARCO  ELEGIDO||||||||||||\n{persona.Barco}");
            Console.WriteLine($"||||||||||||TANQUE ELEGIDO||||||||||||\n{persona.Tanque}");
        }

        /// Muestra todas las personas disponibles y permite al usuario seleccionar una.
        public Persona MostrarPersonaAElegir(List<Persona> persona)
        {
            for (int i = 0; i < persona.Count; i++)
            {
                Console.WriteLine($"||||||||||||||PERSONAJE|||||||||||||||\n{i + 1} - {persona[i]}");
            }

            Console.Write("Seleccionar personaje: ");
            int opcionPersona = GuardClause.GuardClause.ValidarOpcion(1, persona.Count);

            return persona[opcionPersona - 1];
        }
    }
}