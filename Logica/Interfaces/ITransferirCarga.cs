using Logica.entidades;

namespace Logica.Interfaces
{
    public interface ITransferirCarga<T>
    {
        void TransferirCarga(T operadorDestino, Carga carga);

    }
}
