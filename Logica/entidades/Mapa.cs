
using Localidades;
using Logica.entidades.Logica.entidades;
using Logica.Localizacion;
using Logica.Operadores;
using System.Text.Json;

namespace Logica.entidades
{
    public class Mapa
    {

        private static Mapa instancia;
        private List<ElementoMapa>[,] elementosMapa;

        private Mapa(int filas, int columnas)
        {
            elementosMapa = new List<ElementoMapa>[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    elementosMapa[i, j] = new List<ElementoMapa>();
                }
            }
            GenerarLocalidadesAleatorias();
        }
        public static Mapa ObtenerInstancia(int filas, int columnas)
        {
            if (instancia == null)
            {
                instancia = new Mapa(filas, columnas);
            }
            return instancia;
        }

        public static Mapa ObtenerInstanciaExistente()
        {
            if (instancia == null)
            {

                throw new InvalidOperationException("La instancia del mapa no ha sido creada.");
            }
            return instancia;
        }

        public void MostrarMapa()
        {
            Console.WriteLine("  +-------------------------------------------+");
            for (int i = 0; i < elementosMapa.GetLength(0); i++)
            {
                Console.Write("  |");
                for (int j = 0; j < elementosMapa.GetLength(1); j++)
                {
                    if (elementosMapa[i, j].Count > 0)
                    {
                        foreach (ElementoMapa elemento in elementosMapa[i, j])
                        {
                            Console.Write($" {elemento.Nombre.PadRight(7)} ");
                        }
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("         |");
                    }
                }
                Console.WriteLine("\n  +-------------------------------------------+");
            }
        }

        public void AgregarElemento(ElementoMapa elemento, int fila, int columna)
        {
            elementosMapa[fila, columna].Add(elemento);
            elemento.Fila = fila;
            elemento.Columna = columna;
        }

        public void MoverElemento(ElementoMapa elemento, int nuevaFila, int nuevaColumna)
        {
            elementosMapa[elemento.Fila, elemento.Columna].Remove(elemento);
            elementosMapa[nuevaFila, nuevaColumna].Add(elemento);
            elemento.Fila = nuevaFila;
            elemento.Columna = nuevaColumna;
        }
        public List<ElementoMapa> ElementosEnPosicion(int fila, int columna)
        {
            return elementosMapa[fila, columna];
        }
        public List<Localizacion.Localizacion> ObtenerLocalidadesEnPosicion(int fila, int columna)
        {
            List<Localizacion.Localizacion> localidades = new List<Localizacion.Localizacion>();

            foreach (ElementoMapa elemento in elementosMapa[fila, columna])
            {
                if (elemento is Localizacion.Localizacion localizacion)
                {
                    localidades.Add(localizacion);
                }
            }

            return localidades;
        }
        public void GenerarLocalidadesAleatorias()
        {
            Random random = new Random();

            // Definir la cantidad máxima de cuarteles permitidos
            int maxCuartel = 3;
            int cuartelCount = 0;

            // Definir la cantidad de filas y columnas del mapa
            int filas = elementosMapa.GetLength(0);
            int columnas = elementosMapa.GetLength(1);

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    int tipoLocalizacion = random.Next(6); // Se elige entre 0 y 5

                    switch (tipoLocalizacion)
                    {
                        case 0:
                            new Lago($"Lago_{i}_{j}", i, j, this);
                            break;
                        case 1:
                            LugarDeReciclaje lugarDeReciclaje = new LugarDeReciclaje($"LugarDeReciclaje_{i}_{j}", i, j, this);
                            Cuartel.ListaReciclajes.Add(lugarDeReciclaje);
                            break;
                        case 2:
                            new TerrenoBaldio($"Terreno_{i}_{j}", i, j, this);
                            break;
                        case 3:
                            if (cuartelCount < maxCuartel)
                            {
                                new Cuartel(i, j, this);
                                cuartelCount++;
                            }
                            else
                            {
                                new TerrenoBaldio($"Terreno_{i}_{j}", i, j, this);
                            }
                            break;
                        case 4:
                            Vertedero vertedero = new Vertedero($"Vertedero_{i}_{j}", i, j, this);
                            Cuartel.ListaVertederos.Add(vertedero);
                            break;
                        case 5:
                            new VertederoElectronico($"VertederoElectronico_{i}_{j}", i, j, this, 20);
                            break;
                    }
                }
            }
        }

        //transformando la lista bidimensional en una lista de listas para la serializacion
        private List<List<ElementoMapa>> listaDeListas = new List<List<ElementoMapa>>();
        private void ListaDeListas()
        {
            for (int i = 0; i < elementosMapa.GetLength(0); i++)
            {
                List<ElementoMapa> listaTemporal = new List<ElementoMapa>();

                for (int j = 0; j < elementosMapa.GetLength(1); j++)
                {
                    listaTemporal.AddRange(elementosMapa[i, j]);
                }

                listaDeListas.Add(listaTemporal);
            }
        }

        // persistencia de datos del mapa
        public void GuardarDatosMapa()
        {
            // Serializar la lista elementosMapa a JSON
            string path = Directory.GetCurrentDirectory();
            path += "\\data";
            Directory.CreateDirectory(path);
            string fileName = "\\Mapa.json";
            ListaDeListas();
            string data = JsonSerializer.Serialize(listaDeListas);
            File.WriteAllText(path + fileName, data);
        }

        public void DevolverDatosMapa()
        {
            // Deserializar la lista elementosMapa desde JSON
            string path = Directory.GetCurrentDirectory();
            path += "\\data";
            string fileName = "\\Mapa.json";
            string data = File.ReadAllText(path + fileName);
            List<List<ElementoMapa>> listaDeListas = JsonSerializer.Deserialize<List<List<ElementoMapa>>>(data);// error de constructor sin parametros

            ElementoMapa[,] elementosMapa = new ElementoMapa[listaDeListas.Count, listaDeListas[0].Count];

            for (int i = 0; i < listaDeListas.Count; i++)
            {
                for (int j = 0; j < listaDeListas[i].Count; j++)
                {
                    elementosMapa[i, j] = listaDeListas[i][j];
                }
            }
        }
        //fin de persistencia de datos
    }
}
