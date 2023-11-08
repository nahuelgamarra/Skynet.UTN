using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class UAV : Operador
    {
        public override double CargaMaxima => 5;
        public UAV() {
            this.Bateria = new Bateria( CapacidadBateria.CHICA);
      
          
        }
        public override void Moverse(string distancia)
        {
            throw new NotImplementedException();
        }
    }
}
