using System;
using Logica.entidades;

namespace Logica.Operadores
{
    public class UAV : Operador
    {


        public UAV(int fila, int columna, double cargaMaxima, Mapa mapa) : base("UAV", fila, columna, cargaMaxima, mapa)
        {
            Bateria = new Bateria(CapacidadBateria.CHICA);
        }

        public override void Moverse(double distancia)
        {
            // Implementa la lógica de movimiento para UAV
        }
        public override bool PuedeNadar()
        {
            return true;
        }
    }
}
