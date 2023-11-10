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

    public Operador(string nombre, int fila, int columna, double cargaMaxima) : base(nombre, fila, columna)
    {
        CargaMaxima = cargaMaxima;
        Id = contadorId++;
    }

    public  double CargaMaxima { get; private set; }
    public abstract void Moverse(double distancia);
    public virtual string MostrarLocalizacio() {

        return "";
    } 

    public  string MostrarLocalizacion() { 
      LocalizacionActual= $"Fila {Fila}, Columna {Columna}";
        return LocalizacionActual;
    }
    
        // Otras propiedades y métodos

        public bool EstanEnLaMismaUbicacion(Operador otroOperador)
        {
            return this.Fila == otroOperador.Fila && this.Columna == otroOperador.Columna;
        }
    
}

