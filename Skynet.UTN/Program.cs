﻿using Logica.entidades;  // Asegúrate de incluir esta línea
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
            Operador operador2 = new K9(3, 1,20);
            Operador operador3 = new UAV(3, 1,8);
            Operador operador4 = new UAV(3, 1,7);
            cuartel.AgregarElemento(operador);
            cuartel.AgregarElemento(operador2);
            cuartel.AgregarElemento(operador3);

            mapa.AgregarElemento(operador, operador.Fila, operador.Columna);
            mapa.AgregarElemento(operador2, operador2.Fila, operador2.Columna);
            mapa.AgregarElemento(operador3, operador3.Fila, operador3.Columna);
            mapa.AgregarElemento(cuartel, cuartel.Fila, cuartel.Columna);
           
            Carga carga = new Carga();
            carga.Descripcion = "carga 1";
            carga.Peso = 2;
            cuartel.cargasEnCuartel.Add(carga);
            Console.WriteLine("Veremos cuantas cargas hay en el cuartel ");
            Console.WriteLine(cuartel.cargasEnCuartel.Count);
            cuartel.TransferirCarga(operador2, carga);
            Console.WriteLine("Veremos cuantas cargas hay en el cuartel luego de pasar la carga ");
            Console.WriteLine(cuartel.cargasEnCuartel.Count);
            Console.WriteLine("Veremos cuantas cargas hay en el operador 2 luego de pasar la carga ");
            Console.WriteLine(operador2.Cargas.Count);

        }
    }
}
