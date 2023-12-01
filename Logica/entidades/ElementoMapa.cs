namespace Logica.entidades
{
    public class ElementoMapa
    {
        public string Nombre { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public Mapa Mapa { get; private set; }

        public ElementoMapa(string nombre, int fila, int columna, Mapa mapa)
        {
            Nombre = nombre;
            Fila = fila;
            Columna = columna;
            Mapa = mapa;
            mapa.AgregarElemento(this, Fila, Columna);
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
