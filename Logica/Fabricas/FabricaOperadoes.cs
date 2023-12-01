using Logica.entidades;
using System;

namespace Logica.Operadores
{
    public class FabricaOperadores
    {
        public Operador CrearOperador(string tipo, int fila, int columna, double cargaMaxima, Mapa mapa)
        {
            switch (tipo.ToLower())
            {
                case "m8":
                    return new M8(fila, columna, cargaMaxima, mapa);
                case "k9":
                    return new K9(fila, columna, cargaMaxima, mapa);
                case "uav":
                    return new UAV(fila, columna, cargaMaxima, mapa);
                default:
                    throw new ArgumentException("Tipo de operador no válido");
            }
        }
    }
}
