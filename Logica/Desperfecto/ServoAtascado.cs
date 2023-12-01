using Logica.Desperfecto;
using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desperfecto
{
    public class ServoAtascado : Desperfecto
    {
        public ServoAtascado(string descripcion) : base(descripcion, TipoDesperfecto.ServoAtascado)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            BloquearCargaYDescarga(operador);
        }

        private void BloquearCargaYDescarga(Operador operador)
        {
            operador.Estados.Add(EstadoOperador.Blocked_Load);
        }
    }
}
