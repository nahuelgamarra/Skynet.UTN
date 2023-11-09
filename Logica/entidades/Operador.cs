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
        public int Bateria { get; set; }
        public string Estado {  get; set; }
        public int CargaMaxima { get; }
        public double VelocidadOptima { get;}
        public string Posicion { get; set; }

        public Operador(int id, int bateria, string estado, int cargaMaxima, double velocidadOptima, string posicion)
    {
        Id = id;
        Bateria = bateria;
        Estado = estado;
        CargaMaxima = cargaMaxima;
        VelocidadOptima = velocidadOptima;
        Posicion = posicion;
    }
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
