using Logica.entidades;  // Asegúrate de incluir esta línea
using Logica.entidades.Logica.entidades;

namespace Skynet.UTN
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mapa mapa = new(8, 8);

            // Crear un operador específico, por ejemplo, K9
            Cuartel cuartel = new Cuartel(1, 2);
           
            Operador operador = new K9(2, 1);
            Operador operador2 = new K9(3, 1);
            Operador operador3 = new UAV(3, 1);
            Operador operador4 = new UAV(3, 1);
            cuartel.AgregarElemento(operador);
            cuartel.AgregarElemento(operador2);
            cuartel.AgregarElemento(operador3);

            mapa.AgregarElemento(operador, operador.Fila, operador.Columna);
            mapa.AgregarElemento(operador2, operador2.Fila, operador2.Columna);
            mapa.AgregarElemento(operador3, operador3.Fila, operador3.Columna);
            mapa.AgregarElemento(cuartel, cuartel.Fila, cuartel.Columna);
            Console.WriteLine("VAmos a mostrar lo que hay en el cuartel");
            Console.WriteLine("Fila "+cuartel.Fila +" Columna " +cuartel.Columna);
            cuartel.MostrarElementosEnCuartel();
            Console.WriteLine("VAmos a mostrar lo que hay en el mapa ");
            mapa.MostrarMapa();


        }
    }
}
