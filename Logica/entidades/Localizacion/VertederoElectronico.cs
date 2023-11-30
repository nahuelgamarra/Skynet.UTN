using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades.Operadores;

namespace Logica.entidades.Localizacion
{
    public class VertederoElectronico : Localizacion
    {
        private int Reduccion;

        public VertederoElectronico(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {
            ReducirCapacidadBateria(operador.Bateria);
        }
        private void ReducirCapacidadBateria(Bateria bateria)
        {
            bateria.SufrirDanio(Reduccion);
        }
    }


}
