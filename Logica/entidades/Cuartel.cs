using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    /*
    public class Cuartel
    {
        private static int contadorId = 0;
        private List<Operador> operadores = new List<Operador>();

        public void CrearOperador(string tipo)
        {
            Operador nuevoOperador;

            switch (tipo)
            {
                case "UAV":
                    nuevoOperador = new UAV();
                    break;
                case "K9":
                    nuevoOperador = new K9();
                    break;
                case "M8":
                    nuevoOperador = new M8();
                    break;
                default:
                    Console.WriteLine("Tipo de operador no válido");
                    return;
            }

            // Asignar un ID único al objeto
            nuevoOperador.Id = contadorId;
            nuevoOperador.Bateria.Id = contadorId;
            contadorId++;

            // Agregar el objeto a la lista
            operadores.Add(nuevoOperador);
        }
        public void MostrarOperadores()
        {
            foreach (Operador operador in operadores)
            {
                Console.WriteLine($"ID: {operador.Id}");
                Console.WriteLine($"Tipo: {operador.GetType().Name}");
                Console.WriteLine($"Estado: {operador.Estado}");
                Console.WriteLine($"Carga Máxima: {operador.CargaMaxima}");
                Console.WriteLine($"Velocidad Óptima: {operador.VelocidadOptima}");
                Console.WriteLine($"Posición: {operador.LocalizacionActual}");
                Console.WriteLine($"Carga de la bateria: {operador.Bateria.CargaBateria}");
                Console.WriteLine("-------------------------");
            }
        }

        public void ModificarOperador(int id, string nuevaPosicion, double nuevaCarga)
        {
            // Buscar el operador por su ID
            Operador operador = operadores.Find(o => o.Id == id);

            // Si el operador no existe, imprimir un mensaje de error y salir del método
            if (operador == null)
            {
                Console.WriteLine("Operador no encontrado");
                return;
            }

            // Cambiar las propiedades del operador
            //operador.Moverse(nuevaPosicion);
            operador.LocalizacionActual = nuevaPosicion;
            operador.Bateria.GastarBateria(nuevaCarga);
        }

    }*/
    using System;
    using System.Collections.Generic;

    namespace Logica.entidades
    {
        public class Cuartel : ElementoMapa, ITransferirCarga<Operador>
        {
            private static int contadorId = 0;

            private List<Operador> operadoresEnCuartel = new List<Operador>();

            public int Id { get; private set; }

            public List<Carga> cargasEnCuartel { get; private set; } = new List<Carga>();

            public Cuartel(int fila, int columna) : base("Cuartel", fila, columna)
            {
                Id = contadorId;
                contadorId++;
            }

            public void AgregarElemento(Operador operador)
            {
                operadoresEnCuartel.Add(operador);
                operador.Fila = this.Fila;
                operador.Columna = this.Columna;
            }

            public void MostrarElementosEnCuartel()
            {
                foreach (Operador elemento in operadoresEnCuartel)
                {
                    Console.WriteLine($"Elemento: {elemento.Nombre} en ({elemento.Fila}, {elemento.Columna}) idElemento {elemento.Id}");
                }
            }

            public void TransferirCarga(Operador operadorDestino, Carga carga)
            {
                try
                {
                    operadorDestino.AgregarCarga(carga);
                    SacarCarga(carga);
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
             
            }

            private void SacarCarga(Carga carga)
            {
                cargasEnCuartel.Remove(carga);
            }
        }
    }
}

