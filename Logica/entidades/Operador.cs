using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades;

public abstract class Operador : ElementoMapa
{
    private static int contadorId = 0;
    public int Id { get; private set; }
    public Bateria Bateria { get; set; }
    public EstadoOperador Estado { get; set; }
    public double VelocidadOptima { get; }
    public string LocalizacionActual { get; set; }

    public Operador(string nombre, int fila, int columna) : base(nombre, fila, columna)
    {
        Id = contadorId++;
    }

    public abstract double CargaMaxima { get; }
    public abstract void Moverse(string distancia);
}

