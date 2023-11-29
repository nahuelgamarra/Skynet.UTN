using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades.Operadores;

namespace Logica.entidades.Localizacion
{

    internal class LugarDeReciclaje : Localizacion
    {
        public LugarDeReciclaje(string nombre, int fila, int columna) : base(nombre, fila, columna)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {
            throw new NotImplementedException();
        }
        public void RecargarOperador(Operador operrador)
        {
            
        }
    }
}
