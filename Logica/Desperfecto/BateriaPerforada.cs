using Logica.entidades;
using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Desperfecto
{
    public class BateriaPerforada : Desperfecto
    {
        public BateriaPerforada(string descripcion) : base(descripcion)
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
