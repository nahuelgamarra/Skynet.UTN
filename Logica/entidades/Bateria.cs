namespace Logica.entidades
{
    public class Bateria
    {
        public int Id { get; set; }

        public CapacidadBateria Capacidad { get; set; }
        public double CargaBateria { get; set; }

        public Bateria(CapacidadBateria capacidad)
        {
            this.Capacidad = capacidad;
            this.CargaBateria = (double)capacidad; 
        }

        public void CargarBateria(double cargaBateria)
        {
            this.CargaBateria += cargaBateria;
        }

        public void GastarBateria(double gastarBateria)
        {
            this.CargaBateria -= gastarBateria;
        }
    }
}