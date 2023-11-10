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
           
            Operador operador = new K9(2, 1,5);
            Operador operador2 = new K9(3, 1,0);
            Operador operador3 = new UAV(3, 1,8);
            Operador operador4 = new UAV(3, 1,7);
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
            Console.WriteLine("Ahora vamos a ver la localizacion del operador ");
            Console.WriteLine(operador.MostrarLocalizacion().GetHashCode());
            Console.WriteLine("Ahora vamos a ver la localizacion del operador 2");
            Console.WriteLine(operador2.MostrarLocalizacion().GetHashCode());

            if (operador.EstanEnLaMismaUbicacion(operador4))
            {
                Console.WriteLine("Los operadores están en la misma ubicación.");
            }
            else
            {
                Console.WriteLine("Los operadores están en ubicaciones diferentes.");
            }
        }
    }
}
