using Logica.entidades.Interfaces;
using Logica.entidades.Logica.entidades;


namespace Logica.entidades.Operadores;

public abstract class Operador : ElementoMapa, ITransferirCarga<Operador>,
    ITransferirCarga<Cuartel>, IPuedeNadar

{
    private static int contadorId = 0;
    public int Id { get; private set; }
    public Bateria Bateria { get; set; }
    public EstadoOperador Estado { get; set; }
    public double VelocidadOptima { get; set; }

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
            SuperaPesoMaximo(carga);
            Cargas.Add(carga);
        }
        catch (Exception ex)
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
            SufrirDanio();
            int nuevaColumna = Columna + Math.Sign(distanciaColumnas);
            BateriaGastadaPorDistancia(1);
            ActualizarPosicion(Fila, nuevaColumna);
        }
    }

    private void MoversePorFila(int distanciaFilas)
    {
        for (int pasoFila = 0; pasoFila < Math.Abs(distanciaFilas); pasoFila++)
        {
            SufrirDanio();
            int nuevaFila = Fila + Math.Sign(distanciaFilas);
            BateriaGastadaPorDistancia(1);
            ActualizarPosicion(nuevaFila, Columna);
        }
    }


    private void ActualizarPosicion(int fila, int columna)
    {
       

        this.Fila = fila;
        this.Columna = columna;
    }

    internal void SufrirDanio()
    {
        Console.WriteLine("Estoy sufriendo algu  daño");

    }

    public abstract bool PuedeNadar();

}

