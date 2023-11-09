using System;

namespace Logica.entidades
{
    public class M8 : Operador
    {
        public override double CargaMaxima => 250;

        public M8(int fila, int columna) : base("M8", fila, columna)
        {
            this.Bateria = new Bateria(CapacidadBateria.GRANDE);
        }

        public override void Moverse(string distancia)
        {
            // Implementa la lógica de movimiento para M8
        }
    }
}
