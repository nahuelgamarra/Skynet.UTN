using Logica.entidades;
using Logica.Operadores;

namespace Logica.Localizacion
{
    public abstract class Localizacion : ElementoMapa
    {
        private static int contadorId = 0;
        public int ID { get; private set; }

        protected Localizacion(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
            ID = contadorId++;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Descripcion { get; private set; }

        public abstract void AplicarEfecto(Operador operador);


    }
}
