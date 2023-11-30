using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades;
using Logica.Operadores;

namespace Logica.Localizacion
{
    public class Vertedero : Localizacion
    {
        private HashSet<Carga> cargas;
        public Vertedero(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
            PosibilidadDeDanio = 5;
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
                operador.SufrirDanio();
            }
        }

        private void CargarVertedero()
        {
            for (int i = 0; i < 10; i++)
            {
                cargas.Add(new Carga());
            }
        }
    }
}
