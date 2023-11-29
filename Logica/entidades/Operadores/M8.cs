using System;

namespace Logica.entidades.Operadores
{
    public class M8 : Operador
    {


        public M8(int fila, int columna, double cargaMaxima) : base("M8", fila, columna, cargaMaxima)
        {
            Bateria = new Bateria(CapacidadBateria.GRANDE);
        }

        public override void Moverse(double distancia)
        {
            // Implementa la lógica de movimiento para M8
        }
        public override bool PuedeNadar()
        {
            return false;
        }
    }
}
