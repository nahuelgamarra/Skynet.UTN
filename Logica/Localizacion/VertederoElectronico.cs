using Logica.entidades;
using Logica.Operadores;

namespace Logica.Localizacion
{
    public class VertederoElectronico : Localizacion
    {
        private int Reduccion;

        public VertederoElectronico(string nombre, int fila, int columna, Mapa mapa, int Reduccion) : base(nombre, fila, columna, mapa)
        {
            this.Reduccion = Reduccion;
        }

        public override void AplicarEfecto(Operador operador)
        {
            ReducirCapacidadBateria(operador.Bateria);
        }
        private void ReducirCapacidadBateria(Bateria bateria)
        {
            bateria.SufrirDanio(Reduccion);
        }
    }


}
