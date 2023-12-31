﻿using Logica.entidades;
using Logica.entidades.Logica.entidades;
using Logica.Interfaces;


namespace Logica.Operadores;

public abstract class Operador : ElementoMapa, ITransferirCarga<Operador>,
    ITransferirCarga<Cuartel>, IPuedeNadar

{
    private static int contadorId = 0;
    public int Id { get; private set; }
    public Bateria Bateria { get; set; }
    public HashSet<EstadoOperador> Estados { get; set; } = new HashSet<EstadoOperador>();
    public double VelocidadOptima { get; set; }

    public HashSet<Carga> Cargas { get; set; } = new HashSet<Carga>();

    public Operador(string nombre, int fila, int columna, double cargaMaxima, Mapa mapa = null)
         : base(nombre, fila, columna, mapa)
    {
        CargaMaxima = cargaMaxima;
        Id = contadorId++;
    }

    public double CargaMaxima { get; private set; }
    public abstract void Moverse(double distancia);

    public string MostrarLocalizacion()
    {
        string LocalizacionActual = "Fila " + Fila + " Columna " + Columna;
        return LocalizacionActual;
    }

    public void TransferirBateria(Operador operador, int cantidadATransferir)
    {
        try
        {
            EstanEnLaMismaUbicacion(operador);
            TieneCapacidadBateriaSufiente(cantidadATransferir);

            double faltante = operador.Bateria.CargaBateria - (double)operador.Bateria.Capacidad;
            if (faltante > cantidadATransferir)
            {
                Bateria.GastarBateria(cantidadATransferir);
                operador.Bateria.CargarBateria(cantidadATransferir);
            }
            else
            {
                operador.Bateria.CargarBateria(cantidadATransferir);
                Bateria.GastarBateria(faltante);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private bool TieneCapacidadBateriaSufiente(double cantidad)
    {
        return Bateria.CargaBateria > cantidad ? true : throw new Exception("No puede mandar tantos mAh");
    }

    public void TransferirCarga(Operador destico, Carga carga)
    {
        try
        {
            ContieneCarga(carga);
            EstanEnLaMismaUbicacion(destico);
            SuperaPesoMaximo(carga);
            SacarCarga(carga);
            destico.AgregarCarga(carga);

        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
    public void TransferirCarga(Cuartel destino, Carga carga)
    {
        try
        {
            ContieneCarga(carga);
            SacarCarga(carga);
            destino.Cargas.Add(carga);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void SacarCarga(Carga carga)
    {
        Cargas.Remove(carga);
    }

    public void AgregarCarga(Carga carga)
    {
        try
        {
            VerificarEstado();
            SuperaPesoMaximo(carga);
            Cargas.Add(carga);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private void VerificarEstado()
    {
        if (this.Estados.Contains(EstadoOperador.Blocked_Load))
        {
            throw new Exception("El servo se encuentra atascado,  no puede cargar ni descargar ");
        }

    }

    public double ObtenerPesoDeCargaActual()
    {
        return Cargas.Sum(carga => carga.Peso);
    }

    private void SuperaPesoMaximo(Carga carga)
    {
        if (ObtenerPesoDeCargaActual() + carga.Peso > CargaMaxima) throw new Exception("Supera el peso maximo soportado");
    }

    private bool ContieneCarga(Carga carga)
    {
        return Cargas.Contains(carga) ? true : throw new Exception("No posee la carga que quiere transferir ");
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
            Cargas.Clear();
            Console.WriteLine("Se pudo transferir toda la carga");
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    public void LlenarBateria()
    {
        Bateria.LlenarBateria();
    }


    public void MoverseYConsumirBateria(int fila, int columna)
    {
        try
        {
            int distanciaFilas = fila - Fila;
            int distanciaColumnas = columna - Columna;

            MoversePorFila(distanciaFilas);
            MoversePorColumna(distanciaColumnas);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void BateriaGastadaPorDistancia(int distanciaARecorrer)
    {
        double tiempoEstimado = distanciaARecorrer / VelocidadOptima;

        if (tiempoEstimado * 1000 < Bateria.CargaBateria)
        {
            int tiempoEstimadoEnSegundos = (int)Math.Ceiling(tiempoEstimado);
            double bateriaGastadaPorSegundo = Bateria.CargaBateria / (tiempoEstimadoEnSegundos * 1000);

            while (tiempoEstimadoEnSegundos > 0)
            {
                Bateria.GastarBateria(bateriaGastadaPorSegundo);
                tiempoEstimadoEnSegundos--;
            }
        }
        else
        {
            throw new Exception("No hay batería disponible para realizar el movimiento");
        }
    }

    /*
        private void Moverse(int fila, int columna)
        {
            int distanciaFilas = fila - Fila;
            int distanciaColumnas = columna - Columna;

            MoversePorFila(distanciaFilas);

            MoversePorColumna(distanciaColumnas);
        }
    */
    private void MoversePorColumna(int distanciaColumnas)
    {
        for (int pasoColumna = 0; pasoColumna < Math.Abs(distanciaColumnas); pasoColumna++)
        {
            int nuevaColumna = Columna + Math.Sign(distanciaColumnas);
            BateriaGastadaPorDistancia(1);
            ActualizarPosicion(Fila, nuevaColumna);
        }
    }

    private void MoversePorFila(int distanciaFilas)
    {
        for (int pasoFila = 0; pasoFila < Math.Abs(distanciaFilas); pasoFila++)
        {
            int nuevaFila = Fila + Math.Sign(distanciaFilas);
            BateriaGastadaPorDistancia(1);
            ActualizarPosicion(nuevaFila, Columna);
        }
    }

    public void CambiarBateria()
    {
        Bateria nueva = new Bateria(this.Bateria.Capacidad);
        this.Bateria = nueva;
    }

    private void ActualizarPosicion(int fila, int columna)
    {
        List<Localizacion.Localizacion> listaDeLocalidades = Mapa.ObtenerLocalidadesEnPosicion(fila, columna);
        foreach (Localizacion.Localizacion localizacion in listaDeLocalidades)
        {
            localizacion.AplicarEfecto(this);
        }
        Mapa.MoverElemento(this, fila, columna);
    }



    internal void SufrirDanio()
    {
        Console.WriteLine("Estoy sufriendo algu  daño");
    }

    public abstract bool PuedeNadar();

}

