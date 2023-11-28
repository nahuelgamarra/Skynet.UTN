using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades.Localizacion
{
    public class Lago : Localizacion
    {
        public Lago(string nombre, int fila, int columna) : base(nombre, fila, columna)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {
            if (!operador.PuedeNadar())
            {
                throw new Exception($"{operador.Nombre} No sabe puede pasar por un lago");
            }
        }
    }
}
