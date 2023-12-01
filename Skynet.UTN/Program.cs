using Logica.entidades;
using Logica.Interfaces;
using Logica.Operadores;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skynet.UTN
{
    public class Program
    {
        static Mapa mapa;
        static Cuartel miCuartel;
        static List<Operador> listaOperadores = new List<Operador>();
        private static bool salir;

        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("\n=== Menú ===");
                Console.WriteLine("1. Crear Mapa");
                Console.WriteLine("2. Crear Operadores");
                Console.WriteLine("3. Agregar Otro Operador");
                Console.WriteLine("4. Crear Cuartel");
                Console.WriteLine("5. Agregar Operador al Cuartel");
                Console.WriteLine("6. Listar Operadores en el Cuartel");
                Console.WriteLine("7. Seleccionar Operador y entrar al Menú");
                Console.WriteLine("8. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ConfigurarMapa();
                        break;

                    case "2":
                        CargarOperadores();
                        break;

                    case "3":
                        AgregarOtroOperador();
                        break;

                    case "4":
                        CrearCuartel();
                        break;

                    case "5":
                        AgregarOperadorAlCuartel();
                        break;

                    case "6":
                        ListarOperadoresEnCuartel();
                        break;

                    case "7":
                        SeleccionarOperadorYEntrarAlMenu();
                        break;

                    case "8":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!salir);
        }

        private static void ConfigurarMapa()
        {
            int filas, columnas;

            do
            {
                Console.Write("Ingrese la cantidad de filas para el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out filas) || filas <= 0);

            do
            {
                Console.Write("Ingrese la cantidad de columnas para el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out columnas) || columnas <= 0);

            mapa = Mapa.ObtenerInstancia(filas, columnas);
            mapa.MostrarMapa();

            Console.WriteLine("Mapa configurado correctamente.");
        }

        private static void AgregarOtroOperador()
        {
            if (mapa == null)
            {
                Console.WriteLine("Error: Debes crear un mapa primero.");
                return;
            }

            CargarOperadores();
            mapa.MostrarMapa();
        }
        private static void SeleccionarOperadorYEntrarAlMenu()
        {
            if (miCuartel == null)
            {
                Console.WriteLine("Error: Debes crear un cuartel primero.");
                return;
            }

            Console.WriteLine("Operadores en el cuartel:");
            miCuartel.MostrarOperadoresEnCuartel();

            Console.WriteLine("Seleccione el Id del Operador:");
            int idOperador;
            if (int.TryParse(Console.ReadLine(), out idOperador))
            {
                Operador operadorSeleccionado = BuscarOperadorPorId(idOperador);
                if (operadorSeleccionado != null)
                {
                    MenuOperador(operadorSeleccionado);
                }
                else
                {
                    Console.WriteLine("Operador no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Id de operador no válido.");
            }
        }
        private static void MenuOperador(Operador operador)
        {
            bool salir = false;

            do
            {
                Console.WriteLine($"\n=== Menú del Operador {operador.Id} ===");
                Console.WriteLine("1. Transferir Batería a otro Operador");
                Console.WriteLine("2. Transferir Carga a otro Operador");
                Console.WriteLine("3. Volver al Menú Principal");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        TransferirBateria(operador);
                        break;

                    case "2":
                        TransferirCarga(operador);
                        break;

                    case "3":
                        salir = true;
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (!salir);
        }


        private static void AgregarOperadorAlCuartel()
        {
            if (miCuartel == null)
            {
                Console.WriteLine("Error: Debes crear un cuartel primero.");
                return;
            }

            Console.WriteLine("Selecciona un operador para agregar al cuartel:");

            // Mostrar la lista de operadores disponibles
            MostrarOperadoresDisponibles();

            int indiceOperador;
            do
            {
                Console.Write("Índice del operador: ");
            } while (!int.TryParse(Console.ReadLine(), out indiceOperador) || indiceOperador < 0 || indiceOperador >= listaOperadores.Count);

            Operador operadorSeleccionado = listaOperadores[indiceOperador];
            miCuartel.AgregarOperador(operadorSeleccionado);

            Console.WriteLine($"Operador {operadorSeleccionado.Nombre} agregado al cuartel correctamente.");
        }

        private static void MostrarOperadoresDisponibles()
        {
            Console.WriteLine("Operadores disponibles:");

            for (int i = 0; i < listaOperadores.Count; i++)
            {
                Console.WriteLine($"{i}. {listaOperadores[i].Nombre}");
            }
        }

        private static void ListarOperadoresEnCuartel()
        {
            if (miCuartel == null)
            {
                Console.WriteLine("Error: Debes crear un cuartel primero.");
                return;
            }

            Console.WriteLine("Operadores en el cuartel:");
            miCuartel.MostrarOperadoresEnCuartel();
        }

        private static void CargarOperadores()
        {
            Console.WriteLine("Ingrese el tipo de operador (m8, k9, uav): ");
            string tipoOperador;
            do
            {
                tipoOperador = Console.ReadLine().ToLower();
            } while (tipoOperador != "m8" && tipoOperador != "k9" && tipoOperador != "uav");

            int fila, columna;
            do
            {
                Console.Write("Ingrese la fila en el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out fila) || fila < 0 || fila >= Mapa.Filas);

            do
            {
                Console.Write("Ingrese la columna en el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna >= Mapa.Columnas);

            double cargaMaxima;
            do
            {
                Console.Write("Ingrese la carga máxima del operador: ");
            } while (!double.TryParse(Console.ReadLine(), out cargaMaxima) || cargaMaxima <= 0);

            // Llamar al método estático para crear el operador
            Operador miOperador = CrearOperador(tipoOperador, fila, columna, cargaMaxima);

            listaOperadores.Add(miOperador);

            Console.WriteLine($"Operador creado: {miOperador.Nombre} en la posición ({miOperador.Fila}, {miOperador.Columna})");
        }

        private static Operador CrearOperador(string tipo, int fila, int columna, double cargaMaxima)
        {
            FabricaOperadores fabrica = new FabricaOperadores();
            return fabrica.CrearOperador(tipo, fila, columna, cargaMaxima, mapa);
        }

        private static void CrearCuartel()
        {
            if (mapa == null)
            {
                Console.WriteLine("Error: Debes crear un mapa primero.");
                return;
            }

            Console.WriteLine("Vamos a crear un cuartel");

            int fila, columna;
            do
            {
                Console.Write("Ingrese la fila en el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out fila) || fila < 0 || fila >= Mapa.Filas);

            do
            {
                Console.Write("Ingrese la columna en el mapa: ");
            } while (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna >= Mapa.Columnas);

            // Validar que la posición esté dentro de los límites del mapa
            if (fila < 0 || fila >= Mapa.Filas || columna < 0 || columna >= Mapa.Columnas)
            {
                Console.WriteLine("La posición está fuera de los límites del mapa. No se puede crear el cuartel.");
                return;
            }

            // Llamar al constructor directo de Cuartel
            miCuartel = new Cuartel(fila, columna, mapa);

            Console.WriteLine($"Cuartel creado: {miCuartel.Nombre} en la posición ({miCuartel.Fila}, {miCuartel.Columna})");
        }
        // ...

     


        private static void TransferirBateria(Operador operador)
        {
            Console.WriteLine("Ingrese el Id del Operador al que desea transferir la batería:");

            int idDestino;
            do
            {
                Console.Write("Id del Operador destino: ");
            } while (!int.TryParse(Console.ReadLine(), out idDestino) || idDestino == operador.Id);

            Operador operadorDestino = BuscarOperadorPorId(idDestino);

            if (operadorDestino != null)
            {
                Console.WriteLine("Ingrese la cantidad de batería a transferir (mAh):");

                int cantidadATransferir;
                do
                {
                    Console.Write("Cantidad de batería: ");
                } while (!int.TryParse(Console.ReadLine(), out cantidadATransferir) || cantidadATransferir <= 0);

                operador.TransferirBateria(operadorDestino, cantidadATransferir);
                Console.WriteLine("Transferencia de batería completada.");
            }
            else
            {
                Console.WriteLine("Operador destino no encontrado.");
            }
        }

        private static void TransferirCarga(Operador operador)
        {
            Console.WriteLine("Ingrese el Id del Operador o Cuartel al que desea transferir la carga:");

            int idDestino;
            do
            {
                Console.Write("Id del Operador o Cuartel destino: ");
            } while (!int.TryParse(Console.ReadLine(), out idDestino));

            ElementoMapa destino = BuscarElementoPorId(idDestino);

            if (destino != null)
            {
                Console.WriteLine("Ingrese el Id de la carga que desea transferir:");

                int idCarga;
                do
                {
                    Console.Write("Id de la carga: ");
                } while (!int.TryParse(Console.ReadLine(), out idCarga));

                Carga carga = operador.Cargas.FirstOrDefault(c => c.Id == idCarga);

                if (carga != null)
                {
                    if (destino is Operador operadorDestino)
                    {
                        operador.TransferirCarga(operadorDestino, carga);
                    }
                    else if (destino is Cuartel cuartelDestino)
                    {
                        operador.TransferirCarga(cuartelDestino, carga);
                    }

                    Console.WriteLine("Transferencia de carga completada.");
                }
                else
                {
                    Console.WriteLine("Carga no encontrada.");
                }
            }
            else
            {
                Console.WriteLine("Destino no encontrado.");
            }
        }

        private static Operador BuscarOperadorPorId(int id)
        {
            return listaOperadores.FirstOrDefault(o => o.Id == id);
        }

        private static ElementoMapa BuscarElementoPorId(int id)
        {
            Operador operador = BuscarOperadorPorId(id);

            if (operador != null)
            {
                return operador;
            }

            // Agregar lógica para buscar en otros elementos (si es necesario)

            return null;
        }

        // ...


    }
}
