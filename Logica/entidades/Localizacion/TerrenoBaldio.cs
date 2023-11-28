using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades.Localizacion
{
    public class TerrenoBaldio : Localizacion
    {
        public TerrenoBaldio(string nombre, int fila, int columna) : base(nombre, fila, columna)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {

        }
    }
}
