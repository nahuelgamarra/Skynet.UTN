namespace Logica.entidades
{
    public class Bateria
    {
        public int Id { get; set; }

        public CapacidadBateria capacidad { get; set; } 
        public double CargaBateria { get; set; }

        public void CargarBateria(double cargaBateria) {
            this.CargaBateria += cargaBateria;
        }

        public void GastarBateria(double gastarBateria)
        {
            this.CargaBateria -= gastarBateria;
        }
        
    }
}