using Barcos.Models;
using Barcos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Barcos
{
    class Program
    {
        static void Main(string[] args)
        {
            BarcoService barcoService = new BarcoService();
            PersonaService personaService = new PersonaService();
            TanqueService tanqueService = new TanqueService();
            BloqueService bloqueService = new BloqueService();

            List<Barco> barcos = new List<Barco>
            {
                new Barco("El Invencible", 50, 25),
                new Barco("La Fortuna", 40, 15),
                new Barco("El Corsario", 30, 5),
                new Barco("El Naufrago", 18, 10)
            };
            List<Tanque> tanques = new List<Tanque>
            {
                new Tanque("Panzer IV", "Alemania", 1942, 25, new List<string> { "Italia", "Japón" }),
                new Tanque("Sherman", "EE.UU.", 1943, 30, new List<string> { "Reino Unido", "Francia", "URSS" }),
                new Tanque("T-34", "URSS", 1941, 28, new List<string> { "EE.UU.", "Reino Unido" }),
                new Tanque("Churchill", "Reino Unido", 1942, 39, new List<string> { "EE.UU.", "Canadá", "URSS" })
            };
            List<Persona> personas = new List<Persona>
            {
                new Persona("Carlos", "Masculino", 30, barcos[1], tanques[0]),
                new Persona("Ana", "Femenino", 25, barcos[2], tanques[1]),
                new Persona("Luis", "Masculino", 40, barcos[3], tanques[2]),
                new Persona("María", "Femenino", 35, barcos[1], tanques[3])
            };
            List<Bloque> bloques = new List<Bloque>
            {
                new Bloque(2, 3, 4),
                new Bloque(5, 5, 5),
                new Bloque(10, 2, 1),
                new Bloque(7, 3, 2)
            };

            Persona personaTanqueYBarcoSeleccionado = null;

            int opcion;
            do
            {
                opcion = Menu();

                switch (opcion)
                {
                    case 1:
                        tanqueService.CrearTanque(tanques);
                        break;
                    case 2:
                        barcoService.CrearBarco(barcos);
                        break;
                    case 3:
                        personaService.CrearPersona(personas, barcos, tanques);
                        personaTanqueYBarcoSeleccionado = personas.Last();
                        break;
                    case 4:
                        personaTanqueYBarcoSeleccionado = personaService.MostrarPersonaAElegir(personas);
                        break;
                    case 5:
                        if (personaTanqueYBarcoSeleccionado != null)
                        {
                            tanqueService.BatallaContraTanque(personaTanqueYBarcoSeleccionado, tanques);
                        }
                        else
                        {
                            Console.WriteLine("Primero debes crear o seleccionar un personaje para atacar.");
                        }
                        break;
                    case 6:
                        if (personaTanqueYBarcoSeleccionado != null)
                        {
                            barcoService.BatallaContraBarco(personaTanqueYBarcoSeleccionado, barcos);
                        }
                        else
                        {
                            Console.WriteLine("Primero debes crear o seleccionar un personaje para atacar.");
                        }
                        break;
                    case 7:
                        barcoService.RespuestaSaquear(barcos);
                        break;
                    case 8:
                        bloqueService.MenuBloque(bloques);
                        break;
                }
            } while (opcion != 0);
        }
        private static int Menu()
        {
            Console.WriteLine("############# MENU DEL PRINCIPAL #############\n");
            Console.WriteLine("1 - CREAR TANQUE");
            Console.WriteLine("2 - CREAR BARCO");
            Console.WriteLine("3 - CREAR PERSONAJE");
            Console.WriteLine("4 - ELEGIR PERSONAJE");
            Console.WriteLine("5 - BATALLA CONTRA TANQUE");
            Console.WriteLine("6 - BATALLA CONTRA BARCO");
            Console.WriteLine("7 - ESPIAR BARCO");
            Console.WriteLine("8 - MENU BLOQUES");
            Console.WriteLine("0 - Salir\n");

            int opcion = GuardClause.GuardClause.ValidarOpcion(0, 8);

            return opcion;
        }
    }
}
