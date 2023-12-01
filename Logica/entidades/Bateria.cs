
namespace Logica.entidades
{
    public class Bateria
    {
        public int Id { get; set; }

        public CapacidadBateria Capacidad { get; set; }

        public double CargaBateria { get; set; }
        private double velocidadDeDescarga;
        public bool PuertoConectado { get; private set; } = true;


        public Bateria(CapacidadBateria capacidad)
        {
            this.velocidadDeDescarga = 1;
            this.Capacidad = capacidad;
            this.CargaBateria = (double)Capacidad;
        }

        public void CargarBateria(int cargaBateria)
        {
            ComprobarSiSePuedeCargar();
            this.CargaBateria += cargaBateria;
        }

        private void ComprobarSiSePuedeCargar()
        {
            if (!PuertoConectado)
            {
                throw new Exception("No puede realizar esta operacion, el puerto se encuentra averiado");
            }
        }

        public void GastarBateria(double gastarBateria)
        {
            try
            {
                ComprobarSiSePuedeCargar();
                double bateriaLuegoDeGastar = this.CargaBateria - gastarBateria * velocidadDeDescarga;
                if (bateriaLuegoDeGastar < 0)
                {
                    throw new Exception("Se quedo sin bateria");
                }
                this.CargaBateria = bateriaLuegoDeGastar;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LlenarBateria()
        {
            ComprobarSiSePuedeCargar();
            this.CargaBateria = (int)Capacidad;
        }

        public void SufrirDanio(int reduccion)
        {
            double nuevaCapacidad = (double)this.Capacidad * (1 - reduccion / 100.0);
            nuevaCapacidad = Math.Max(0, nuevaCapacidad);
            this.Capacidad = (CapacidadBateria)nuevaCapacidad;
            this.CargaBateria = Math.Min((int)this.Capacidad, this.CargaBateria);
        }
        public void PerforarBateria()
        {
            this.velocidadDeDescarga = 5;
        }

        public void DesconectarPuerto()
        {
            this.PuertoConectado = false;
        }
        public void RepararPuerto()
        {
            this.PuertoConectado = true;
        }

    }
}