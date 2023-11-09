using System;

namespace Logica.entidades
{
    public class UAV : Operador
    {
        public override double CargaMaxima => 5;

        public UAV(int fila, int columna) : base("UAV", fila, columna)
        {
            this.Bateria = new Bateria(CapacidadBateria.CHICA);
        }

        public override void Moverse(string distancia)
        {
            // Implementa la lógica de movimiento para UAV
        }
    }
}
