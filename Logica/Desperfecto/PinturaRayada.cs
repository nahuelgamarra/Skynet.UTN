using Logica.Desperfecto;
using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desperfecto
{

    public class PinturaRayada : Desperfecto
    {
        public PinturaRayada(string descripcion) : base(descripcion, TipoDesperfecto.PinturaRayada)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            Console.WriteLine("Se te rayo la pintura");
        }
    }
}
