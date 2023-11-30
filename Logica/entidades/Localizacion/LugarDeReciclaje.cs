using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades.Operadores;

namespace Logica.entidades.Localizacion
{

    public class LugarDeReciclaje : Localizacion
    {
        public LugarDeReciclaje(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
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
