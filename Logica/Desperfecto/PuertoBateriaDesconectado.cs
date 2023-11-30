using Logica.Desperfecto;
using Logica.entidades;
using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desperfecto
{
    public class PuertoBateriaDesconectado : Desperfecto
    {
        public PuertoBateriaDesconectado(string descripcion) : base(descripcion, TipoDesperfecto.PuertoBateriaDesconectado)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            DesconectarPuertoDeBateria(operador.Bateria);
        }

        private void DesconectarPuertoDeBateria(Bateria bateria)
        {
            bateria.DesconectarPuerto();
        }
    }
}
