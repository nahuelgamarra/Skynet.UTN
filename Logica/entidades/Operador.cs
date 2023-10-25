using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public abstract class Operador
    {
        public int Id {  get; set; }
        public Bateria Bateria { get; set; }
        public EstadoOperador Estado {  get; set; }
        public double CargaMaxima { get; }
        public double VelocidadOptima { get;}
        public string Posicion { get; set; }

      public abstract void Moverse(double distancia);
        public abstract void TransferirEnergia(double energia);
        public abstract void CambiarBateria(Bateria bateria);
        public abstract void CargarBateria();
    }
}
