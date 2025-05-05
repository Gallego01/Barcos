using Barcos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcos.Services
{
    public class BloqueService
    {
        /// Solicita al usuario que seleccione un bloque de la lista y muestra su largo.
        public void ObtenerLargo(List<Bloque> bloque)
        {
            Bloque bloqueSeleccionado = MostrarBloques(bloque);
            Console.WriteLine($"Largo del bloque: {bloqueSeleccionado.Largo}");
        }

        /// Solicita al usuario que seleccione un bloque de la lista y muestra su ancho.
        public void ObtenerAncho(List<Bloque> bloque)
        {
            Bloque bloqueSeleccionado = MostrarBloques(bloque);
            Console.WriteLine($"Ancho del bloque: {bloqueSeleccionado.Ancho}");
        }

        /// Solicita al usuario que seleccione un bloque de la lista y muestra su alto.
        public void ObtenerAlto(List<Bloque> bloque)
        {
            Bloque bloqueSeleccionado = MostrarBloques(bloque);
            Console.WriteLine($"Alto del bloque: {bloqueSeleccionado.Alto}");
        }

        /// Calcula y muestra el volumen del bloque seleccionado por el usuario.
        public void ObtenerVolumen(List<Bloque> bloque)
        {
            Bloque bloqueSeleccionado = MostrarBloques(bloque);
            int valorVolumen = bloqueSeleccionado.Largo * bloqueSeleccionado.Ancho * bloqueSeleccionado.Alto;
            Console.WriteLine($"Volumen del bloque: {valorVolumen}");
        }

        /// Calcula y muestra el área de superficie del bloque seleccionado por el usuario.
        public void ObtenerAreaSuperficie(List<Bloque> bloque)
        {
            Bloque bloqueSeleccionado = MostrarBloques(bloque);
            int valorAreaSuperficie = 2 * (bloqueSeleccionado.Largo * bloqueSeleccionado.Ancho + bloqueSeleccionado.Ancho * bloqueSeleccionado.Alto + bloqueSeleccionado.Alto * bloqueSeleccionado.Largo);
            Console.WriteLine($"Area de superficie del bloque: {valorAreaSuperficie}");
        }

        /// Muestra los bloques disponibles y permite al usuario seleccionar uno.
        public Bloque MostrarBloques(List<Bloque> bloque)
        {
            Console.WriteLine("¿Que desea calcular?");

            for (int i = 0; i < bloque.Count; i++)
            {
                Console.WriteLine($"||||||||||||||||BLOQUES|||||||||||||||\n{i + 1} - {bloque[i]}");
            }

            Console.Write("Seleccionar un bloque: ");
            int opcionBloque = GuardClause.GuardClause.ValidarOpcion(1, bloque.Count);

            return bloque[opcionBloque - 1];
        }

        /// Permite al usuario crear un nuevo bloque solicitando largo, ancho y alto. Valida que los valores sean positivos.
        public void CrearBloque(List<Bloque> bloques)
        {
            int largo = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese el alto: ");
            
            int ancho = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese el ancho: ");

            int alto = GuardClause.GuardClause.ValidarNumeroPositivo("Ingrese la alto: ");

            Bloque nuevoBloque = new Bloque(largo, ancho, alto);
            bloques.Add(nuevoBloque);

            Console.WriteLine($"\nDatos cargados exitosamente.");
        }

        /// Menu principal de operaciones sobre bloques. Permite crear y consultar propiedades de bloques.
        public void MenuBloque(List<Bloque> bloques)
        {
            int opcion;
            do
            {
                opcion = Menu();

                switch (opcion)
                {
                    case 1:
                        CrearBloque(bloques);
                        break;
                    case 2:
                        ObtenerLargo(bloques);
                        break;
                    case 3:
                        ObtenerAncho(bloques);
                        break;
                    case 4:
                        ObtenerAlto(bloques);
                        break;
                    case 5:
                        ObtenerVolumen(bloques);
                        break;
                    case 6:
                        ObtenerAreaSuperficie(bloques);
                        break;
                }
            } while (opcion != 0);
        }

        /// Muestra el menú de opciones para trabajar con bloques y devuelve la opción seleccionada.
        public static int Menu()
        {
            Console.WriteLine("############# MENU DE BLOQUE #############\n");
            Console.WriteLine("1 - CREAR BLOQUE");
            Console.WriteLine("2 - OBTENER LARGO");
            Console.WriteLine("3 - OBTENER ANCHO");
            Console.WriteLine("4 - OBTENER ALTO");
            Console.WriteLine("5 - OBTENER VOLUMEN");
            Console.WriteLine("6 - OBTENER AREA DE SUPERFICIE");
            Console.WriteLine("0 - Salir\n");

            int opcion = GuardClause.GuardClause.ValidarOpcion(0, 5);

            return opcion;
        }
    }
}
