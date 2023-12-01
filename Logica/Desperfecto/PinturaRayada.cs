using Logica.Desperfecto;
using Logica.Operadores;

namespace Desperfecto
{

    public class PinturaRayada : Desperfecto
    {
        public PinturaRayada(string descripcion) : base(descripcion, TipoDesperfecto.PinturaRayada)
        {
        }

        public override void AplicarDesperfecto(Operador operador)
        {
            Console.WriteLine("Se te rayo la pintura");
        }
    }
}
