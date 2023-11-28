using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades.Localizacion
{
    public class Vertedero : Localizacion
    {
        public Vertedero(string nombre, int fila, int columna) : base(nombre, fila, columna)
        {
        }

        public int PosibilidadDeDanio {  get;private set; }

        public override void AplicarEfecto(Operador operador)
        {
            RandomizarDanio(operador);
        }
        private void RandomizarDanio(Operador operador)
        {
            Random random = new Random();
            int posibleDanio = random.Next(0, 101);
            if (posibleDanio < PosibilidadDeDanio)
            {
                operador.SufrirDanio();
            }
        }
    }
}
