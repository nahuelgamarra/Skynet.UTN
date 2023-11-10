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
    }
}