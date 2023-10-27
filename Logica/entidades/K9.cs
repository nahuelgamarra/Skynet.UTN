using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class K9 : Operador
    {
        public override double CargaMaxima => 40;
        public K9()
        {
            this.Bateria = new Bateria(CapacidadBateria.MEDIANA);
        }
        public override void Moverse(double distancia)
        {
            throw new NotImplementedException();
        }
    }
}
