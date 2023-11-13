using System;

namespace Logica.entidades
{
    public class UAV : Operador
    {
  

        public UAV(int fila, int columna, double cargaMaxima) : base("UAV", fila, columna, cargaMaxima)
        {
            this.Bateria = new Bateria(CapacidadBateria.CHICA);
        }

        public override void Moverse(double distancia)
        {
            // Implementa la lógica de movimiento para UAV
        }
    }
}
