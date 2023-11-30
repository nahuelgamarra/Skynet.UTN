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
        private HashSet<Carga> cargasParaReciclar;
        public LugarDeReciclaje(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
            this.cargasParaReciclar = new HashSet<Carga>();
        }

        public override void AplicarEfecto(Operador operador)
        {
            Console.WriteLine($"Pasaste por un lugar de reciclaje {operador.ObtenerPesoDeCargaActual()}");
            DejarCargaParaReciclar(operador);
            Console.WriteLine($"te llevas esta carga {operador.ObtenerPesoDeCargaActual()}");
        }
       private void DejarCargaParaReciclar(Operador operador) {
            if (operador.Cargas.Any())
            {
                cargasParaReciclar.UnionWith(operador.Cargas);
                operador.Cargas.Clear();
            }
        }
    }
}
