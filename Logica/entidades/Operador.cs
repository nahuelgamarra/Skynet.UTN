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

    public List<Carga> Cargas { get; } = new List<Carga>();

    public Operador(string nombre, int fila, int columna, double cargaMaxima) : base(nombre, fila, columna)
    {
      
        CargaMaxima = cargaMaxima;
        Id = contadorId++;
    }

    public double CargaMaxima { get; private set; }
    public abstract void Moverse(double distancia);
    public virtual string MostrarLocalizacio()
    {

        return "";
    }

    public string MostrarLocalizacion()
    {
        LocalizacionActual = $"Fila {Fila}, Columna {Columna}";
        return LocalizacionActual;
    }

    public void TransferirCarga(Carga carga, Operador operador)
    {
        if (EstanEnLaMismaUbicacion(operador) && !SuperaPesoMaximo(carga))
        {
            this.sacarCarga(carga);
            operador.AgregarCarga(carga);
        }
        else {
            Console.WriteLine("No se pudo transferir la carga");
        }
          
    }

    public void sacarCarga(Carga carga)
    {
        Cargas.Remove(carga);
    }

    public void AgregarCarga(Carga carga)
    {
        if(!SuperaPesoMaximo(carga))
        {
            Cargas.Add(carga);
        }else
        {
            Console.WriteLine("No se pudo agregar la carga debido al peso excedido.");
        }


    }
    private double ObtenerPesoDeCargaActual()
    {

        return Cargas.Sum(carga => carga.Peso);
    }

    private bool SuperaPesoMaximo(Carga carga)
    {
        return ObtenerPesoDeCargaActual() + carga.Peso > CargaMaxima;
    }

    public bool EstanEnLaMismaUbicacion(Operador otroOperador)
    {
        return this.Fila == otroOperador.Fila && this.Columna == otroOperador.Columna;
    }

}

