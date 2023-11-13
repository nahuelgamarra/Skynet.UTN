using Logica.entidades.Logica.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades;

public abstract class Operador : ElementoMapa, ITransferirCarga<Operador>, ITransferirCarga<Cuartel>
{
    private static int contadorId = 0;
    public int Id { get; private set; }
    public Bateria Bateria { get; set; }
    public EstadoOperador Estado { get; set; }
    public double VelocidadOptima { get; set; }
    public int PosicionX { get; set; }
    public int PosicionY { get; set; }



    public HashSet<Carga> Cargas { get; set; } = new HashSet<Carga>();

    public Operador(string nombre, int fila, int columna, double cargaMaxima) : base(nombre, fila, columna)
    {

        CargaMaxima = cargaMaxima;
        Id = contadorId++;
    }

    public double CargaMaxima { get; private set; }
    public abstract void Moverse(double distancia);


    public string MostrarLocalizacion()
    {
        PosicionX = Fila;
        PosicionY = Columna;
        string LocalizacionActual = "Fila " + PosicionX + " Columna " + PosicionY;
        return LocalizacionActual;
    }

    public void TransferirBateria(Operador operador, double cantidadATransferir)
    {
        try
        {
            EstanEnLaMismaUbicacion(operador);
            TieneCapacidadBateriaSufiente(cantidadATransferir);

            double faltante = (operador.Bateria.CargaBateria - (double)operador.Bateria.Capacidad);
            if (faltante > cantidadATransferir)
            {
                this.Bateria.GastarBateria(cantidadATransferir);
                operador.Bateria.CargarBateria(cantidadATransferir);
            }
            else
            {
                operador.Bateria.CargarBateria(cantidadATransferir);
                this.Bateria.GastarBateria(faltante);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private bool TieneCapacidadBateriaSufiente(double cantidad)
    {
        return this.Bateria.CargaBateria > cantidad ? true : throw new Exception("No puede mandar tantos mAh");
    }

    public void TransferirCarga(Operador destico, Carga carga)
    {
        try
        {
            ContieneCarga(carga);
            EstanEnLaMismaUbicacion(destico);
            SuperaPesoMaximo(carga);
            this.sacarCarga(carga);
            destico.AgregarCarga(carga);

        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }


    }
    public void TransferirCarga(Cuartel destino, Carga carga)
    {
        try
        {
            ContieneCarga(carga);
            this.sacarCarga(carga);
            destino.Cargas.Add(carga);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

    public void sacarCarga(Carga carga)
    {
        Cargas.Remove(carga);
    }

    public void AgregarCarga(Carga carga)
    {
        try
        {
            SuperaPesoMaximo(carga);
            Cargas.Add(carga);
        }catch (Exception ex)
        {
            throw new Exception("No se pudo agregar la carga debido al peso excedido.");
        }
    }
    private double ObtenerPesoDeCargaActual()
    {

        return Cargas.Sum(carga => carga.Peso);
    }

    private bool SuperaPesoMaximo(Carga carga)
    {
        return ObtenerPesoDeCargaActual() + carga.Peso > CargaMaxima ? true : throw new Exception("Supera el peso maximo soportado");
    }
    /*
    public bool EstanEnLaMismaUbicacion(ElementoMapa otroElemento)
    {
        return this.Fila == otroElemento.Fila && this.Columna == otroElemento.Columna;
    }*/
    private bool ContieneCarga(Carga carga)
    {
        return this.Cargas.Contains(carga) ? true : throw new Exception("No posee la carga que quiere transferir ");
    }

    public void TransferirTodaLaCargaAlCuartel(Cuartel cuartel)
    {
        try
        {
            EstanEnLaMismaUbicacion(cuartel);
            foreach (var carga in Cargas)
            {
                cuartel.Cargas.Add(carga);
            }
            Cargas.Clear(); // Vaciar las cargas del operador después de la transferencia
            Console.WriteLine("Se pudo transferir toda la carga");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    public void LlenarBateria()
    {
        this.Bateria.LlenarBateria();
    }


    public void MoverseYConsumirBateria( int fila, int columna)
    {
        try
        {
            Moverse(fila, columna);
            PosicionX = fila;
            PosicionY = columna;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    public bool BateriaDisponible()
    {
        return Bateria.CargaBateria > 0 ? true : throw new Exception("No posee bateria para moverse");
    }

    public bool BateriaGastadaPorDistancia(int distanciaARecorrer)
    {
        double tiempoEstimado = distanciaARecorrer / VelocidadOptima;
        if ((tiempoEstimado * 1000) < Bateria.CargaBateria)
        {
            for (int i = 0; i < tiempoEstimado; i++)
            {
                Bateria.GastarBateria(1000);
            }
        }
        return Bateria.CargaBateria > 0 ? true : throw new Exception("No hay bateria disponible para realizar el movimiento");
    }

    public bool Moverse(int fila, int columna)
    {
        int distanciaARecorrer = Math.Abs(fila - PosicionX) + Math.Abs(columna - PosicionY);
        BateriaDisponible();
        BateriaGastadaPorDistancia(distanciaARecorrer);
        return distanciaARecorrer > 0 ? true : throw new Exception("El operador ya se encuentra en la posicion indicada");
    }
}

