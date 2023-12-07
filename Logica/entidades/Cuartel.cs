namespace Logica.entidades
{
    using global::Logica.Interfaces;
    using global::Logica.Operadores;
    using global::Logica.Localizacion;
    using Localidades;
    using System;
    using System.Collections.Generic;
    using System.Text.Json;


    namespace Logica.entidades
    {
        public class Cuartel : ElementoMapa, ITransferirCarga<Operador>
        {
            private static int contadorId = 0;

            public HashSet<Operador> ListaOperadores = new HashSet<Operador>();
            //Lista de Vertederos y reciclajes
            public static List<Vertedero> ListaVertederos = new List<Vertedero>();
            public static List<LugarDeReciclaje> ListaReciclajes = new List<LugarDeReciclaje>();
            //fin de las listas 
            public int Id { get; private set; }
            public HashSet<Carga> Cargas { get; private set; } = new HashSet<Carga>();

            public Cuartel(int fila, int columna, Mapa mapa) : base("Cuartel", fila, columna, mapa)
            {
                Id = contadorId;
                contadorId++;
            }
            public void AgregarElemento(Operador operador)
            {
                ListaOperadores.Add(operador);
                operador.Fila = this.Fila;
                operador.Columna = this.Columna;
            }

            public void MostrarElementosEnCuartel()
            {
                foreach (Operador elemento in ListaOperadores)
                {
                    Console.WriteLine($"Elemento: {elemento.Nombre} en ({elemento.Fila}, {elemento.Columna}) idElemento {elemento.Id} Bateria {elemento.Bateria.CargaBateria}");
                }
            }

            public void TransferirCarga(Operador operadorDestino, Carga carga)
            {
                try
                {
                    ContieneCarga(carga);
                    operadorDestino.AgregarCarga(carga);
                    SacarCarga(carga);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            private void SacarCarga(Carga carga)
            {
                Cargas.Remove(carga);
            }
            private bool ContieneCarga(Carga carga)
            {
                return this.Cargas.Contains(carga) ? true : throw new Exception("No posee la carga que quiere transferir ");
            }
            public void ListarEstadoDeOperadores()
            {
                foreach (Operador operador in ListaOperadores)
                {
                    Console.WriteLine($"Operador id: {operador.Id}, estado  {string.Join(", ", operador.Estados)}");
                }
            }

            public void RepararOperador(Operador operador)
            {
                operador.LlenarBateria();
                operador.Estados.Clear();
                operador.Bateria.RepararPuerto();
                operador.Estados.Add(EstadoOperador.Repaired);
            }

            public void RecargarBateria(Operador operador)
            {
                operador.Bateria.LlenarBateria();
            }

            public void ListarEstadoDeOperadoresEnLocalizacion(ElementoMapa elemento)
            {
                Console.WriteLine($"LocalDataStoreSlot que esten en esta ubicacion Fila{elemento.Fila}, columna{elemento.Columna} ");
                foreach (Operador operador in ListaOperadores)
                {
                    if (operador.MismaUbicacion(elemento))
                    {
                        Console.WriteLine($"Operador id: {operador.Id}, estado  {string.Join(", ", operador.Estados)}");
                    }
                }
            }

            //Codigo para mover operadores en standby al vertedero y luego al reciclaje
            
            public void BuscarVertederoYReciclajeMasCercanos()
            {
                // Busca el vertedero y el reciclaje más cercanos para cada operador
                foreach (Operador operador in ListaOperadores)
                {
                    // Filtra los operadores que están en estado StandBy
                    List<Operador> operadores = ListaOperadores.Where(o => o.Estados.Contains(EstadoOperador.StandBy)).ToList();

                    // Calcula la distancia entre la ubicación del operador y cada vertedero
                    Dictionary<Vertedero, double> distanciasVertederos = new Dictionary<Vertedero, double>();
                    foreach (Vertedero vertedero in ListaVertederos)
                    {
                        int dx = operador.Fila - vertedero.Fila;
                        int dy = operador.Columna - vertedero.Columna;
                        double distancia = Math.Sqrt(dx * dx + dy * dy);
                        distanciasVertederos.Add(vertedero, distancia);
                    }


                    // Encuentra el vertedero más cercano
                    Vertedero vertederoMasCercano = distanciasVertederos.OrderBy(d => d.Value).First().Key;

                    // Cambia el estado del operador a "On"
                    operador.Estados.Add(EstadoOperador.On);

                    // Busca el reciclaje más cercano desde el vertedero
                    Dictionary<LugarDeReciclaje, double> distanciasReciclajes = new Dictionary<LugarDeReciclaje, double>();
                    foreach (LugarDeReciclaje reciclaje in ListaReciclajes)
                    {
                        int dx = vertederoMasCercano.Fila - reciclaje.Fila;
                        int dy = vertederoMasCercano.Columna - reciclaje.Columna;
                        double distancia = Math.Sqrt(dx * dx + dy * dy);
                        distanciasReciclajes.Add(reciclaje, distancia);
                    }


                    // Encuentra el reciclaje más cercano
                    LugarDeReciclaje reciclajeMasCercano = distanciasReciclajes.OrderBy(d => d.Value).First().Key;

                    // Usa el método SacarCarga para cada operador en el reciclaje
                    foreach (Operador operadorReciclaje in reciclajeMasCercano.Operadores)
                    {
                        operadorReciclaje.SacarCarga(new Carga());
                    }
                }
            }
            //fin del codigo de movimiento. borrar o modificar a gusto

            // persistencia de datos de los operadores
            public void GuardarDatos()
            {
                // Serializar solo el campo Estados de la lista ListaOperadores a JSON
                string path = Directory.GetCurrentDirectory();
                path += "\\data";
                Directory.CreateDirectory(path);
                string fileName = "\\EstadosDeOperadores.json";
                string data = JsonSerializer.Serialize(ListaOperadores);
                File.WriteAllText(path + fileName, data);
            }

            public void DevolverDatosOperadores()
            {
                // Deserializar la lista ListaOperadores desde JSON
                string path = Directory.GetCurrentDirectory();
                path += "\\data";
                string fileName = "\\EstadosDeOperadores.json";
                string data = File.ReadAllText(path + fileName);
                List<Operador> n = JsonSerializer.Deserialize<List<Operador>>(data);//problema con la deserializacion, necesita un constructor vacio
                foreach (Operador operador in n)
                {
                    if (operador is K9)
                    {
                        ListaOperadores.Add(operador as K9);
                    }
                    else if (operador is UAV)
                    {
                        ListaOperadores.Add(operador as UAV);
                    }
                    else
                    {
                        ListaOperadores.Add(operador as M8);
                    }
                }
            }
        }
    }
}
