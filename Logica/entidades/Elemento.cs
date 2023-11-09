using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class ElementoMapa
    {
        public string Nombre { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public ElementoMapa(string nombre, int fila, int columna)
        {
            Nombre = nombre;
            Fila = fila;
            Columna = columna;
        }
    }
}
