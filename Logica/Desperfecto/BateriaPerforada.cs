using Logica.Desperfecto;
using Logica.entidades;
using Logica.Operadores;

namespace Desperfecto
{
    public class BateriaPerforada : Desperfecto
    {
        public BateriaPerforada(string descripcion) : base(descripcion, TipoDesperfecto.BateriaPerforada)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            PerforarBateria(operador.Bateria);
        }

        private void PerforarBateria(Bateria bateria)
        {
            bateria.PerforarBateria();
        }
    }
}
