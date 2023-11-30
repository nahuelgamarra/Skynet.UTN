using Desperfecto;
using Logica.Desperfecto;
using Logica.entidades;
using Logica.Localizacion;
using Logica.Operadores;
namespace Localidades
{
    public class Vertedero : Localizacion
    {
        private List<Desperfecto.Desperfecto> desperfectos;
        private HashSet<Carga> cargas;

        public Vertedero(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
            PosibilidadDeDanio = 5;
            desperfectos = GenerarListaDesperfectos();
            cargas = new HashSet<Carga>();
            CargarVertedero();
        }

        public int PosibilidadDeDanio { get; private set; }

        public override void AplicarEfecto(Operador operador)
        {
            try
            {
                RandomizarDanio(operador);
                LlenarOperadorDeCargas(operador);
            }
            catch (Exception ex)
            {
                Console.WriteLine(cargas.Count() + "  Luego de cargarlo");
            }
        }

        private void LlenarOperadorDeCargas(Operador operador)
        {
            Console.WriteLine(cargas.Count() + "  Antes de cargar operador");
            foreach (var carga in cargas)
            {
                operador.AgregarCarga(carga);
                cargas.Remove(carga);
            }

        }

        private void RandomizarDanio(Operador operador)
        {
            Random random = new Random();
            int posibleDanio = random.Next(0, 101);
            if (posibleDanio < PosibilidadDeDanio)
            {
                AplicarDesperfecto(operador);
            }
        }

        private void AplicarDesperfecto(Operador operador)
        {
            foreach (var desperfecto in desperfectos)
            {
                desperfecto.AplicarDesperfecto(operador);
                Console.WriteLine($"Se aplicó el desperfecto: {desperfecto.TipoDesperfecto}");
            }
        }

        private void CargarVertedero()
        {
            for (int i = 0; i < 10; i++)
            {
                cargas.Add(new Carga());
            }
        }

        private List<Desperfecto.Desperfecto> GenerarListaDesperfectos()
        {
            return new List<Desperfecto.Desperfecto>
        {
            new MotorComprometido("Motor comprometido"),
            new PinturaRayada("Se le rayo la pintura"),
            new PuertoBateriaDesconectado("Puerto de batería desconectado"),
            new ServoAtascado("Servo atascado"),
            new BateriaPerforada("Batería perforada")
            // Agrega más tipos de desperfectos según sea necesario
        };
        }
    }
}
