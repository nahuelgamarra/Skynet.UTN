using Logica.entidades;
using Logica.Operadores;

namespace Logica.Localizacion
{
    public class TerrenoBaldio : Localizacion
    {
        public TerrenoBaldio(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {

        }
    }
}
