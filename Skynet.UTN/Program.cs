using Logica.entidades;  // Asegúrate de incluir esta línea
using Logica.entidades.Logica.entidades;
using Logica.entidades.Operadores;


namespace Skynet.UTN
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mapa mapa = new(10, 10);

            // Crear un operador específico, por ejemplo, K9
            Cuartel cuartel = new Cuartel(1, 2);
           
            Operador operador8 = new K9(9, 9,5);
            Operador operador2 = new K9(3, 1,20);
            Operador operador3 = new UAV(3, 1,8);
            Operador operador4 = new UAV(8, 1,7);
           // cuartel.AgregarElemento(operador);
            cuartel.AgregarElemento(operador2);
            cuartel.AgregarElemento(operador3);

            

            Console.WriteLine($"Veremos cuantos operadores hay en el cuarte  {cuartel.ListaOperadores.Count}");
            


            mapa.AgregarElemento(operador8, operador8.Fila, operador8.Columna);
            mapa.AgregarElemento(operador2, operador2.Fila, operador2.Columna);
            mapa.AgregarElemento(operador3, operador3.Fila, operador3.Columna);
            mapa.AgregarElemento(cuartel, cuartel.Fila, cuartel.Columna);
           
            Carga carga = new Carga();
            Carga carga2 = new Carga();
            carga.Descripcion = "carga 1";
            carga.Peso = 2;
            cuartel.Cargas.Add(carga);
            Console.WriteLine("Veremos cuantas cargas hay en el cuartel ");
            Console.WriteLine(cuartel.Cargas.Count);


            operador4.TransferirCarga(operador2, carga);

            cuartel.TransferirCarga(operador4, carga2);
            Console.WriteLine("Veremos cuantas cargas hay en el cuartel luego de pasar la carga ");
            Console.WriteLine(cuartel.Cargas.Count);

            Console.WriteLine("Veremos cuantas cargas hay en el operador 2 luego de pasar la carga ");
            Console.WriteLine(operador2.Cargas.Count);

            operador2.TransferirCarga(cuartel, carga);
            Console.WriteLine("Veremos cuantas cargas hay en el cuartel luego de pasar la carga ");
            Console.WriteLine(cuartel.Cargas.Count);
            Console.WriteLine("Veremos cuantas cargas hay en el operador 2 luego de pasar la carga ");
            Console.WriteLine(operador2.Cargas.Count);

            Console.WriteLine("Aca vamos a tirar la carga que no esta en el op2");
            operador2.TransferirCarga(cuartel, carga);

            Console.WriteLine("Probemos si se puede transferir carga de operador a cuartel");
            operador3.TransferirTodaLaCargaAlCuartel(cuartel);
            cuartel.ListarEstadoDeOperadores();

            ElementoMapa elemento = new ElementoMapa("Filtro",1, 7);
            cuartel.ListarEstadoDeOperadoresEnLocalizacion(elemento);


            Console.WriteLine("Elementos del cuartel: ");
            cuartel.MostrarElementosEnCuartel();
            Console.WriteLine("Mover elementos:");
            operador8.VelocidadOptima = 10;
         
            cuartel.MostrarElementosEnCuartel();
           
            cuartel.MostrarElementosEnCuartel();
           Console.WriteLine(operador8.MostrarLocalizacion() + " Aca esta el operador Antes de moverse");
            Console.WriteLine(operador8.Bateria.CargaBateria + " Y tiene esta bateria");
            operador8.MoverseYConsumirBateria(8, 5);
            Console.WriteLine(operador8.MostrarLocalizacion()+ "Aca esta el operador luego de moverse");
            Console.WriteLine(operador8.Bateria.CargaBateria + " Y tiene esta bateria");
           
        }
    }
}
