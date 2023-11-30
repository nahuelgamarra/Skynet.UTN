using Logica.Desperfecto;
using Logica.Operadores;
namespace Desperfecto
{ 
public abstract class Desperfecto
{
    public string Descripcion { get; private set; }
    public TipoDesperfecto TipoDesperfecto { get; private set; }

    public Desperfecto(string descripcion, TipoDesperfecto tipoDesperfecto)
    {
        Descripcion = descripcion;
        TipoDesperfecto = tipoDesperfecto;
    }

    public abstract void AplicarDesperfecto(Operador operador);
    }
}