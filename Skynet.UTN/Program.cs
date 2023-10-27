using Logica.entidades;

namespace Skynet.UTN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UAV volador = new UAV();


            Console.WriteLine("Hello, World!"+ volador.CargaMaxima + " carga maxima" + volador.Bateria.CargaBateria+ " la carga de la bateria ");
        }
    }
}