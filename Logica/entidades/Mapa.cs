using Logica.entidades.Localizacion;
using Logica.entidades.Logica.entidades;

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
                            new LugarDeReciclaje($"Reciclaje_{i}_{j}", i, j, this);
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
                            new Vertedero($"Vertedero_{i}_{j}", i, j, this);
                            break;
                        case 5:
                            new VertederoElectronico($"VertederoElectronico_{i}_{j}", i, j, this);
                            break;
                    }
                }
            }
        }

    }

}
