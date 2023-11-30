using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Desperfecto
{
    public abstract class Desperfecto
    {
        public string Descripcion {  get;private set; }
        public Desperfecto(string descripcion)
        {
            Descripcion = descripcion;
        }

        public abstract void AplicarDesperfecto(Operador operador);
       
    }
}
