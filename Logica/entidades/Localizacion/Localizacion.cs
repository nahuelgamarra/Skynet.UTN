using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica.entidades.Operadores;

namespace Logica.entidades.Localizacion
{
    public abstract class Localizacion : ElementoMapa
    {
        private static int contadorId = 0;

        protected Localizacion(string nombre, int fila, int columna) : base(nombre, fila, columna)
        {
            
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Descripcion { get; private set; }
       
        public abstract void AplicarEfecto(Operador operador);


    }
}
