using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class Carga
    {
        private static int contadorId = 0;
        public int Id { get; private set; }
        public string Descripcion { get; set; }
        public double Peso { get; set; }
        public Carga() { 
        Id= contadorId++;
            GenerarPesoRandomDeLaCarga();
        }
        private void GenerarPesoRandomDeLaCarga()
        {
            Random random = new Random();
            // Generar un número aleatorio entre 5 y 150
          this.Peso = random.Next(5, 10);
        }
    }
}
