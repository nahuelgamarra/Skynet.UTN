using System;

namespace Logica.entidades.Operadores
{
    public class UAV : Operador
    {


        public UAV(int fila, int columna, double cargaMaxima) : base("UAV", fila, columna, cargaMaxima)
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
