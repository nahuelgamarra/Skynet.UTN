
namespace Logica.entidades
{
    public class Bateria
    {
        public int Id { get; set; }

        public CapacidadBateria Capacidad { get; set; }

        public int CargaBateria { get; set; }


        public Bateria(CapacidadBateria capacidad)
        {
            this.Capacidad = capacidad;
            this.CargaBateria = (int)capacidad;
        }

        public void CargarBateria(int cargaBateria)
        {
            this.CargaBateria += cargaBateria;
        }

        public void GastarBateria(int gastarBateria)
        {
            this.CargaBateria -= gastarBateria;
        }
        public void LlenarBateria()
        {
            this.CargaBateria = (int)Capacidad;
        }

        internal void SufrirDanio(int reduccion)
        {
            double nuevaCapacidad = (double)this.Capacidad * (1 - reduccion / 100.0);
            nuevaCapacidad = Math.Max(0, nuevaCapacidad);
            this.Capacidad = (CapacidadBateria)nuevaCapacidad;
            this.CargaBateria = Math.Min((int)this.Capacidad, this.CargaBateria);
        }
    }
}