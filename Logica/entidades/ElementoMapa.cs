using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.entidades
{
    public class ElementoMapa
    {
        public string Nombre { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }

        public ElementoMapa(string nombre, int fila, int columna)
        {
            Nombre = nombre;
            Fila = fila;
            Columna = columna;
        }
        public virtual bool EstanEnLaMismaUbicacion(ElementoMapa otroElemento)
        {
            return this.Fila == otroElemento.Fila && this.Columna == otroElemento.Columna ? true : throw new Exception("No estan en la misma ubicacion");
        }
        public bool MismaUbicacion(ElementoMapa otroElemento)
        {
            return this.Fila == otroElemento.Fila && this.Columna == otroElemento.Columna;
        }
        public List<Localizacion.Localizacion> ListarLocalidades()
        {
            return new List<Localizacion.Localizacion>();
        }
    }
}
