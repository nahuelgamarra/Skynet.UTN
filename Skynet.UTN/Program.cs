using Logica.entidades;

namespace Skynet.UTN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UAV volador = new UAV();


            Console.WriteLine("Hello, World!"+ volador.CargaMaxima + " carga maxima" + volador.Bateria.CargaBateria+ " la carga de la bateria ");

            Cuartel cuartel = new Cuartel();
            cuartel.CrearOperador("UAV");
            cuartel.CrearOperador("K9");
            cuartel.MostrarOperadores();
            Console.WriteLine("\n\nModificacion en el UAV 1: \n\n");
            cuartel.ModificarOperador(0, "inicial", 500);
            cuartel.MostrarOperadores();
        }
    }
}