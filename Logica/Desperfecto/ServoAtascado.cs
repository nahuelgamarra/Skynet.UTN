﻿using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Desperfecto
{
    public class ServoAtascado : Desperfecto
    {
        public ServoAtascado(string descripcion) : base(descripcion)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            BloquearCargaYDescarga(operador);
        }

        private void BloquearCargaYDescarga(Operador operador)
        {
            operador.Estado = EstadoOperador.Blocked_Load;
        }
    }
}
