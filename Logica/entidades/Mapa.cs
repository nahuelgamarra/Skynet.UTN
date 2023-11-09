using System;

namespace Logica.entidades
{
    public class Mapa
    {
        private List<ElementoMapa>[,] elementosMapa;

        public Mapa(int filas, int columnas)
        {
            elementosMapa = new List<ElementoMapa>[filas, columnas];
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    elementosMapa[i, j] = new List<ElementoMapa>();
                }
            }
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
    }
}
