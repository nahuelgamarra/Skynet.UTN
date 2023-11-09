using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades;

   public class K9 : Operador
    {
        public override double CargaMaxima => 40;

        public K9(int fila, int columna) : base("K9", fila, columna)
        {
            // Inicializar propiedades específicas de K9
            this.Bateria = new Bateria(CapacidadBateria.MEDIANA);
        }

        public override void Moverse(string distancia)
        {
            // Implementar lógica de movimiento para K9
        }
    }

