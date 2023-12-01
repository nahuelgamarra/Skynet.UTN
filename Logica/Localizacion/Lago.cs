using Logica.entidades;
using Logica.Operadores;

namespace Logica.Localizacion
{
    public class Lago : Localizacion
    {
        public Lago(string nombre, int fila, int columna, Mapa mapa) : base(nombre, fila, columna, mapa)
        {
        }

        public override void AplicarEfecto(Operador operador)
        {
            if (!operador.PuedeNadar())
            {
                throw new Exception($"{operador.Nombre} No sabe puede pasar por un lago, usted se quedo en {operador.MostrarLocalizacion()}");
            }
            Console.WriteLine("Pase por el lago");
        }
    }
}
