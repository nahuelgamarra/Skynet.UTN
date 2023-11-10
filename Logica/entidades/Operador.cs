using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class Operador
    {
        public int Id {  get; set; }
        public Bateria Bateria { get; set; }
        public EstadoOperador Estado {  get; set; }
        abstract public double CargaMaxima { get; }
        public double VelocidadOptima { get;}
        public string Posicion { get; set; }

        public Operador() { }
    public void Mover(double distancia)
    {
        // Implementar la lógica para mover el operador y actualizar la batería y velocidad
    }

    public void TransferirCargaBateria(Operador otroOperador)
    {
        // Implementar la transferencia de carga de batería entre operadores en la misma localización
    }

    public void VolverAlCuartel()
    {
        // Implementar el retorno al cuartel y transferencia de carga física y recarga de batería
    }

    public override string ToString()
    {
        return $"Operador ID: {Id}, Batería: {Bateria} mAh, Estado: {Estado}, Localización: {Posicion}";
    }
    }
}
