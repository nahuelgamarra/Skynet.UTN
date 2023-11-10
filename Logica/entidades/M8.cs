using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    internal class M8 : Operador
    {
        public override double CargaMaxima => 250;
        public M8()
        {
            this.Bateria = new Bateria(CapacidadBateria.GRANDE);
        }

        


        public override void Moverse(string distancia)
        {
            throw new NotImplementedException();
        }
    }
}
