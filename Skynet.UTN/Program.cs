//Autores
//Angel Gomez
//Nahuel Gamarra

using Logica.entidades;  // Asegúrate de incluir esta línea
using Logica.entidades.Logica.entidades;
using Logica.Operadores;


namespace Skynet.UTN
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mapa mapa = Mapa.ObtenerInstancia(100, 100);
            Operador operador = new UAV(0, 0,50, mapa);
            Console.WriteLine(operador.CargaMaxima);
            Console.WriteLine("Posicion antes de moverse " + operador.MostrarLocalizacion());
            operador.VelocidadOptima = 20;
         
        
            operador.MoverseYConsumirBateria(82, 65);
     
            Console.WriteLine("Luego de moverse ");
            Console.WriteLine("Posicion despues de moverse " + operador.MostrarLocalizacion());
           
            
            Console.WriteLine(operador.ObtenerPesoDeCargaActual()+ " Contengo esta cantidad de cargas"); 
           
           // Crear un operador específico, por ejemplo, K9
           Cuartel cuartel = new Cuartel(1, 2, mapa);


           Operador operador2 = new K9(3, 1,20, mapa);
           Operador operador3 = new UAV(3, 1,8, mapa);
           Operador operador4 = new UAV(8, 1,7, mapa);
           cuartel.AgregarElemento(operador);
           cuartel.AgregarElemento(operador2);
           cuartel.AgregarElemento(operador3);

     
       Console.WriteLine($"Veremos cuantos operadores hay en el cuarte  {cuartel.ListaOperadores.Count}");



        
            // mapa2.MostrarMapa();
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

           ElementoMapa elemento = new ElementoMapa("Filtro",1, 7,mapa);
           cuartel.ListarEstadoDeOperadoresEnLocalizacion(elemento);


           Console.WriteLine("Elementos del cuartel: ");
           cuartel.MostrarElementosEnCuartel();
           Console.WriteLine("Mover elementos:");
           operador2.VelocidadOptima = 10;

           cuartel.MostrarElementosEnCuartel();

           cuartel.MostrarElementosEnCuartel();
           Console.WriteLine(operador.MostrarLocalizacion() + " Aca esta el operador Antes de moverse");
           Console.WriteLine(operador.Bateria.Capacidad + " Y tiene esta bateria");

           Console.WriteLine(operador.MostrarLocalizacion()+ "Aca esta el operador luego de moverse");
       

        }
    }
}
