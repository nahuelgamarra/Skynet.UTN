﻿using Logica.entidades;

namespace Logica.Operadores;

public class K9 : Operador
{


    public K9(int fila, int columna, double cargaMaxima, Mapa mapa) : base("K9", fila, columna, cargaMaxima, mapa)
    {
        // Inicializar propiedades específicas de K9
        Bateria = new Bateria(CapacidadBateria.MEDIANA);

    }

    public override void Moverse(double distancia)
    {
        // Implementar lógica de movimiento para K9
    }

    public override bool PuedeNadar()
    {
        return false;
    }
}

